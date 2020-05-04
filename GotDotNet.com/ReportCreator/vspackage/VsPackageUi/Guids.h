/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind, 
    it is not recommended for use in a production environment.
***************************************************************************/

// Guids.h
//

// do not use #pragma once - used by ctc compiler
#ifndef __GUIDS_H_
#define __GUIDS_H_

#ifndef _CTC_GUIDS_


#define guidVsPackagePkg   CLSID_VsPackagePackage

// Command set guid for our commands (used with IOleCommandTarget)
// {2713e020-c2b7-4634-a436-5e8d4fbb631f}
DEFINE_GUID(guidVsPackageCmdSet, 
0x2713E020, 0xC2B7, 0x4634, 0xA4, 0x36, 0x5E, 0x8D, 0x4F, 0xBB, 0x63, 0x1F);

#else  // _CTC_GUIDS


#define guidVsPackagePkg      { 0x9AA75229, 0x9D91, 0x4841, { 0x8A, 0x43, 0x45, 0xF0, 0x30, 0x18, 0xA2, 0x50 } }
#define guidVsPackageCmdSet	  { 0x2713E020, 0xC2B7, 0x4634, { 0xA4, 0x36, 0x5E, 0x8D, 0x4F, 0xBB, 0x63, 0x1F } }

#endif // _CTC_GUIDS_

#endif // __GUIDS_H_
