//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;


public class TimeCheck
{
    private DateTime m_dtmBegin;
    private TimeSpan m_EndSpan;

    // Begin the timecheck
    public void Begin()
	{
        m_dtmBegin = DateTime.Now;
    }

    // End the timecheck
    public void End()
	{
        m_EndSpan = DateTime.Now.Subtract(m_dtmBegin);
    }

    public long Milliseconds
	{
        get {
            return ((long) (m_EndSpan.TotalMilliseconds));
        }
    }
}

