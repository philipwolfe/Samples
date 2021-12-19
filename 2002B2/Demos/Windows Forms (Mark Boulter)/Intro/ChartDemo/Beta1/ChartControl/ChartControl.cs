namespace Charting {
    using System;
    using System.WinForms;
    using System.Drawing;
    using ChartEngine;

    public class ChartControl : RichControl {

        private ChartData chartData ;
        private ChartEngine che = new ChartEngine() ;

        public ChartControl() {
            SetStyle(ControlStyles.ResizeRedraw, true);
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


