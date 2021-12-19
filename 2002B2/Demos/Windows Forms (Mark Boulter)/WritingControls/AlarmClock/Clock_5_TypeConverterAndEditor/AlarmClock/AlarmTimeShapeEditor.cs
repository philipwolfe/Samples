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
namespace MyCompany.Controls {
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;
    using System.Drawing.Design;
    using System.Collections;

    /// <summary>
    ///    <para>
    ///       A custom Type Editor for AlarmTimeShape.  This editor allows us
    ///       to draw a visual representation of the shape in the property grid
    ///       drop-down boxes, rather than just show the enum value name.
    ///       Note that even though this class is internal, the property
    ///       grid can still create an instance of it.  This is possible because
    ///       the property grid is signed with a "reflection" permission that
    ///       allows for private reflection.
    ///    </para>
    /// </summary>
    internal sealed class AlarmTimeShapeEditor : UITypeEditor {

        private IWindowsFormsEditorService edSvc = null;
        private TypeConverter enumConverter ;

        /// <summary>
        ///    <para>
        ///         Creates a list box to show in the property grid.
        ///    </para>
        /// </summary>
        private ListBox CreateListBox(ITypeDescriptorContext context, object value) {
            ShapeEditorListBox listBox = new ShapeEditorListBox(this);
            listBox.Click += new EventHandler(this.OnListClick);
            FillValues(listBox, context, (AlarmTimeShape)value);
            return listBox;
        }
        
        /// <summary>
        ///    <para>
        ///         This is an override from UITypeEditor.  The property grid will call this when
        ///         it wants to display the editor for the given value.
        ///    </para>
        /// </summary>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {

            if (context != null && context.Instance != null && provider != null) {

                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                enumConverter = context.PropertyDescriptor.Converter;

                if (edSvc != null && enumConverter != null) {
                    ListBox possibleValues = CreateListBox(context, value);
                    edSvc.DropDownControl(possibleValues);
                    value = ((AlarmTimeShapeListItem)(possibleValues.SelectedItem)).value;
                }
            }

            return value;
        }

        /// <summary>
        ///    <para>
        ///         Private function to fill the contents of our list box.
        ///    </para>
        /// </summary>
        private void FillValues(ListBox listBox, ITypeDescriptorContext context, AlarmTimeShape value) {
            
            ICollection possibleValues = enumConverter.GetStandardValues(context);
            if (possibleValues != null) {
            
                foreach (AlarmTimeShape possibleValue in possibleValues) {
                    AlarmTimeShapeListItem listItem =  new AlarmTimeShapeListItem( 
                        enumConverter.ConvertToString(context,possibleValue)
                        , ((AlarmTime)(context.Instance)).Color
                        , possibleValue);

                    int index = listBox.Items.Add(listItem);
                    if (value == possibleValue) {
                        listBox.SelectedIndex = index;
                    }
                }
            }
        }

        /// <summary>
        ///    <para>
        ///         This is an override from UITypeEditor.  The editor style indicates what
        ///         type of editor we are providing:  we can either display a dialog or a
        ///         drop-down box.  Our editor always shows a drop-down box.
        ///    </para>
        /// </summary>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            if (context != null && context.Instance != null) {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        /// <summary>
        ///    <para>
        ///         This is an override from UITypeEditor and indicates if we support 
        ///         painting a small representation of our value in the property grid.
        ///    </para>
        /// </summary>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context) {
            return true;
        }

        /// <summary>
        ///    <para>
        ///         Called when the user clicks something in the list box.  We close
        ///         the drop down at this time.
        ///    </para>
        /// </summary>
        private void OnListClick(object sender, EventArgs e) {
            if (edSvc != null) {
                edSvc.CloseDropDown();
            }
        }
        
        /// <summary>
        ///    <para>
        ///         This is an override from UITypeEditor.  The property grid will call this when
        ///         it wants us to paint a small glyph depicting the value.
        ///    </para>
        /// </summary>
        public override void PaintValue(PaintValueEventArgs e) {
            // The value passed to us is the value of the AlarmTimeShape enum.  We need more information
            // from the AlarmTime object itself, however, so we retrieve it from the context's "Instance"
            // property.
            if (e.Context != null && e.Context.Instance != null) {
                AlarmTime at = (AlarmTime)e.Context.Instance;
                PaintValue((AlarmTimeShape)e.Value, at.Color, e.Graphics, e.Bounds);
            }
        }

        /// <summary>
        ///    <para>
        ///         This actual paints the given value.  It is used both by the PaintValue method and by
        ///         the list box.
        ///    </para>
        /// </summary>
        internal void PaintValue(AlarmTimeShape value, Color color, Graphics graphics, Rectangle rectangle) {
            Pen pen = new Pen(color);
            pen.Width=2;
            pen.EndCap=(LineCap)value;
            float yPos = rectangle.Y + rectangle.Height/2;
            float xStartPos = rectangle.X + 2;
            float xEndPos = rectangle.X + rectangle.Width - 2;

            //End caps extend past the end of the line - but by how much?
            if (value != AlarmTimeShape.Square) {
                xEndPos = xEndPos - (pen.Width*2) ;
            }

            graphics.DrawLine(pen, xStartPos, yPos, xEndPos , yPos);
            pen.Dispose();
        }

        /// <summary>
        ///    <para>
        ///         This class is used to hold information about shape enum values in the list box.
        ///    </para>
        /// </summary>
        private struct AlarmTimeShapeListItem {
            internal AlarmTimeShape value;
            internal Color color;
            internal string name;

            internal AlarmTimeShapeListItem(string name, Color color, AlarmTimeShape value) {
                this.value=value;
                this.color=color;
                this.name=name;
            }
        }

        /// <summary>
        ///    <para>
        ///         Owner draw list box displays shapes in the list box
        ///    </para>
        /// </summary>
        private class ShapeEditorListBox : ListBox {

            AlarmTimeShapeEditor editor ;

            internal ShapeEditorListBox(AlarmTimeShapeEditor editor) {
                this.editor = editor;
                this.Visible = true;
                this.IntegralHeight = false;
                this.DrawMode = DrawMode.OwnerDrawFixed;
                this.BorderStyle = BorderStyle.None;
            }

            /// <summary>
            ///    <para>
            ///         We override this from Control so we can designate
            ///         that the return key should be used for input.  In
            ///         other words, we want return to come to us, not be
            ///         treated as the "OK" to dismiss a dialog.
            ///    </para>
            /// </summary>
            protected override bool IsInputKey(System.Windows.Forms.Keys keyData) {
                if (keyData == Keys.Return) {
                    return true;
                }

                return base.IsInputKey(keyData);
            }

            /// <summary>
            ///    <para>
            ///         We handle keyboard processing here for the return
            ///         key.  We treat this key like a click on the list
            ///         box.
            ///    </para>
            /// </summary>
            protected override void OnKeyDown(KeyEventArgs e) {
                if (e.KeyCode == Keys.Return) {
                    OnClick(EventArgs.Empty);
                } 
                else {
                    base.OnKeyDown(e);
                }

            }

            /// <summary>
            ///    <para>
            ///         This override paints our individual item.
            ///    </para>
            /// </summary>
            protected override void OnDrawItem(DrawItemEventArgs die) {
                AlarmTimeShapeListItem listItem = (AlarmTimeShapeListItem)(this.Items[die.Index]);
                
                // Draw the normal listbox background.
                die.DrawBackground();
                
                // Now draw the glyph for this item as well as a text string that describes
                // it.
                editor.PaintValue(listItem.value, listItem.color, die.Graphics, new Rectangle(die.Bounds.X + 2, die.Bounds.Y + 2, 22, die.Bounds.Height - 4));
                die.Graphics.DrawRectangle(SystemPens.WindowText, new Rectangle(die.Bounds.X + 2, die.Bounds.Y + 2, 22, die.Bounds.Height - 4));
                die.Graphics.DrawString(listItem.name, this.Font, new SolidBrush(die.ForeColor), die.Bounds.X + 26, die.Bounds.Y);
            }
        }            
    }
}

