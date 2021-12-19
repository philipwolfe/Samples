using System.Security;
using System.Security.Permissions;

//We have to have SafeSubWindow, we optionally need other permissions
[assembly:PermissionSetAttribute(SecurityAction.RequestOptional,Unrestricted=true)] 
[assembly:UIPermissionAttribute(SecurityAction.RequestMinimum,Window=UIPermissionWindow.SafeSubWindows)]
namespace Charting {

    using System;
    using System.Threading;
    using System.Collections;
    using System.ComponentModel;
    using System.WinForms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using ChartEngine ;
    using System.IO ;
	using CustomizerForm;

    //Define a custom exception handler that writes to a logging stream rather than
    //displaying an error - in the PDC release MessageBox is not secure and so cannot 
    //be used
    internal class CustomExceptionHandler {

        ChartPanel control;

        //Pass in the control so that we can access the error log
        public CustomExceptionHandler(ChartPanel control) { 
            this.control = control ;
        }

        //Called when an unhandled exception occurs
        public void OnThreadException(object sender, ThreadExceptionEventArgs t) {
            Exception e = t.exception;
            control.errorLog.WriteLine("Exception: \n\n" + e.Message + "\n\nStack Trace:\n" + e.StackTrace);
            ErrorForm ef = new ErrorForm("Exception: \n\n" + e.Message + "\n\nStack Trace:\n" + e.StackTrace);
            ef.Show();
        }
    }

    //The Panel that contains the chart control - allows:
    // 
    //       Lines to be added to the chart
    //       The chart to be customised (permissions allowing)
    //       Reading and writing of chart data (permission allowing)
    // 
    public class ChartPanel : UserControl {
    	private Charting.ChartControl chartControl1;
	    private Button buttonCustomise;
	    private Button buttonSaveFile;
	    private Button buttonLoadFile;
        private TextBox textBoxPrompt;
        private ChartData chartData = new ChartData(); 

        //Used to record debug  and record 
        internal StringWriter debugLog = new StringWriter();
        internal StringWriter errorLog = new StringWriter();
    
        //Location of files
        string fileLocation="";

        public ChartPanel() {
            
            //Register our custom exception handler
            CustomExceptionHandler eh = new CustomExceptionHandler(this);
            Application.ThreadException += new ThreadExceptionEventHandler(eh.OnThreadException);

            //Write version number so that we know we downloaded the right version
            debugLog.WriteLine("*** V16 ***\n");
            
            //Initialise the chart data
            InitData();

            //Initialize the Form
            InitializeComponent();

            //Hook property change so that we can set back colors 
            this.PropertyChanged += new PropertyChangedEventHandler(ChartPanel_PropertyChanged);
            
            //Set the chart data into the chart control
            chartControl1.ChartData = chartData;

            //First get the location of "MyDocuments"
            //If we can't get it then immediately return
            fileLocation = SystemInformation.GetFolderPath(SpecialFolder.Personal);
            
            //Set up the UI based on our security permissions
            //DetermineSecuritySettings();

            debugLog.WriteLine("*** ChartPanel CTOR COMPLETE ***\n");
        }

        //Allow Hosts to set the data for the chart
        public ChartData ChartData { 
            get { return chartData; }
            set { chartData = value; }
        }

        //Set up the UI based on our security permissions    
        private void DetermineSecuritySettings() {


            //See if we have read permission
            FileIOPermission readPerm = 
				new FileIOPermission(FileIOPermissionAccess.Read, fileLocation);

            try {
                readPerm.Demand(); 
                buttonLoadFile.Enabled=true; 
                debugLog.WriteLine("*** READ PERM DEMAND SUCEEDED ***");
            } catch(Exception ex) {
                buttonLoadFile.Enabled=false; 
                debugLog.WriteLine("*** READ PERM DEMAND FAILED ***");
                debugLog.WriteLine(ex.ToString());
            }
            

			//See if we have write permission
            FileIOPermission writePerm = new FileIOPermission(FileIOPermissionAccess.Write, fileLocation);

            try {
                writePerm.Demand(); 
                buttonSaveFile.Enabled=true; 
                debugLog.WriteLine("*** WRITE PERM DEMAND SUCEEDED ***");
            } catch(Exception ex) {
                buttonSaveFile.Enabled=false; 
                debugLog.WriteLine("*** WRITE PERM DEMAND FAILED ***");
                debugLog.WriteLine(ex.ToString());
            }
        }


        //Allow public read access to logs including from script on a web page
        public string DebugLog {
            get { return debugLog.ToString(); }
        }
        
        public string ErrorLog {
            get { return errorLog.ToString(); }
        }
    

        //*** Event Handlers 

        private void buttonCustomise_Click(object sender, EventArgs e) {
            ChartCustomizerForm custform = new ChartCustomizerForm(chartData, chartControl1);
            custform.Show() ;
        }






        private void buttonLoadFile_Click(object sender, EventArgs e) {

            string filename = fileLocation + "\\" + textBoxPrompt.Text;

            ChartData oldData = chartData;
            StreamReader reader = new StreamReader(filename);
			
            try {
				this.Cursor = Cursors.WaitCursor;
                chartData = new ChartData();
                chartData.LoadData(reader);
            } catch(Exception ex1) {
                chartData=oldData;
                throw ex1;
            } finally {
				this.Cursor = Cursors.Default;
				reader.Close();
            }
            chartControl1.ChartData = chartData;
            chartControl1.Invalidate();

        }






        private void buttonSaveFile_Click(object sender, EventArgs e) {
            
            string filename = fileLocation + "\\" + textBoxPrompt.Text;

            StreamWriter writer = new StreamWriter(filename);

            try {
                chartData.SaveData(writer);
            } finally {
				this.Cursor = Cursors.Default;
                writer.Close();
            }

        }






        //Explicitly set BackColors of Buttons to workaround PDC light colored backgrounds bug
        private void ChartPanel_PropertyChanged(object sender, PropertyChangedEventArgs e) {

            if (e.PropertyName.Equals("BackColor")) {
                setButtonColors();
            }
        }

        protected override void OnCreateControl() {
            setButtonColors();
        }

        private void setButtonColors() {
            buttonCustomise.BackColor = ControlPaint.Dark(this.BackColor);
            buttonLoadFile.BackColor = ControlPaint.Dark(this.BackColor);
            buttonSaveFile.BackColor = ControlPaint.Dark(this.BackColor);
        
            buttonCustomise.ForeColor = this.ForeColor;
            buttonLoadFile.ForeColor = this.ForeColor;
            buttonSaveFile.ForeColor = this.ForeColor;
        }


        //Initialise the data to be displayed by the Chart - pig iron production 1988 - 1992
        private void InitData() {

            chartData.YTickSize = 20000 ;
            chartData.YMax = 120000 ;
            chartData.YMin = 0;
            chartData.XAxisTitles = new string[]{ "1988", "1989", "1990", "1991", "1992" };

            chartData.Lines.Add(InitCIS()) ;
            chartData.Lines.Add(InitJapan()) ;
            chartData.Lines.Add(InitChina()) ;
            chartData.Lines.Add(InitUSA()) ;
        }

        private ChartLine InitCIS() {
            ChartLine chartLine = new ChartLine();
            chartLine.Color = Color.Orange;
            chartLine.Width = 3 ;
            chartLine.LineStyle = DashStyle.Solid;
            chartLine.Title = "Soviet Union/CIS";
            chartLine.Symbol = " ";
            chartLine.Values = new float[]{ 114559, 113928,  110167,  90953,   85396  };
            return chartLine ;
        }

        private ChartLine InitJapan() {
            ChartLine chartLine = new ChartLine();
            chartLine.Color = Color.Red;
            chartLine.Width = 3 ;
            chartLine.LineStyle = DashStyle.Dash;
            chartLine.Title = "Japan";
            chartLine.Symbol = " ";
            chartLine.Values = new float[]{ 79295,      80197,      80229,      79985,      73144   };
            return chartLine ;
        }

        private ChartLine InitChina() {
            ChartLine chartLine = new ChartLine();
            chartLine.Color = Color.Brown;
            chartLine.Width = 3 ;
            chartLine.LineStyle = DashStyle.Solid;
            chartLine.Title = "China";
            chartLine.Symbol = " ";
            chartLine.Values = new float[]{ 57040,      58200,      62606,      64280,      73438  };
            return chartLine ;
        }

        private ChartLine InitUSA() {
            ChartLine chartLine = new ChartLine();
            chartLine.Color = Color.Green;
            chartLine.Width = 3 ;
            chartLine.LineStyle = DashStyle.Solid;
            chartLine.Title = "USA";
            chartLine.Symbol = " ";
            chartLine.Values = new float[]{ 50572,      50677,      49666,      44123,      47378    };
            return chartLine ;
        }

        private void InitializeComponent() {
            this.buttonCustomise = new Button();
            this.buttonSaveFile = new Button();
            this.buttonLoadFile = new Button();
            this.textBoxPrompt = new TextBox();
            this.chartControl1 = new Charting.ChartControl();
            this.chartControl1 = new Charting.ChartControl();
            this.Font = new System.Drawing.Font ("Tahoma", 12, System.Drawing.FontStyle.Bold);

            buttonCustomise.TabIndex = 3;
            buttonCustomise.Size = new Size(140, 32);
            buttonCustomise.Text = "Customise";
            buttonCustomise.Location = new Point(10, 288);
            buttonCustomise.Anchor = AnchorStyles.BottomLeft;
            buttonCustomise.FlatStyle = FlatStyle.Flat;
            buttonCustomise.Click += new EventHandler(buttonCustomise_Click);


            buttonSaveFile.TabIndex = 3;
            buttonSaveFile.Size = new Size(140, 32);
            buttonSaveFile.Text = "Save...";
            buttonSaveFile.Location = new Point(160, 288);
            buttonSaveFile.Anchor = AnchorStyles.BottomLeft;
            buttonSaveFile.FlatStyle = FlatStyle.Flat;
            buttonSaveFile.Click += new EventHandler(buttonSaveFile_Click);

            buttonLoadFile.TabIndex = 3;
            buttonLoadFile.Size = new Size(140, 32);
            buttonLoadFile.Text = "Load...";
            buttonLoadFile.Location = new Point(310, 288);
            buttonLoadFile.Anchor = AnchorStyles.BottomLeft;
            buttonLoadFile.FlatStyle = FlatStyle.Flat;
            buttonLoadFile.Click += new EventHandler(buttonLoadFile_Click);

            chartControl1.TabIndex = 5;
            chartControl1.Size = new Size(592, 264);
            chartControl1.Text = "chartControl1";
            chartControl1.Location = new Point(10, 8);
            chartControl1.Anchor = AnchorStyles.All;

            textBoxPrompt.Text = "Enter chart file name";
            textBoxPrompt.Size = new System.Drawing.Size(200, 32);
            textBoxPrompt.Location = new System.Drawing.Point(460, 292);
            textBoxPrompt.Anchor = AnchorStyles.BottomLeft;
            textBoxPrompt.TabIndex = 4;
			textBoxPrompt.BorderStyle = System.WinForms.BorderStyle.FixedSingle;

            this.TabIndex = 0;
            this.Size = new Size(608, 392);
            this.Text = "Control1";

            this.Controls.Add(chartControl1);
            this.Controls.Add(buttonCustomise);
            this.Controls.Add(buttonLoadFile);
            this.Controls.Add(buttonSaveFile);
            this.Controls.Add(textBoxPrompt);
    		
        }
    	
    }

}




