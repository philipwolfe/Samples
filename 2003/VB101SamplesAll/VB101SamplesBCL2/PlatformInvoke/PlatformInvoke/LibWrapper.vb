Option Strict On

Imports System
Imports System.Runtime.InteropServices

' Stucture on the DLL
'typedef struct _MYPOINT
'{
'	int x; 
'	int y; 
'} MYPOINT;

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyPoint
    Public x As Integer
    Public y As Integer

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.x = x
        Me.y = y
    End Sub
End Structure

' Stucture on the DLL
'typedef struct _MYRECTANGLE
'{
'	MYPOINT myPoints[2]; // 0 = TopLeft, 1 = BottomRight
'} MYRECTANGLE;

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyRectangle

    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> _
    Public MyPoints As MyPoint()

    Public Sub New(ByVal topLeft As MyPoint, ByVal bottomRight As MyPoint)

        ReDim Preserve MyPoints(2)
        MyPoints(0) = New MyPoint(topLeft.x, topLeft.y)
        MyPoints(1) = New MyPoint(bottomRight.x, bottomRight.y)
    End Sub
End Structure

' Declaration on the DLL
'typedef void (CALLBACK *FPTR)(int i);
Public Delegate Sub FPtr(ByVal value As Integer)

Public Class LibWrapper
    ' int GetRectangleArea(MYRECTANGLE* pStruct)
    Declare Function GetRectangleArea Lib "..\..\PinvokeLib.dll" _
        (ByRef rectangle As MyRectangle) As Integer

    'void TestCallBack(FPtr pf, MYRECTANGLE* pStruct)
    Declare Sub GetRectangleAreaCallBack Lib "..\..\PinvokeLib.dll" _
        (ByVal cb As FPtr, ByRef rectangle As MyRectangle)

End Class
