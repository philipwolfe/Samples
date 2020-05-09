/**CSS**********************************************************************************************
**
** SRC-MODULE : ImageList
** NAME-SPACE : Ironring.Management.MMC
** VERSION    : 00-06
**
** AUTHOR     : Paul Kubitscheck
** SUBSTITUTE : Jim Murphy
**
** HISTORY    : 02-08-20 new
**
***************************************************************************************************/

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

namespace Ironring.Management.MMC
{
   /**CSC*******************************************************************************************
   **
   ** CLASS      : ImageList
   ** BASE-CLASS : System.Collections.ArrayList
   **
   ** AUTHOR     : Paul Kubitscheck
   ** SUBSTITUTE : Jim Murphy
   **
   ** HISTORY    : 02-08-20 new
   **
   ************************************************************************************************/
   /// <summary>
   /// This class provides a typed list of images for a MMC snap-in.
   /// </summary>
   public class ImageList: ArrayList
   {
      /// <summary>
      /// This structure defines an image entry in the list.
      /// </summary>
      protected struct ImageEntry
      {
         /// <summary>
         /// This hold the image object.
         /// </summary>
         public object image;
         /// <summary>
         /// This hold a WIN32 icon handle of the image object. If the managed image object is a
         /// bitmap, this handle was created by CreateIconIndirect and must be deleted by the
         /// destructor. Otherwise, the icon handle refers of the managed object and must not be
         /// deleted by the destructor.
         /// </summary>
         public IntPtr iconHandle;
         /// This hold a WIN32 bitmap handle of the image object. The handle must be deleted by the
         /// destructor in any case, because the unmanaged bitmap is an object of it's own.
         /// </summary>
         public IntPtr bitmapHandle;
         /// <summary>
         /// This contructor creates a new image entry.
         /// </summary>
         public ImageEntry(object image)
         {
            this.image = image;
            this.iconHandle = IntPtr.Zero;
            this.bitmapHandle = IntPtr.Zero;
         }
      }
      /**CSF****************************************************************************************
      **
      ** FUNCTION   : FindImage
      **
      ** AUTHOR     : Jim Murphy
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method searches the assemblies of the current application domain for the image
      /// resource specified and loads the image found.
      /// specified.
      /// </summary>
      /// <param name="name">Name of the image resource.
      /// </param>
      /// <returns>
      /// Returns the image object loaded.
      /// </returns>
      public static object FindImage(string name)
      {
         if (name != null && name.Length > 0)
         {
            try
            {
               object image = null;

               // from this assembly?
               Assembly exeAsm = Assembly.GetExecutingAssembly();
               if ((image = LoadImage(exeAsm, name)) != null)
                  return image;

               // from the calling assembly?
               Assembly callAsm = Assembly.GetCallingAssembly();
               if ((image = LoadImage(callAsm, name)) != null)
                  return image;

               // or from any assembly in the app domain?
               foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
               {
                  if ((image = LoadImage(a, name)) != null)
                     return image;
               }
            }
            catch (Exception e)
            {
               System.Diagnostics.Debug.WriteLine("FindImage Exception - " + e.Message);
               throw new SnapinException("Image " + name + " not found in app domain assemblies.", 
                                         e);
            }
         }
         return null;
      }
      /**CSF****************************************************************************************
      **
      ** FUNCTION   : LoadImage
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method searches the resource names of the specified assembly for the image resource
      /// specified and loads the image found. The image resource may either be a bitmap or an icon.
      /// </summary>
      /// <param name="name">Name of the image resource (*.bmp;*.ico).
      /// </param>
      /// <returns>
      /// Returns the image object loaded.
      /// </returns>
      protected static object LoadImage(Assembly a, string name)
      {
         string[] names = a.GetManifestResourceNames();

         Stream s = a.GetManifestResourceStream(name);
         if (s != null)
         {
            if (Path.GetExtension(name).ToLower() == ".ico")
            {
               return new Icon(s);
            }
            else
            {
               return new Bitmap(s);
            }
         }
         return null;
      }
      /**CSF****************************************************************************************
      **
      ** FUNCTION   : DeleteObject
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      public static extern int DeleteObject(IntPtr hObject);

      /**CSM****************************************************************************************
      **
      ** METHOD     : DestroyIcon
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("user32.dll")]
      public static extern int DestroyIcon(IntPtr hIcon);

      /**CSM****************************************************************************************
      **
      ** METHOD     : CreateCompatibleDC
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

      /**CSM****************************************************************************************
      **
      ** METHOD     : DeleteDC
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      public static extern uint DeleteDC(IntPtr hdc);

      /**CSM****************************************************************************************
      **
      ** METHOD     : GetObject
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      internal static extern int GetObject(IntPtr hgdiobj, int cbBuffer, ref DIBSECTION lpvObject);

      /**CSM****************************************************************************************
      **
      ** METHOD     : SetDIBits
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      internal static extern int SetDIBits(IntPtr hdc, IntPtr hbmp, uint uStartScan, int uScanLines, 
                                           IntPtr lpvBits, ref BITMAPINFO lpbmi, uint fuColorUse);
      /**CSM****************************************************************************************
      **
      ** METHOD     : CreateDIBSection
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      internal static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, 
                                                     out IntPtr ppvBits, IntPtr hSection, uint 
                                                     dwOffset);
      /**CSM****************************************************************************************
      **
      ** METHOD     : GetDeviceCaps
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method calls the WIN32 API function with the same name.
      /// </summary>
      [DllImport("gdi32.dll")]
      internal static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

      /**CSR****************************************************************************************
      **
      ** CONSTRUCTOR: ImageList
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This contructor creates the image list by calling the base constructor.
      /// </summary>
      public ImageList() : base()
      {
      }
      /**CSR****************************************************************************************
      **
      ** DESTRUCTOR : ~ImageList
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This destructor releases all unmanaged bitmap objects.
      /// </summary>
      ~ImageList()
      {
         for (int i = 0; i < Count; i++)
         {
            DeleteHandle(i);
         }
      }
      /**CSP****************************************************************************************
      **
      ** PROPERTY   : ImageList[]
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This indexer allows to set or get an image at the specified index.
      /// constructor.
      /// </summary>
      protected new virtual ImageEntry this[int index]
      {
         get
         {
            return (ImageEntry)base[index];
         }
         set
         {
            DeleteHandle(index);
            base[index] = value;
         }
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Add
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This overloaded method appends an image to the list.
      /// </summary>
      /// <param name="image">Specifies the image to be appended.
      /// </param>
      public override int Add(object image)
      {
         return base.Add(new ImageEntry(image));
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Add
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This overloaded method appends an image specified by name to the list. The image is loaded
      /// from an embedded resource.
      /// </summary>
      /// <param name="name">Specifies the name of the image to be loaded and appended.
      /// </param>
      public virtual int Add(string name)
      {
         return base.Add(new ImageEntry(FindImage(name)));
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : AddRange
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method is not supported.
      /// </summary>
      /// <param name="c">Specifies the collection to be appended.
      /// </param>
      public override void AddRange(ICollection c)
      {
         throw new SnapinException("ImageList.AddRange not supported.");
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Insert
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This overloaded method inserts an image at the specified index.
      /// </summary>
      /// <param name="image">Specifies the image to be inserted.
      /// </param>
      public override void Insert(int index, object image)
      {
         base.Insert(index, new ImageEntry(image));
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Insert
      **
      ** AUTHOR     : Paul Kubitscheck
      ** AUTHOR     : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method inserts an image specified by name at the specified index. The image is loaded
      /// from an embedded resource.
      /// </summary>
      /// <param name="name">Specifies the name of the image to be loaded and inserted.
      /// </param>
      public virtual void Insert(int index, string name)
      {
         base.Insert(index, new ImageEntry(FindImage(name)));
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Replace
      **
      ** AUTHOR     : Paul Kubitscheck
      ** AUTHOR     : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This overloaded method replaces an image at the specified index.
      /// </summary>
      /// <param name="image">Specifies the image to be inserted.
      /// </param>
      public virtual void Replace(int index, Image image)
      {
         this[index] = new ImageEntry(image);
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : Replace
      **
      ** AUTHOR     : Paul Kubitscheck
      ** AUTHOR     : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method replaces an image specified by name at the specified index. The image is
      /// loaded from an embedded resource.
      /// </summary>
      /// <param name="name">Specifies the name of the image to be loaded and inserted.
      /// </param>
      public virtual void Replace(int index, string name)
      {
         this[index] = new ImageEntry(FindImage(name));
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : LoadImageList
      **
      ** AUTHOR     : Jim Murphy
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method loads all images of the list into the unmanaged image list
      /// specified.
      /// </summary>
      /// <param name="il">Specifies the image list to be loaded.
      /// </param>
      public virtual void LoadImageList(IImageList il)
      {
         LoadImageList(il, 0);
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : LoadImageList
      **
      ** AUTHOR     : Jim Murphy
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method loads all images of the list into the unmanaged image list
      /// specified.
      /// </summary>
      /// <param name="il">Specifies the image list to be loaded.
      /// </param>
      /// <param name="baseCookie">Specifies the base cookie value (most significant word).
      /// </param>
      public virtual void LoadImageList(IImageList il,  
                                        int baseCookie)
      {
         try
         {
            int i, items = Count;

            for (i = 0; i < items; i++)
            {
               if (this[i].image != null)
               {
                  il.ImageListSetIcon(GetIconHandle(i), (baseCookie << 16) + i);
               }
            }
         }
         catch (Exception e)
         {
            throw new SnapinException("LoadImageList failed. Reason: " + e.Message);
         }
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : DeleteHandle
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method deletes the bitmap and/or icon handle of the image entry.
      /// </summary>
      /// <param name="index">Specifies the index of the image.
      /// </param>
      /// <returns>
      public virtual void DeleteHandle(int index)
      {
         ImageEntry ime = this[index];

         if (ime.image != null)
         {
             if (ime.bitmapHandle != IntPtr.Zero)
             {
                 DeleteObject(ime.bitmapHandle);
             }
             if (ime.iconHandle != IntPtr.Zero && ime.image is Bitmap)
             {
                 DestroyIcon(ime.iconHandle);
             }
         }
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : GetBitmapHandle
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method creates a bitmap handle to the specified image. The image may be either an
      /// icon or a bitmap. The handle will be deleted automatically by the destructor.
      /// </summary>
      /// <param name="index">Specifies the index of the image.
      /// </param>
      /// <returns>
      /// Returns a bitmap handle to the specified image.
      /// </returns>
      public virtual IntPtr GetBitmapHandle(int index)
      {
         Bitmap bm;
         ImageEntry ime = this[index];

         if (ime.image != null && ime.bitmapHandle == IntPtr.Zero)
         {
            if (ime.image is Icon)
            {
               bm = ((Icon)ime.image).ToBitmap();
            }
            else
            {
               bm = (Bitmap)ime.image;
            }
            ime.bitmapHandle = GetCompatibleBitmapHandle(bm);
            this[index] = ime;
         }
         return ime.bitmapHandle;
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : GetIconHandle
      **
      ** AUTHOR     : Paul Kubitscheck
      ** SUBSTITUTE : Jim Murphy
      **
      ** HISTORY    : 02-08-20 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method creates an icon handle to the specified image. The image may be either an icon
      /// or a bitmap. The handle will be deleted automatically by the destructor.
      /// </summary>
      /// <param name="index">Specifies the index of the image.
      /// </param>
      /// <returns>
      /// Returns an icon handle to the specified image.
      /// </returns>
      public virtual IntPtr GetIconHandle(int index)
      {
         ImageEntry ime = this[index];

         if (ime.image != null && ime.iconHandle == IntPtr.Zero)
         {
            if (ime.image is Icon)
            {
               ime.iconHandle = ((Icon)ime.image).Handle;
            }
            else
            {
               ime.iconHandle = ((Bitmap)ime.image).GetHicon();
            }
            this[index] = ime;
         }
         return ime.iconHandle;
      }
      /**CSM****************************************************************************************
      **
      ** METHOD     : GetCompatibleBitmapHandle
      **
      ** AUTHOR     : MS Fellow
      ** SUBSTITUTE : Paul Kubitscheck
      **
      ** HISTORY    : 02-07-30 new
      **
      *********************************************************************************************/
      /// <summary>
      /// This method must do a messy job. A quick explanation of what is going on:
      /// If we were to call Bitmap.GetHbitmap, we'll get back an HBitmap that is intended for
      /// 32-bit displays. MMC expects the HBITMAP it gets to be compatible with the screen.
      /// So, if the current video display is not set to 32 bit, MMC will fail to show the bitmap.
      /// So what do we do? We translate the bitmaps into the color depth that the screen is
      /// currently displaying. If we were to call Bitmap.GetHbitmap, we'll get back an HBitmap that
      /// is intended for 32-bit displays. MMC expects the HBITMAP it gets to be compatible with the
      /// screen. So, if the current video display is not set to 32 bit, MMC will fail to show the
      /// bitmap. So what do we do? We translate the bitmaps into the color depth that the screen is
      /// currently displaying.
      /// </summary>
      internal IntPtr GetCompatibleBitmapHandle(Bitmap bm)
      {
         IntPtr hFinalBitmap, hBitmap;
         hFinalBitmap = hBitmap = new Bitmap(bm).GetHbitmap();

         /* Get a DC that is compatible with the display */
         IntPtr hdc = CreateCompatibleDC(IntPtr.Zero);

         /* Now get the BITMAP information on this guy */
         DIBSECTION ds = new DIBSECTION();
         int nLen = GetObject(hBitmap, Marshal.SizeOf(typeof(DIBSECTION)), ref ds);

         /* Create BITMAPINFO structures and put in the appropriate values */
         BITMAPINFO bmiOld = new BITMAPINFO();
         bmiOld.bmiHeader = ds.dsBmih;
         BITMAPINFO bmiNew = new BITMAPINFO();
         bmiNew.bmiHeader = ds.dsBmih;

         /* The old color depth is always 32. Get the color depth the screen supports and compare it 
            with the old one. */
         bmiNew.bmiHeader.biBitCount = (ushort) GetDeviceCaps(hdc, 12 /* BITSPIXEL */);

         if (bmiNew.bmiHeader.biBitCount != bmiOld.bmiHeader.biBitCount)
         {
            IntPtr bits; // Garbage variable... just need it for the function call

            // This will create a bitmap handle with the color depth of the current screen
            hFinalBitmap = CreateDIBSection(hdc, ref bmiNew, 1 /* DIB_PAL_COLORS */, out bits, 
                                          IntPtr.Zero, 0);

            // Translate the 32bpp pixels to something the screen can show
            SetDIBits(hdc, hFinalBitmap, 0, ds.dsBmih.biHeight, ds.dsBm.bmBits, ref bmiOld,
                      1 /* DIB_PAL_COLORS */);

            // Delete old bitmap
            DeleteObject(hBitmap);
         }
         // Cleanup
         DeleteDC(hdc);

         return hFinalBitmap;
      }
   }
}
