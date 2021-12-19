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
namespace Microsoft.Samples.WinForms.Cs.HelpLabel {
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.WinForms;
    using System.WinForms.Design;
    
    //
    // <doc>
    // <desc>
    // Help Label offers an extender property called
    // "HelpText".  It monitors the active control
    // and displays the help text for the active control.
    // </desc>
    // </doc>
    //
    [
    ProvideProperty("HelpText"),
    Designer(typeof(HelpLabel.HelpLabelDesigner))
    ]
    public class HelpLabel : RichControl, IExtenderProvider {
        private Hashtable helpTexts;
        private Control activeControl;
        
        //
        // <doc>
        // <desc>
        //      Creates a new help label object.
        // </desc>
        // </doc>
        //
        public HelpLabel() {
            helpTexts = new Hashtable();
            BackColor = SystemColors.Info;
            ForeColor = SystemColors.InfoText;
            TabStop = false;
        }
        
        //
        // <doc>
        // <desc>
        //      Overrides the default tab stop property.  Here, we just
        //      change the default value to be false.
        // </desc>
        // </doc>
        //
        [
        DefaultValue(false)
        ]
        public bool TabStop {
            override get {
                return base.TabStop;
            }
            override set {
                base.TabStop = value;
            }
        }
        
        //
        // <doc>
        // <desc>
        //      Overrides the text property of RichControl.  This label ignores
        //      the text property, so we add additional attributes here so the
        //      property does not show up in the property browser and is not
        //      persisted.
        // </desc>
        // </doc>
        //
        [
        Browsable(false),
        Persistable(PersistableSupport.None)
        ]
        public string Text {
            override get {
                return base.Text;
            }
            override set {
                base.Text = value;
            }
        }

        //
        // <doc>
        // <desc>
        //      This implements the IExtenderProvider.CanExtend method.  The
        //      help label provides an extender property, and the design time
        //      framework will call this method once for each component to determine
        //      if we are interested in providing our extended properties for the
        //      component.  We return true here if the object is a control and is
        //      not a HelpLabel (since it would be silly to add this property to
        //      ourselves).
        // </desc>
        // </doc>
        //
        bool IExtenderProvider.CanExtend(object target) {
            if (target is Control &&
                !(target is HelpLabel)) {

                return true;
            }
            return false;
        }
        
        //
        // <doc>
        // <desc>
        //      This is the extended property for the HelpText property.  Extended
        //      properties are actual methods because they take an additional parameter
        //      that is the object or control to provide the property for.
        // </desc>
        // </doc>
        //
        [
        DefaultValue(""),
        ExtenderProperty(typeof(Control))
        ]
        public string GetHelpText(Control control) {
            string text = (string)helpTexts[control];
            if (text == null) {
                text = string.Empty;
            }
            return text;
        }
        
        //
        // <doc>
        // <desc>
        //      This is an event handler that responds to the OnControlEnter
        //      event.  We attach this to each control we are providing help
        //      text for.
        // </desc>
        // </doc>
        //
        private void OnControlEnter(object sender, EventArgs e) {
            activeControl = (Control)sender;
            Invalidate();
        }
        
        //
        // <doc>
        // <desc>
        //      This is an event handler that responds to the OnControlLeave
        //      event.  We attach this to each control we are providing help
        //      text for.
        // </desc>
        // </doc>
        //
        private void OnControlLeave(object sender, EventArgs e) {
            if (sender == activeControl) {
                activeControl = null;
                Invalidate();
            }
        }
        
        //
        // <doc>
        // <desc>
        //      This is the extended property for the HelpText property.  
        // </desc>
        // </doc>
        //
        public void SetHelpText(Control control, string value) {
            if (value == null) {
                value = string.Empty;
            }
            
            if (value.Length == 0) {
                helpTexts.Remove(control);
            
                control.Enter -= new EventHandler(OnControlEnter);
                control.Leave -= new EventHandler(OnControlLeave);
            }
            else {
                helpTexts[control] = value;
                
                control.Enter += new EventHandler(OnControlEnter);
                control.Leave += new EventHandler(OnControlLeave);
            }
            
            if (control == activeControl) {
                Invalidate();
            }
        }
        
        //
        // <doc>
        // <desc>
        //      Overrides RichControl.OnPaint.  Here we draw our
        //      label.
        // </desc>
        // </doc>
        //
        protected override void OnPaint(PaintEventArgs pe) {
        
            // Let the base draw.  This will cover our back
            // color and set any image that the user may have
            // provided.
            //
            base.OnPaint(pe);
        
            // Draw a rectangle around our control.
            //
            Rectangle rect = ClientRectangle;
            
            Pen borderPen = new Pen(ForeColor);
            pe.Graphics.DrawRectangle(borderPen, rect);
            borderPen.Dispose();
            
            // Finally, draw the text over the top of the
            // rectangle.
            //
            if (activeControl != null) {
                string text = (string)helpTexts[activeControl];
                if (text != null && text.Length > 0) {
                    rect.Inflate(-2, -2);
                    Brush brush = new SolidBrush(ForeColor);
                    pe.Graphics.DrawString(text, Font, brush, rect);
                    brush.Dispose();
                }
            }
        }
        
        // <doc>
        // <desc>
        //     Returns true if the backColor should be persisted in code gen.  We
        //      override this because we change the default back color.
        // </desc>
        // <retvalue>
        //     true if the backColor should be persisted.
        // </retvalue>
        // </doc>
        //
        public override bool ShouldPersistBackColor() {
            return(!BackColor.Equals(SystemColors.Info));
        }

        // <doc>
        // <desc>
        //     Returns true if the foreColor should be persisted in code gen.  We
        //      override this because we change the default foreground color.
        // </desc>
        // <retvalue>
        //     true if the foreColor should be persisted.
        // </retvalue>
        // </doc>
        //
        public override bool ShouldPersistForeColor() {
            return(!ForeColor.Equals(SystemColors.InfoText));
        }
        
        //
        // <doc>
        // <desc>
        //      This is a designer for the HelpLabel.  This designer provides
        //      design time feedback for the label.  The help label responds
        //      to changes in the active control, but these events do not
        //      occur at design time.  In order to provide some usable feedback
        //      that the control is working the right way, this designer listens
        //      to selection change events and uses those events to trigger active
        //      control changes.
        // </desc>
        // </doc>
        //
        public class HelpLabelDesigner : RichControlDesigner {
        
            //
            // <doc>
            // <desc>
            //      Overrides Dispose.  Here we remove our handler for the selection changed
            //      event.  With designers, it is critical that they clean up any events they
            //      have attached.  Otherwise, during the course of an editing session many
            //      designers may get created and never destroyed.
            // </desc>
            // </doc>
            //
            public override void Dispose() {
                base.Dispose();
            
                ISelectionService ss = (ISelectionService)GetServiceObject(typeof(ISelectionService));
                if (ss != null) {
                    ss.SelectionChanged -= new EventHandler(OnSelectionChanged);
                }
            }
        
            //
            // <doc>
            // <desc>
            //       Overrides initialize.  Here we add an event handler to the selection service.
            //      Notice that we are very careful not to assume that the selection service is
            //      available.  It is entirely optional that a service is available and you should
            //      always degrade gracefully if a service could not be found.
            // </desc>
            // </doc>
            //
            public override void Initialize(IComponent component) {
                base.Initialize(component);
                
                ISelectionService ss = (ISelectionService)GetServiceObject(typeof(ISelectionService));
                if (ss != null) {
                    ss.SelectionChanged += new EventHandler(OnSelectionChanged);
                }
            }
            
            //
            // <doc>
            // <desc>
            //      Our handler for the selection change event.  Here we update the active control within
            //      the help label.
            // </desc>
            // </doc>
            //
            private void OnSelectionChanged(object sender, EventArgs e) {
            
                ISelectionService ss = (ISelectionService)sender;
                object c = ss.GetPrimarySelection();
                if (c is Control) {
                    HelpLabel helpLabel = (HelpLabel)Component;
                    helpLabel.activeControl = (Control)c;
                    helpLabel.Invalidate();
                }
            }
        }
    }
}
