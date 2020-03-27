
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 6.00.0342 */
/* at Tue May 22 05:55:41 2001
 */
/* Compiler settings for Math.idl:
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

MIDL_DEFINE_GUID(IID, IID_IAdder,0x8E127E6C,0x16B3,0x44B4,0x89,0xCE,0x52,0x0C,0x90,0x58,0xA8,0xC1);


MIDL_DEFINE_GUID(IID, IID_ISubtracter,0xD6FB16C3,0x18F8,0x421E,0x8B,0xC4,0xEB,0xAA,0x1B,0xC5,0x3D,0x72);


MIDL_DEFINE_GUID(IID, LIBID_MathLib,0xA54A8EDB,0xEA0C,0x4FFA,0xB6,0x4A,0xC1,0x9C,0xB6,0x63,0xA2,0xEB);


MIDL_DEFINE_GUID(CLSID, CLSID_Adder,0xFF381FA0,0x7EA5,0x4F6F,0x9D,0xD1,0xDA,0xDE,0x83,0x24,0x9E,0xD5);


MIDL_DEFINE_GUID(CLSID, CLSID_Subtracter,0x843DBE57,0x63C3,0x47C4,0xAF,0x6E,0x82,0x9C,0x91,0xA0,0xA2,0xA8);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



#endif /* !defined(_M_IA64) && !defined(_M_AMD64)*/

