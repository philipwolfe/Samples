using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Security;

using ChartEngine;
using CustomizerForm;

using System.IO;

namespace Charting {
    /// <summary>
    /// Summary description for ChartPanel.
    /// </summary>
    public class ChartPanel : System.Windows.Forms.UserControl {
        private System.Windows.Forms.Button buttonCustomise;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private Charting.ChartControl chartControl1;

        private ChartData chartData = new ChartData(); 

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ChartPanel() {

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //Initialise the chart data
            InitData();

        }


        //Allow Hosts to set the data for the chart
        public ChartData ChartData { 
            get { 
                return chartData; 
            }
            set { 
                chartData = value; 
                chartControl1.ChartData = chartData;
            }
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

            chartControl1.ChartData = chartData;
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



        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        public override void Dispose() {
            if(components != null) {
                components.Dispose();
            }
            base.Dispose();
        }

		#region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonCustomise = new System.Windows.Forms.Button();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.chartControl1 = new Charting.ChartControl();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCustomise
            // 
            this.buttonCustomise.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.buttonCustomise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomise.Location = new System.Drawing.Point(10, 344);
            this.buttonCustomise.Name = "buttonCustomise";
            this.buttonCustomise.Size = new System.Drawing.Size(140, 32);
            this.buttonCustomise.TabIndex = 3;
            this.buttonCustomise.Text = "&Customize...";
            this.buttonCustomise.Click += new System.EventHandler(this.buttonCustomise_Click);
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.textBoxPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPrompt.Location = new System.Drawing.Point(460, 344);
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(200, 20);
            this.textBoxPrompt.TabIndex = 4;
            this.textBoxPrompt.Text = "Enter chart file name";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Location = new System.Drawing.Point(310, 344);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(140, 32);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "&Load...";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.chartControl1.Location = new System.Drawing.Point(16, 16);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.Size = new System.Drawing.Size(720, 304);
            this.chartControl1.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(160, 344);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 32);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save...";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ChartPanel
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.chartControl1,
                                                                          this.textBoxPrompt,
                                                                          this.buttonSave,
                                                                          this.buttonLoad,
                                                                          this.buttonCustomise});
            this.Name = "ChartPanel";
            this.Size = new System.Drawing.Size(752, 392);
            this.ResumeLayout(false);

        }
		#endregion

        private void buttonCustomise_Click(object sender, System.EventArgs e) {
            try {
                ChartCustomizerForm cf = new ChartCustomizerForm(chartData, chartControl1);
                cf.Font = this.Font;
                cf.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, System.EventArgs e) {
            try {
                string fileLocation = SystemInformation.GetFolderPath(SpecialFolder.Personal);
                string filename = fileLocation + "\\" + textBoxPrompt.Text;

                using (StreamWriter writer = new StreamWriter(filename)) {
                    chartData.SaveData(writer);
                }

            } catch(Exception ex) {
                MessageBox.Show("Cannot save file:\n\n" + ex.ToString());
            }
            
        }

        private void buttonLoad_Click(object sender, System.EventArgs e) {
            try {
                string fileLocation = SystemInformation.GetFolderPath(SpecialFolder.Personal);
                string filename = fileLocation + "\\" + textBoxPrompt.Text;

                ChartData oldData = chartData;
                
                using (StreamReader reader = new StreamReader(filename)) {
                    try {
                        chartData = new ChartData();
                        chartData.LoadData(reader);
                    } catch(Exception ex1) {
                        chartData=oldData;
                        throw ex1;
                    } 
                }

                chartControl1.ChartData = chartData;
                chartControl1.Invalidate();

            } catch(Exception ex) {
                MessageBox.Show("Cannot load file:\n\n" + ex.ToString());
            }

            /*
            ChartData oldData = chartData;

            try {
                string fileLocation = SystemInformation.GetFolderPath(SpecialFolder.Personal);
                string filename = fileLocation + "\\" + textBoxPrompt.Text;

                
                using (StreamReader reader = new StreamReader(filename)) {
                    try {
                        chartData = new ChartData();
                        chartData.LoadData(reader);
                    } catch(Exception ex1) {
                        chartData=oldData;
                        throw ex1;
                    } 
                }

                chartControl1.ChartData = chartData;
                chartControl1.Invalidate();

            } catch(SecurityException secex) {

                using (OpenFileDialog fd = new OpenFileDialog()) {

                    if (fd.ShowDialog() == DialogResult.OK) {

                        using (Stream s = fd.OpenFile()) {
                            try {
                                StreamReader reader = new StreamReader(s);
                                chartData = new ChartData();
                                chartData.LoadData(reader);
                            } catch(Exception ex1) {
                                chartData=oldData;
                                throw ex1;
                            } 
                        }

                    }
                }

            } catch(Exception ex) {
                MessageBox.Show("Cannot load file:\n\n" + ex.ToString());
            }
*/

        }
    }
}
