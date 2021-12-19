//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.FlashTrackBar {
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Design;
    using System.WinForms;
    using System.Diagnostics;

    public class FlashTrackBar : RichControl {
        private const int LeftRightBorder = 10;
        private int value = 0;
        private int min = 0;
        private int max = 100;
        private bool showPercentage = false;
        private bool showValue = false;
        private bool allowUserEdit = true;
        private bool showGradient = true;
        private int dragValue = 0;
        private bool dragging = false;
        private Color startColor = Color.Red;
        private Color endColor = Color.LimeGreen;
        private EventHandler onValueChanged;
        private Brush baseBackground = null;
        private Brush backgroundDim = null;
        private byte darkenBy = 200;


        public FlashTrackBar() {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Debug.Assert(GetStyle(ControlStyles.ResizeRedraw), "Should be redraw!");
            ForeColor = Color.White;
            BackColor = Color.Black;
            Size = new Size(100, 23);
            Text = "FlashTrackBar";
        }

        [
            Category("Flash"),
            DefaultValue(true)
        ]
        public bool AllowUserEdit {
            get {
                return allowUserEdit;
            }
            set {
                if (value != allowUserEdit) {
                    allowUserEdit = value;
                    if (!allowUserEdit) {
                        Capture = false;
                        dragging = false;
                    }
                }
            }
        }

        [
            Category("Flash")
        ]
        public Color EndColor {
            get {
                return endColor;
            }
            set {
                endColor = value;
                if (baseBackground != null && showGradient) {
                    baseBackground.Dispose();
                    baseBackground = null;
                }
                Invalidate();
            }
        }

        public bool ShouldPersistEndColor() {
            return !(endColor == Color.LimeGreen);
        }


        [
            Category("Flash"), 
            Editor(typeof(FlashTrackBarDarkenByEditor), typeof(UITypeEditor)),
            DefaultValue((byte)200)
        ]
        public byte DarkenBy {
            get {
                return darkenBy;
            }
            set {
                if (value != darkenBy) {
                    darkenBy = value;
                    if (backgroundDim != null) {
                        backgroundDim.Dispose();
                        backgroundDim = null;
                    }
                    OptimizedInvalidate(Value, max);
                }
            }
        }
        
        [
            Category("Flash"),
            DefaultValue(100)
        ]
        public int Max {
            get {
                return max;
            }
            set {
                if (max != value) {
                    max = value;
                    Invalidate();
                }
            }
        }

        [
            Category("Flash"),
            DefaultValue(0)
        ]
        public int Min {
            get {
                return min;
            }
            set {
                if (min != value) {
                    min = value;
                    Invalidate();
                }
            }
        }

        [
            Category("Flash")
        ]
        public Color StartColor {
            get {
                return startColor;
            }
            set {
                startColor = value;
                if (baseBackground != null && showGradient) {
                    baseBackground.Dispose();
                    baseBackground = null;
                }
                Invalidate();
            }
        }

        public bool ShouldPersistStartColor() {
            return !(startColor == Color.Red);
        }



        [
            Category("Flash"), 
            RefreshProperties(RefreshProperties.Repaint),
            DefaultValue(false)
        ]
        public bool ShowPercentage {
            get {
                return showPercentage;
            }
            set {
                if (value != showPercentage) {
                    showPercentage = value;
                    if (showPercentage) {
                        showValue = false;
                    }
                    Invalidate();
                }
            }
        }

        [
            Category("Flash"),
            RefreshProperties(RefreshProperties.Repaint),
            DefaultValue(false)
        ]
        public bool ShowValue {
            get {
                return showValue;
            }
            set {
                if (value != showValue) {
                    showValue = value;
                    if (showValue) {
                        showPercentage = false;
                    }
                    Invalidate();
                }
            }
        }

        [
            Category("Flash"),
            DefaultValue(true)
        ]
        public bool ShowGradient {
            get {
                return showGradient;
            }
            set {
                if (value != showGradient) {
                    showGradient = value;
                    if (baseBackground != null) {
                        baseBackground.Dispose();
                        baseBackground = null;
                    }
                    Invalidate();
                }
            }
        }

        [
            Category("Flash"), 
            Editor(typeof(FlashTrackBarValueEditor), typeof(UITypeEditor)),
            DefaultValue(0)
        ]
        public int Value {
            get {
                if (dragging) {
                    return dragValue;
                }
                return value;
            }
            set {
                if (value != this.value) {
                    int old = this.value;
                    this.value = value;
                    OnValueChanged(EventArgs.Empty);
                    OptimizedInvalidate(old, this.value);
                }
            }
        }

        // ValueChanged Event
        [Description("Raised when the Value displayed changes")]
        public event EventHandler ValueChanged {
            get {
                return onValueChanged;
            }
            set {
                onValueChanged = value;
            }
        }

        private void OptimizedInvalidate(int oldValue, int newValue) {
            Rectangle client = ClientRectangle;

            float oldPercentValue = ((float)oldValue / ((float)Max - (float)Min));
            int oldNonDimLength = (int)(oldPercentValue * (float)client.Width);

            float newPercentValue = ((float)newValue / ((float)Max - (float)Min));
            int newNonDimLength = (int)(newPercentValue * (float)client.Width);

            int min = Math.Min(oldNonDimLength, newNonDimLength);
            int max = Math.Max(oldNonDimLength, newNonDimLength);

            Rectangle invalid = new Rectangle(client.X + min, client.Y, max - min, client.Height);
            Invalidate(invalid);

            string oldToDisplay;
            string newToDisplay;

            if (ShowPercentage) {
                oldToDisplay = Convert.ToString((int)(oldPercentValue * 100f)) + "%";
                newToDisplay = Convert.ToString((int)(newPercentValue * 100f)) + "%";
            }
            else if (ShowValue) {
                oldToDisplay = Convert.ToString(oldValue);
                newToDisplay = Convert.ToString(newValue);
            }
            else {
                oldToDisplay = null;
                newToDisplay = null;
            }

            if (oldToDisplay != null && newToDisplay != null) {
                Graphics g = CreateGraphics();
                SizeF oldFontSize = g.MeasureString(oldToDisplay, Font);
                SizeF newFontSize = g.MeasureString(newToDisplay, Font);
                RectangleF oldFontRect = new RectangleF(new PointF(0, 0), oldFontSize);
                RectangleF newFontRect = new RectangleF(new PointF(0, 0), newFontSize);
                oldFontRect.X = (client.Width - oldFontRect.Width) / 2;
                oldFontRect.Y = (client.Height - oldFontRect.Height) / 2;
                newFontRect.X = (client.Width - newFontRect.Width) / 2;
                newFontRect.Y = (client.Height - newFontRect.Height) / 2;

                Invalidate((Rectangle)oldFontRect);
                Invalidate((Rectangle)newFontRect);
            }
        }


        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            if (!allowUserEdit) {
                return;
            }
            Capture = true;
            dragging = true;
            SetDragValue(new Point(e.X, e.Y));
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (!allowUserEdit || !dragging) {
                return;
            }
            SetDragValue(new Point(e.X, e.Y));
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if (!allowUserEdit || !dragging) {
                return;
            }
            Capture = false;
            dragging = false;
            value = dragValue;
            OnValueChanged(EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (baseBackground == null) {
                if (showGradient) {
                    baseBackground = new LinearGradientBrush(new Point(0, 0), 
                                                             new Point(ClientSize.Width, 0),
                                                             StartColor,
                                                             EndColor);
                }
                else if (BackgroundImage != null) {
                    baseBackground = new TextureBrush(BackgroundImage);
                }
                else {
                    baseBackground = new SolidBrush(BackColor);
                }
            }

            if (backgroundDim == null) {
                backgroundDim = new SolidBrush(Color.FromARGB(DarkenBy, Color.Black));
            }

            Rectangle toDim = ClientRectangle;
            float percentValue = ((float)Value / ((float)Max - (float)Min));
            int nonDimLength = (int)(percentValue * (float)toDim.Width);
            toDim.X += nonDimLength;
            toDim.Width -= nonDimLength;


            string text = Text;
            string toDisplay = null;
            RectangleF textRect = new RectangleF();

            if (ShowPercentage || ShowValue || text.Length > 0) {

                if (ShowPercentage) {
                    toDisplay = Convert.ToString((int)(percentValue * 100f)) + "%";
                }
                else if (ShowValue) {
                    toDisplay = Convert.ToString(Value);
                }
                else {
                    toDisplay = text;
                }

                SizeF textSize = e.Graphics.MeasureString(toDisplay, Font);
                textRect.Width = textSize.Width;
                textRect.Height = textSize.Height;
                textRect.X = (ClientRectangle.Width - textRect.Width) / 2;
                textRect.Y = (ClientRectangle.Height - textRect.Height) / 2;
            }

            e.Graphics.FillRectangle(baseBackground, ClientRectangle);
            e.Graphics.FillRectangle(backgroundDim, toDim);
            e.Graphics.Flush();
            if (toDisplay != null && toDisplay.Length > 0) {
                e.Graphics.DrawString(toDisplay, Font, new SolidBrush(ForeColor), textRect);
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
            base.OnPropertyChanged(e);
            if (e.PropertyName == "Text") {
                Invalidate();
            }
            else if (!showGradient) {
                if (e.PropertyName == "BackColor"
                    || e.PropertyName == "BackgroundImage") {

                    if (baseBackground != null) {
                        baseBackground.Dispose();
                        baseBackground = null;
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (baseBackground != null) {
                baseBackground.Dispose();
                baseBackground = null;
            }
        }

        protected virtual void OnValueChanged(EventArgs e) {
            if (onValueChanged != null) {
                onValueChanged.Invoke(this, e);
            }
        }

        private void SetDragValue(Point mouseLocation) {

            Rectangle client = ClientRectangle;

            if (client.Contains(mouseLocation)) {
                float percentage = (float)mouseLocation.X / (float)ClientRectangle.Width;
                int newDragValue = (int)(percentage * (float)(max - min));
                if (newDragValue != dragValue) {
                    int old = dragValue;
                    dragValue = newDragValue;
                    OptimizedInvalidate(old, dragValue);
                }
            }
            else {
                if (client.Y <= mouseLocation.Y && mouseLocation.Y <= client.Y + client.Height) {
                    if (mouseLocation.X <= client.X && mouseLocation.X > client.X - LeftRightBorder) {
                        int newDragValue = min;
                        if (newDragValue != dragValue) {
                            int old = dragValue;
                            dragValue = newDragValue;
                            OptimizedInvalidate(old, dragValue);
                        }
                    }
                    else if (mouseLocation.X >= client.X + client.Width && mouseLocation.X < client.X + client.Width + LeftRightBorder) {
                        int newDragValue = max;
                        if (newDragValue != dragValue) {
                            int old = dragValue;
                            dragValue = newDragValue;
                            OptimizedInvalidate(old, dragValue);
                        }
                    }
                }
                else {
                    if (dragValue != value) {
                        int old = dragValue;
                        dragValue = value;
                        OptimizedInvalidate(old, dragValue);
                    }
                }
            }
        }
    }
}
