
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Sat Apr 05 14:18:19 2003
 */
/* Compiler settings for MMCFormsShim.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#if !defined(_M_IA64) && !defined(_M_AMD64)

#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_IMMCFormsShimCtrl,0x85BCEB7D,0x7628,0x4BEB,0x8A,0x00,0x56,0x41,0x47,0x02,0xFD,0xC8);


MIDL_DEFINE_GUID(IID, IID_IMMCFormsShim,0xB8F882F8,0x3D93,0x401c,0xA4,0xD4,0xE3,0xA9,0x94,0x3E,0x85,0x8D);


MIDL_DEFINE_GUID(IID, LIBID_MMCFormsShimLib,0x222A2FC0,0x81A9,0x4B3B,0x92,0xB6,0x1D,0x9E,0x06,0x91,0xBA,0xA8);


MIDL_DEFINE_GUID(IID, IID_IWin32Window,0x458AB8A2,0xA1EA,0x4D7B,0x8E,0xBE,0xDE,0xE5,0xD3,0xD9,0x44,0x2C);


MIDL_DEFINE_GUID(CLSID, CLSID_MMCFormsShimCtrl,0x97AD17DA,0x70A5,0x45B9,0x9E,0x10,0xDE,0xAA,0x3D,0x26,0xE1,0x7D);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

