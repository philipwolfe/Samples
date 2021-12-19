// Copyright (C) Microsoft Corporation.  All Rights Reserved.
// terraForm.cs

namespace terraDemo
{
    using System;
    using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Drawing.Imaging;
	using System.Drawing.Printing;
	using System.Data;
	using System.IO;
	using System.Net;
    using System.Collections;
    using System.Windows;
	using System.Windows.Forms;
	using System.Threading;
	using SHDocVw;							// Internet Explorer for "Help"

	using TerraServer;
	using LonLatPt = TerraServer.LonLatPt;
	using LandmarkServer;
	
    /// <summary>
    ///    Summary description for terraDemo.
    /// </summary>
    public class terraDemo : System.Windows.Forms.Form
    {
		static TerraService ts = new TerraService();

		public Hashtable stringToIndex = new Hashtable();
		LonLatPt TestPt = new LonLatPt();
//////////////////////////////////////////////////////////////////////////////////////////////
/// The following "static" variables are used by the "Thread", createImageThread			//
//////////////////////////////////////////////////////////////////////////////////////////////		
		private static LonLatPt centerPoint		= new LonLatPt();
		private static UtmPt utmPoint = new UtmPt(), utmPointNW = new UtmPt(), utmPointNE = new UtmPt(), utmPointSE = new UtmPt(), utmPointSW = new UtmPt();
		private static Int32 screenUtmX, screenUtmY, screenUtmZ = 0;
		private static LonLatPt lowerRight=null;
		private static Int32 metersPerPixel=0;
		private static Boolean bNewCenter=false;
		private static String currentTheme="Find";
		private static Boolean bResized=false;
		private static System.Windows.Forms.PictureBox[] landmarkPics = null;
		private static System.Windows.Forms.PictureBox[] topoLandmarkPics = null;
		private static Int32 borderPixels=0;			// border width
		private static String photoPlaceDescription;
		private static String topoPlaceDescription;
		private static String placeDescription;
		private static TileId tileid = null;
		private static Int32 imageWidth, imageHeight;
		private static AreaBoundingBox abb;		
		private static Hashtable weakImageHash = new Hashtable();
		private static DirectoryInfo cacheDir=null;
		private static String CACHEDIR="c:\\temp\\cache\\";
		private static LRUCache cache = new LRUCache(5 * 8);	// 5 screenfuls of 8 images each
		private static ArrayList photoImageList = new ArrayList();
		private static ArrayList topoImageList = new ArrayList();
		private System.Windows.Forms.Panel photoPanel;
		private System.Windows.Forms.Panel topoPanel;
		private static System.Windows.Forms.Panel sPhotoPanel;
		private static System.Windows.Forms.Panel sTopoPanel;
		private static System.Windows.Forms.TabControl sControl;
//
//		Screen Offset Points
//
		public static LonLatPt screenNWPoint	= new LonLatPt(), screenNEPoint = new LonLatPt(), 
			screenSEPoint	= new LonLatPt(), screenSWPoint	= new LonLatPt();

		Boolean tabChanged = false;
		Boolean centerChanged = false;
		Boolean isPrinting=false;
		Boolean isSaving=false;

		private DataGridTableStyle ts1 = null;				// table style, used for data grid on "Find" page

		public String[]	landmarkPointTypes = null;
		public LandmarkPoint[] lps = null;
		
		Font   errorFont=null;
		Color   errorFontColor = Color.Black;
		Brush errorFontBrush;

		Font drawingFont=null;
		Color drawingFontColor = Color.Black;
		Brush drawingFontBrush;

		Font printerFont=null;
		Color printerFontColor = Color.Black;
		Brush printerFontBrush;

		private Color borderColor=Color.White;

		private Image directionImageInOut=null;
		private Image directionImageIn=null;
		private Image directionImageOut=null;
		private Image logoImage=null;
		Int32 gridIndex=-99;
		static Int32 tabWidth=790, tabHeight=550;

		int screenX=0, screenY=0;		// screen resolution
//
//		Map Size
//
		static Int32 mapWidth=tabWidth;
		static Int32 mapHeight=tabHeight;
		Int32 prevMapWidth=0, prevMapHeight=0;
		Boolean bBorder=false;			// draw border now?
		Boolean	bGrid=false;			// draw grid now?
		Boolean bLogo=false;			// draw USGS logo now?
		Boolean chkLogo=false;			// USGS check box checked/unchecked

		Int32 gridWidth=0;				// grid line width
		Color gridColor=Color.White;	// white w/no alpha-blending
		Boolean	gridUtm	= false;		// Default grid is Geographic

		TerraServer.Scale prevPhotoScale=0;
		TerraServer.Scale prevTopoScale;
		Boolean fetchImage=false;
		PlaceFacts[] pfs;

		Rectangle north = new Rectangle (48, 50, 15, 31);
		Rectangle south = new Rectangle (48, 119, 15, 31);
		Rectangle east = new Rectangle (74, 93, 31, 15);
		Rectangle west = new Rectangle (5, 93, 31, 15);

		GraphicsPath zoomIn = new GraphicsPath();
		Point[] zoomInPoints = new Point [6] 
		{
			new Point(47,83),new Point(53,83),new Point(53,117),
			new Point(47,117),new Point(38,108), new Point(38,93)
		};

		GraphicsPath zoomOut = new GraphicsPath();
		Point[] zoomOutPoints = new Point [6] 
		{
			new Point(55,83),new Point(63,83),new Point(72,93),
			new Point(72,108),new Point(63,117), new Point(55,117)
		};

		GraphicsPath northEast = new GraphicsPath();		
		Point[] northEastPoints = new Point [3] 
		{
			new Point(63,82),new Point(82,72),new Point(73,93)
		};

		GraphicsPath northWest = new GraphicsPath();		
		Point[] northWestPoints = new Point [3] 
		{
			new Point(27,72),new Point(47,81),new Point(36,92)
		};

		GraphicsPath southEast = new GraphicsPath();		
		Point[] southEastPoints = new Point [3] 
		{
			new Point(72,109),new Point(81,127),new Point(62,118)
		};

		GraphicsPath southWest = new GraphicsPath();		
		Point[] southWestPoints = new Point [3] 
		{
			new Point(36,109),new Point(47,119),new Point(28,127)
		};
		public Int32 xStart, yStart;
//
//		Grid line label variables
//
		Font   gridFontName    = new Font("Arial", 8, FontStyle.Regular);
		Color    gridFontColor    = Color.White;
		Boolean bLabelGridLines = true;
		Boolean bLandmarks = true;

//
//		Caching variables
//
		private Image[] myImage= new Image[8];
		private TileId currentId = null;
		//TileFetch tileFetch = null;			// This class/object will fetch images in a seperate thread
		Thread tileFetchThread = null;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblLandmark;
		private System.Windows.Forms.ListBox listLandmark;
		private System.Windows.Forms.ListBox listLandmarkTopo;

		private System.Windows.Forms.ImageList landmarkImageList;
		private System.Windows.Forms.MenuItem contentsMenu;
		private System.Windows.Forms.Button topoDisplay;
		private System.Windows.Forms.Button photoDisplay;
		private System.Windows.Forms.StatusBar terraBar;
		private System.Windows.Forms.ListBox listScaleTopo;
		private System.Windows.Forms.Label lblScaleTopo;
		private System.Windows.Forms.TextBox LatitudeTopo;
		private System.Windows.Forms.Label lblLatTopo;
		private System.Windows.Forms.TextBox LongitudeTopo;

		private System.Windows.Forms.Label lblLongTopo;
		private System.Windows.Forms.ListBox listScalePhoto;
		private System.Windows.Forms.Label lblScalePhoto;
		private System.Windows.Forms.TextBox LatitudePhoto;
		private System.Windows.Forms.Label lblLatPhoto;
		private System.Windows.Forms.TextBox LongitudePhoto;
		private System.Windows.Forms.Label lblLongPhoto;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.DataGrid placeGrid;
		private System.Windows.Forms.TextBox txtFindPlace;
		private System.Windows.Forms.Label lblFindPlace;
		private System.Windows.Forms.MenuItem fileMenu;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.TabControl control;
		private System.Windows.Forms.TabPage findPage;
		private System.Windows.Forms.TabPage photoPage;
		private System.Windows.Forms.TabPage topoPage;
		private static System.Windows.Forms.TabPage currentTabPage;
		private System.Windows.Forms.MenuItem printMenu;
		private System.Windows.Forms.MenuItem saveMenu;
		private System.Windows.Forms.MenuItem exitMenu;
		private System.Windows.Forms.MenuItem toolsMenu;
		private System.Windows.Forms.MenuItem optionsMenu;
		private System.Windows.Forms.MenuItem helpMenu;
		private System.Windows.Forms.MenuItem aboutMenu;
		private System.Windows.Forms.MenuItem mnuClearCache;
		private System.Windows.Forms.ImageList directionImageList;
		private System.Windows.Forms.ImageList usgsLogoImageList;
		private static System.Windows.Forms.Panel currentPanel;
//////////////////////////////////////////////////////////////////////////////////////
//	Constructor
//////////////////////////////////////////////////////////////////////////////////////
        public terraDemo()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
			sPhotoPanel = this.photoPanel;
			sTopoPanel = this.topoPanel;
			sControl = this.control;
			//
			//	create the cache directory

			cacheDir = new DirectoryInfo(CACHEDIR);
			if (!cacheDir.Exists)
			{
				cacheDir = Directory.CreateDirectory(CACHEDIR);
			}
			//
			//	Get screen resolution
			//
			screenX = SystemInformation.PrimaryMonitorSize.Width;		
			screenY = SystemInformation.PrimaryMonitorSize.Height;			

			Array scale = Enum.GetValues(typeof(Scale));

			Int32 index = 0;

			foreach (Scale scl in scale) 
			{
				if (index >= 10 && index <= 19)
				{
					if (index < 17)
					{
						listScalePhoto.Items.Add(scl.ToString());
					}
					if (index > 10 && index < 20)
					{
						listScaleTopo.Items.Add(scl.ToString());
					}
				}
				index++;
			}	

			northEast.AddPolygon (northEastPoints);
			northWest.AddPolygon (northWestPoints);
			southEast.AddPolygon (southEastPoints);
			southWest.AddPolygon (southWestPoints);
			zoomIn.AddPolygon(zoomInPoints);
			zoomOut.AddPolygon(zoomOutPoints);
//
//		Load various icons/images
//
			try
			{
				directionImageInOut = directionImageList.Images[0];
				directionImageIn = directionImageList.Images[1];
				directionImageOut = directionImageList.Images[2];
				logoImage = usgsLogoImageList.Images[0];
			}
			catch
			{
				MessageBox.Show ("Unable to read image from disk",
					"Microsoft TerraService Warning",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
//	start scale at 16m
			listScalePhoto.SelectedIndex = (int)photo.scale16m;
			listScaleTopo.SelectedIndex = (int)topo.scale16m;

			errorFont = new Font("Arial", 10, FontStyle.Regular);
			errorFontBrush = new SolidBrush(errorFontColor);
			if (errorFontBrush == null) throw new Exception("null errorFontBrush");

			drawingFont = new Font("Arial", 10, FontStyle.Regular);
			drawingFontBrush = new SolidBrush(drawingFontColor);
			if (drawingFontBrush == null) throw new Exception("null drawingFontBrush");

			printerFont = new Font("Arial", 10, FontStyle.Regular);				
			printerFontBrush = new SolidBrush(drawingFontColor);
			if (printerFontBrush == null) throw new Exception("null printerFontBrush");

			LandmarkService ls = new LandmarkService();
			LandmarkType[] lt = ls.GetLandmarkTypes();
			int numLandmarkTypes = lt.Length;
			landmarkPointTypes = new String[numLandmarkTypes];
			//
			//	Populate a hash table associating an index with a landmark type
			//	This will be used when drawing landmarks, to associate a landmark type
			//	with an image in an image list, which is addressed by index
			//
			for (int i=0; i < numLandmarkTypes; i++)
			{
				stringToIndex.Add (lt[i].Type, i);
			}
			OptionsForm opt = new OptionsForm();
		}

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(terraDemo));
			this.printMenu = new System.Windows.Forms.MenuItem();
			this.LatitudeTopo = new System.Windows.Forms.TextBox();
			this.photoPanel = new System.Windows.Forms.Panel();
			this.control = new System.Windows.Forms.TabControl();
			this.findPage = new System.Windows.Forms.TabPage();
			this.findButton = new System.Windows.Forms.Button();
			this.placeGrid = new System.Windows.Forms.DataGrid();
			this.txtFindPlace = new System.Windows.Forms.TextBox();
			this.lblFindPlace = new System.Windows.Forms.Label();
			this.photoPage = new System.Windows.Forms.TabPage();
			this.lblLandmark = new System.Windows.Forms.Label();
			this.listLandmark = new System.Windows.Forms.ListBox();
			this.photoDisplay = new System.Windows.Forms.Button();
			this.listScalePhoto = new System.Windows.Forms.ListBox();
			this.lblScalePhoto = new System.Windows.Forms.Label();
			this.LatitudePhoto = new System.Windows.Forms.TextBox();
			this.lblLatPhoto = new System.Windows.Forms.Label();
			this.LongitudePhoto = new System.Windows.Forms.TextBox();
			this.lblLongPhoto = new System.Windows.Forms.Label();
			this.topoPage = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.topoDisplay = new System.Windows.Forms.Button();
			this.listScaleTopo = new System.Windows.Forms.ListBox();
			this.lblScaleTopo = new System.Windows.Forms.Label();
			this.lblLongTopo = new System.Windows.Forms.Label();
			this.lblLatTopo = new System.Windows.Forms.Label();
			this.LongitudeTopo = new System.Windows.Forms.TextBox();
			this.listLandmarkTopo = new System.Windows.Forms.ListBox();
			this.topoPanel = new System.Windows.Forms.Panel();
			this.directionImageList = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.saveMenu = new System.Windows.Forms.MenuItem();
			this.exitMenu = new System.Windows.Forms.MenuItem();
			this.toolsMenu = new System.Windows.Forms.MenuItem();
			this.optionsMenu = new System.Windows.Forms.MenuItem();
			this.mnuClearCache = new System.Windows.Forms.MenuItem();
			this.helpMenu = new System.Windows.Forms.MenuItem();
			this.contentsMenu = new System.Windows.Forms.MenuItem();
			this.aboutMenu = new System.Windows.Forms.MenuItem();
			this.usgsLogoImageList = new System.Windows.Forms.ImageList(this.components);
			this.landmarkImageList = new System.Windows.Forms.ImageList(this.components);
			this.terraBar = new System.Windows.Forms.StatusBar();
			this.control.SuspendLayout();
			this.findPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.placeGrid)).BeginInit();
			this.photoPage.SuspendLayout();
			this.topoPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// printMenu
			// 
			this.printMenu.Enabled = false;
			this.printMenu.Index = 0;
			this.printMenu.Text = "&Print...";
			this.printMenu.Click += new System.EventHandler(this.cmdPrint);
			// 
			// LatitudeTopo
			// 
			this.LatitudeTopo.Location = new System.Drawing.Point(10, 246);
			this.LatitudeTopo.Name = "LatitudeTopo";
			this.LatitudeTopo.Size = new System.Drawing.Size(80, 20);
			this.LatitudeTopo.TabIndex = 3;
			this.LatitudeTopo.Text = "39.1";
			this.LatitudeTopo.TextChanged += new System.EventHandler(this.lonLatChanged);
			// 
			// photoPanel
			// 
			this.photoPanel.Location = new System.Drawing.Point(110, 50);
			this.photoPanel.Name = "photoPanel";
			this.photoPanel.Size = new System.Drawing.Size(670, 490);
			this.photoPanel.TabIndex = 9;
			this.photoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPhotoPanelPaint);
			this.photoPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reportLonLat);
			this.photoPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_Click_Panel);
			// 
			// control
			// 
			this.control.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.findPage,
																				  this.photoPage,
																				  this.topoPage});
			this.control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.control.Name = "control";
			this.control.SelectedIndex = 0;
			this.control.Size = new System.Drawing.Size(800, 600);
			this.control.TabIndex = 0;
			this.control.SelectedIndexChanged += new System.EventHandler(this.tabIndexChanged);
			// 
			// findPage
			// 
			this.findPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.findButton,
																				   this.placeGrid,
																				   this.txtFindPlace,
																				   this.lblFindPlace});
			this.findPage.Location = new System.Drawing.Point(4, 22);
			this.findPage.Name = "findPage";
			this.findPage.Size = new System.Drawing.Size(792, 574);
			this.findPage.TabIndex = 0;
			this.findPage.Text = "Find";
			// 
			// findButton
			// 
			this.findButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.findButton.Location = new System.Drawing.Point(300, 30);
			this.findButton.Name = "findButton";
			this.findButton.TabIndex = 2;
			this.findButton.Text = "Find Place";
			this.findButton.Click += new System.EventHandler(this.cmdFindPlace);
			// 
			// placeGrid
			// 
			this.placeGrid.DataMember = "";
			this.placeGrid.Location = new System.Drawing.Point(8, 64);
			this.placeGrid.Name = "placeGrid";
			this.placeGrid.ReadOnly = true;
			this.placeGrid.Size = new System.Drawing.Size(740, 400);
			this.placeGrid.TabIndex = 3;
			this.placeGrid.Visible = false;
			// 
			// txtFindPlace
			// 
			this.txtFindPlace.Location = new System.Drawing.Point(100, 30);
			this.txtFindPlace.Name = "txtFindPlace";
			this.txtFindPlace.Size = new System.Drawing.Size(176, 20);
			this.txtFindPlace.TabIndex = 1;
			this.txtFindPlace.Text = "seattle";
			// 
			// lblFindPlace
			// 
			this.lblFindPlace.AutoSize = true;
			this.lblFindPlace.Location = new System.Drawing.Point(20, 30);
			this.lblFindPlace.Name = "lblFindPlace";
			this.lblFindPlace.Size = new System.Drawing.Size(69, 13);
			this.lblFindPlace.TabIndex = 4;
			this.lblFindPlace.Text = "Place Name:";
			// 
			// photoPage
			// 
			this.photoPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblLandmark,
																					this.listLandmark,
																					this.photoDisplay,
																					this.listScalePhoto,
																					this.lblScalePhoto,
																					this.LatitudePhoto,
																					this.lblLatPhoto,
																					this.LongitudePhoto,
																					this.lblLongPhoto,
																					this.photoPanel});
			this.photoPage.Location = new System.Drawing.Point(4, 22);
			this.photoPage.Name = "photoPage";
			this.photoPage.Size = new System.Drawing.Size(792, 574);
			this.photoPage.TabIndex = 1;
			this.photoPage.Text = "Aerial Images";
			this.photoPage.Resize += new System.EventHandler(this.photoPageResized);
			this.photoPage.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPhotoPagePaint);
			this.photoPage.MouseLeave += new System.EventHandler(this.leaveImage);
			this.photoPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_Click);
			// 
			// lblLandmark
			// 
			this.lblLandmark.AutoSize = true;
			this.lblLandmark.Location = new System.Drawing.Point(10, 344);
			this.lblLandmark.Name = "lblLandmark";
			this.lblLandmark.Size = new System.Drawing.Size(63, 13);
			this.lblLandmark.TabIndex = 8;
			this.lblLandmark.Text = "Landmarks:";
			// 
			// listLandmark
			// 
			this.listLandmark.Items.AddRange(new object[] {
															  "Building",
															  "Cemetery",
															  "Church",
															  "Encarta Article",
															  "Golf Course",
															  "Hospital",
															  "Institution",
															  "Landmark",
															  "Locale",
															  "Parks",
															  "Populated Place",
															  "Recreation Area",
															  "Retail Center",
															  "Stream Gauge",
															  "Summit",
															  "Terminal",
															  "Unknown Type"});
			this.listLandmark.Location = new System.Drawing.Point(8, 368);
			this.listLandmark.Name = "listLandmark";
			this.listLandmark.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listLandmark.Size = new System.Drawing.Size(80, 147);
			this.listLandmark.TabIndex = 7;
			// 
			// photoDisplay
			// 
			this.photoDisplay.Location = new System.Drawing.Point(10, 520);
			this.photoDisplay.Name = "photoDisplay";
			this.photoDisplay.Size = new System.Drawing.Size(72, 24);
			this.photoDisplay.TabIndex = 6;
			this.photoDisplay.Text = "Display";
			this.photoDisplay.Click += new System.EventHandler(this.displayPhoto);
			// 
			// listScalePhoto
			// 
			this.listScalePhoto.Location = new System.Drawing.Point(10, 304);
			this.listScalePhoto.Name = "listScalePhoto";
			this.listScalePhoto.Size = new System.Drawing.Size(80, 30);
			this.listScalePhoto.TabIndex = 5;
			// 
			// lblScalePhoto
			// 
			this.lblScalePhoto.AutoSize = true;
			this.lblScalePhoto.Location = new System.Drawing.Point(10, 280);
			this.lblScalePhoto.Name = "lblScalePhoto";
			this.lblScalePhoto.Size = new System.Drawing.Size(33, 13);
			this.lblScalePhoto.TabIndex = 4;
			this.lblScalePhoto.Text = "Scale";
			// 
			// LatitudePhoto
			// 
			this.LatitudePhoto.Location = new System.Drawing.Point(10, 246);
			this.LatitudePhoto.Name = "LatitudePhoto";
			this.LatitudePhoto.Size = new System.Drawing.Size(80, 20);
			this.LatitudePhoto.TabIndex = 3;
			this.LatitudePhoto.Text = "47.59999";
			this.LatitudePhoto.TextChanged += new System.EventHandler(this.lonLatChanged);
			// 
			// lblLatPhoto
			// 
			this.lblLatPhoto.AutoSize = true;
			this.lblLatPhoto.Location = new System.Drawing.Point(10, 223);
			this.lblLatPhoto.Name = "lblLatPhoto";
			this.lblLatPhoto.Size = new System.Drawing.Size(45, 13);
			this.lblLatPhoto.TabIndex = 2;
			this.lblLatPhoto.Text = "Latitude";
			// 
			// LongitudePhoto
			// 
			this.LongitudePhoto.Location = new System.Drawing.Point(10, 193);
			this.LongitudePhoto.Name = "LongitudePhoto";
			this.LongitudePhoto.Size = new System.Drawing.Size(80, 20);
			this.LongitudePhoto.TabIndex = 1;
			this.LongitudePhoto.Text = "-122.33000";
			this.LongitudePhoto.TextChanged += new System.EventHandler(this.lonLatChanged);
			// 
			// lblLongPhoto
			// 
			this.lblLongPhoto.AutoSize = true;
			this.lblLongPhoto.Location = new System.Drawing.Point(10, 170);
			this.lblLongPhoto.Name = "lblLongPhoto";
			this.lblLongPhoto.Size = new System.Drawing.Size(54, 13);
			this.lblLongPhoto.TabIndex = 0;
			this.lblLongPhoto.Text = "Longitude";
			// 
			// topoPage
			// 
			this.topoPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.label1,
																				   this.topoDisplay,
																				   this.listScaleTopo,
																				   this.lblScaleTopo,
																				   this.lblLongTopo,
																				   this.LatitudeTopo,
																				   this.lblLatTopo,
																				   this.LongitudeTopo,
																				   this.listLandmarkTopo,
																				   this.topoPanel});
			this.topoPage.Location = new System.Drawing.Point(4, 4);
			this.topoPage.Name = "topoPage";
			this.topoPage.Size = new System.Drawing.Size(792, 592);
			this.topoPage.TabIndex = 2;
			this.topoPage.Text = "Topo Maps";
			this.topoPage.Resize += new System.EventHandler(this.topoPageResized);
			this.topoPage.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTopoPagePaint);
			this.topoPage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reportLonLat);
			this.topoPage.MouseLeave += new System.EventHandler(this.leaveImage);
			this.topoPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 344);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Landmarks";
			// 
			// topoDisplay
			// 
			this.topoDisplay.Location = new System.Drawing.Point(10, 520);
			this.topoDisplay.Name = "topoDisplay";
			this.topoDisplay.Size = new System.Drawing.Size(72, 24);
			this.topoDisplay.TabIndex = 6;
			this.topoDisplay.Text = "Display";
			this.topoDisplay.Click += new System.EventHandler(this.displayTopo);
			// 
			// listScaleTopo
			// 
			this.listScaleTopo.Location = new System.Drawing.Point(10, 304);
			this.listScaleTopo.Name = "listScaleTopo";
			this.listScaleTopo.Size = new System.Drawing.Size(80, 30);
			this.listScaleTopo.TabIndex = 5;
			// 
			// lblScaleTopo
			// 
			this.lblScaleTopo.AutoSize = true;
			this.lblScaleTopo.Location = new System.Drawing.Point(10, 280);
			this.lblScaleTopo.Name = "lblScaleTopo";
			this.lblScaleTopo.Size = new System.Drawing.Size(33, 13);
			this.lblScaleTopo.TabIndex = 4;
			this.lblScaleTopo.Text = "Scale";
			// 
			// lblLongTopo
			// 
			this.lblLongTopo.AutoSize = true;
			this.lblLongTopo.Location = new System.Drawing.Point(10, 170);
			this.lblLongTopo.Name = "lblLongTopo";
			this.lblLongTopo.Size = new System.Drawing.Size(54, 13);
			this.lblLongTopo.TabIndex = 0;
			this.lblLongTopo.Text = "Longitude";
			// 
			// lblLatTopo
			// 
			this.lblLatTopo.AutoSize = true;
			this.lblLatTopo.Location = new System.Drawing.Point(10, 223);
			this.lblLatTopo.Name = "lblLatTopo";
			this.lblLatTopo.Size = new System.Drawing.Size(45, 13);
			this.lblLatTopo.TabIndex = 7;
			this.lblLatTopo.Text = "Latitude";
			// 
			// LongitudeTopo
			// 
			this.LongitudeTopo.Location = new System.Drawing.Point(10, 193);
			this.LongitudeTopo.Name = "LongitudeTopo";
			this.LongitudeTopo.Size = new System.Drawing.Size(80, 20);
			this.LongitudeTopo.TabIndex = 1;
			this.LongitudeTopo.Text = "-94.6";
			this.LongitudeTopo.TextChanged += new System.EventHandler(this.lonLatChanged);
			// 
			// listLandmarkTopo
			// 
			this.listLandmarkTopo.Items.AddRange(new object[] {
																  "Building",
																  "Cemetery",
																  "Church",
																  "Encarta Article",
																  "Golf Course",
																  "Hospital",
																  "Institution",
																  "Landmark",
																  "Locale",
																  "Parks",
																  "Populated Place",
																  "Recreation Area",
																  "Retail Center",
																  "Stream Gauge",
																  "Summit",
																  "Terminal",
																  "Unknown Type"});
			this.listLandmarkTopo.Location = new System.Drawing.Point(10, 368);
			this.listLandmarkTopo.Name = "listLandmarkTopo";
			this.listLandmarkTopo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listLandmarkTopo.Size = new System.Drawing.Size(80, 147);
			this.listLandmarkTopo.TabIndex = 7;
			// 
			// topoPanel
			// 
			this.topoPanel.Location = new System.Drawing.Point(110, 50);
			this.topoPanel.Name = "topoPanel";
			this.topoPanel.Size = new System.Drawing.Size(670, 490);
			this.topoPanel.TabIndex = 9;
			this.topoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTopoPanelPaint);
			this.topoPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reportLonLat);
			this.topoPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_Click_Panel);
			// 
			// directionImageList
			// 
			this.directionImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.directionImageList.ImageSize = new System.Drawing.Size(100, 100);
			this.directionImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("directionImageList.ImageStream")));
			this.directionImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenu,
																					  this.toolsMenu,
																					  this.helpMenu});
			// 
			// fileMenu
			// 
			this.fileMenu.Index = 0;
			this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.printMenu,
																					 this.saveMenu,
																					 this.exitMenu});
			this.fileMenu.Text = "&File";
			// 
			// saveMenu
			// 
			this.saveMenu.Enabled = false;
			this.saveMenu.Index = 1;
			this.saveMenu.Text = "&Save...";
			this.saveMenu.Click += new System.EventHandler(this.cmdSave);
			// 
			// exitMenu
			// 
			this.exitMenu.Index = 2;
			this.exitMenu.Text = "E&xit";
			this.exitMenu.Click += new System.EventHandler(this.cmdExit);
			// 
			// toolsMenu
			// 
			this.toolsMenu.Index = 1;
			this.toolsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.optionsMenu,
																					  this.mnuClearCache});
			this.toolsMenu.Text = "&Tools";
			// 
			// optionsMenu
			// 
			this.optionsMenu.Index = 0;
			this.optionsMenu.Text = "&Options...";
			this.optionsMenu.Click += new System.EventHandler(this.cmdOptions);
			// 
			// mnuClearCache
			// 
			this.mnuClearCache.Index = 1;
			this.mnuClearCache.Text = "Clear Cache";
			this.mnuClearCache.Click += new System.EventHandler(this.clearCache);
			// 
			// helpMenu
			// 
			this.helpMenu.Index = 2;
			this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.contentsMenu,
																					 this.aboutMenu});
			this.helpMenu.Text = "Help";
			// 
			// contentsMenu
			// 
			this.contentsMenu.Index = 0;
			this.contentsMenu.Text = "Contents...";
			this.contentsMenu.Click += new System.EventHandler(this.cmdHelp);
			// 
			// aboutMenu
			// 
			this.aboutMenu.Index = 1;
			this.aboutMenu.Text = "About...";
			this.aboutMenu.Click += new System.EventHandler(this.cmdAbout);
			// 
			// usgsLogoImageList
			// 
			this.usgsLogoImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.usgsLogoImageList.ImageSize = new System.Drawing.Size(38, 12);
			this.usgsLogoImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("usgsLogoImageList.ImageStream")));
			this.usgsLogoImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// landmarkImageList
			// 
			this.landmarkImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.landmarkImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.landmarkImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("landmarkImageList.ImageStream")));
			this.landmarkImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// terraBar
			// 
			this.terraBar.Location = new System.Drawing.Point(0, 580);
			this.terraBar.Name = "terraBar";
			this.terraBar.Size = new System.Drawing.Size(800, 20);
			this.terraBar.TabIndex = 27;
			// 
			// terraDemo
			// 
			this.AcceptButton = this.findButton;
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.terraBar,
																		  this.control});
			this.Menu = this.mainMenu1;
			this.Name = "terraDemo";
			this.Text = "Microsoft TerraService Demo";
			this.Click += new System.EventHandler(this.cmdPrint);
			this.control.ResumeLayout(false);
			this.findPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.placeGrid)).EndInit();
			this.photoPage.ResumeLayout(false);
			this.topoPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		protected void photoPageResized (object sender, System.EventArgs e)
		{
			bResized = true;
		}

		protected void topoPageResized (object sender, System.EventArgs e)
		{
			bResized = true;
		}
		protected void clearCache (object sender, System.EventArgs e)
		{
			try
			{		
				GC.Collect();
				weakImageHash.Clear();
				Directory.Delete(CACHEDIR, true);
				cacheDir = new DirectoryInfo(CACHEDIR);
				if (!cacheDir.Exists)
				{
					cacheDir = Directory.CreateDirectory(CACHEDIR);
				}
			}
			catch (IOException ie)
			{
				MessageBox.Show(this, ie.ToString());
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Get the currently selected landmarks from the list														// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		public void landmarkChanged ()
		{
			if (currentTheme == "Photo")
			{
				for (int i = 0; i < listLandmarkTopo.Items.Count; i++)
				{
					listLandmarkTopo.SetSelected(i, false);
				}
				if (listLandmark.SelectedItems.Count > 0)
				{
					ListBox.SelectedObjectCollection c = listLandmark.SelectedItems;
					int i = 0, j = 0;
					landmarkPointTypes = new String[c.Count];
					if (c != null)
					{
						foreach (String str in c)
						{
							landmarkPointTypes[j++] = str;
							if (str.Equals("Terminal"))
								i = (Int32)stringToIndex["Transportation Terminal"];
							else
								i = (Int32)stringToIndex[str];
							listLandmarkTopo.SetSelected(i, true);
						}
						//
						//	The following line should not be necessary. However, at least with Beta 2,
						//	if listLandmarkTopo.SelectedIndices.Count is not referenced here, when we
						//	go to the Topo page the first time the value in this variable is zero,
						//	not the value that it should be.
						//
						int temp = listLandmarkTopo.SelectedIndices.Count;
						terraBar.Text = "Fetching landmarks from Landmark Service";
						getLandmarks();
						terraBar.Text = "";
					}
				}
				else
					clearLandmarks();
			}
			else if (currentTheme == "Topo")
			{
				for (int i = 0; i < listLandmark.Items.Count; i++)
				{
					listLandmark.SetSelected(i, false);
				}
				if (listLandmarkTopo.SelectedItems.Count > 0)
				{
					ListBox.SelectedObjectCollection c = listLandmarkTopo.SelectedItems;
					int i = 0, j = 0;
					landmarkPointTypes = new String[c.Count];
					if (c != null)
					{
						foreach (String str in c)
						{
							landmarkPointTypes[j++] = str;
							if (str.Equals("Terminal"))
								i = (Int32)stringToIndex["Transportation Terminal"];
							else
								i = (Int32)stringToIndex[str];
							listLandmark.SetSelected(i, true);
						}
						//
						//	The following line should not be necessary. However, at least with Beta 2,
						//	if listLandmark.SelectedIndices.Count is not referenced here, when we
						//	go to the Photo page the first time the value in this variable is zero,
						//	not the value that it should be.
						//
						int temp = listLandmark.SelectedIndices.Count;
						terraBar.Text = "Fetching landmarks from Landmark Service";
						getLandmarks();
						terraBar.Text = "";
					}
				}
				else
					clearLandmarks();
			}
		}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Longitude or Latitude text changed																		// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		protected void lonLatChanged (object sender, System.EventArgs e)
		{
			Double lonLat;
			TextBox txtBox = (TextBox)sender;

			try
			{
				lonLat = Convert.ToDouble(txtBox.Text);
			}
			catch
			{
				if (txtBox.Text != "-")
				{
					MessageBox.Show ("Please enter only numbers", "TerraService Error", 
						 MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtBox.SelectAll();
					txtBox.Focus();
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked display button	on topo page																// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		protected void displayTopo (object sender, System.EventArgs e)
		{
			LonLatPt tempPt1 = new LonLatPt();
			tempPt1.Lon = Convert.ToDouble(LongitudeTopo.Text);
			tempPt1.Lat = Convert.ToDouble(LatitudeTopo.Text);

			LonLatPt tempPt2 = new LonLatPt();
			tempPt2.Lon = Convert.ToDouble(centerPoint.Lon.ToString("F5",null));
			tempPt2.Lat = Convert.ToDouble(centerPoint.Lat.ToString("F5",null));
//
//		If Lon, Lat or scale has changed, go get new image(s)
//
			Scale scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);

			if (tempPt1.Lon != tempPt2.Lon || tempPt1.Lat != tempPt2.Lat || scale != prevTopoScale)
			{			
				LongitudePhoto.Text = LongitudeTopo.Text;
				LatitudePhoto.Text = LatitudeTopo.Text;
				prevTopoScale = scale;
				adjustScale(listScaleTopo.SelectedIndex);
				centerChanged = true;
				topoImageList.Clear();
				currentPanel.Invalidate();
				cmdGetTopoMap();						
			}	
			ListBox.SelectedObjectCollection c = listLandmarkTopo.SelectedItems;
			if (c != null)
				landmarkChanged();
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked display button	on topo page																//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		protected void displayPhoto(object sender, System.EventArgs e)
		{
			LonLatPt tempPt1 = new LonLatPt();
			tempPt1.Lon = Convert.ToDouble(LongitudePhoto.Text);
			tempPt1.Lat = Convert.ToDouble(LatitudePhoto.Text);

			LonLatPt tempPt2 = new LonLatPt();
			tempPt2.Lon = Convert.ToDouble(centerPoint.Lon.ToString("F5",null));
			tempPt2.Lat = Convert.ToDouble(centerPoint.Lat.ToString("F5",null));
//
//		If Lon, Lat or scale has changed, go get new image(s)
//
			Scale scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
			if (tempPt1.Lon != tempPt2.Lon || tempPt1.Lat != tempPt2.Lat || scale != prevPhotoScale)
			{			
				LongitudeTopo.Text = LongitudePhoto.Text;
				LatitudeTopo.Text = LatitudePhoto.Text;
				prevPhotoScale = scale;
				adjustScale(listScalePhoto.SelectedIndex);
				centerChanged = true;
				photoImageList.Clear();
				currentPanel.Invalidate();
				cmdGetPhotoImage();						
			}
			ListBox.SelectedObjectCollection c = listLandmark.SelectedItems;
			if (c != null)
				landmarkChanged();
		}
//////////////////////////////////////////////////////////////////////////////////////
//			User selected "Find" button												//
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdFindPlace (object sender, System.EventArgs e)
		{
			findPage.Cursor = Cursors.WaitCursor;
			try
			{
				Rectangle cRect;
				cRect = findPage.ClientRectangle;	// size of client rectangle

				this.Invalidate();
				placeGrid.Width = cRect.Width - 20;
				placeGrid.Height = cRect.Height - 20;
				pfs = ts.GetPlaceList(txtFindPlace.Text, placeGrid.Height/21, false);
				if (pfs == null)
				{
					MessageBox.Show("Unable to find any places by that name\nPlease try again", 
						"Microsoft TerraService Warning", 
						 MessageBoxButtons.OK, MessageBoxIcon.Warning);
					findPage.Cursor = Cursors.Default;
					return;
				}
				DataSet placeSet = new DataSet("PlaceFacts");			// create a dataset
				DataTable tbPlace = new DataTable("Place");				// create a table
				placeSet.Tables.Add(tbPlace);							// add the table to the dataset
				DataColumn dcCity = new DataColumn("City");				// create columns for the table
				DataColumn dcState = new DataColumn("State");
				DataColumn dcCountry = new DataColumn("Country");
				DataColumn dcLatitude = new DataColumn("Latitude");
				DataColumn dcLongitude = new DataColumn("Longitude");

				placeSet.Tables["Place"].Columns.Add(dcCity);			// add the columns to the table
				placeSet.Tables["Place"].Columns.Add(dcState);
				placeSet.Tables["Place"].Columns.Add(dcCountry);
				placeSet.Tables["Place"].Columns.Add(dcLatitude);
				placeSet.Tables["Place"].Columns.Add(dcLongitude);

				DataRow newRow;

				foreach( PlaceFacts objPlace in pfs)					// add the rows to the table
				{
					newRow = tbPlace.NewRow();
					newRow["City"] = objPlace.Place.City;
					newRow["State"] = objPlace.Place.State;
					newRow["Country"] = objPlace.Place.Country;
					newRow["Latitude"] = Convert.ToDouble(objPlace.Center.Lat.ToString("F5",null));
					newRow["Longitude"] = Convert.ToDouble(objPlace.Center.Lon.ToString("F5",null));	
					tbPlace.Rows.Add (newRow);
				}

				placeGrid.DataSource = placeSet;						// associate the dataset and the datagrid
				placeGrid.DataMember = "Place";							// and the grid and the table
				placeGrid.CurrentRowIndex = 0;							// index to first row in grid
				//
				//		size the columns in the grid
				//
				if (ts1 == null)
				{
					ts1 = new DataGridTableStyle();
					ts1.MappingName = "Place";

					/* Add a GridColumnStyle and set its MappingName 
					to the name of a DataColumn in the DataTable. 
					Set the HeaderText and Width properties. */
      
					DataGridColumnStyle cityCol = new DataGridTextBoxColumn();
					cityCol.MappingName = "City";
					cityCol.HeaderText = "City";
					cityCol.Width = 200;
					ts1.GridColumnStyles.Add(cityCol);

					DataGridColumnStyle stateCol = new DataGridTextBoxColumn();
					stateCol.MappingName = "State";
					stateCol.HeaderText = "State";
					stateCol.Width = ((placeGrid.Width-200) / 4) -10;
					ts1.GridColumnStyles.Add(stateCol);

					DataGridColumnStyle countryCol = new DataGridTextBoxColumn();
					countryCol.MappingName = "Country";
					countryCol.HeaderText = "Country";
					countryCol.Width = ((placeGrid.Width-200) / 4) -10;
					ts1.GridColumnStyles.Add(countryCol);

					DataGridColumnStyle latCol = new DataGridTextBoxColumn();
					latCol.MappingName = "Latitude";
					latCol.HeaderText = "Latitude";
					latCol.Width = ((placeGrid.Width-200) / 4) -10;
					ts1.GridColumnStyles.Add(latCol);

					DataGridColumnStyle lonCol = new DataGridTextBoxColumn();
					lonCol.MappingName = "Longitude";
					lonCol.HeaderText = "Longitude";
					lonCol.Width = ((placeGrid.Width-200) / 4) -10;

					ts1.GridColumnStyles.Add(lonCol);

					/* Add the DataGridTableStyle instances to 
					the GridTableStylesCollection. */
					placeGrid.TableStyles.Add(ts1);
				}
				placeGrid.CaptionText = "" + pfs.Length + " places named " + txtFindPlace.Text + " retrieved";
				placeGrid.Visible = true;								// make the grid visible
				gridIndex = -99;
				listScalePhoto.SelectedIndex = (int)photo.scale16m;		// 16m
				listScaleTopo.SelectedIndex = (int)topo.scale16m;		// 16m
				printMenu.Enabled = true;
				centerChanged = true;
				photoImageList.Clear();
				topoImageList.Clear();
			}
			catch (Exception we)
			{
				MessageBox.Show("Unable to retrieve places from server\nPlease try again later" +
					we.ToString(),
					"Microsoft TerraService Error",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			finally
			{
				findPage.Cursor = Cursors.Default;
			}		
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User clicked "Close button", exit application
//////////////////////////////////////////////////////////////////////////////////////
		protected void exitButton_Click (object sender, System.EventArgs e) 
		{
			if (tileFetchThread != null)
				tileFetchThread.Abort();		// stop the additional thread
			this.Close();
		}
//////////////////////////////////////////////////////////////////////////////////////
//	The user switched tabs
//////////////////////////////////////////////////////////////////////////////////////
		protected void tabIndexChanged (object sender, System.EventArgs e)
		{
			clearLandmarks();
			switch (control.SelectedIndex)
			{
				case 0:								// Find tab...
					currentTheme = "Find";
					saveMenu.Enabled = false;
					this.AcceptButton = this.findButton;
					break;
				case 1:
					currentTheme = "Photo";
					saveMenu.Enabled = true;
					this.AcceptButton = this.photoDisplay;
					currentTabPage = control.SelectedTab;
					currentPanel = photoPanel;
					tabChanged = true;
					break;
				case 2:
					currentTheme = "Topo";	
					saveMenu.Enabled = true;
					this.AcceptButton = this.topoDisplay;
					currentTabPage = control.SelectedTab;	
					currentPanel = topoPanel;
					tabChanged = true;
					break;
				default:
					currentTheme = "Find";
					if (tileFetchThread != null)
					{
						tileFetchThread.Abort();
						tileFetchThread = null;
						//tileFetch = null;
					}
					break;
			}	 
		}
//////////////////////////////////////////////////////////////////////////////////////
//	The user moved the mouse off the image or topo map
//////////////////////////////////////////////////////////////////////////////////////
		protected void leaveImage (object sender, System.EventArgs e)
		{
			terraBar.Text = "";
		}
//////////////////////////////////////////////////////////////////////////////////////
//	The user moved the mouse in the image or topo map
//////////////////////////////////////////////////////////////////////////////////////
		protected void reportLonLat (object sender, System.Windows.Forms.MouseEventArgs e) 
		{
			LonLatPt textPt = new LonLatPt();
			textPt = pixelsToLonLat (e.X, e.Y);
			if (textPt.Lon == 0.0 && textPt.Lat == 0.0)
				terraBar.Text = "";
			else
				terraBar.Text = "Longitude: " + textPt.Lon.ToString("F3", null)
						+ " Latitude: " + textPt.Lat.ToString("F3", null);
		}
//////////////////////////////////////////////////////////////////////////////////////
//	Convert from Pixels to Lon/Lat
//////////////////////////////////////////////////////////////////////////////////////
		protected LonLatPt pixelsToLonLat (int x, int y) 
		{
			Double nwLon = screenNWPoint.Lon, nwLat = screenNWPoint.Lat, neLon = screenNEPoint.Lon, neLat = screenNEPoint.Lat, seLon = screenSEPoint.Lon, seLat = screenSEPoint.Lat, swLon = screenSWPoint.Lon, swLat = screenSWPoint.Lat, cnLon = centerPoint.Lon, cnLat =centerPoint.Lat;
			Double Lon = cnLon, Lat = cnLat;
			Double OffsetX = x , OffsetY = y;
			Int32	MidX = (Int32)(mapWidth/2); 
			Int32	MidY = (Int32)(mapHeight/2);
			LonLatPt retPoint = new LonLatPt();
			retPoint.Lon = retPoint.Lat = 0.0;

			if(x < MidX) 
				if(OffsetY < MidY)
					Lon = cnLon - ((cnLon - nwLon) * ((MidX - OffsetX) / MidX));
				else
					Lon = cnLon - ((cnLon - swLon) * ((MidX - OffsetX) / MidX));
			else
				if(OffsetY < MidY)
				Lon = cnLon + ((neLon - cnLon) * ((OffsetX - MidX) / MidX));
			else
				Lon = cnLon + ((seLon - cnLon) * ((OffsetX - MidX) / MidX));
			if(OffsetY < MidY) 
				if(OffsetX < MidX)
					Lat = cnLat + ((nwLat - cnLat) * ((MidY - OffsetY) / MidY));
				else
					Lat = cnLat + ((neLat - cnLat) * ((MidY - OffsetY) / MidY));
			else
				if(OffsetX < MidX)
				Lat = cnLat - ((cnLat - swLat) * ((OffsetY - MidY) / MidY));
			else
				Lat = cnLat - ((cnLat - seLat) * ((OffsetY - MidY) / MidY));
			retPoint.Lon = Lon;
			retPoint.Lat = Lat;
			return retPoint;
		}
//////////////////////////////////////////////////////////////////////////////////////
//		screen geometry has changed, recalculate the geographic corners
//////////////////////////////////////////////////////////////////////////////////////
		protected void recalculateCorners () 
		{
			#if NO
			utmPoint.Zone = abb.Center.TileMeta.Id.Scene;
			utmPoint.X = (((abb.NorthWest.TileMeta.Id.X * 200) + abb.NorthWest.Offset.XOffset) * metersPerPixel) +
				((imageWidth/2) * metersPerPixel);
			utmPoint.Y = (((abb.NorthWest.TileMeta.Id.Y * 200) + (200 - abb.NorthWest.Offset.YOffset))
				* metersPerPixel) - ((imageHeight/2) * metersPerPixel);
			centerPoint = Projection.UtmNad83PtToLonLatPt(utmPoint);		// new center calculated

			utmPointSE.X = utmPointNE.X = utmPoint.X =
				(((abb.NorthWest.TileMeta.Id.X*200) + abb.NorthWest.Offset.XOffset) * metersPerPixel) +
				((imageWidth * metersPerPixel));

			utmPointNE.Y = utmPoint.Y = (((abb.NorthWest.TileMeta.Id.Y * 200) + 
				(200 - abb.NorthWest.Offset.YOffset)) * metersPerPixel);
			screenNEPoint = Projection.UtmNad83PtToLonLatPt(utmPoint);

			utmPointSW.Y = utmPointSE.Y = utmPoint.Y -= imageHeight * metersPerPixel;
			screenSEPoint = Projection.UtmNad83PtToLonLatPt(utmPoint);

			utmPointSW.X = utmPoint.X = 
				(((abb.NorthWest.TileMeta.Id.X * 200) + (abb.NorthWest.Offset.XOffset)) * metersPerPixel);
			screenSWPoint = Projection.UtmNad83PtToLonLatPt(utmPoint);
			#endif
		}
//////////////////////////////////////////////////////////////////////////////////////
//	The user clicked in the photo or topo "Tabpage"
//////////////////////////////////////////////////////////////////////////////////////
		protected void Image_Click (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button != MouseButtons.Left)
				return;

			if (north.Contains(new Point(e.X, e.Y)))
				cmdPanNorth();
			else if (south.Contains(new Point(e.X, e.Y)))
				cmdPanSouth();
			else if (east.Contains(new Point(e.X, e.Y)))
				cmdPanEast();
			else if (west.Contains(new Point(e.X, e.Y)))
				cmdPanWest();
			else
			{	
				RectangleF tstRect = northEast.GetBounds();
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdPanNorthEast();

				tstRect = southEast.GetBounds();
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdPanSouthEast();

				tstRect = northWest.GetBounds();
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdPanNorthWest();

				tstRect = southWest.GetBounds();
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdPanSouthWest();
					
				tstRect = zoomIn.GetBounds();			
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdZoomIn();

				tstRect = zoomOut.GetBounds();			
				if (tstRect.Contains(new PointF(e.X, e.Y)))
					cmdZoomOut();
			}
		}
//////////////////////////////////////////////////////////////////////////////////////
//	The user clicked in the image or topo map "Panel"
//////////////////////////////////////////////////////////////////////////////////////
		protected void Image_Click_Panel (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button != MouseButtons.Left)
				return;
			TileId id = new TileId();
			id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
			id.Scene = 0;		// What should this be?

			Double nwLon = screenNWPoint.Lon, nwLat = screenNWPoint.Lat, neLon = screenNEPoint.Lon, neLat = screenNEPoint.Lat, seLon = screenSEPoint.Lon, seLat = screenSEPoint.Lat, swLon = screenSWPoint.Lon, swLat = screenSWPoint.Lat, cnLon = centerPoint.Lon, cnLat =centerPoint.Lat;
			Int32	MidX = (Int32)(mapWidth/2); 
			Int32	MidY = (Int32)(mapHeight/2);
			Double OffsetX = e.X , OffsetY = e.Y;
			Double Lon = cnLon, Lat = cnLat;

			if (currentTheme == "Topo")
			{	
				id.Scale = prevTopoScale;						// user clicked on image, override selection in scale list
				listScaleTopo.SelectedIndex=(int)id.Scale-11;	// reset the selected index in the list to the previous
			}
			else if (currentTheme == "Photo")
			{
				id.Scale = prevPhotoScale;						// user clicked on image, override selection in scale list
				listScalePhoto.SelectedIndex=(int)id.Scale-10;	// reset the selected index in the list to the previous
			}
			if (currentTheme == "Photo" && listScalePhoto.SelectedIndex != 0 
				|| currentTheme == "Topo" && listScaleTopo.SelectedIndex != 0)
			{
				if(OffsetX < MidX) 
					if(OffsetY < MidY)
						Lon = cnLon - ((cnLon - nwLon) * ((MidX - OffsetX) / MidX));
					else
						Lon = cnLon - ((cnLon - swLon) * ((MidX - OffsetX) / MidX));
				else
					if(OffsetY < MidY)
					Lon = cnLon + ((neLon - cnLon) * ((OffsetX - MidX) / MidX));
				else
					Lon = cnLon + ((seLon - cnLon) * ((OffsetX - MidX) / MidX));
				if(OffsetY < MidY) 
					if(OffsetX < MidX)
						Lat = cnLat + ((nwLat - cnLat) * ((MidY - OffsetY) / MidY));
					else
						Lat = cnLat + ((neLat - cnLat) * ((MidY - OffsetY) / MidY));
				else
					if(OffsetX < MidX)
					Lat = cnLat - ((cnLat - swLat) * ((OffsetY - MidY) / MidY));
				else
					Lat = cnLat - ((cnLat - seLat) * ((OffsetY - MidY) / MidY));

				centerPoint.Lon = Lon;
				centerPoint.Lat = Lat;

				id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);

				if (currentTheme == "Topo")
				{	
					//id.Scale = prevTopoScale;						// user clicked on image, override selection in scale list
					//listScaleTopo.SelectedIndex=(int)id.Scale-11;	// reset the selected index in the list to the previous

					if (listScaleTopo.SelectedIndex > 0)
						listScaleTopo.SelectedIndex -= 1;
					id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);
					prevTopoScale = id.Scale;
					adjustScale (listScaleTopo.SelectedIndex);
				}
				else if (currentTheme == "Photo")
				{
					//id.Scale = prevPhotoScale;						// user clicked on image, override selection in scale list
					//listScalePhoto.SelectedIndex=(int)id.Scale-10;	// reset the selected index in the list to the previous

					if (listScalePhoto.SelectedIndex > 0)
						listScalePhoto.SelectedIndex -= 1;
					id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
					prevPhotoScale = id.Scale;
					adjustScale(listScalePhoto.SelectedIndex);
					
				}

				id.Scene = 0;		// What should this be?

				this.Cursor = Cursors.WaitCursor;
				topoPlaceDescription = ts.ConvertLonLatPtToNearestPlace(centerPoint);
				TileMeta tm = ts.GetTileMetaFromLonLatPt(centerPoint, id.Theme, id.Scale);
				topoPlaceDescription += ", " + tm.Capture.ToString("D", null);
				this.Cursor = Cursors.Default;
	
				LongitudePhoto.Text = LongitudeTopo.Text = centerPoint.Lon.ToString("F5", null);
				LatitudePhoto.Text = LatitudeTopo.Text = centerPoint.Lat.ToString("F5", null);

				//
				//	Erase the image
				//
				if (currentTheme == "Photo")
					photoImageList.Clear();
				else
					topoImageList.Clear();

				bGrid = bBorder = bLogo = false;
				clearLandmarks();

				currentPanel.Invalidate();
				//
				//	Create and redraw the image
				//
				bGrid = bBorder = bLogo = true;
				fetchImage = true;
				createImage (centerPoint, id);
			}
			currentId = id;				// save the TileId
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked North button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanNorth() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?
		
		newCenter	= centerPoint;	// abb.Center.TileMeta.Center

		if(screenNWPoint.Lat < screenNEPoint.Lat)
			newCenter.Lat = screenNWPoint.Lat + ((screenNEPoint.Lat - screenNWPoint.Lat) / 2);
		else
			newCenter.Lat = screenNEPoint.Lat + ((screenNWPoint.Lat - screenNEPoint.Lat) / 2);

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		bGrid = bBorder = bLogo = false;

		getPlaceDescription(newCenter, id);
		
		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		currentPanel.Invalidate();

		fetchImage = true;
		bGrid = bBorder = bLogo = true;
		createImage (newCenter, id);
		centerPoint = newCenter;
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked South button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanSouth() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?
		
		newCenter = centerPoint; //abb.Center.TileMeta.Center;

		if(screenSWPoint.Lat < screenSEPoint.Lat)
			newCenter.Lat = screenSWPoint.Lat + ((screenSEPoint.Lat - screenSWPoint.Lat) / 2);
		else
			newCenter.Lat = screenSEPoint.Lat + ((screenSWPoint.Lat - screenSEPoint.Lat) / 2);

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		getPlaceDescription(newCenter, id);

		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}
		bGrid = bBorder = bLogo = false;
		currentPanel.Invalidate();
		bGrid = bBorder = bLogo = true;

		fetchImage = true;
		createImage (newCenter, id);

		centerPoint = newCenter;
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked East button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanEast() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?

		newCenter = centerPoint; //abb.Center.TileMeta.Center;
		if(screenNEPoint.Lon < screenSEPoint.Lon)
			newCenter.Lon = screenNEPoint.Lon + ((screenSEPoint.Lon - screenNEPoint.Lon) / 2);
		else
			newCenter.Lon = screenSEPoint.Lon + ((screenNEPoint.Lon - screenSEPoint.Lon) / 2);		

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);
		this.Invalidate();
	
		getPlaceDescription(newCenter, id);
	
		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;	
		clearLandmarks();
	
		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		createImage (newCenter, id);
		centerPoint = newCenter;
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked West button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanWest() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?

		newCenter	= centerPoint; // abb.Center.TileMeta.Center;
		if(screenNWPoint.Lon < screenSWPoint.Lon)
			newCenter.Lon = screenNWPoint.Lon + ((screenSWPoint.Lon - screenNWPoint.Lon) / 2);
		else
			newCenter.Lon = screenSWPoint.Lon + ((screenNWPoint.Lon - screenSWPoint.Lon) / 2);		

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);
	
		getPlaceDescription(newCenter, id);

		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		clearLandmarks();

		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		createImage (newCenter, id);
	
		centerPoint = newCenter;
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked northWest button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanNorthWest() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);
		id.Scene = 0;		// What should this be?
	
		if(abb.NorthWest.TileMeta.TileExists){
			newCenter	= screenNWPoint;
		}
		
		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		getPlaceDescription(newCenter, id);

		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		clearLandmarks();

		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		centerPoint = newCenter;
		createImage (newCenter, id);
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked soutWest button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanSouthWest() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?
	
		if(abb.SouthWest.TileMeta.Id.X > 0)
		{
			newCenter	= screenSWPoint;
		}

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		getPlaceDescription(newCenter, id);

		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		clearLandmarks();

		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		centerPoint = newCenter;
		createImage (newCenter, id);
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked northEast button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanNorthEast() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?
	
		newCenter = centerPoint;
		if(abb.NorthEast.TileMeta.TileExists){
			newCenter = screenNEPoint;			
		}
		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		bGrid = bBorder = bLogo = false;

		getPlaceDescription(newCenter, id);

		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		clearLandmarks();

		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		centerPoint = newCenter;
		createImage (newCenter, id);
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked southEast button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdPanSouthEast() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
		if (currentTheme == "Photo")
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
		else
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);	    
		id.Scene = 0;		// What should this be?
	
		if(abb.SouthEast.TileMeta.Id.X > 0){
			newCenter	= screenSEPoint;
		}

		LongitudePhoto.Text = LongitudeTopo.Text = newCenter.Lon.ToString("F5", null);
		LatitudePhoto.Text = LatitudeTopo.Text = newCenter.Lat.ToString("F5", null);

		getPlaceDescription(newCenter, id);
		
		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();	
			topoPlaceDescription = placeDescription;
		}	

		bGrid = bBorder = bLogo = false;
		clearLandmarks();

		currentPanel.Invalidate();
		fetchImage = bGrid = bBorder = bLogo = true;
		centerPoint = newCenter;
		createImage (newCenter, id);
		centerChanged = true;
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked zoom in button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdZoomIn() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		if ((currentTheme == "Photo" && listScalePhoto.SelectedIndex == 0) 
			|| (currentTheme == "Topo" && listScaleTopo.SelectedIndex == 0))
			return;

		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);

		if (currentTheme == "Topo")
		{	
			if (listScaleTopo.SelectedIndex > 0)
				listScaleTopo.SelectedIndex -= 1;
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);
			prevTopoScale = id.Scale;
			adjustScale(listScaleTopo.SelectedIndex);
		}
		else if (currentTheme == "Photo")
		{
			if (listScalePhoto.SelectedIndex > 0)
				listScalePhoto.SelectedIndex -= 1;
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
			prevPhotoScale = id.Scale;
			adjustScale(listScalePhoto.SelectedIndex);
		}	

		id.Scene = 0;		// What should this be?

		getPlaceDescription(centerPoint, id);
//
//	Erase the image
//
		bGrid = bBorder = bLogo = false;
		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else
		{
			topoImageList.Clear();
			topoPlaceDescription = placeDescription;
		}	

		clearLandmarks();
		currentPanel.Invalidate();
//
//	Create and redraw the image
//
		fetchImage = bGrid = bBorder = bLogo = true;
		createImage (centerPoint, id);
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked zoom out button																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void cmdZoomOut() 
	{
		LonLatPt newCenter = new LonLatPt();
        TileId id = new TileId();
		id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);

		if ((currentTheme == "Photo" && listScalePhoto.SelectedIndex >= 6) 
			|| (currentTheme == "Topo" && listScaleTopo.SelectedIndex >= 8))
			return;

		if (currentTheme == "Topo")
		{	
			if (listScaleTopo.SelectedIndex <= 7)
				listScaleTopo.SelectedIndex += 1;
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);
			prevTopoScale = id.Scale;
			adjustScale(listScaleTopo.SelectedIndex);
		}
		else if (currentTheme == "Photo")
		{
			if (listScalePhoto.SelectedIndex <= 5)
				listScalePhoto.SelectedIndex += 1;
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
			prevPhotoScale = id.Scale;
			adjustScale(listScalePhoto.SelectedIndex);
		}	

		id.Scene = 0;		// What should this be?

		getPlaceDescription(centerPoint, id);
//
//	Erase the image
//		
		bGrid = bBorder = bLogo = false;
		if (currentTheme == "Photo")
		{
			photoImageList.Clear();
			photoPlaceDescription = placeDescription;
		}
		else if (currentTheme == "Topo")
		{
			topoImageList.Clear();	
			topoPlaceDescription = placeDescription;
		}	
		clearLandmarks();
		currentPanel.Invalidate();
//
//	Create and redraw the image
//
		fetchImage = bGrid = bBorder = bLogo = true;
		createImage (centerPoint, id);
		currentId = id;				// save the TileId
	}
//////////////////////////////////////////////////////////////////////////////////////
//	User chose the "Print" menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdPrint (object sender, System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument() ;

			PrintDialog dlg = new PrintDialog();
			dlg.Document = pd ;

		   if(dlg.ShowDialog() != DialogResult.Cancel)
		   {
			   pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
			   if (currentTheme == "Find")
				   pd.DefaultPageSettings.Landscape = false;
			   else
				pd.DefaultPageSettings.Landscape = true;

			   pd.Print();
		   }
		}
		protected void pd_PrintPage (object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			System.Windows.Forms.PaintEventArgs ee = new PaintEventArgs(e.Graphics, e.PageBounds);

			if(currentTheme == "Photo")
			{
				isPrinting = true;
				OnPhotoPanelPaint (sender, ee);
				isPrinting = false;
			}
			else if (currentTheme == "Topo")
			{
				isPrinting = true;
				OnTopoPanelPaint (sender, ee);
				isPrinting = false;
			}
			else if (currentTheme == "Find")
			{
				Font font = new Font("Arial", 10, FontStyle.Regular);
				if (font == null) throw new Exception("null font");
				int yLoc = 50;
				Brush fontBrush = new SolidBrush(Color.Black);
				if (fontBrush == null) throw new Exception("null fontBrush");
				foreach( PlaceFacts objPlace in pfs)					// add the rows to the table
				{
					String places = objPlace.Place.City + ", " + objPlace.Place.State +
						", " + objPlace.Place.Country + " Longitude: " +
						objPlace.Center.Lon.ToString("F5", null) +
						" Latitude: " + objPlace.Center.Lat.ToString("F5", null);

					g.DrawString(places, printerFont, printerFontBrush, 50, yLoc);					
					yLoc += font.Height + 5;
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User chose the "Save" menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdSave (object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
			dlg.DefaultExt = "jpg";
			if (currentTheme == "Photo")
			{
				dlg.Title = "Microsoft TerraService Save Aerial Image";
			}
			else if (currentTheme == "Topo")
			{
				dlg.Title = "Microsoft TerraService Save Topo Map";
			}
			else
				return;
			
			if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				String fileName = dlg.FileName;
				if (fileName.IndexOf(".") == 0)
				{
					fileName += "." + dlg.DefaultExt;
				}					

				Image image = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppRgb);
				Graphics g = Graphics.FromImage(image);

				Rectangle rect = photoPage.ClientRectangle;
				System.Windows.Forms.PaintEventArgs ee = new PaintEventArgs(g, rect);

				isSaving = true;
				if(currentTheme == "Photo")
					OnPhotoPanelPaint (sender, ee);
				else if (currentTheme == "Topo")
					OnTopoPanelPaint (sender, ee);	

				isSaving = false;
				try
				{
					image.Save(fileName, ImageFormat.Jpeg);
					MessageBox.Show (fileName + " has been saved");	
				}
				catch
				{
					MessageBox.Show ("Unable to save the file " + fileName);
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User chose the "Exit" menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdExit (object sender, System.EventArgs e)
		{
			if (tileFetchThread != null)
				tileFetchThread.Abort();		// stop the additional thread
			this.Close();
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User has chosen the About... menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdAbout (object sender, System.EventArgs e)
		{
			AboutForm dlg = new AboutForm();
			dlg.ShowDialog(this);
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User has chosen the Help... menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdHelp (object sender, System.EventArgs e)
		{
			Object o = null;
			SHDocVw.InternetExplorer m_IExplorer;
			IWebBrowserApp m_WebBrowser;

			try
			{
				// start the browser
				m_IExplorer = new SHDocVw.InternetExplorer();
			}
			catch(Exception ee)
			{
				Console.WriteLine("Exception when creating IE object", ee);
				return;
			}

			try
			{	
				// go to terraservice home page
				m_WebBrowser = (IWebBrowserApp) m_IExplorer;
				m_WebBrowser.Visible = true;
				m_WebBrowser.GoHome();
				m_WebBrowser.Navigate("http://terraservice.net", ref o, ref o, ref o, ref o);
			}
			catch (Exception ee)
			{
				Console.WriteLine("Exception accessing help page on the internet", ee);
				return;
			}
		}
//////////////////////////////////////////////////////////////////////////////////////
//	User has chosen the Options... menu
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdOptions (object sender, System.EventArgs e)
		{
			OptionsForm opt = new OptionsForm();
			opt.txtGridWidth.Text = gridWidth.ToString();
			opt.gridColor = gridColor;
			opt.txtBorderWidth.Text = borderPixels.ToString();
			opt.borderColor = borderColor;
			opt.chkLogo.Checked = chkLogo;
			opt.gridTextColor = gridFontColor;
			opt.gridTextFont = gridFontName;
			opt.chkLabel.Checked = bLabelGridLines;
			opt.chkLandmarks.Checked = bLandmarks;

			if (gridUtm == true)
				opt.utmButton.Checked = true;
			else
				opt.geoButton.Checked = true;

			if (opt.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				currentPanel.Update();
				//
				//	Get the grid line width
				//
				if (opt.txtGridWidth.Text == String.Empty)
					gridWidth = 0;
				else
					gridWidth = Convert.ToInt32(opt.txtGridWidth.Text);
				//
				//	Get the grid color
				//
				gridColor  = opt.gridColor; 
				//
				//	Get the border line width
				//
				if (opt.txtBorderWidth.Text == String.Empty)
					borderPixels = 0;
				else
					borderPixels = Convert.ToInt32(opt.txtBorderWidth.Text);
				//
				//	Get the border color
				//
					borderColor  = opt.borderColor;
				//
				//	Get the grid line type (UTM or Geographic)
				//
				if (opt.utmButton.Checked == true)
				{
					gridUtm = true;
				}
				else
					gridUtm = false;
				//
				//	Get the grid line label information
				//
				gridFontColor  = opt.gridTextColor;
				gridFontName = opt.gridTextFont;
				chkLogo = opt.chkLogo.Checked;
				bLabelGridLines = opt.chkLabel.Checked;
				bLandmarks = opt.chkLandmarks.Checked;
			}
			photoPanel.Invalidate();
			topoPanel.Invalidate();
		}
//////////////////////////////////////////////////////////////////////////////////////
//	Fetch the Aerial Photo
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdGetPhotoImage ()	//(object sender, System.EventArgs e)
		{
	        TileId id = new TileId();
			imageWidth = mapWidth;
			imageHeight = mapHeight;
//
//	Get the center of the image
//
			LonLatPt center = new LonLatPt();
															 
			if (pfs != null)			// do we have any place facts?
			{
				if (placeGrid.CurrentRowIndex != gridIndex)
				{
					center.Lon = centerPoint.Lon = pfs[placeGrid.CurrentRowIndex].Center.Lon;
					center.Lat = centerPoint.Lat = pfs[placeGrid.CurrentRowIndex].Center.Lat;
					LatitudePhoto.Text = LatitudeTopo.Text = center.Lat.ToString("F5", null);
					LongitudePhoto.Text = LongitudeTopo.Text = center.Lon.ToString("F5", null);
					listScalePhoto.SelectedIndex = (int)photo.scale16m;	// 16m
					listScaleTopo.SelectedIndex = (int)topo.scale16m;	// 16m
					gridIndex = placeGrid.CurrentRowIndex;
					topoImageList.Clear();
					centerChanged = true;
				}
				else
				{
					try
					{					
						center.Lon = centerPoint.Lon = Convert.ToDouble(LongitudePhoto.Text);
						center.Lat = centerPoint.Lat = Convert.ToDouble(LatitudePhoto.Text);
					}
					catch
					{
						MessageBox.Show ("Please enter only numbers for Longtitude and Latitude", "TerraService Error", 
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			else
			{
				center.Lon = centerPoint.Lon = Convert.ToDouble(LongitudePhoto.Text);
				center.Lat = centerPoint.Lat = Convert.ToDouble(LatitudePhoto.Text);				
			}
//
//	If the Longitude and/or Latitude have not changed, we may not need to re-fetch the tiles
//
			if (centerChanged == true)
			{
				fetchImage = true;
				centerPoint = center;
				photoImageList.Clear();
				centerChanged = false;
			}
//
//	If the Map width and/or Map height have not changed, we may not need to re-fetch the tiles
//
			if (prevMapWidth != mapWidth || prevMapHeight != mapHeight)
			{
				fetchImage = true;
				prevMapWidth = mapWidth;
				prevMapHeight = mapHeight;
				photoImageList.Clear();
			}
			imageWidth = mapWidth;
			imageHeight = mapHeight;

			id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScalePhoto.SelectedItem);
			id.Scene = 0;		// What should this be?

			if (id.Scale != prevPhotoScale)
			{
				fetchImage = true;
				prevPhotoScale = id.Scale;
				photoImageList.Clear();
			}

			try
			{	
				if (fetchImage)
				{
					photoPage.Cursor = Cursors.WaitCursor;
					photoPlaceDescription = ts.ConvertLonLatPtToNearestPlace(center);
					try
					{
						TileMeta tm = ts.GetTileMetaFromLonLatPt(center, id.Theme, id.Scale);
						photoPlaceDescription += ", " + tm.Capture.ToString("D", null);
						placeDescription = photoPlaceDescription;
					}
					catch {}
				}
				bBorder = bGrid = bLogo = false;
				photoPage.Invalidate();
				bBorder = bGrid = bLogo = true;
				createImage(center, id);				
			}
			catch
			{
				MessageBox.Show ("Failure fetching image from server\nPlease try again later", 
					"Microsoft TerraService Error", 
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				photoPage.Cursor = Cursors.Default;
			}
		}

//////////////////////////////////////////////////////////////////////////////////////
//	Fetch the Topo Map
//////////////////////////////////////////////////////////////////////////////////////
		protected void cmdGetTopoMap() //(object sender, System.EventArgs e)
		{
	        TileId id = new TileId();
			imageWidth = mapWidth;
			imageHeight = mapHeight;
//
//	Get the center of the image
//
			LonLatPt center = new LonLatPt();

			if (pfs != null)			// do we have any place facts?
			{	
				if (placeGrid.CurrentRowIndex != gridIndex)
				{
					center.Lon = centerPoint.Lon = pfs[placeGrid.CurrentRowIndex].Center.Lon;
					center.Lat = centerPoint.Lat = pfs[placeGrid.CurrentRowIndex].Center.Lat;
					LatitudePhoto.Text = LatitudeTopo.Text = center.Lat.ToString("F5", null);
					LongitudePhoto.Text = LongitudeTopo.Text = center.Lon.ToString("F5", null);
					listScalePhoto.SelectedIndex = (int)photo.scale16m;	// 16m
					listScaleTopo.SelectedIndex = (int)topo.scale16m;	// 16m				
					gridIndex = placeGrid.CurrentRowIndex;
					photoImageList.Clear();
				}
				else
				{
					try
					{
						center.Lon = centerPoint.Lon = Convert.ToDouble(LongitudeTopo.Text);
						center.Lat = centerPoint.Lat = Convert.ToDouble(LatitudeTopo.Text);					
					}
					catch
					{
						MessageBox.Show ("Please enter only numbers for Longtitude and Latitude", "TerraService Error", 
							 MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			else
			{
				center.Lon = centerPoint.Lon = Convert.ToDouble(LongitudeTopo.Text);
				center.Lat = centerPoint.Lat = Convert.ToDouble(LatitudeTopo.Text);			
			}
//
//	If the Longitude and/or Latitude have not changed, we may not need to re-fetch the tiles
//

			if (centerChanged == true)
			{
				fetchImage = true;
				centerPoint = center;
				topoImageList.Clear();
				centerChanged = false;
			}
//
//	If the Map width and/or Map height have not changed, we may not need to re-fetch the tiles
//
			if (prevMapWidth != mapWidth || prevMapHeight != mapHeight)
			{
				fetchImage = true;
				prevMapWidth = mapWidth;
				prevMapHeight = mapHeight;
				topoImageList.Clear();
			}

			imageWidth = mapWidth;
			imageHeight = mapHeight;

			id.Theme = (TerraServer.Theme)Enum.Parse(typeof(Theme),(string)currentTheme);
			id.Scale = (TerraServer.Scale)Enum.Parse(typeof(TerraServer.Scale),(string)listScaleTopo.SelectedItem);
			id.Scene = 0;		// What should this be?
//
//	If the Theme and/or scale have not changed, we may not need to re-fetch the tiles
//				
			if (id.Scale != prevTopoScale)
			{
				fetchImage = true;
				prevTopoScale = id.Scale;
				topoImageList.Clear();
			}
			try
			{				
				if (fetchImage)
				{
					topoPage.Cursor = Cursors.WaitCursor;
					topoPlaceDescription = ts.ConvertLonLatPtToNearestPlace(center);
					try
					{
						TileMeta tm = ts.GetTileMetaFromLonLatPt(center, id.Theme, id.Scale);
						topoPlaceDescription += ", " + tm.Capture.ToString("D", null);
						placeDescription = topoPlaceDescription;
					}
					catch {}
					placeDescription = topoPlaceDescription;
				}

				bBorder = bGrid = bLogo = false;
				topoPage.Invalidate();
				bBorder = bGrid = bLogo = true;
				createImage(center, id);			
			}
			catch
			{
				MessageBox.Show ("Failure fetching image from server\nPlease try again later", 
					"Microsoft TerraService Error", 
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				topoPage.Cursor = Cursors.Default;
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		create the composite image																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	protected void createImage (LonLatPt center, TileId id)
	{
		Rectangle cRect;
		
		if (fetchImage == true)
		{
			clearLandmarks();

			if (currentTheme == "Photo")
			{
				cRect = photoPage.ClientRectangle;	// size of client rectangle
				photoPlaceDescription = placeDescription;
			}
			else
			{
				cRect = topoPage.ClientRectangle;	// size of client rectangle		
				topoPlaceDescription = placeDescription;
			}
			mapWidth = cRect.Width;
			mapHeight = cRect.Height;
			Int32 mapLeft  = borderPixels;
			Int32 mapRight = borderPixels;
			Int32 mmapWidth = mapWidth - (2 * borderPixels);
			Int32 mmapHeight = mapHeight - (2 * borderPixels);

			if (tileFetchThread != null)
			{
				tileFetchThread.Abort();			// stop the thread
				tileFetchThread = null;
			}

			bNewCenter = false;
			tileid = id;
			ThreadStart tStart = new ThreadStart(createImageThread);
			tileFetchThread = new Thread (tStart);
			tileFetchThread.Start();
						
			while(!bNewCenter)				// wait for image creation thread to set new center
			{				
				terraBar.Text = "Waiting for seperate thread to set new center";
				tileFetchThread.Join(500);	// wait for thread to end or for 500 mSecs
			}
			terraBar.Text = "";
			bNewCenter = false;

			ListBox.SelectedObjectCollection c = null;
			if (currentTheme == "Photo")
				c = listLandmark.SelectedItems;
			else
				c = listLandmarkTopo.SelectedItems;

			if (c != null)
					landmarkChanged();		
		}		
		this.Cursor = Cursors.Default;
	}

//////////////////////////////////////////////////////////////////////////////////
//			createImageThread													//
//			invoked in a seperate thread when terraDemo needs to fetch			//
//			another set of tiles.												//		
//////////////////////////////////////////////////////////////////////////////////
		public static void createImageThread ()
		{					
			Rectangle cRect;
			Int32 yStart=0, xStart=0;
			currentTabPage.Cursor = Cursors.WaitCursor;
			clearLandmarks();
			cRect = currentPanel.ClientRectangle;	// size of client rectangle
			if (currentTheme == "Photo")
				photoPlaceDescription = placeDescription;
			else
				topoPlaceDescription = placeDescription;

			mapWidth = imageWidth = cRect.Width;
			mapHeight = imageHeight = cRect.Height;
			Int32 mapLeft  = borderPixels;
			Int32 mapRight = borderPixels;
			Int32 mmapWidth = mapWidth - (2 * borderPixels);
			Int32 mmapHeight = mapHeight - (2 * borderPixels);
			abb = ts.GetAreaFromPt(centerPoint, tileid.Theme, tileid.Scale, mmapWidth, mmapHeight);
			bResized = false;
			screenNWPoint	= abb.NorthWest.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointNW);
			screenNEPoint	= abb.NorthEast.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointNE);
			screenSEPoint	= abb.SouthEast.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointSE);
			screenSWPoint	= abb.SouthWest.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointSW);

			metersPerPixel	= (1 << ((Int32) abb.Center.TileMeta.Id.Scale - 10));
			screenUtmZ		= abb.Center.TileMeta.Id.Scene;
			screenUtmX		= (abb.NorthWest.TileMeta.Id.X * 200 * metersPerPixel) + (abb.NorthWest.Offset.XOffset * metersPerPixel);
			screenUtmY		= (abb.NorthWest.TileMeta.Id.Y * 200 * metersPerPixel) + ((200 - abb.NorthWest.Offset.YOffset) * metersPerPixel);
			utmPointNW.Zone			= screenUtmZ;
			utmPointNW.X			= (double)screenUtmX;
			utmPointNW.Y			= (double)screenUtmY;
			screenNWPoint	= abb.NorthWest.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointNW);
			utmPointNE.Zone			= screenUtmZ;
			utmPointNE.X			= (abb.NorthEast.TileMeta.Id.X * 200 * metersPerPixel) + (abb.NorthEast.Offset.XOffset * metersPerPixel);
			utmPointNE.Y			= (abb.NorthEast.TileMeta.Id.Y * 200 * metersPerPixel) + ((200 - abb.NorthEast.Offset.YOffset) * metersPerPixel);
			screenNEPoint	= abb.NorthEast.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointNE);
			utmPointSE.Zone			= screenUtmZ;
			utmPointSE.X			= (abb.SouthEast.TileMeta.Id.X * 200 * metersPerPixel) + (abb.SouthEast.Offset.XOffset * metersPerPixel);
			utmPointSE.Y			= (abb.SouthEast.TileMeta.Id.Y * 200 * metersPerPixel) + ((200 - abb.SouthEast.Offset.YOffset) * metersPerPixel);
			screenSEPoint	= abb.SouthEast.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointSE);
			utmPointSW.Zone			= screenUtmZ;
			utmPointSW.X			= (abb.SouthWest.TileMeta.Id.X * 200 * metersPerPixel) + (abb.SouthWest.Offset.XOffset * metersPerPixel);
			utmPointSW.Y			= (abb.SouthWest.TileMeta.Id.Y * 200 * metersPerPixel) + ((200 - abb.SouthWest.Offset.YOffset) * metersPerPixel);
			screenSWPoint	= abb.SouthWest.Offset.Point;		// Projection.UtmNad83PtToLonLatPt(utmPointSW);
			xStart = xStart = abb.NorthWest.TileMeta.Id.X;
			yStart = yStart = abb.NorthWest.TileMeta.Id.Y;

			metersPerPixel	= (1 << ((Int32) abb.Center.TileMeta.Id.Scale - 10));
			int xLoc=0, yLoc=0, width=0, height=0;
//////////////////////////////////////////////////////////////////////////////////
//		Fetch and display the tiles for this geometry							//
//////////////////////////////////////////////////////////////////////////////////
			int tileCount = 0;
			Graphics g = currentTabPage.CreateGraphics();			// needed to output feedback messages
			FontFamily[] fm = FontFamily.GetFamilies(g);
			Font f = new Font(fm[0], 10.0F);
			SolidBrush sb = new SolidBrush(Color.Green);
			SolidBrush bg = new SolidBrush(sControl.BackColor);

			int screenX = SystemInformation.PrimaryMonitorSize.Width;
			int screenY = SystemInformation.PrimaryMonitorSize.Height;
			int numTilesX = abb.NorthEast.TileMeta.Id.X - xStart;
			int numTilesNeededX = screenX/200 - numTilesX;
			int numTilesY = yStart - abb.SouthWest.TileMeta.Id.Y ;
			int numTilesNeededY = screenY/200 - numTilesY;
			int numTotalTiles = (numTilesX + numTilesNeededX) * (numTilesY + numTilesNeededY + 1);
 
			Image tileImage = null;
			Int32 x=0, y=0;
//
//		calculate the lon/lat for the lower right corner, we will use this in fetching landmarks ahead
//
			Int32 tscreenUtmZ		= abb.Center.TileMeta.Id.Scene;
			Int32 tscreenUtmX		= ((abb.SouthEast.TileMeta.Id.X+numTilesNeededX) * 200 * metersPerPixel)
				+ (200 * metersPerPixel);
			Int32 tscreenUtmY		= ((abb.SouthEast.TileMeta.Id.Y-numTilesNeededY) * 200 * metersPerPixel);
			UtmPt tutmPointSE = new UtmPt();
			tutmPointSE.Zone			= tscreenUtmZ;
			tutmPointSE.X			= (double)tscreenUtmX;
			tutmPointSE.Y			= (double)tscreenUtmY;
			lowerRight = Projection.UtmNad83PtToLonLatPt(tutmPointSE);			

			bNewCenter = true;
			for ( x = xStart; x <= abb.NorthEast.TileMeta.Id.X; x++) 
			{
				for ( y = yStart; y >= abb.SouthWest.TileMeta.Id.Y; y--) 
				{
					TileId tid = abb.NorthWest.TileMeta.Id;
					tid.X = x;
					tid.Y = y;

					g.FillRectangle(bg, 0, 0, 200, 27);					
					g.DrawString("Downloading tile " + (tileCount+1) + " of " + numTotalTiles, f, sb, 
							10, 10);	

					tileImage = getTileFromCache(tid);
					cache.Add(tileImage);

					imageObj io = new imageObj(tileImage, 
						mapLeft  + (x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset,
						mapRight + (yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);
					
					tileCount++;
					
					if (currentTheme == "Photo")
						photoImageList.Add(io);
					else
						topoImageList.Add(io);

					//
					// force redraw of the already available tiles
					//
					width = tileImage.Width;
					height = tileImage.Height;
					xLoc = ((x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset);
					yLoc = ((yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);

					if (xLoc < 0)
					{
						width += xLoc;
						xLoc = borderPixels;
					}
					if (yLoc < 0)
					{
						height += yLoc;
						yLoc = borderPixels;
					}
					if (xLoc == borderPixels)
						xLoc = 0;
					if (yLoc == borderPixels)
						yLoc = 0;
					currentPanel.Invalidate(new Region(new Rectangle(xLoc, yLoc, width, height)));
				}
			}
			currentTabPage.Cursor = Cursors.Default;
///////////////////////////////////////////////////////////////////////////////////////////
//		Fetch some additional tiles to the "east", so that we have them for resizing...////
///////////////////////////////////////////////////////////////////////////////////////////

			for ( x = abb.NorthEast.TileMeta.Id.X+1; x <= abb.NorthEast.TileMeta.Id.X+numTilesNeededX; x++) 
			{
				for ( y = yStart; y >= abb.SouthWest.TileMeta.Id.Y; y--) 
				{
					TileId tid = abb.NorthWest.TileMeta.Id;
					tid.X = x;
					tid.Y = y;

					g.FillRectangle(bg, 0, 0, 200, 27);					
					g.DrawString("Downloading tile " + (tileCount+1) + " of " + numTotalTiles, f, sb, 
							10, 10);	
											
					tileImage = getTileFromCache(tid);
					cache.Add(tileImage);
					imageObj io = new imageObj(tileImage, 
						mapLeft  + (x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset,
						mapRight + (yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);

					tileCount++;
					
					if (currentTheme == "Photo")
						photoImageList.Add(io);
					else
						topoImageList.Add(io);
					
					//
					// force redraw of the already available tiles
					//
					width = tileImage.Width;
					height = tileImage.Height;
					xLoc = ((x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset);
					yLoc = ((yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);

					if (xLoc < 0)
					{
						width += xLoc;
						xLoc = borderPixels;
					}
					if (yLoc < 0)
					{
						height += yLoc;
						yLoc = borderPixels;
					}
					if (xLoc == borderPixels)
						xLoc = 0;
					if (yLoc == borderPixels)
						yLoc = 0;
					currentPanel.Invalidate(new Region(new Rectangle(xLoc, yLoc, width, height)));
				}
			}
//////////////////////////////////////////////////////////////////////////////////////////////
//		Fetch some additional tiles to the "south", so that we have them for resizing...	//
//////////////////////////////////////////////////////////////////////////////////////////////
			for ( x = xStart; x <= abb.NorthEast.TileMeta.Id.X+numTilesNeededX; x++) 
			{
				for ( y = abb.SouthWest.TileMeta.Id.Y-1; y >= abb.SouthWest.TileMeta.Id.Y-numTilesNeededY+1; y--) 
				{
					TileId tid = abb.NorthWest.TileMeta.Id;
					tid.X = x;
					tid.Y = y;

					g.FillRectangle(bg, 0, 0, 200, 27);					
					g.DrawString("Downloading tile " + (tileCount+1) + " of " + numTotalTiles, f, sb, 
							10, 10);	

					tileImage = getTileFromCache(tid);										
					cache.Add(tileImage);
					imageObj io = new imageObj(tileImage, 
						mapLeft  + (x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset,
						mapRight + (yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);

					tileCount++;
					
					if (currentTheme == "Photo")
						photoImageList.Add(io);
					else
						topoImageList.Add(io);

					//
					// force redraw of the already available tiles
					//
					width = tileImage.Width;
					height = tileImage.Height;
					xLoc = ((x - xStart) * tileImage.Width  - (Int32) abb.NorthWest.Offset.XOffset);
					yLoc = ((yStart - y) * tileImage.Height - (Int32) abb.NorthWest.Offset.YOffset);

					if (xLoc < 0)
					{
						width += xLoc;
						xLoc = borderPixels;
					}
					if (yLoc < 0)
					{
						height += yLoc;
						yLoc = borderPixels;
					}
					if (xLoc == borderPixels)
						xLoc = 0;
					if (yLoc == borderPixels)
						yLoc = 0;
					currentPanel.Invalidate(new Region(new Rectangle(xLoc, yLoc, width, height)));
				}
			}
			g.FillRectangle(bg, 0, 0, 200, 27);		// clear feedback text...
		}	
//////////////////////////////////////////////////////////////////////////////////
//	Get the next tile from memory, disk cache or TerraService					//
//////////////////////////////////////////////////////////////////////////////////
		protected static Image getTileFromCache(TileId tid) //int Theme, int Scale, int X, int Y, int Scene, String URL)
		{
			if (currentTheme == "Photo")
						// why isn't Theme already set?
				tid.Theme = (Theme)1;
			else if(currentTheme == "Topo")
			{
				tid.Theme = (Theme)2;
			}
			String URL = "http://terraservice.net/gettile.ashx?t=" + (Int32)tid.Theme +"&s=" + (Int32)tid.Scale +
				"&x=" + tid.X + "&y=" + tid.Y + "&z=" + tid.Scene;	
			String key = "T" + (Int32)tid.Theme + "-S" + (Int32)tid.Scale + "-Z" + tid.Scene 
				+ "-X" + tid.X + "-Y" + tid.Y;				// build the hash key

			Image image=null;

			if ((image = (Image)getTileFromHashtable(key))== null)
			{
				image = getImageFromTerraServer(URL);
				if (image != null)
				{
					try
					{
						saveKey(key, image);
					}
					catch (ArgumentException ae)
					{
						MessageBox.Show(ae.ToString());
					}
				
					image.Save(CACHEDIR + key + ".jpg" , ImageFormat.Jpeg);
				}
			}
			return image;
		}
//////////////////////////////////////////////////////////////////////////////////
//		Save the image in a hashtable											//
//////////////////////////////////////////////////////////////////////////////////
		protected static void saveKey(String key, Image image)
		{
			WeakReference wr = new WeakReference(image);
			try
			{
				weakImageHash.Add (key, wr);
			}
			catch(Exception)
			{
				MessageBox.Show("Item " + key + " already added to hash table");
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//		Retreive an image from a hastable										//
//////////////////////////////////////////////////////////////////////////////////
		protected static Image getTileFromHashtable(String key)
		{
			WeakReference wr = (WeakReference) weakImageHash[key];// get the weak ref from the hashtable
			if (wr != null)
			{ 
				Image img = (Image) wr.Target;
				if (img != null) return img;					// create a strong reference
     			weakImageHash.Remove(key);						// apparently the image has been GC'd
			}

			try
			{
				return getImageFromFile(key);					// get it from the cached file
			}
			catch (Exception)
			{
			}						
			return null;										// never executes
		}
//////////////////////////////////////////////////////////////////////////////////
//		Get an image from a cached file											//
//////////////////////////////////////////////////////////////////////////////////
		private static Image getImageFromFile(String key)
		{
			if(weakImageHash.ContainsKey(key))
			{
				weakImageHash.Remove(key);
			}
			Image cacheImage = Image.FromFile(CACHEDIR + key + ".jpg");
			saveKey (key, cacheImage);		// got image from file, save in hashtable
			return cacheImage;
		}
//////////////////////////////////////////////////////////////////////////////////
 //		Get an image from terraserver											//
 /////////////////////////////////////////////////////////////////////////////////
		private static Image getImageFromTerraServer(String URL)
		{
			try
			{			
				HttpWebResponse myResponse=null;
				HttpWebRequest myRequest = 
					(HttpWebRequest)WebRequest.Create(URL);

				myResponse = (HttpWebResponse)myRequest.GetResponse();

				Stream myStream = myResponse.GetResponseStream();				// get a "Stream" from the "Response" object
				//
				//	we could not use the "Stream" returned by "GetRepsonseStream()above
				//	to create an Image.FromStream below, because the returned "Stream"
				//	does not support "seek" operations (we get an exception if we try)
				//
				Byte [] buffer = new Byte[(Int32)myResponse.ContentLength];		// allocate a "Byte" buffer of the appropriate size
				Int32 bytesLeft = (Int32)myResponse.ContentLength;
				Int32 startByte = 0;
				while(bytesLeft > 0)
				{
					Int32 bytesRead = myStream.Read(buffer,startByte,bytesLeft);
					if(bytesRead > 0)
					{
						startByte += bytesRead;
						bytesLeft -= bytesRead;
					}
					else
						bytesLeft = 0;
				}

				myStream.Close();												// we don't need the stream any more, close it
				return Image.FromStream(new MemoryStream(buffer));		// create an "Image" from the buffer
			}
			catch (WebException we)
			{
				MessageBox.Show (we.ToString());
				return null;
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		User clicked the Exit menu																				//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		protected void exitClicked (object sender, System.EventArgs e)
		{
			if (tileFetchThread != null)
				tileFetchThread.Abort();		// stop the additional thread
			this.Close();
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Paint the Photo panel override - All drawing occurs here (not counting components						//
//		which know how to draw themselves																		//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	    protected void OnPhotoPanelPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);            
			Graphics g = e.Graphics;

			Rectangle cRect = photoPage.ClientRectangle;
			photoPanel.Size = new Size(cRect.Width - 110, cRect.Height - 70);

			cRect = photoPanel.ClientRectangle;
			mapWidth = imageWidth = cRect.Width;
			mapHeight = imageHeight = cRect.Height;	

			if (bResized)
			{
				recalculateCorners();
				bResized = false;
			}
			//
			//	Draw the Image
			//

			if (photoImageList != null)
			{
				RectangleF clipRect = g.ClipBounds;
				g.SetClip(new RectangleF(0, 0, mapWidth, mapHeight));
				imageObj images = null;
				System.Collections.IEnumerator myEnum = photoImageList.GetEnumerator();
				if(myEnum != null)
				{
					try
					{
						while (myEnum.MoveNext())
						{
							images = (imageObj)myEnum.Current;
							g.DrawImage(images.tile, 
								images.x,
								images.y,
								images.tile.Width, images.tile.Height);
						}
					}
					catch (Exception)
					{
						Invalidate();
					}

				}
				g.SetClip(clipRect);
			}
			//
			//	Draw the grid lines on the image, if requested
			//
			drawGridLines(g);
			//
			// Show the Logo
			//
			drawLogo(g);

			if (isPrinting || isSaving)
			{
				drawLandmarks(g);
			}
			if (isPrinting)
			{
				String temp = photoPlaceDescription + " - Aerial Image courtesy of USGS";
				g.DrawString (temp, drawingFont, drawingFontBrush, (float)10.0, (float)(photoPanel.Size.Height + 10.0));
			}
			g.Dispose();
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Paint the Photo page override - All drawing occurs here (not counting components						//
//		which know how to draw themselves																		//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	    protected void OnPhotoPagePaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);            
			Graphics g = e.Graphics;
			//
			//	Draw the place name information above the image
			//
			if (tabChanged)
			{
				tabChanged = false;
				this.Cursor = Cursors.WaitCursor;
				photoImageList.Clear();

				cmdGetPhotoImage();
				this.Cursor = Cursors.Default;
			}

			SolidBrush sb = new SolidBrush(control.BackColor);
			g.FillRectangle(sb, 0, 0, imageWidth, 0);
			g.DrawString (photoPlaceDescription, drawingFont, drawingFontBrush, (float)110, (float)25);
			//
			//	Draw the direction icon
			//
			drawDirectionIcon(g);

			g.Dispose();							// free the Graphics resource
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Paint the Topo panel override - All drawing occurs here (not counting components						//
//		which know how to draw themselves																		//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	    protected void OnTopoPanelPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);            
			Graphics g = e.Graphics;

			Rectangle cRect = topoPage.ClientRectangle;
			topoPanel.Size = new Size(cRect.Width - 110, cRect.Height - 70);

			cRect = topoPanel.ClientRectangle;
			mapWidth = imageWidth = cRect.Width;
			mapHeight = imageHeight = cRect.Height;	

			if (bResized)
			{
				recalculateCorners();
				bResized = false;
			}
			//
			//	Draw the Image
			//
			if (photoImageList != null)
			{
				RectangleF clipRect = g.ClipBounds;
				g.SetClip(new RectangleF(0, 0, mapWidth, mapHeight));
				imageObj images = null;
				System.Collections.IEnumerator myEnum = topoImageList.GetEnumerator();
				if(myEnum != null)
				{
					try
					{
						while (myEnum.MoveNext())
						{
							images = (imageObj)myEnum.Current;
							g.DrawImage(images.tile, 
								images.x,
								images.y,
								images.tile.Width, images.tile.Height);
						}
					}
					catch (Exception)
					{
						Invalidate();
					}
				}
				g.SetClip(clipRect);
			}
			//
			//	Draw the grid lines on the image, if requested
			//
			drawGridLines(g);
			//
			// Show the Logo
			//
			drawLogo(g);

			if (isPrinting || isSaving)
			{
				drawLandmarks(g);
			}
			if (isPrinting)
			{
				String temp = topoPlaceDescription + " - Aerial Image courtesy of USGS";
				g.DrawString (temp, drawingFont, drawingFontBrush, (float)10.0, (float)(photoPanel.Size.Height + 10.0));
			}
			g.Dispose();							// free the Graphics resource
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//		Paint the Topo Map page override - All drawing occurs here												//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	    protected void OnTopoPagePaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);            
			Graphics g = e.Graphics;
	//
	//	Draw the place name information above the image
	//
			if (tabChanged)
			{
				tabChanged = false;
				this.Cursor = Cursors.WaitCursor;
				cmdGetTopoMap();
				this.Cursor = Cursors.Default;
			}
			Rectangle cRect = topoPage.ClientRectangle;
			mapWidth = imageWidth = cRect.Width;
			mapHeight = imageHeight = cRect.Height;

			SolidBrush sb = new SolidBrush(control.BackColor);
			g.FillRectangle(sb, 0, 0, imageWidth, 0);
			g.DrawString (topoPlaceDescription, drawingFont, drawingFontBrush, (float)110, (float)25);		
//
//	Draw the direction icon
//
			drawDirectionIcon(g);

			g.Dispose();							// free the Graphics resource
		}
//////////////////////////////////////////////////////////////////////////////////
//			draw the direction icon												//
//////////////////////////////////////////////////////////////////////////////////
		protected void drawDirectionIcon(Graphics g)
		{
			try 
			{
				if(currentTheme == "Photo")
				{
					if (listScalePhoto.SelectedIndex == 6)
						g.DrawImage(directionImageIn, 
							5,
							50,
							directionImageIn.Width, 
							directionImageIn.Height);
					else if (listScalePhoto.SelectedIndex == 0)
						g.DrawImage(directionImageOut, 
							5,
							50,
							directionImageOut.Width, 
							directionImageOut.Height);
					else
					{
						g.DrawImage(directionImageInOut, 
							5,
							50,
							directionImageInOut.Width, 
							directionImageInOut.Height);
					}
				}
				else if (currentTheme == "Topo")
				{
					if (listScaleTopo.SelectedIndex == 8)
						g.DrawImage(directionImageIn, 
							5,
							50,
							directionImageIn.Width, 
							directionImageIn.Height);
					else if (listScaleTopo.SelectedIndex == 0)
						g.DrawImage(directionImageOut, 
							5,
							50,
							directionImageOut.Width, 
							directionImageOut.Height);
					else
						g.DrawImage(directionImageInOut, 
							5,
							50,
							directionImageInOut.Width, 
							directionImageInOut.Height);
				}

			}
			catch 
			{
				g.DrawString ("Directional\nimage\nunavailable", errorFont, errorFontBrush, 5, 50);
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//			draw the USGS Logo													//
//////////////////////////////////////////////////////////////////////////////////
		protected void drawLogo(Graphics g)
		{
			if (chkLogo && bLogo || isPrinting) 
			{
				try
				{
					g.DrawImage(logoImage,
						mapWidth - logoImage.Width  - 1,
						mapHeight - logoImage.Height - 1, 
						logoImage.Width, 
						logoImage.Height);
				}
				catch (Exception)
				{
				}
			}	
		}
//////////////////////////////////////////////////////////////////////////////////
//			clear any existing landmarks										//
//////////////////////////////////////////////////////////////////////////////////
		public static void clearLandmarks()
		{
			//	remove any existing landmarks
			if (landmarkPics != null)
			{
				for (int i = 0;i < landmarkPics.Length; i++)
				{
					if (landmarkPics[i] != null)
					{
						sPhotoPanel.Controls.Remove(landmarkPics[i]);
						sTopoPanel.Controls.Remove(topoLandmarkPics[i]);
					}
				}
				landmarkPics = null;
				topoLandmarkPics = null;
				currentPanel.Invalidate();
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//			get any requested landmarks											//
//////////////////////////////////////////////////////////////////////////////////
		protected void getLandmarks()
		{
			int numLandmarks = 0;
			currentTabPage.Cursor = Cursors.WaitCursor;

			clearLandmarks();

			LandmarkService ls = null;
			if (landmarkPointTypes != null) 
			{
				if (ls == null) ls = new LandmarkService();
				BoundingRect br = new BoundingRect();
				
				LandmarkServer.LonLatPt tempPt = new LandmarkServer.LonLatPt();

				br.LowerRight = new LandmarkServer.LonLatPt();
				if(bLandmarks == true)						// fetch landmarks ahead
				{
					br.LowerRight.Lon = lowerRight.Lon;
					br.LowerRight.Lat = lowerRight.Lat;
				}
				else										// don't fetch ahead				
				{
					int tilesNeededX = (mapWidth - prevMapWidth)/200;
					int tilesNeededY = (mapHeight - prevMapHeight)/200;

					Int32 tscreenUtmZ		= abb.Center.TileMeta.Id.Scene;
					Int32 tscreenUtmX		= ((abb.SouthEast.TileMeta.Id.X+tilesNeededX) * 200 * metersPerPixel)
						+ (abb.SouthEast.Offset.XOffset * metersPerPixel);
					Int32 tscreenUtmY		= ((abb.SouthEast.TileMeta.Id.Y-tilesNeededY) * 200 * metersPerPixel)
						+ ((200 - abb.SouthEast.Offset.YOffset) * metersPerPixel);
					UtmPt tutmPointSE = new UtmPt();
					tutmPointSE.Zone			= tscreenUtmZ;
					tutmPointSE.X			= (double)tscreenUtmX;
					tutmPointSE.Y			= (double)tscreenUtmY;
					lowerRight = Projection.UtmNad83PtToLonLatPt(tutmPointSE);	
					br.LowerRight.Lon = lowerRight.Lon;
					br.LowerRight.Lat = lowerRight.Lat;					
				}

				br.UpperLeft = new LandmarkServer.LonLatPt();
				br.UpperLeft.Lon = screenNWPoint.Lon;
				br.UpperLeft.Lat = screenNWPoint.Lat;
				
				if (landmarkPointTypes[0] == "Terminal")
				{
					landmarkPointTypes[0] = "Transportation Terminal";
				}
				lps = ls.GetLandmarkPointsByRect(br, landmarkPointTypes);				
				if (lps == null)
					return;

				// Start of tootips on landmark code...

				landmarkPics = new PictureBox[lps.Length];
				topoLandmarkPics = new PictureBox[lps.Length];

				ToolTip myPhotoTip = new ToolTip();
				ToolTip myTopoTip = new ToolTip();
				try 
				{
					Image GifUrl = null;
					foreach (LandmarkPoint lp in lps) 
					{
						GifUrl = null;
						LonLatPt pt = new LonLatPt();
						pt.Lon = lp.Point.Lon;
						pt.Lat = lp.Point.Lat;
						UtmPt utmpt = Projection.LonLatPtToUtmNad83Pt(pt);
						Int32 landmarkX = (Int32) ((utmpt.X - screenUtmX) / metersPerPixel);
						Int32 landmarkY = (Int32) ((screenUtmY - utmpt.Y) / metersPerPixel);
						
						int maxWidth = SystemInformation.PrimaryMonitorMaximizedWindowSize.Width;
						int maxHeight = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height;
						if (new Rectangle(borderPixels, borderPixels, maxWidth, maxHeight).Contains(landmarkX, landmarkY)) 
						{
							GifUrl = landmarkImageList.Images[(Int32)stringToIndex[lp.Type]];
							if (landmarkX >= 0 && (landmarkY - GifUrl.Height) >= 0)
							{
								landmarkPics[numLandmarks] = new PictureBox();								// create a PictureBox to hold the image
								landmarkPics[numLandmarks].Location = new System.Drawing.Point (landmarkX, landmarkY - GifUrl.Height);
								landmarkPics[numLandmarks].Size = new System.Drawing.Size (GifUrl.Width, GifUrl.Height);
								landmarkPics[numLandmarks].Image = GifUrl;
								landmarkPics[numLandmarks].Text = lp.Name;
								landmarkPics[numLandmarks].MouseEnter += new System.EventHandler (this.pbEntered);
								landmarkPics[numLandmarks].Click += new System.EventHandler (this.pbClicked);

								myPhotoTip.SetToolTip(landmarkPics[numLandmarks], lp.Name);
								myPhotoTip.Active = true;

								topoLandmarkPics[numLandmarks] = new PictureBox();								// create a PictureBox to hold the image
								topoLandmarkPics[numLandmarks].Location = new System.Drawing.Point (landmarkX, landmarkY - GifUrl.Height);
								topoLandmarkPics[numLandmarks].Size = new System.Drawing.Size (GifUrl.Width, GifUrl.Height);
								topoLandmarkPics[numLandmarks].Image = GifUrl;
								topoLandmarkPics[numLandmarks].Text = lp.Name;
								topoLandmarkPics[numLandmarks].MouseEnter += new System.EventHandler (this.pbEntered);
								myTopoTip.SetToolTip(topoLandmarkPics[numLandmarks], lp.Name);
								myTopoTip.Active = true;

								photoPanel.Controls.Add (landmarkPics[numLandmarks]);
								topoPanel.Controls.Add (topoLandmarkPics[numLandmarks]);
								numLandmarks++;
							}
						}
					}
				}
				catch (Exception ee)
				{
					MessageBox.Show("exception in landmark acquistion" + ee);
				}			
			}
			currentTabPage.Cursor = Cursors.Default;	
		}
//////////////////////////////////////////////////////////////////////////////////
//			Get the place description from the service							//
//////////////////////////////////////////////////////////////////////////////////
		protected void getPlaceDescription(LonLatPt newCenter, TileId id)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				placeDescription = ts.ConvertLonLatPtToNearestPlace(newCenter);
				TileMeta tm = ts.GetTileMetaFromLonLatPt(newCenter, id.Theme, id.Scale);
				placeDescription += ", " + tm.Capture.ToString("D", null);
			}
			catch
			{
				MessageBox.Show("Unable to convert Lat/Lon to Place\nPlease try again later",
					"Microsoft TerraService Warning",
					 MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}						
		}
//////////////////////////////////////////////////////////////////////////////////
//			Adjust the scale between topo and photo								//
//////////////////////////////////////////////////////////////////////////////////
		protected void adjustScale (int scale)
		{
			if (currentTheme == "Topo")
			{
				switch(scale)
				{
					case (int)topo.scale2m:
						listScalePhoto.SelectedIndex = (int)photo.scale2m;
						break;
					case (int)topo.scale4m:
						listScalePhoto.SelectedIndex = (int)photo.scale4m;
						break;
					case (int)topo.scale8m:
						listScalePhoto.SelectedIndex = (int)photo.scale8m;
						break;
					case (int)topo.scale16m:
						listScalePhoto.SelectedIndex = (int)photo.scale16m;
						break;
					case (int)topo.scale32m:
						listScalePhoto.SelectedIndex = (int)photo.scale32m;
						break;
					case (int)topo.scale64m:
						listScalePhoto.SelectedIndex = (int)photo.scale64m;
						break;
					case (int)topo.scale128m:
					case (int)topo.scale256m:
					case (int)topo.scale512m:
						listScalePhoto.SelectedIndex = (int)photo.scale64m;
						break;
					default:
						break;
				}	
			}
			else if (currentTheme == "Photo")
			{
				switch(scale)
				{
					case (int)photo.scale1m:
						listScaleTopo.SelectedIndex = (int)topo.scale2m;
						break;
					case (int)photo.scale2m:
						listScaleTopo.SelectedIndex = (int)topo.scale2m;
						break;
					case (int)photo.scale4m:
						listScaleTopo.SelectedIndex = (int)topo.scale4m;
						break;
					case (int)photo.scale8m:
						listScaleTopo.SelectedIndex = (int)topo.scale8m;
						break;
					case (int)photo.scale16m:
						listScaleTopo.SelectedIndex = (int)topo.scale16m;
						break;
					case (int)photo.scale32m:
						listScaleTopo.SelectedIndex = (int)topo.scale32m;
						break;
					case (int)photo.scale64m:
						listScaleTopo.SelectedIndex = (int)topo.scale64m;
						break;
					default:
						break;
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//			Display the text associated with the landmark icon					//
//			in the status bar.													//
//			This is in addition to the tooltips. Tooltips seemed to be a		//
//			bit problematic in Beta 1											//
//////////////////////////////////////////////////////////////////////////////////
		public void pbEntered (object sender, System.EventArgs e)
		{
			for (int i = 0; i < landmarkPics.Length; i++)
			{
				if (sender.Equals(landmarkPics[i]))
				{
					PictureBox pb = (PictureBox)sender;
					terraBar.Text = pb.Text;
				}
			}
			for (int i = 0; i < topoLandmarkPics.Length; i++)
			{
				if (sender.Equals(topoLandmarkPics[i]))
				{
					PictureBox pb = (PictureBox)sender;
					terraBar.Text = pb.Text;
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//			User clicked on a landmark, get it's location						//
//			and zoom to that place												//
//////////////////////////////////////////////////////////////////////////////////
		public void pbClicked (object sender, System.EventArgs e)
		{
			if (currentTheme == "Photo")
			{
				for (int i = 0; i < landmarkPics.Length; i++)
				{
					if (sender.Equals(landmarkPics[i]))
					{
						int x = landmarkPics[i].Location.X;
						int y = landmarkPics[i].Location.Y;
						MouseEventArgs me = new MouseEventArgs( 
							MouseButtons.Left, 1, x, y, 0);
						Image_Click_Panel(sender, me);
					}
				}
			}
			else if (currentTheme == "Topo")
			{
				for (int i = 0; i < topoLandmarkPics.Length; i++)
				{
					if (sender.Equals(topoLandmarkPics[i]))
					{
						int x = landmarkPics[i].Location.X;
						int y = landmarkPics[i].Location.Y;
						MouseEventArgs me = new MouseEventArgs( 
							MouseButtons.Left, 1, x, y, 0);
						Image_Click_Panel(sender, me);
					}
				}
			}
		}
//////////////////////////////////////////////////////////////////////////////////
//			Draw the grid lines on the Aerial image or topo map					//
//////////////////////////////////////////////////////////////////////////////////
		protected void drawGridLines(Graphics g)
		{
			Matrix m = new Matrix(); 
//////////////////////////////////////////////////////////////////////////
//		UTM lines														//
//////////////////////////////////////////////////////////////////////////

			if (gridUtm && (gridWidth != 0) && bGrid)			// Drawing UTM grid lines
			{			
				Pen pen = new Pen(gridColor, gridWidth);

				for (Int32 x = xStart; x <= abb.NorthEast.TileMeta.Id.X; x++) 
				{
					Int32 xCoord = (x - xStart) * 200 - (Int32) abb.NorthWest.Offset.XOffset;
					if(xCoord > 0)
						g.DrawLine(pen, new Point(xCoord, 0), new Point(xCoord, imageHeight));
				}

				for (Int32 y = yStart; y <= abb.SouthWest.TileMeta.Id.Y; y++) 
				{
					Int32 yCoord = (y - yStart) * 200 - (Int32) abb.NorthWest.Offset.YOffset;
					if (yCoord > 0)
						g.DrawLine(pen, new Point(0, yCoord), new Point(imageWidth, yCoord));
				}
			}
//////////////////////////////////////////////////////////////////////////
//		Geographic lines												//
//////////////////////////////////////////////////////////////////////////

			if (!gridUtm && (gridWidth != 0) && bGrid)			// or Geographic grid lines
			{
				Int32 xTopCoord, xBotCoord, yLeftCoord, yRightCoord;
				Pen pen = new Pen(gridColor, gridWidth);
//////////////////////////////////////////////////////////////////////////
//		Longitude lines	at 1/4, 1/2, 3/4 points							//
//		Calculate in pixels, then convert to lon/lat					//
//////////////////////////////////////////////////////////////////////////

				for (int i=0; i < 3 ;i++)
				{
					int div=1, mul=1;
					switch (i)
					{
						case 0:
							div = 4;
							mul = 1;
							break;
						case 1:
							div = 2;
							mul = 1;
							break;
						case 2:
							div = 4;
							mul = 3;
							break;
						default:
							break;
					}
				//		Get UTM Point for the top edge of the image (northern centerPoint)
				//
				//	
					utmPoint.Zone	= utmPointNW.Zone;
					utmPoint.X		= utmPointNW.X + (Int32)((utmPointNE.X - utmPointNW.X) / 2);
					utmPoint.Y		= utmPointNW.Y;
					TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have lon / lat for northern centerPoint right over center
					if(TestPt.Lon < centerPoint.Lon)	
					{			// Longitude lines leaning right (/)
						xTopCoord	= (Int32)((((imageWidth) / div)*mul) + ((((imageWidth) / div)*mul) * ((centerPoint.Lon - TestPt.Lon) / (screenNEPoint.Lon - TestPt.Lon))));
						if(xTopCoord > (imageWidth)) xTopCoord = imageWidth;
					} 
					else 
					{			// Longitude lines leaning left (\)
						xTopCoord	= (Int32)((((imageWidth) / div)*mul) - ((((imageWidth) / div)*mul) * ((TestPt.Lon - centerPoint.Lon) / (TestPt.Lon - screenNWPoint.Lon))));
						if(xTopCoord < 0) xTopCoord = 0;
					}
					//
					//		Get UTM Point for the bottom edge of the image (southern centerPoint)
					///
					utmPoint.Zone	= utmPointSW.Zone;
					utmPoint.X		= utmPointSW.X + (Int32)((utmPointSE.X - utmPointSW.X) / 2);
					utmPoint.Y		= utmPointSW.Y;
					TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have long / lat for southern centerPoint right over center
					if(TestPt.Lon < centerPoint.Lon)	
					{			// Longitude lines leaning right (\)
						xBotCoord	= (Int32)((((imageWidth) / div)*mul) + ((((imageWidth) / div)*mul) * ((centerPoint.Lon - TestPt.Lon) / (screenSEPoint.Lon - TestPt.Lon))));
					} 
					else 
					{								// Longitude lines leaning right (/)
						xBotCoord	= (Int32)((((imageWidth) / div)*mul) - ((((imageWidth) / div)*mul) * ((TestPt.Lon - centerPoint.Lon) / (TestPt.Lon - screenSWPoint.Lon))));
					}
					//
					//		Draw center longitude line
					//		Label it if we have a valid font size
					//
					g.DrawLine(pen, new Point(xTopCoord+ 0), new Point(xBotCoord, imageHeight));
				}
//////////////////////////////////////////////////////////////////////////
//		Latitude lines at 1/4, 1/2, 3/4 points							//
//		Calculate in pixels, then convert to lon/lat					//
//////////////////////////////////////////////////////////////////////////
				for (int i = 0 ; i < 3; i++)
				{
					int div=1, mul=1;
					switch (i)
					{
						case 0:
							div = 4;
							mul = 1;
							break;
						case 1:
							div = 2;
							mul = 1;
							break;
						case 2:
							div = 4;
							mul = 3;
							break;
						default:
							break;
					}
				//
				//		Get UTM Point for the left edge of the image (west centerPoint)
				//
					utmPoint.Zone	= utmPointSW.Zone;
					utmPoint.X		= utmPointSW.X;
					utmPoint.Y		= utmPointSW.Y + (Int32)((utmPointNW.Y - utmPointSW.Y) / 2);
					TestPt			= Projection.UtmNad83PtToLonLatPt((UtmPt)utmPoint);		// Have long / lat for Western centerPoint left of center
					if(TestPt.Lat < centerPoint.Lat)	
					{			// Latitude lines leaning right (\)
						yLeftCoord	= (Int32)((((imageHeight) / div)*mul) - ((((imageHeight) / div)*mul) * ((centerPoint.Lat - TestPt.Lat) / (screenNWPoint.Lat - TestPt.Lat))));
						if(yLeftCoord < 0) yLeftCoord = 0;
					} 
					else 
					{								// Longitude lines leaning left (/)
						yLeftCoord	= (Int32)((((imageHeight) / div)*mul) + ((((imageHeight) / div)*mul) * ((TestPt.Lat - centerPoint.Lat) / (TestPt.Lat - screenSWPoint.Lat))));
						if(yLeftCoord > imageHeight) yLeftCoord = (imageHeight);
					}
					//
					//		Get UTM Point for right edge of the image (eastern centerPoint)
					//
					utmPoint.Zone	= utmPointSE.Zone;
					utmPoint.X		= utmPointSE.X;
					utmPoint.Y		= utmPointSE.Y + (Int32)((utmPointNE.Y - utmPointSE.Y) / 2);
					TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have long / lat for Western centerPoint left of center
					if(TestPt.Lat < centerPoint.Lat)	
					{			// Latitude lines leaning left (/)
						yRightCoord = (Int32)((((imageHeight) / div)*mul) - ((((imageHeight) / div)*mul) * ((centerPoint.Lat - TestPt.Lat) / (screenNEPoint.Lat - TestPt.Lat))));
						if(yRightCoord < 0) yLeftCoord = 0;
					} 
					else 
					{								// Longitude lines leaning right (\)
						yRightCoord = (Int32)((((imageHeight) / div)*mul) + ((((imageHeight) / div)*mul) * ((TestPt.Lat - centerPoint.Lat) / (TestPt.Lat - screenSEPoint.Lat))));
						if(yRightCoord > (imageHeight)) yRightCoord = (imageHeight);
					}
					g.DrawLine(pen, new Point(0, yLeftCoord), new Point(imageWidth, yRightCoord));
				}				
			}
		//	
		//		Blank-out the border area
		//
		if (bBorder)
		{
			Brush borderBrush = new SolidBrush(borderColor);
			g.FillRectangle(borderBrush, 0, 0, imageWidth, borderPixels);
			g.FillRectangle(borderBrush, 0, imageHeight-borderPixels, imageWidth, borderPixels);
			g.FillRectangle(borderBrush, 0, 0, borderPixels, imageHeight);
			g.FillRectangle(borderBrush, imageWidth - borderPixels, 0, borderPixels, imageHeight);
		}
		//
		//		Label the UTM grid lines
		//
		if (gridUtm && (gridWidth != 0) && bGrid) {
			
			// label longitude lines

			for (Int32 x = xStart; x <= abb.NorthEast.TileMeta.Id.X; x++) 
			{
				Int32 xCoord = (x - xStart) * 200 - (Int32) abb.NorthWest.Offset.XOffset;
				if(xCoord > 0) 
				{
					if (bLabelGridLines) 
					{
						Brush fontBrush = new SolidBrush(gridFontColor);
						if (fontBrush != null) 
						{
							Int32 xGrid = x * 200 * metersPerPixel;
							String str = String.Format("{0:N0}",xGrid);
							SizeF size = g.MeasureString(str, gridFontName);
							//	labels at top
							g.DrawString(String.Format("{0:N0}",xGrid), gridFontName, fontBrush, 
								new PointF(xCoord - (size.Width/2), 0));
							// labels at bottom
							g.DrawString(String.Format("{0:N0}",xGrid), gridFontName, fontBrush, 
								new PointF(xCoord - (size.Width/2), imageHeight - gridFontName.Height));							
						}
					}
				}
			}
			// label latitude lines
			for (Int32 y = yStart; y <= abb.SouthWest.TileMeta.Id.Y; y++) 
			{				
				if (bLabelGridLines) 
				{
					
					Brush fontBrush = new SolidBrush(gridFontColor);
					if (fontBrush != null) 
					{

						Int32 yCoord = (yStart - y) * 200 - (Int32) abb.NorthWest.Offset.YOffset;						

						Int32 yGrid = y * 200 * metersPerPixel;
						SizeF size = g.MeasureString(String.Format("{0:N0}",yGrid), gridFontName);

						g.SetClip(new RectangleF(0, 0, mapWidth, mapHeight));
						m.Reset();
						m.RotateAt(-90, new PointF(0, yCoord));
						m.Translate(-size.Width/2, 0);
						g.Transform = m;
						g.DrawString(String.Format("{0:N0}",yGrid), gridFontName, fontBrush, 
							new PointF(0, yCoord));

						m.Reset();
						m.RotateAt(-90, new PointF(imageWidth - size.Width, yCoord));
						m.Translate(-size.Width/2, size.Width/2 + gridFontName.Height);
						g.Transform = m;						
						g.DrawString(String.Format("{0:N0}",yGrid), gridFontName, fontBrush, 
							new PointF(imageWidth - size.Width, (yCoord)));

						m.Reset();
						g.Transform = m;
						g.ResetClip();
					}
				}
			}
		}
//////////////////////////////////////////////////////////////////
//		Label the geographic grid lines							//
//////////////////////////////////////////////////////////////////
		if (!gridUtm && (gridWidth != 0) && bGrid) {
			Int32 xTopCoord, xBotCoord, yLeftCoord, yRightCoord;
//	longitude lines
			for (int i = 0; i < 3; i++)
			{
				int div=1, mul=1;
				switch (i)
				{
					case 0:
						div = 4;
						mul = 1;
						break;
					case 1:
						div = 2;
						mul = 1;
						break;
					case 2:
						div = 4;
						mul = 3;
						break;
					default:
						break;
				}
			//
			//		(longitude lines) Get UTM Point for the top edge of the image (northern centerPoint)
			//

				utmPoint.Zone	= utmPointNW.Zone;
				utmPoint.X		= utmPointNW.X + (Int32)((utmPointNE.X - utmPointNW.X) / 2);
				utmPoint.Y		= utmPointNW.Y;
				TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have long / lat for northern centerPoint right over center
				if(TestPt.Lon < centerPoint.Lon)	
				{			// Longitude lines leaning right (/)
					xTopCoord	= (Int32)((((imageWidth) / div)*mul) + ((((imageWidth) / div)*mul) * ((centerPoint.Lon - TestPt.Lon) / (screenNEPoint.Lon - TestPt.Lon))));
					if(xTopCoord > (imageWidth)) xTopCoord = imageWidth;
				} 
				else 
				{								// Longitude lines leaning left (\)
					xTopCoord	= (Int32)((((imageWidth) / div)*mul) - ((((imageWidth) / div)*mul) * ((TestPt.Lon - centerPoint.Lon) / (TestPt.Lon - screenNWPoint.Lon))));
					if(xTopCoord < 0) xTopCoord = 0;
				}
				//
				//		Get UTM Point for the bottom edge of the image (southern centerPoint)
				///
				utmPoint.Zone	= utmPointSW.Zone;
				utmPoint.X		= utmPointSW.X + (Int32)((utmPointSE.X - utmPointSW.X) / 2);
				utmPoint.Y		= utmPointSW.Y;
				TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have long / lat for southern centerPoint right over center
				if(TestPt.Lon < centerPoint.Lon)	
				{			// Longitude lines leaning right (\)
					xBotCoord	= (Int32)((((imageWidth) / div)*mul) + ((((imageWidth) / div)*mul) * ((centerPoint.Lon - TestPt.Lon) / (screenSEPoint.Lon - TestPt.Lon))));
				} 
				else 
				{								// Longitude lines leaning right (/)
					xBotCoord	= (Int32)((((imageWidth) / div)*mul) - ((((imageWidth) / div)*mul) * ((TestPt.Lon - centerPoint.Lon) / (TestPt.Lon - screenSWPoint.Lon))));
				}
				//
				//		Label it if we have a valid font size
				//
				if (bLabelGridLines) 
				{
					Brush fontBrush = new SolidBrush(gridFontColor);
					if (fontBrush != null) 
					{

						if (i == 1)
						{
							TestPt = centerPoint;			// the center Lon/Lat
						}
						else
						{
							TestPt = pixelsToLonLat(((xTopCoord+xBotCoord) /2), 0);
						}
						// label lines at top
						g.DrawString(String.Format("{0:N3}",TestPt.Lon), gridFontName, fontBrush, 
							new PointF(xTopCoord - (2 * gridFontName.Height), 0));
						//	label lines at bottom
						String str = String.Format("{0:N3}",TestPt.Lon);
						SizeF size = g.MeasureString(str, gridFontName);
						g.DrawString(String.Format("{0:N3}",TestPt.Lon), gridFontName, fontBrush, 
							new PointF(xBotCoord - (2 * gridFontName.Height), imageHeight - gridFontName.Height));
					}
				}
			}
			//
			//		(latitude lines) - Get UTM Point for the left edge of the image (west centerPoint)
			//
			for (int i = 0; i < 3 ; i++)
			{
				int div=1, mul=1;
				switch (i)
				{
					case 0:
						div = 4;
						mul = 1;
						break;
					case 1:
						div = 2;
						mul = 1;
						break;
					case 2:
						div = 4;
						mul = 3;
						break;
					default:
						break;
				}
				//		Get UTM Point for the left edge of the image (west centerPoint)
				//
				//
	
				utmPoint.Zone	= utmPointSW.Zone;
				utmPoint.X		= utmPointSW.X;
				utmPoint.Y		= utmPointSW.Y + (Int32)((utmPointNW.Y - utmPointSW.Y) / 2);
				TestPt			= Projection.UtmNad83PtToLonLatPt((UtmPt)utmPoint);		// Have long / lat for Western centerPoint left of center
				if(TestPt.Lat < centerPoint.Lat)	
				{			// Latitude lines leaning right (\)
					yLeftCoord	= (Int32)((((imageHeight) / div)*mul) - ((((imageHeight) / div)*mul) * ((centerPoint.Lat - TestPt.Lat) / (screenNWPoint.Lat - TestPt.Lat))));
					if(yLeftCoord < 0) yLeftCoord = 0;
				} 
				else 
				{								// Longitude lines leaning left (/)
					yLeftCoord	= (Int32)((((imageHeight) / div)*mul) + ((((imageHeight) / div)*mul) * ((TestPt.Lat - centerPoint.Lat) / (TestPt.Lat - screenSWPoint.Lat))));
					if(yLeftCoord > imageHeight) yLeftCoord = (imageHeight);
				}
				//
				//		Get UTM Point for right edge of the image (eastern centerPoint)
				//
				utmPoint.Zone	= utmPointSE.Zone;
				utmPoint.X		= utmPointSE.X;
				utmPoint.Y		= utmPointSE.Y + (Int32)((utmPointNE.Y - utmPointSE.Y) / 2);
				TestPt			= Projection.UtmNad83PtToLonLatPt(utmPoint);		// Have long / lat for Western centerPoint left of center
				if(TestPt.Lat < centerPoint.Lat)	
				{			// Latitude lines leaning left (/)
					yRightCoord = (Int32)((((imageHeight) / div)*mul) - ((((imageHeight) / div)*mul) * ((centerPoint.Lat - TestPt.Lat) / (screenNEPoint.Lat - TestPt.Lat))));
					if(yRightCoord < 0) yLeftCoord = 0;
				} 
				else 
				{								// Longitude lines leaning right (\)
					yRightCoord = (Int32)((((imageHeight) / div)*mul) + ((((imageHeight) / div)*mul) * ((TestPt.Lat - centerPoint.Lat) / (TestPt.Lat - screenSEPoint.Lat))));
					if(yRightCoord > (imageHeight)) yRightCoord = (imageHeight);
				}
				//
				//		Label latitude line
				//
				if (bLabelGridLines) 
				{
					Brush fontBrush = new SolidBrush(gridFontColor);
					if (fontBrush != null) 
					{
						if (i == 1)
						{
							TestPt = centerPoint;			// the center Lon/Lat
						}
						else
						{
							TestPt = pixelsToLonLat(0, ((yLeftCoord+yRightCoord) / 2));
						}	

						g.SetClip(new RectangleF(0, 0, mapWidth, mapHeight));
						SizeF size = g.MeasureString(String.Format("{0:N3}",TestPt.Lat), gridFontName);

						m.Reset();
						m.RotateAt(-90, new PointF(0, yLeftCoord));
						m.Translate(-size.Width/2, 0);
						g.Transform = m;
						g.DrawString(String.Format("{0:N3}",TestPt.Lat), gridFontName, fontBrush, 
							new PointF(0, yLeftCoord));

						m.Reset();
						m.RotateAt(-90, new PointF(imageWidth - size.Width, yRightCoord));
						m.Translate(-size.Width/2, size.Width/2 + gridFontName.Height/2);
						g.Transform = m;
						g.DrawString(String.Format("{0:N3}",TestPt.Lat), gridFontName, fontBrush, 
							new PointF(imageWidth - size.Width, yRightCoord));

						m.Reset();
						g.Transform = m;
						g.ResetClip();
					}
				}
			}
		}	
	}

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
			components.Dispose();
			base.Dispose();		// Jeff Richter, changed order of calls.
        }
//////////////////////////////////////////////////////////////////////////////////
//			draw the any requested landmarks									//
//			only called when printing or saving, otherwise landmarks			//
//			are drawn as picture boxes in order to support tooltips				//
//////////////////////////////////////////////////////////////////////////////////
		protected void drawLandmarks(Graphics g)
		{
			// Draw the landmark Points on the composite image
			if (landmarkPointTypes != null) 
			{
				if (lps == null)
					return;
	
				Rectangle cRect = new Rectangle (0, 0, 
					currentTabPage.ClientRectangle.Width, currentTabPage.ClientRectangle.Height);
				g.SetClip(cRect);
				Image GifUrl = null;

				try 
				{
					foreach (LandmarkPoint lp in lps) 
					{
						GifUrl = null;
						LonLatPt pt = new LonLatPt();
						pt.Lon = lp.Point.Lon;
						pt.Lat = lp.Point.Lat;
						UtmPt utmpt = Projection.LonLatPtToUtmNad83Pt(pt);
						Int32 landmarkX = (Int32) ((utmpt.X - screenUtmX) / metersPerPixel);
						Int32 landmarkY = (Int32) ((screenUtmY - utmpt.Y) / metersPerPixel);
						if (new Rectangle(borderPixels, borderPixels, mapWidth, mapHeight).Contains(landmarkX, landmarkY)) 
						{
							GifUrl = landmarkImageList.Images[(Int32)stringToIndex[lp.Type]];

							g.DrawImage(GifUrl, 
								landmarkX, landmarkY - GifUrl.Height, 
								GifUrl.Width, GifUrl.Height);
						}
					}
				}
				catch (Exception ee)
				{
					MessageBox.Show("exception in landmark drawing" + ee);
				}
			}	
		}
        /// <summary>
        /// The main entry centerPoint for the application.
        /// </summary>
        /// 
		[STAThread]
        public static void Main(string[] args) 
        {
            Application.Run(new terraDemo());
        }
 /////////////////////////////////////////////////////////////////////////////////
 //		Used to keep photo and topo scales in sync								//
 /////////////////////////////////////////////////////////////////////////////////
		public enum photo
		{		    
			scale1m,		    
			scale2m,		    
			scale4m,		    
			scale8m,		    
			scale16m,		    
			scale32m,		    
			scale64m,        
		}
		public enum topo 
		{		    		    
			scale2m,		    
			scale4m,		    
			scale8m,		    
			scale16m,		    
			scale32m,		    
			scale64m,
			scale128m,
			scale256m,
			scale512m,
		}
		public enum landmarks
		{
			Building,
			Cemetery,
			Church,
			EncartaArticle,
			GolfCourse,
			Hospital,
			Institution,
			Locale,
			Parks,
			PopulatedPlace,
			RecreationArea,
			RetailCenter,
			StreamGauge,
			Terminal,
		}
	}
}