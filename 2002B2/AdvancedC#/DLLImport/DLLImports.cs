using System.Runtime.InteropServices;

class DLLImports
{
	[DllImport("user32.dll")]
	public static extern int GetDesktopWindow();

	[DllImport("user32.dll")]
	public static extern int GetDC(int hwnd);

	[DllImport("user32.dll")]
	public static extern int InvalidateRect(int hwnd, RECT pRect, int bErase);

	[DllImport("user32.dll")]
	public static extern short GetAsyncKeyState(int vKey);

	[DllImport("user32.dll")]
	public static extern int FillRect(int hdc, RECT pRect, int hbrush);

	[DllImport("gdi32.dll")]
	public static extern int GetClipBox(int hdc, RECT pRect);

	[DllImport("gdi32.dll")]
	public static extern int GdiFlush();

	[DllImport("gdi32.dll")]
	public static extern int CreateSolidBrush(int color);

	[DllImport("gdi32.dll")]
	public static extern int CreatePen(int style, int width, int color);

	[DllImport("gdi32.dll")]
	public static extern int DeleteObject(int hobject);

	[DllImport("gdi32.dll")]
	public static extern int SelectObject(int hdc, int hobj);

	[DllImport("gdi32.dll")]
	public static extern int MoveToEx(int hdc, int x, int y, Point p); 

	[DllImport("gdi32.dll")]
	public static extern int LineTo(int hdc, int x, int y);
	
	[DllImport("kernel32.dll")]
	public static extern void Sleep(int msecs);

	[DllImport("kernel32.dll")]
	public static extern int GetLastError();

	[DllImport("kernel32.dll")]
	public static extern void SetLastError(int code);

	[DllImport("kernel32.dll")]
	public static extern int GetTickCount();
}