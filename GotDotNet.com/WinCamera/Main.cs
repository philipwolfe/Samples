using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

public class CameraForm  {
  static void PrintUsage() {
    Console.WriteLine("Usage: wincamera -i:10 -t:1000 -s:1 -f:jpeg image");
    Console.WriteLine("Takes 10 snapshots of screen 1 with 1 second delay between each and");
    Console.WriteLine("saves them as jpeg files named \"image1.jpeg\" through \"image10.jpeg\"");
    Console.WriteLine("Options:");
    Console.WriteLine("  -i       specifies the number of shots to take (default is 1)");
    Console.WriteLine("  -t       specifies the delay between each shot in milliseconds (default 1000)");
    Console.WriteLine("  -s       specifies which screen to copy (default is primary screen)");
    Console.WriteLine("  -f       specifies image format (default jpeg)");
    Console.WriteLine("           supported formats: bmp, emf, gif, png, jpg, tiff, wmf");
    Console.WriteLine("filename - the base file name to use (default \"image\")");
  }
  static void Main(string[] args) {
    int interval = 1000; // 1 seconds
    int total = 1; // 10 shots.
    int screen = 1;
    string baseName = "image";
    ImageFormat format = ImageFormat.Jpeg;
    string ext = "jpg";

    for (int i = 0; i < args.Length; i++) {
      string arg = args[i];
      if (arg[0] == '-') {
        string argvalue = arg.Length>2 ? arg.Substring(3) : "?";
        string name = arg.Length>1 ? arg.Substring(0,2) : "?";
        switch (name) {
          case "-t":
            interval = Int32.Parse(argvalue);
            break;
          case "-i":
            total = Int32.Parse(argvalue);
            break;
          case "-s":
            screen = Int32.Parse(argvalue);
            break;
          case "-f":
            ext = argvalue;
            switch (argvalue.ToLower()) {
              case "bmp":
                format = ImageFormat.Bmp;
                break;
              case "emf":
                format = ImageFormat.Emf;
                break;
              case "gif":
                format = ImageFormat.Gif;
                break;
              case "jpg":
                format = ImageFormat.Jpeg;
                break;
              case "png":
                format = ImageFormat.Png;
                break;
              case "tiff":
                format = ImageFormat.Tiff;
                break;
              case "wmf":
                format = ImageFormat.Wmf;
                break;
              default:
                Console.WriteLine("Unrecognized image format: {0}", argvalue);
                return;
            }
            ext = argvalue;
            break;
          default:
            PrintUsage();
            return;
        }
      } else {
        baseName = arg;
      }
    }
    Screen[] screens = Screen.AllScreens;
    Screen chosenScreen = Screen.PrimaryScreen;
    if (screen < screens.Length) {
      chosenScreen = screens[screen];
    }

    IntPtr hdcScreen = CreateDC(chosenScreen.DeviceName, null, null, IntPtr.Zero);
    if (hdcScreen == IntPtr.Zero) {
      Console.WriteLine("CreateDC failed"); 
      return;
    }
    IntPtr hdcCompatible = CreateCompatibleDC(hdcScreen); 
    if (hdcCompatible == IntPtr.Zero) {
      Console.WriteLine("CreateCompatibleDC failed"); 
      return;
    }

    for (int i = 0; i < total; i++) {
      Thread.Sleep(interval);
      int width = chosenScreen.Bounds.Width;
      int height = chosenScreen.Bounds.Height;
      IntPtr hbmScreen = CreateCompatibleBitmap(hdcScreen, width, height); 
      if (hbmScreen == IntPtr.Zero) {
        Console.WriteLine("CreateCompatibleBitmap failed"); 
        break;
      }

      // Select the bitmaps into the compatible DC. 
      if (SelectObject(hdcCompatible, hbmScreen) == IntPtr.Zero) {
        Console.WriteLine("SelectObject failed"); 
        break;
      }
  
      //Copy color data for the entire display into a 
      //bitmap that is selected into a compatible DC. 
 
      int SRCCOPY = 0x00CC0020;
      if (!BitBlt(hdcCompatible, 0,0, width, height, hdcScreen, 0,0, SRCCOPY)) { 
        Console.WriteLine("Screen to Compat Blt Failed"); 
        break;
      }
      
      Image img = Image.FromHbitmap(hbmScreen);
      string name = baseName+i+"."+ext;
      img.Save(name, format);
      Console.WriteLine(name);

    }
    
  }
  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateDC(
    string lpszDriver,        // driver name
    string lpszDevice,        // device name
    string lpszOutput,        // not used; should be NULL
    IntPtr lpInitData);       // optional printer data
                  
  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateCompatibleDC(
    IntPtr hdc   // handle to DC
    );
  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateCompatibleBitmap(
    IntPtr hdc,        // handle to DC
    int nWidth,     // width of bitmap, in pixels
    int nHeight     // height of bitmap, in pixels
    ); 
  [DllImport("gdi32.dll")]
  public static extern IntPtr SelectObject(
    IntPtr hdc,          // handle to DC
    IntPtr hgdiobj   // handle to object
    );
  [DllImport("gdi32.dll")]
  public static extern bool BitBlt(
    IntPtr hdcDest, // handle to destination DC
    int nXDest,  // x-coord of destination upper-left corner
    int nYDest,  // y-coord of destination upper-left corner
    int nWidth,  // width of destination rectangle
    int nHeight, // height of destination rectangle
    IntPtr hdcSrc,  // handle to source DC
    int nXSrc,   // x-coordinate of source upper-left corner
    int nYSrc,   // y-coordinate of source upper-left corner
    int dwRop  // raster operation code
    );

}