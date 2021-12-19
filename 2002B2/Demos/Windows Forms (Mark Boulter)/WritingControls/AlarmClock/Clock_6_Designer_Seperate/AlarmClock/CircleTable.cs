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
    using System.Drawing;
       
    /// <summary>
    ///    <para>
    ///      Table of values used to paint the clock
    ///    </para>
    /// </summary>
    internal class CircleTable { 
         
         public static int SCALE = 8000;

         private static Point[] circleTable = {
             new Point(0, -7999),        new Point(836, -7956),
             new Point(1663, -7825),     new Point(2472, -7608),
             new Point(3253, -7308),     new Point(3999, -6928),
             new Point(4702, -6472),     new Point(5353, -5945),
             new Point(5945, -5353),     new Point(6472, -4702),
             new Point(6928, -4000),     new Point(7308, -3253),
             new Point(7608, -2472),     new Point(7825, -1663),
             new Point(7956, -836),      new Point(8000, 0),
             new Point(7956, 836),       new Point(7825, 1663),
             new Point(7608, 2472),      new Point(7308, 3253),
             new Point(6928, 4000),      new Point(6472, 4702),
             new Point(5945, 5353),      new Point(5353, 5945),
             new Point(4702, 6472),      new Point(3999, 6928),
             new Point(3253, 7308),      new Point(2472, 7608),
             new Point(1663, 7825),      new Point(836, 7956),
             new Point(0, 7999),         new Point(-836, 7956),
             new Point(-1663, 7825),     new Point(-2472, 7608),
             new Point(-3253, 7308),     new Point(-4000, 6928),
             new Point(-4702, 6472),     new Point(-5353, 5945),
             new Point(-5945, 5353),     new Point(-6472, 4702),
             new Point(-6928, 3999),     new Point(-7308, 3253),
             new Point(-7608, 2472),     new Point(-7825, 1663),
             new Point(-7956, 836),      new Point(-7999, 0),
             new Point(-7956, -836),     new Point(-7825, -1663),
             new Point(-7608, -2472),    new Point(-7308, -3253),
             new Point(-6928, -4000),    new Point(-6472, -4702),
             new Point(-5945, -5353),    new Point(-5353, -5945),
             new Point(-4702, -6472),    new Point(-3999, -6928),
             new Point(-3253, -7308),    new Point(-2472, -7608),
             new Point(-1663, -7825),    new Point(-836, -7956)
         };

         public static int NumPoints { 
             get { return circleTable.Length; }
         }

         public static Point GetPoint(int index) { 
             return circleTable[index]; 
         }
   
    }
}
