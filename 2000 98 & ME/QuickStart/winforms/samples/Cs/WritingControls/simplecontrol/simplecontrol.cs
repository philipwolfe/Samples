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
namespace Microsoft.Samples.WinForms.Cs.SimpleControl {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Drawing;


    [
    DefaultProperty("DrawingMode"),
    DefaultEvent("DrawingModeChanged"),
    ]
    public class SimpleControl : RichControl {

        private DrawingMode drawingMode ;
        private EventHandler onDrawingModeChanged; 

        //*** Constructors

        public SimpleControl() :base() {
            
            //Initialise drawingMode
            drawingMode = DrawingMode.Happy;
            
            //Initialise BackColor and ForeColor based on DrawingMode
            SetColors();

            //Make sure the control repaints as it is resized
            SetStyle(ControlStyles.ResizeRedraw, true);
        }


        //*** Properties

        //Remove the BackColor property from the property browser
        [Browsable(false)]
        public Color BackColor { 
            override get {return base.BackColor;}  
            override set {} 
        }


        //DrawingMode - controls how the control paints
        [
            Category("Appearance"),
            Description("Controls how the control paints"),
            DefaultValue(DrawingMode.Happy),
            Bindable(true),
        ]
        public DrawingMode DrawingMode {
            get { return drawingMode;}
            set { 
                drawingMode=value;

                //Set BackColor and ForeColor based on DrawingMode
                SetColors();

                //Raise property changed event for DrawingMode
                RaisePropertyChangedEvent("DrawingMode");
            }
        }


        //Remove the ForeColor property from the property browser
        [Browsable(false)]
        public Color ForeColor  { 
            override get {return base.ForeColor;}  
            override set {} 
        }


        //*** Events

        //Handle the paint event
        protected override void OnPaint(PaintEventArgs e) {

            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            Size textSize = (Size) e.Graphics.MeasureString(Text, Font);

            float xPos = (ClientRectangle.Width/2) - (textSize.Width/2);
            float yPos = (ClientRectangle.Height/2) - (textSize.Height/2);

            e.Graphics.DrawString(Text, 
                                  Font, 
                                  new SolidBrush(ForeColor), 
                                  xPos, yPos);

        }


        //Catch property changed event for DrawingMode to fire DrawingMode changed 
        //and repaint the control
        protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
            base.OnPropertyChanged(e);
            string d = e.PropertyName;

            if (d.Equals("DrawingMode")) {
                OnDrawingModeChanged(EventArgs.Empty);
            }
        }

        //DrawingModeChanged Event
        [Description("Raised when the DrawingMode changes")]
        public event EventHandler DrawingModeChanged {
            get {
                return onDrawingModeChanged;
            }
            set {
                onDrawingModeChanged = value;
            }
        }

        protected virtual void OnDrawingModeChanged(EventArgs e) {
            Invalidate();
            if (onDrawingModeChanged != null) onDrawingModeChanged.Invoke(this, e);
        }


        //Set the ForeColor and BackColor based on the value of DrawingMode
        private void SetColors() {

            switch (drawingMode) {

               case DrawingMode.Happy:
                   base.BackColor = Color.Yellow ;
                   base.ForeColor = Color.Green ;
                   break ;

               case DrawingMode.Sad:
                   base.BackColor = Color.LightSlateGray ;
                   base.ForeColor = Color.White ;
                   break ;

              case DrawingMode.Angry:
                  base.BackColor = Color.Red ;
                  base.ForeColor = Color.Teal ;
                  break ;

               default:
                   base.BackColor = Color.Black ;
                   base.ForeColor = Color.White ;
           }

        }

        
    }
}
