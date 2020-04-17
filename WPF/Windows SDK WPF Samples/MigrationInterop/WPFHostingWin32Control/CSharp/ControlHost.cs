﻿#region Using directives

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Runtime.InteropServices;

#endregion

namespace WPF_Hosting_Win32_Control
{
  public class ControlHost : HwndHost
  {
    IntPtr hwndControl;
    IntPtr hwndHost;
    int hostHeight, hostWidth;

    public ControlHost(double height, double width)
    {
      hostHeight = (int)height;
      hostWidth = (int)width;
    }
    protected override HandleRef BuildWindowCore(HandleRef hwndParent)
    {
      hwndControl = IntPtr.Zero;
      hwndHost = IntPtr.Zero;

      hwndHost = CreateWindowEx(0, "static", "",
                                WS_CHILD | WS_VISIBLE,
                                0, 0,
                                hostHeight, hostWidth,
                                hwndParent.Handle,
                                (IntPtr)HOST_ID,
                                IntPtr.Zero,
                                0);

      hwndControl = CreateWindowEx(0, "listbox", "",
                                    WS_CHILD | WS_VISIBLE | LBS_NOTIFY
                                      | WS_VSCROLL | WS_BORDER,
                                    0, 0,
                                    hostHeight, hostWidth,
                                    hwndHost,
                                    (IntPtr) LISTBOX_ID,
                                    IntPtr.Zero,
                                    0);

      return new HandleRef(this, hwndHost);
    }
    protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
      handled = false;
      return IntPtr.Zero;
    }

    protected override void DestroyWindowCore(HandleRef hwnd)
    {
      DestroyWindow(hwnd.Handle);
    }
    public IntPtr hwndListBox
    {
      get { return hwndControl; }
    }
    //PInvoke declarations
    [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Auto)]
    internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                  string lpszClassName,
                                                  string lpszWindowName,
                                                  int style,
                                                  int x, int y,
                                                  int width, int height,
                                                  IntPtr hwndParent,
                                                  IntPtr hMenu,
                                                  IntPtr hInst,
                                                  [MarshalAs(UnmanagedType.AsAny)] object pvParam);
    [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Auto)]
    internal static extern bool DestroyWindow(IntPtr hwnd);
    internal const int
      WS_CHILD = 0x40000000,
      WS_VISIBLE = 0x10000000,
      LBS_NOTIFY = 0x00000001,
      HOST_ID = 0x00000002,
      LISTBOX_ID = 0x00000001,
      WS_VSCROLL = 0x00200000,
      WS_BORDER = 0x00800000;
  }
}
