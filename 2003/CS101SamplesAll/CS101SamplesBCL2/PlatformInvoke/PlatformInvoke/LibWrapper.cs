using System;
using System.Runtime.InteropServices;

namespace PlatformInvoke
{
    //  Stucture on the DLL
    // typedef struct _MYPOINT
    // {
    // 	int x; 
    // 	int y; 
    // } MYPOINT;
    [StructLayout(LayoutKind.Sequential)]
    public struct MyPoint
    {
        public int x;
        public int y;

        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //  Stucture on the DLL
    // typedef struct _MYRECTANGLE
    // {
    // 	MYPOINT myPoints[2]; // 0 = TopLeft, 1 = BottomRight
    // } MYRECTANGLE;
    [StructLayout(LayoutKind.Sequential)]
    public struct MyRectangle
    {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public MyPoint[] MyPoints;

        public MyRectangle(MyPoint topLeft, MyPoint bottomRight)
        {
            MyPoints = new MyPoint[2];

            MyPoints[0] = new MyPoint(topLeft.x, topLeft.y);
            MyPoints[1] = new MyPoint(bottomRight.x, bottomRight.y);
        }
    }
    //  Declaration on the DLL
    // typedef void (CALLBACK *FPTR)(int i);
    public delegate void FPtr(int value);

    class LibWrapper
    {
        //  int GetRectangleArea(MYRECTANGLE* pStruct)
        [DllImport("..\\..\\PinvokeLib.dll")]
        public static extern int GetRectangleArea(ref MyRectangle rectangle);

        // void TestCallBack(FPtr pf, MYRECTANGLE* pStruct)
        [DllImport("..\\..\\PinvokeLib.dll")]
        public static extern void GetRectangleAreaCallBack(FPtr cb, ref MyRectangle rectangle);

    }
}
