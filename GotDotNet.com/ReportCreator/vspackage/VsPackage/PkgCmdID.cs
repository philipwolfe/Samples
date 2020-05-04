
/***************************************************************************
         Copyright (c) Microsoft CorporationAll rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind
    it is not recommended for use in a production environment.
***************************************************************************/

// PkgCmdID.cs
// MUST match PkgCmdID.h (for the satellite DLL)
using System;

namespace Vsip.VsPackage
{
    class PkgCmdIDList
    {
		public const uint icmd_PageColor=		0x0101;
		public const uint icmd_PageBackground=	0x0102;
		public const uint icmd_AddCell=			0x0103;
		public const uint icmd_DeleteCell=		0x0104;
		public const uint icmd_CellMoveLeft=	0x0105;
		public const uint icmd_CellMoveRight=	0x0106;
		public const uint icmd_SplitCell=		0x0107;
		public const uint icmd_MergeCellsHor=	0x0108;
		public const uint icmd_MergeCellsVer=	0x0109;
		public const uint icmd_CellShape=		0x0110;
		public const uint icmd_CellProperties=	0x0111;
		public const uint icmd_AddBand=			0x0112;
		public const uint icmd_Deleteband=		0x0113;
		public const uint icmd_BandMoveUp=		0x0114;
		public const uint icmd_BandMoveDown=	0x0115;
		public const uint icmd_Styles=			0x0116;
		public const uint icmd_Preview=			0x0117;		

    };
}