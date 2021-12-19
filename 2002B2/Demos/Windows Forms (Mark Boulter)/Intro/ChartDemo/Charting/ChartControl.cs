namespace Charting {
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using ChartEngine;

    public class ChartControl : Control {

        private ChartData chartData ;
        private ChartEngine che = new ChartEngine() ;

        public ChartControl() {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            //Dummy data
            chartData = new ChartData();
            chartData.YTickSize = 10 ;
            chartData.YMax = 20 ;
            chartData.YMin = 0;
            chartData.XAxisTitles = new string[]{ "Test1", "Test2" };
        }                           

        protected override void OnPaint(PaintEventArgs paintevent) {
            PaintControl(paintevent);
            base.OnPaint(paintevent);
        }

        private void PaintControl(PaintEventArgs paintevent) {
            Rectangle r = ClientRectangle;
            DrawDefaultBorder(paintevent.Graphics, ref r);
            DrawChart(paintevent.Graphics, r);
        }

        protected void DrawChart(Graphics g, Rectangle r) {
            che.DrawChart(g, r, BackColor, ForeColor, Font, this.chartData) ;
        }

        protected void DrawDefaultBorder(Graphics g, ref Rectangle r) {
            ControlPaint.DrawBorder(g, r, SystemColors.WindowFrame, ButtonBorderStyle.Solid);
            r.Inflate(-1, -1);
        }

        public ChartData ChartData { 
            get { return chartData ; }
            set { chartData = value ; }
        }
    
    }

}


