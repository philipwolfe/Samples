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
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    /// <summary>
    ///    <para>
    ///       The shape that is used to represent an alarm on the clock face.
    ///    </para>
    /// </summary>
    [
    Editor(typeof(AlarmTimeShapeEditor), typeof(UITypeEditor))
    ]
    public enum AlarmTimeShape {
        Arrow = LineCap.ArrowAnchor,
        Diamond = LineCap.DiamondAnchor,
        Circle = LineCap.RoundAnchor,
        Square = LineCap.SquareAnchor
    }
}
