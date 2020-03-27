// script.js
//
// This is a part of the Active Template Library.
// Copyright (C) 2001 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// ids of our perfmon objects and counters
var idMarqueeData = 0;
var idFPS = 0;
var idBalls = 0;
var oMarqueePerf = null;

// canvas info
var nCanvasWidth = Canvas.Width;
var nCanvasHeight = Canvas.Height;

// info about our control string
var strControl = "#gATL #rS#oE#yR#gV#bE#pR #WROCKS#g!              ";
var strMessage = "";
var strColors = "";
var oLetters = null;
var oColors = null;
var oColorPerf = null;

function OnInitialize()
{
	SetupPerfmonData();
	CreateLetterArray();
	CreateColorArray();
	ParseControlString();
}

function OnTick()
{
	if (!oMarqueePerf)
		return;

	var nTicks = oMarqueePerf.GetCounter(idFPS);
	oMarqueePerf.SetCounter(idFPS, nTicks+1);

	Canvas.FillRect(0, 0, nCanvasWidth, nCanvasHeight, 0, 0, 0);

	var nMessageCols = strMessage.length*6;
	var nBallSize = Math.floor(nCanvasHeight/8);
	var nMarqueeWidth = Math.floor(nCanvasWidth/nBallSize);

	for (var i=0; i<nMarqueeWidth; i++)
	{
		var nMessageCol = (i+nTicks)%nMessageCols;
		var nLetter = Math.floor(nMessageCol/6);
		var nLetterOrd = strMessage.charCodeAt(nLetter);
		var nLetterCol = nMessageCol%6;
		var oLetterCode = oLetters[nLetterOrd];
		var nLetterColCode = oLetterCode[nLetterCol];
		var nColorOrd = strColors.charCodeAt(nLetter);
		var oColor = oColors[nColorOrd];

		for (var j=0; j<8; j++)
		{
			var bBallOn = nLetterColCode & (1<<j);
			if (bBallOn)
			{
				if (Math.floor(nTicks/25)%2 == 1 && oColor[3] == 1)
				{
					Canvas.Ellipse(i*nBallSize, j*nBallSize,
						(i+1)*nBallSize, (j+1)*nBallSize,
						oColor[0], oColor[1], oColor[2], 0, 0, 0);
				}
				else
				{
					Canvas.Ellipse(i*nBallSize, j*nBallSize,
						(i+1)*nBallSize, (j+1)*nBallSize,
						oColor[0], oColor[1], oColor[2], oColor[0], oColor[1], oColor[2]);
				}
				oMarqueePerf.IncrementCounter(idBalls);
				oColorPerf[nColorOrd].IncrementCounter(idBalls);
			}
		}
	}
}

function CreateLetterArray()
{
	oLetters = new Array();
	oLetters[ 32] = new Array(  0,   0,   0,   0,   0, 0); // space
	oLetters[ 33] = new Array(  0,   0, 191,   0,   0, 0); // !
	oLetters[ 34] = new Array(  0,   6,   0,   6,   0, 0); // "
	oLetters[ 35] = new Array( 20, 255,  20, 255,  20, 0); // #
	oLetters[ 36] = new Array( 36,  74, 219,  82,  36, 0); // $
	oLetters[ 37] = new Array(195,  35,  24, 196, 195, 0); // %
	oLetters[ 38] = new Array(112, 143, 153,  97, 144, 0); // &
	oLetters[ 39] = new Array(  0,   0,   6,   0,   0, 0); // '
	oLetters[ 40] = new Array(  0,  60,  66, 129,   0, 0); // (
	oLetters[ 41] = new Array(  0, 129,  66,  60,   0, 0); // )
	oLetters[ 42] = new Array(  0,  84,  56,  84,   0, 0); // *
	oLetters[ 43] = new Array(  0,  16,  56,  16,   0, 0); // +
	oLetters[ 44] = new Array(  0, 128,  96,   0,   0, 0); // ,
	oLetters[ 45] = new Array(  0,  16,  16,  16,   0, 0); // -
	oLetters[ 46] = new Array(  0,   0, 192,   0,   0, 0); // .
	oLetters[ 47] = new Array(128,  96,  24,   6,   1, 0); // /
	oLetters[ 48] = new Array( 60,  66, 129,  66,  60, 0); // 0
	oLetters[ 49] = new Array(  0, 130, 255, 128,   0, 0); // 1
	oLetters[ 50] = new Array(130, 193, 177, 137, 134, 0); // 2
	oLetters[ 51] = new Array( 66, 129, 153, 153, 102, 0); // 3
	oLetters[ 52] = new Array( 24,  20,  18,  17, 255, 0); // 4
	oLetters[ 53] = new Array( 95, 145, 145, 145, 113, 0); // 5
	oLetters[ 54] = new Array(126, 145, 145, 145,  98, 0); // 6
	oLetters[ 55] = new Array(129,  97,  25,   7,   1, 0); // 7
	oLetters[ 56] = new Array(102, 153, 153, 153, 102, 0); // 8
	oLetters[ 57] = new Array( 70, 137, 137, 137, 126, 0); // 9
	oLetters[ 58] = new Array(  0,   0, 198,   0,   0, 0); // :
	oLetters[ 59] = new Array(  0, 128, 102,   0,   0, 0); // ;
	oLetters[ 60] = new Array(  0,  24,  36,  66,   0, 0); // <
	oLetters[ 61] = new Array( 40,  40,  40,  40,  40, 0); // =
	oLetters[ 62] = new Array(  0,  66,  36,  24,   0, 0); // >
	oLetters[ 63] = new Array(  2,   1, 217,   5,   2, 0); // ?
	oLetters[ 64] = new Array(126, 129, 185, 161,  30, 0); // @
	oLetters[ 65] = new Array(224,  28,  19,  28, 224, 0); // A
	oLetters[ 66] = new Array(255, 137, 137, 137, 118, 0); // B
	oLetters[ 67] = new Array(126, 129, 129, 129,  66, 0); // C
	oLetters[ 68] = new Array(255, 129, 129, 129, 126, 0); // D
	oLetters[ 69] = new Array(255, 137, 137, 129, 129, 0); // E
	oLetters[ 70] = new Array(255,   9,   9,   1,   1, 0); // F
	oLetters[ 71] = new Array(126, 129, 145, 145, 114, 0); // G
	oLetters[ 72] = new Array(255,   8,   8,   8, 255, 0); // H
	oLetters[ 73] = new Array(129, 129, 255, 129, 129, 0); // I
	oLetters[ 74] = new Array( 97, 129, 127,   1,   1, 0); // J
	oLetters[ 75] = new Array(255,  24,  36,  66, 129, 0); // K
	oLetters[ 76] = new Array(255, 128, 128, 128, 128, 0); // L
	oLetters[ 77] = new Array(255,   6,   8,   6, 255, 0); // M
	oLetters[ 78] = new Array(255,   6,  24,  96, 255, 0); // N
	oLetters[ 79] = new Array(126, 129, 129, 129, 126, 0); // O
	oLetters[ 80] = new Array(255,   9,   9,   9,   6, 0); // P
	oLetters[ 81] = new Array(126, 129, 161, 193, 254, 0); // Q
	oLetters[ 82] = new Array(255,  25,  41,  73, 134, 0); // R
	oLetters[ 83] = new Array( 70, 137, 153, 145,  98, 0); // S
	oLetters[ 84] = new Array(  1,   1, 255,   1,   1, 0); // T
	oLetters[ 85] = new Array(127, 128, 128, 128, 127, 0); // U
	oLetters[ 86] = new Array(  7,  56, 192,  56,   7, 0); // V
	oLetters[ 87] = new Array( 15, 240,  15, 240,  15, 0); // W
	oLetters[ 88] = new Array(195,  36,  24,  36, 195, 0); // X
	oLetters[ 89] = new Array(  3,  12, 240,  12,   3, 0); // Y
	oLetters[ 90] = new Array(129, 225, 153, 135, 129, 0); // Z
	oLetters[ 91] = new Array(  0, 255, 129, 129,   0, 0); // [
	oLetters[ 92] = new Array(  1,   6,  24,  96, 128, 0); // \
	oLetters[ 93] = new Array(  0, 129, 129, 255,   0, 0); // ]
	oLetters[ 94] = new Array(  0,   4,   2,   4,   0, 0); // ^
	oLetters[ 95] = new Array(128, 128, 128, 128, 128, 0); // _
	oLetters[ 96] = new Array(  0,   2,   4,   0,   0, 0); // `
	oLetters[ 97] = new Array(224,  28,  19,  28, 224, 0); // a
	oLetters[ 98] = new Array(255, 137, 137, 137, 118, 0); // b
	oLetters[ 99] = new Array(126, 129, 129, 129,  66, 0); // c
	oLetters[100] = new Array(255, 129, 129, 129, 126, 0); // d
	oLetters[101] = new Array(255, 137, 137, 129, 129, 0); // e
	oLetters[102] = new Array(255,   9,   9,   1,   1, 0); // f
	oLetters[103] = new Array(126, 129, 145, 145, 114, 0); // g
	oLetters[104] = new Array(255,   8,   8,   8, 255, 0); // h
	oLetters[105] = new Array(129, 129, 255, 129, 129, 0); // i
	oLetters[106] = new Array( 97, 129, 127,   1,   1, 0); // j
	oLetters[107] = new Array(255,  24,  36,  66, 129, 0); // k
	oLetters[108] = new Array(255, 128, 128, 128, 128, 0); // l
	oLetters[109] = new Array(255,   6,   8,   6, 255, 0); // m
	oLetters[110] = new Array(255,   6,  24,  96, 255, 0); // n
	oLetters[111] = new Array(126, 129, 129, 129, 126, 0); // o
	oLetters[112] = new Array(255,   9,   9,   9,   6, 0); // p
	oLetters[113] = new Array(126, 129, 161, 193, 254, 0); // q
	oLetters[114] = new Array(255,  25,  41,  73, 134, 0); // r
	oLetters[115] = new Array( 70, 137, 153, 145,  98, 0); // s
	oLetters[116] = new Array(  1,   1, 255,   1,   1, 0); // t
	oLetters[117] = new Array(127, 128, 128, 128, 127, 0); // u
	oLetters[118] = new Array(  7,  56, 192,  56,   7, 0); // v
	oLetters[119] = new Array( 15, 240,  15, 240,  15, 0); // w
	oLetters[120] = new Array(195,  36,  24,  36, 195, 0); // x
	oLetters[121] = new Array(  3,  12, 240,  12,   3, 0); // y
	oLetters[122] = new Array(129, 225, 153, 135, 129, 0); // z
	oLetters[123] = new Array(  0,  16, 108, 130,   0, 0); // {
	oLetters[124] = new Array(  0,   0, 255,   0,   0, 0); // |
	oLetters[125] = new Array(  0, 130, 108,  16,   0, 0); // }
	oLetters[126] = new Array( 12,   2,   4,   8,   6, 0); // ~
}

function CreateColorArray()
{
	oColors = new Array();
	oColors[ 66] = new Array(  0,   0, 255, 1); // B (blinking blue)
	oColors[ 71] = new Array(  0, 255,   0, 1); // G (blinking green)
	oColors[ 79] = new Array(255, 128,   0, 1); // O (blinking orange)
	oColors[ 80] = new Array(255,   0, 255, 1); // P (blinking purple)
	oColors[ 82] = new Array(255,   0,   0, 1); // R (blinking red)
	oColors[ 87] = new Array(255, 255, 255, 1); // W (blinking white)
	oColors[ 89] = new Array(255, 255,   0, 1); // Y (blinking yellow)
	oColors[ 98] = new Array(  0,   0, 255, 0); // b (blue)
	oColors[103] = new Array(  0, 255,   0, 0); // g (green)
	oColors[111] = new Array(255, 128,   0, 0); // o (orange)
	oColors[112] = new Array(255,   0, 255, 0); // p (purple)
	oColors[114] = new Array(255,   0,   0, 0); // r (red)
	oColors[119] = new Array(255, 255, 255, 0); // w (white)
	oColors[121] = new Array(255, 255,   0, 0); // y (yellow)

	oColorPerf = new Array();
	oColorPerf[ 66] = PerfMonDisp.CreateInstance(idMarqueeData, 66,  "Blinking Blue");		// B (blinking blue)
	oColorPerf[ 71] = PerfMonDisp.CreateInstance(idMarqueeData, 71,  "Blinking Green");		// G (blinking green)
	oColorPerf[ 79] = PerfMonDisp.CreateInstance(idMarqueeData, 79,  "Blinking Orange");	// O (blinking orange)
	oColorPerf[ 80] = PerfMonDisp.CreateInstance(idMarqueeData, 80,  "Blinking Purple");	// P (blinking purple)
	oColorPerf[ 82] = PerfMonDisp.CreateInstance(idMarqueeData, 82,  "Blinking Red");		// R (blinking red)
	oColorPerf[ 87] = PerfMonDisp.CreateInstance(idMarqueeData, 87,  "Blinking White");		// W (blinking white)
	oColorPerf[ 89] = PerfMonDisp.CreateInstance(idMarqueeData, 89,  "Blinking Yellow");	// Y (blinking yellow)
	oColorPerf[ 98] = PerfMonDisp.CreateInstance(idMarqueeData, 98,  "Blue");				// b (blue)
	oColorPerf[103] = PerfMonDisp.CreateInstance(idMarqueeData, 103, "Green");				// g (green)
	oColorPerf[111] = PerfMonDisp.CreateInstance(idMarqueeData, 111, "Orange");				// o (orange)
	oColorPerf[112] = PerfMonDisp.CreateInstance(idMarqueeData, 112, "Purple");				// p (purple)
	oColorPerf[114] = PerfMonDisp.CreateInstance(idMarqueeData, 114, "Red");				// r (red)
	oColorPerf[119] = PerfMonDisp.CreateInstance(idMarqueeData, 119, "White");				// w (white)
	oColorPerf[121] = PerfMonDisp.CreateInstance(idMarqueeData, 121, "Yellow");				// y (yellow)
}

function ParseControlString()
{
	var strColor = "g"; // default color
	for (var i=0; i<strControl.length; i++)
	{
		if (strControl.charAt(i) == "#")
		{
			if (i == strControl.length-1)
			{
				strMessage += strControl.charAt(i);
				strColors += strColor;
			}
			else
			{
				i++;
				if (typeof(oColors[strControl.charCodeAt(i)]) == "object")
					strColor = strControl.charAt(i)
				else
				{
					strMessage += strControl.charAt(i);
					strColors += strColor;
				}
			}
		}
		else
		{
			strMessage += strControl.charAt(i);
			strColors += strColor;
		}
	}
}

function SetupPerfmonData()
{
	var PERF_SIZE_DWORD             = 0x00000000;
	var PERF_SIZE_LARGE             = 0x00000100;

	var PERF_DETAIL_NOVICE          = 100; // The uninformed can understand it
	var PERF_DETAIL_ADVANCED        = 200; // For the advanced user
	var PERF_DETAIL_EXPERT          = 300; // For the expert user
	var PERF_DETAIL_WIZARD          = 400; // For the system designer

	// 32-bit Counter.  Divide delta by delta time.  Display suffix: "/sec"
	var PERF_COUNTER_COUNTER        = 0x10410400;

	// Indicates the data is a counter  which should not be
	// time averaged on display (such as an error counter on a serial line)
	// Display as is.  No Display Suffix.
	var PERF_COUNTER_RAWCOUNT       = 0x00010000;

	var LANG_ENGLISH = 9;

	PerfMonDisp.AppName = "Marquee";
	if (!PerfMonDisp.Initialize())
	{
		PerfMonDisp.PrepRegister();
		PerfMonDisp.AddObjectDefinition("Marquee Data", "Perfmon Data exposed from the Marquee sample", PERF_DETAIL_NOVICE, 0, false);
		PerfMonDisp.AddCounterDefinition("Frames", "Number of screen refreshes per second", PERF_DETAIL_NOVICE, PERF_COUNTER_COUNTER, 0, 0);
		PerfMonDisp.AddCounterDefinition("Balls Drawn", "number of balls drawn per second displaying the marquee", PERF_DETAIL_NOVICE, PERF_COUNTER_COUNTER, 0, -2);
		PerfMonDisp.Register();
		PerfMonDisp.RegisterStrings(LANG_ENGLISH);

		// register other languages with PrepRegister/Add.../RegisterStrings
		// don't repeat the call to Register()

		PerfMonDisp.Initialize();
	}

	idMarqueeData = PerfMonDisp.GetObjectId("Marquee Data")
	idFPS = PerfMonDisp.GetCounterId(idMarqueeData, "Frames")
	idBalls = PerfMonDisp.GetCounterId(idMarqueeData, "Balls Drawn")

	oMarqueePerf = PerfMonDisp.CreateInstance(idMarqueeData, 1, "Total");
}
