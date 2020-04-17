//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------


using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Globalization;

namespace Microsoft.Samples.MD3DM
{

    /// <summary>
    /// This class implements an fps (frames per second) timer together
    /// with an optional display and file logger.
    /// </summary>
    public class FpsTimerTool
    {
        /// <summary>
        /// The number of recent frames to average time over
        /// </summary>
        private int recentFramesToTrack = 50;

        /// <summary>
        /// The update frquency in seconds of the graphical fps display
        /// </summary>
        private TimeSpan fpsDisplayUpdateFrequency = new TimeSpan(0,0,1);

        /// <summary>
        /// The update frquency in seconds of the file logged fps
        /// </summary>
        private TimeSpan fpsFileDumpUpdateFrequency = new TimeSpan(0,0,1);

        /// <summary>
        /// Whether or not Fps information will be displayed to the screen
        /// </summary>
        private bool fpsDisplayEnabled = false;

        /// <summary>
        /// Whether or not Fps information will be dumped to file
        /// </summary>
        private bool fpsFileDumpEnabled = false;

        /// <summary>
        /// An array of TimeSpans which tracks the rendering time
        /// of the most recent frames
        /// </summary>
        private ArrayList recentFrameTimes = new ArrayList();

        /// <summary>
        /// The time rendering of the most recent frame started
        /// </summary>
        private DateTime startFrameTime;

        /// <summary>
        /// The stream to which to dump fps information
        /// </summary>
        private StreamWriter loggingStream = null;

        /// <summary>
        /// The last time fps information was dumped to file
        /// </summary>
        private DateTime lastFpsFileDumpTime = DateTime.Now;

        /// <summary>
        /// The last time the Fps display was drawn
        /// </summary>
        private DateTime lastFpsDisplayTime = DateTime.Now;

        /// <summary>
        /// The font used for drawing the fps to screen
        /// </summary>
        private Font fpsDisplayFont = null;

        /// <summary>
        /// The value displayed on screen for fps
        /// </summary>
        private float fpsDisplayValue;

        public FpsTimerTool(Device d)
        {
            if(fpsFileDumpEnabled)
            {
                try
                {
                    String filename = GetFullPath("fps_dump.txt");
                    loggingStream = new StreamWriter(filename);
                }
                catch(IOException)
                {
                    fpsFileDumpEnabled = false;
                }
            }
            fpsDisplayFont = new Font(d, new System.Drawing.Font("Arial",
                12F, System.Drawing.FontStyle.Regular));
        }

        /// <summary>
        /// Called when frame rendering begins
        /// </summary>
        public void StartFrame()
        {
            startFrameTime = DateTime.Now;
        }

        /// <summary>
        /// Called when frame rendering ends
        /// </summary>
        public void StopFrame()
        {
            // determine elapsed frame time
            TimeSpan TimeElapsedInFrame = DateTime.Now - startFrameTime;
        
            // store the most recent frame and possibly evict the least
            // recent one so that there are never more than 
            // RecentFramesToTrack frame times in the array
            if(recentFrameTimes.Count == recentFramesToTrack)
                recentFrameTimes.RemoveAt(0);
            recentFrameTimes.Add(TimeElapsedInFrame);

            if(fpsFileDumpEnabled)
            {
                if(DateTime.Now - lastFpsFileDumpTime > 
                    fpsFileDumpUpdateFrequency)
                {
                    lastFpsFileDumpTime = DateTime.Now;
                    try
                    {
                        loggingStream.WriteLine(
                            AverageFps.ToString(CultureInfo.CurrentCulture));
                        loggingStream.Flush();
                    }
                    catch(IOException)
                    {
                        // If we fail to write for whatever reason,
                        // just ignore and continue
                    }
                }
            }

            if(fpsDisplayEnabled)
            {
                if(DateTime.Now - lastFpsDisplayTime > 
                    fpsDisplayUpdateFrequency)
                {
                    fpsDisplayValue = AverageFps;
                    lastFpsDisplayTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Called to draw the fps string onto the screen
        /// </summary>
        public void Render()
        {
            if(fpsDisplayEnabled)
                fpsDisplayFont.DrawText(null, 
                    fpsDisplayValue.ToString(CultureInfo.CurrentCulture),
                    0, 0, System.Drawing.Color.Red);
        }

        /// <summary>
        /// The average fps of recent frames
        /// </summary>
        public float AverageFps
        {
            get
            {
                TimeSpan totalTimeElapsed = new TimeSpan(0);
                foreach(TimeSpan frameTime in recentFrameTimes)
                    totalTimeElapsed += frameTime;

                if(totalTimeElapsed.TotalMilliseconds == 0)
                    return 0;
                else
                    return (float) (1000.0 * recentFrameTimes.Count /
                        totalTimeElapsed.TotalMilliseconds);
            }
        }

        /// <summary>
        /// Get the full path to the specified file by prepending it
        /// with the directory of the executable.
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>Full path of the file</returns>
        /// 
        private string GetFullPath(string fileName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string str = asm.GetModules()[0].FullyQualifiedName;
            string fullName = Path.GetDirectoryName(str);
            Uri uri = new Uri(Path.Combine(fullName, fileName));
            return uri.AbsolutePath;
        }
    }
}