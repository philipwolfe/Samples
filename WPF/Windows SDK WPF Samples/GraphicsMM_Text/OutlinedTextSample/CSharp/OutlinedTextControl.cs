using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    // The OutlinedText object allows you to create and display the geometry of a text string's outline.
    public class OutlinedText : FrameworkElement
    {
        // Class variables
        private FormattedText _formattedText;

        // Property variables
        private Brush       _fill;
        private FontFamily  _fontFamily;
        private double      _fontSize;
        private FontStretch _fontStretch;
        private FontStyle   _fontStyle;
        private FontWeight  _fontWeight;
        private bool        _highlight;
        private Brush       _stroke;
        private double      _strokeThickness;
        private String      _textContent;
        private Geometry    _textGeometry;
        private Geometry    _textHighLightGeometry;

        public OutlinedText(string textContent)
        {
            // Set the default property values.
            _fontFamily = new FontFamily("Verdana");
            _fontStretch = FontStretches.Normal;
            _fontWeight = FontWeights.Bold;
            _fontStyle = FontStyles.Normal;
            _fontSize = 72;
            _textContent = textContent;
            _stroke = Brushes.Black;
            _strokeThickness = 1;
            _fill = Brushes.Transparent;
        }

        // Create the outline geometry based on the formatted text.
        public void CreateText()
        {
            // Create the formatted text based on the properties set.
            _formattedText = new FormattedText(
                _textContent,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(_fontFamily, _fontStyle, _fontWeight, _fontStretch),
                _fontSize,
                Brushes.Black // This brush does not matter since we use the geometry of the text. 
                );

            // Build the geometry object that represents the text.
            _textGeometry = _formattedText.BuildGeometry(new Point(0, 0));

            // Build the geometry object that represents the text hightlight.
            if (_highlight == true)
            {
                _textHighLightGeometry = _formattedText.BuildHighlightGeometry(new Point(0, 0));
            }
        }

        // The OnRender override method allows you to draw directly into
        // the DrawingContext of the outlined text control.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Draw the outline based on the properties that are set.
            drawingContext.DrawGeometry(_fill, new Pen(_stroke, _strokeThickness), _textGeometry);

            // Draw the text highlight based on the properties that are set.
            if (_highlight == true)
            {
                drawingContext.DrawGeometry(_fill, new Pen(_stroke, _strokeThickness), _textHighLightGeometry);
            }
        }

        // The ArrangeOverride and MeasureOverride methods provide layout support for the control.
        //  - ArrangeOverride: Positions the object and determines size. 
        //  - MeasureOverride: Measures and determines the size in layout required for the object.

        // No calculation required -- return the value of the parameter.
        protected override Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
        }

        // Return the size of the formatted text.
        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(_formattedText.Width, _formattedText.Height);
        }

        // Definitions for the outlined text control properties.
        public Brush Fill
        {
            get { return _fill; }
            set { _fill = value; }
        }
        public string FontFamily
        {
            get { return _fontFamily.ToString(); }
            set { _fontFamily = new FontFamily(value); }
        }
        public double FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
        public FontStretch FontStretch
        {
            get { return _fontStretch; }
            set { _fontStretch = value; }
        }
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }
        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set { _fontWeight = value; }
        }
        public bool Highlight
        {
            get { return _highlight; }
            set { _highlight = value; }
        }
        public Brush Stroke
        {
            get { return _stroke; }
            set { _stroke = value; }
        }
        public double StrokeThickness
        {
            get { return _strokeThickness; }
            set { _strokeThickness = value; }
        }
        public String TextContent
        {
            get { return _textContent; }
            set { _textContent = value; }
        }

        // The TextGeometry property allows you to get and set the geometry of the outlined text.
        // The returned value can be used to clip images, video, etc.
        public Geometry TextGeometry
        {
            get
            {
                CreateText();
                return _textGeometry;
            }
            set { _textGeometry = value; }
        }
    }
}
