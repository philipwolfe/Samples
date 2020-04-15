//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

public class ImageAttributes
{
    public string Src;
    public string Alt;
    public string Height;
    public string Width;

    public ImageAttributes(string strSrc ,string strAlt ,string strHeight ,string strWidth )
	{

        Src = strSrc;
        Width = strWidth;
        Height = strHeight;
        Alt = strAlt;

    }

}

