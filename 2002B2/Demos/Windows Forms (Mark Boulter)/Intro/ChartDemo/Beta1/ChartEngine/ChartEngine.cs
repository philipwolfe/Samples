

namespace ChartEngine {
    using System.WinForms;
    using System.Collections;
    using System.Collections.Bases;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
    using System;
    using System.IO;

    //Core Line Data structure - used to transmit chart info across a webservice
    //and by ChartLine
    public struct LineData {
        public float[] LineValues  ;
        public string LineTitle ;
        public string LineSymbol ;
    }

    //Line Data plus display style information 
    public class ChartLine {

        private Color lineColor ;
        private LineData lineData ;
        private DashStyle lineStyle ;
        private int lineWidth  ;

        //Constructors
        public ChartLine() :base() {}

        public ChartLine(LineData lineData) :base() {
            this.lineData = lineData;
        }

        //Properties
        public Color Color { 
            get { return lineColor ; }
            set { lineColor = value ; }
        }

        public DashStyle LineStyle {
            get { return lineStyle ; }
            set { lineStyle = value ; }
        }
        
        public string Symbol {
            get { return lineData.LineSymbol ; }
            set { lineData.LineSymbol = value ; }
        }

        public string Title {
            get { return lineData.LineTitle ; }
            set { lineData.LineTitle = value ; }
        }

        public float[] Values {
            get { return lineData.LineValues ; }
            set { lineData.LineValues = value ; }
        }

        public int Width { 
            get { return lineWidth ; }
            set { lineWidth = value ; }
        }

        //Methods
        public void SetLineData(LineData lineData) {
            this.lineData = lineData;
        }

        public void LoadData(string line) {
            TypeConverter converter ;

            string[] stringValues = line.Split( new char[]{ '\t' } );
            
            this.Symbol = stringValues[0] ;
            this.Title = stringValues[1] ;

            converter = TypeDescriptor.GetConverter(typeof(Color));
            this.Color = (Color)(converter.ConvertFromString(stringValues[2]));

            converter = TypeDescriptor.GetConverter(typeof(DashStyle));
            this.LineStyle = (DashStyle)(converter.ConvertFromString(stringValues[3]));

            converter = TypeDescriptor.GetConverter(typeof(int));
            this.Width = (int)(converter.ConvertFromString(stringValues[4]));

            this.Values = new float[stringValues.Length-6]; //Allow for crlf at end
            converter = TypeDescriptor.GetConverter(typeof(float));

            for (int i = 5 ; i < stringValues.Length - 1; i++) {
                this.Values[i-5] = (float)(converter.ConvertFromString(stringValues[i]));
            }
        }

        public void SaveData(TextWriter writer) {
            TypeConverter converter ;

            converter = TypeDescriptor.GetConverter(typeof(Color));
            string colorString = converter.ConvertToString(this.Color);

            converter = TypeDescriptor.GetConverter(typeof(DashStyle));
            string dashStyleString = converter.ConvertToString(this.LineStyle);

            converter = TypeDescriptor.GetConverter(typeof(int));
            string widthString = converter.ConvertToString(this.Width);
            
            writer.Write(this.Symbol);
            writer.Write("\t");
            writer.Write(this.Title);
            writer.Write("\t");
            writer.Write(colorString);
            writer.Write("\t");
            writer.Write(dashStyleString);
            writer.Write("\t");
            writer.Write(widthString);
            writer.Write("\t");
            SaveDataValues(writer) ;
            writer.WriteLine("");

        }

        private void SaveDataValues(TextWriter writer) {
            
            TypeConverter converter ;
            converter = TypeDescriptor.GetConverter(typeof(float));

            foreach(float f in this.Values) {
                writer.Write(converter.ConvertToString(f));
                writer.Write("\t");
            }

        }

    }

    //Chart Data structure
    public class ChartData {

        private float yTickSize;
        private float yMax;
        private float yMin;
        private string[] xAxisTitles ;
        private ChartLineList lines = new ChartLineList();
        private Color gridColor=Color.Blue;
        private bool showHGridLines=true;
        private bool showVGridLines=true;


        //Properties
        public float YTickSize {
            get { return yTickSize ; }
            set { yTickSize = value ; }
        }

        public float YMax {
            get { return yMax ; }
            set { yMax = value ; }
        }


        public float YMin {
            get { return yMin ; }
            set { yMin = value ; }
        }

        public string[] XAxisTitles {
            get { return xAxisTitles ; }
            set { xAxisTitles = value ; }
        }

        public ChartLineList Lines {
            get { return lines ; }
            set { lines = value ; }
        }

        public Color GridColor {
            get { return gridColor ; }
            set { gridColor = value ; }
        }

        public bool ShowHGridLines {
            get { return showHGridLines ; }
            set { showHGridLines = value ; }
        }

        public bool ShowVGridLines {
            get { return showVGridLines ; }
            set { showVGridLines = value ; }
        }


        public void LoadData(TextReader reader) {
            TypeConverter converter ;
            
            string line = reader.ReadLine();
            if (null == line) return; 

            string[] stringChartData = line.Split( new char[]{ '\t' } );
            
            converter = TypeDescriptor.GetConverter(typeof(float));
            this.YMin = (float)(converter.ConvertFromString(stringChartData[0]));
            this.YMax = (float)(converter.ConvertFromString(stringChartData[1]));
            this.YTickSize = (float)(converter.ConvertFromString(stringChartData[2]));

            converter = TypeDescriptor.GetConverter(typeof(Color));
            this.GridColor = (Color)(converter.ConvertFromString(stringChartData[3]));

            converter = TypeDescriptor.GetConverter(typeof(bool));
            this.ShowHGridLines = (bool)(converter.ConvertFromString(stringChartData[4]));
            this.ShowVGridLines = (bool)(converter.ConvertFromString(stringChartData[5]));
            
            line = reader.ReadLine();
            if (null == line) return; 
            //Allow for crlf at end
            string[] xatvalues = line.Split( new char[]{ '\t' } );
            this.XAxisTitles = new string[xatvalues.Length-1] ;
            Array.Copy(xatvalues, 0, this.XAxisTitles, 0, this.XAxisTitles.Length);

            while ((line = reader.ReadLine()) != null) {
                ChartLine cl = new ChartLine() ;
                cl.LoadData(line);
                this.Lines.Add(cl);
            }

        }

        public void SaveData(TextWriter writer) {
            TypeConverter converter ;

            converter = TypeDescriptor.GetConverter(typeof(float));
            string yMinString = converter.ConvertToString(this.YMin);
            string yMaxString = converter.ConvertToString(this.YMax);
            string yTickSizeString = converter.ConvertToString(this.YTickSize);

            converter = TypeDescriptor.GetConverter(typeof(Color));
            string gridColorString = converter.ConvertToString(this.GridColor);

            converter = TypeDescriptor.GetConverter(typeof(bool));
            string showHGridLinesString = converter.ConvertToString(this.ShowHGridLines);
            string showVGridLinesString = converter.ConvertToString(this.ShowVGridLines);

            writer.Write(yMinString);
            writer.Write("\t");
            writer.Write(yMaxString);
            writer.Write("\t");
            writer.Write(yTickSizeString);
            writer.Write("\t");
            writer.Write(gridColorString);
            writer.Write("\t");
            writer.Write(showHGridLinesString);
            writer.Write("\t");
            writer.WriteLine(showVGridLinesString);
            foreach(string xat in this.XAxisTitles) {
                writer.Write(xat);
                writer.Write("\t");
            }
            writer.WriteLine("");

            foreach(ChartLine cl in this.Lines) {
                cl.SaveData(writer);
            }

        }

        //Collection of Chart Lines
        public class ChartLineList : TypedCollectionBase {
            public ChartLine this[int index] {
                get {
                    return (ChartLine)(List[index]);
                }
                set {
                    List[index] = value;
                }
            }

            public int Add(ChartLine value) {
                return List.Add(value);
            }

            public void Insert(int index, ChartLine value) {
                List.Insert(index, value);
            }

            public int IndexOf(ChartLine value) {
                return List.IndexOf(value);
            }

            public bool Contains(ChartLine value) {
                return List.Contains(value);
            }

            public void Remove(ChartLine value) {
                List.Remove(value);
            }

            public void CopyTo(ChartLine[] array, int index) {
                List.CopyTo(array, index);
            }

        }


    }



    //Charting Engine - draws a chart based on the given ChartData
    public class ChartEngine {

        private ChartData chartData ;

        private float left ;
        private float right ;
        private float top ;
        private float bottom ;

        private float tickCount ;
        private float yCount ;   //Number of horizintal (y-axis) plot points
        private float hspacing ;
        private float vspacing ;

        private Graphics g ;
        private Rectangle r;
        private Color backColor;
        private Color foreColor;
        private Font baseFont;
        private Font legendFont;
        private RectangleF legendRect;

        public ChartEngine() {
        }                           


        public void DrawChart(Graphics g, Rectangle r, Color backColor, Color foreColor, Font baseFont, ChartData chartData) {

            this.chartData = chartData;
            this.g = g;
            this.r = r;
            this.backColor = backColor;
            this.foreColor = foreColor;
            this.baseFont = baseFont;
            this.legendFont = new Font(baseFont.FontFamily, (baseFont.Size * 2/3), baseFont.Style | FontStyle.Bold);


            g.SmoothingMode = SmoothingMode.AntiAlias;

            CalculateChartDimensions();
            
            DrawBackground();
            InternalDrawChart() ;
        }

        private void CalculateChartDimensions() {

            right = r.Width - 5;
            top = 5 * baseFont.Size ;
            bottom = r.Height - baseFont.Size * 2;

            tickCount = chartData.YMin ;
            yCount = (chartData.YMax-chartData.YMin) / chartData.YTickSize ;
            hspacing = (bottom-top) / yCount ;
            vspacing = (right) / chartData.XAxisTitles.Length ;


            //Left depends on width of text - for simplicities sake assume that largest yvalue is the biggest
            //Take into account the first X Axis title
            float maxYTextSize = g.MeasureString(chartData.YMax.ToString(), baseFont).Width;
            float firstXTitle = g.MeasureString(chartData.XAxisTitles[0], baseFont).Width;

            left = (maxYTextSize > firstXTitle) ? maxYTextSize : firstXTitle ;
            left = r.X + left + 5 ;

            //Calculate size of legend box 

            float maxLegendWidth = 0 ;
            float maxLegendHeight = 0 ;

            //Work out size of biggest legend 
            foreach (ChartLine cl in chartData.Lines) {
                float currentWidth = g.MeasureString(cl.Title, legendFont).Width;
                float currentHeight = g.MeasureString(cl.Title, legendFont).Height;
                maxLegendWidth = (maxLegendWidth > currentWidth) ? maxLegendWidth : currentWidth ;
                maxLegendHeight = (maxLegendHeight > currentHeight) ? maxLegendHeight : currentHeight ;
            }

            legendRect = new RectangleF(r.X+2, r.Y+2, maxLegendWidth + 25 + 5, ((maxLegendHeight+2)*chartData.Lines.Count) + 3) ;
        }

        private void DrawBackground() {
            LinearGradientBrush b = new LinearGradientBrush(r, Color.SteelBlue, backColor,LinearGradientMode.Horizontal);
            g.FillRectangle(b, r);
            b.Dispose();
        }

        private void InternalDrawChart() {

            DrawGrid() ;

            foreach (ChartLine cl in chartData.Lines) {
                DrawLine(cl);
            }

            DrawLegend() ;

            //Draw time on chart
            string timeString = DateTime.ToString(DateTime.Now) ;
            SizeF textsize = g.MeasureString(timeString,baseFont);
            g.DrawString(timeString, baseFont, new SolidBrush(foreColor), r.Width - textsize.Width - 5, textsize.Height * 2 / 3) ;
        }                       

        private  void DrawGrid() {

            Pen gridPen = new Pen(chartData.GridColor) ;

            //Vertical - include tick desc's
            if (chartData.ShowVGridLines) {
                for (int i = 0 ; (i < chartData.XAxisTitles.Length) && (vspacing * i) < right; i++) {
                    float x = left + (vspacing *i);           
                    string desc = chartData.XAxisTitles[i];
                    g.DrawLine(gridPen, x,top,x,bottom +(baseFont.Size*1/3));
                    SizeF textsize = g.MeasureString(desc,baseFont);
                    g.DrawString(desc, baseFont, new SolidBrush(chartData.GridColor), x-(textsize.Width/2), bottom + (baseFont.Size*2/3)) ;
                }
            }

            //Horizontal
            if (chartData.ShowHGridLines) {
                for (float i = bottom ; i > top; i-=hspacing) {
                    string desc = tickCount.ToString();
                    tickCount+=chartData.YTickSize;
                    g.DrawLine(gridPen, right, i, left-3, i);
                    SizeF textsize = g.MeasureString(desc,baseFont);
                    g.DrawString(desc, baseFont, new SolidBrush(chartData.GridColor), left-textsize.Width - 3, i - (textsize.Height/2)) ;
                }
            }

        }

        private  void DrawLine(ChartLine chartLine) {

            Pen linePen = new Pen(Color.FromARGB(120, chartLine.Color));
            linePen.StartCap = LineCap.Round;
            linePen.EndCap = LineCap.Round;
            linePen.Width = chartLine.Width ;
            linePen.DashStyle = chartLine.LineStyle;

            PointF[] Values = new PointF[chartLine.Values.Length];
            float scale = hspacing / chartData.YTickSize ;

            for (int i = 0 ; i < chartLine.Values.Length; i++) {
                float x = left + vspacing * i;           
                Values[i] = new PointF(x, bottom-chartLine.Values[i]*scale);
            }

            g.DrawLines(linePen, Values);
        } 

        private void DrawLegend() {

            //Draw Legend Box 
            ControlPaint.DrawBorder(g, (Rectangle)legendRect, SystemColors.WindowFrame, ButtonBorderStyle.Solid);
            LinearGradientBrush b = new LinearGradientBrush(legendRect, backColor, Color.SteelBlue, LinearGradientMode.Horizontal);
            r.Inflate(-1, -1);
            g.FillRectangle(b, legendRect);
            b.Dispose();

            float startY = 5; 

            foreach (ChartLine cl in chartData.Lines) {
                Pen p = new Pen(cl.Color) ;
                p.Width = p.Width*4;
                SizeF textsize = g.MeasureString(cl.Title, legendFont);
                float lineY = startY + textsize.Height / 2 ;
                g.DrawLine(p, r.X + 7, lineY, r.X + 25, lineY);
                g.DrawString(cl.Title, legendFont, new SolidBrush(foreColor), r.X + 30, startY);
                startY += (textsize.Height+2);
            }

        }

    }

}



