// PkgCmdID.h
// Command IDs used in defining command bars
//

// do not use #pragma once - used by ctc compiler
#ifndef __PKGCMDID_H_
#define __PKGCMDID_H_

#define IDG_SYN_MAIN 		0x0100
#define IDG_SYN_PAGE		0x0200
#define	IDG_SYN_CELLS		0x0300
#define IDG_SYN_BANDS		0x0400


#define IDM_SYN_MAIN		0x0500
#define IDM_SYN_PAGE		0x0600
#define IDM_SYN_CELLS		0x0700
#define IDM_SYN_BANDS		0x0800

#define IDG_SYN_CELLMOVE	0x0900
#define IDG_SYN_CELLSPLIT	0x1000
#define IDG_SYN_CELLSHAPE	0x1100
#define IDG_SYN_CELLPRO		0x1200
#define IDG_SYN_STYLE		0x1300
#define IDG_SYN_PREVIEW		0x1400



#define icmd_PageColor		0x0101
#define icmd_PageBackground	0x0102
#define icmd_AddCell		0x0103
#define icmd_DeleteCell		0x0104
#define icmd_CellMoveLeft	0x0105
#define icmd_CellMoveRight	0x0106
#define icmd_SplitCell		0x0107
#define icmd_MergeCellsHor	0x0108
#define icmd_MergeCellsVer	0x0109
#define icmd_CellShape		0x0110
#define icmd_CellProperties	0x0111
#define icmd_AddBand		0x0112
#define icmd_Deleteband		0x0113
#define icmd_BandMoveUp		0x0114
#define icmd_BandMoveDown	0x0115
#define icmd_Styles			0x0116
#define icmd_Preview		0x0117




#endif // __PKGCMDID_H_
