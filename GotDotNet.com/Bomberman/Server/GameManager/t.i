#line 1 "t.cpp"


#line 1 "d:\\liuxiong\\bombman\\gamemanager\\stdafx.h"




#pragma once

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"







#pragma pack(push,8)
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


extern "C" {
#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"







#line 46 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"
#line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"








#line 56 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"
#line 57 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"






#line 64 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"






typedef __w64 unsigned int   size_t;
#line 72 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

#line 74 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"



typedef unsigned short wchar_t;

#line 80 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"



typedef unsigned short wint_t;
typedef unsigned short wctype_t;

#line 87 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"









typedef char *  va_list;
#line 98 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

#line 100 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

























struct _iobuf {
        char *_ptr;
        int   _cnt;
        char *_base;
        int   _flag;
        int   _file;
        int   _charbuf;
        int   _bufsiz;
        char *_tmpfname;
        };
typedef struct _iobuf FILE;

#line 138 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"










#line 149 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"



































#line 185 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"
#line 186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"





 extern FILE _iob[];
#line 193 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"










#line 204 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


typedef __int64 fpos_t;







#line 215 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"
#line 216 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


#line 219 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"




























 int __cdecl _filbuf(FILE *);
 int __cdecl _flsbuf(int, FILE *);




 FILE * __cdecl _fsopen(const char *, const char *, int);
#line 255 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

 void __cdecl clearerr(FILE *);
 int __cdecl fclose(FILE *);
 int __cdecl _fcloseall(void);




 FILE * __cdecl _fdopen(int, const char *);
#line 265 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

 int __cdecl feof(FILE *);
 int __cdecl ferror(FILE *);
 int __cdecl fflush(FILE *);
 int __cdecl fgetc(FILE *);
 int __cdecl _fgetchar(void);
 int __cdecl fgetpos(FILE *, fpos_t *);
 char * __cdecl fgets(char *, int, FILE *);




 int __cdecl _fileno(FILE *);
#line 279 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

 int __cdecl _flushall(void);
 FILE * __cdecl fopen(const char *, const char *);
 int __cdecl fprintf(FILE *, const char *, ...);
 int __cdecl fputc(int, FILE *);
 int __cdecl _fputchar(int);
 int __cdecl fputs(const char *, FILE *);
 size_t __cdecl fread(void *, size_t, size_t, FILE *);
 FILE * __cdecl freopen(const char *, const char *, FILE *);
 int __cdecl fscanf(FILE *, const char *, ...);
 int __cdecl fsetpos(FILE *, const fpos_t *);
 int __cdecl fseek(FILE *, long, int);
 long __cdecl ftell(FILE *);
 size_t __cdecl fwrite(const void *, size_t, size_t, FILE *);
 int __cdecl getc(FILE *);
 int __cdecl getchar(void);
 int __cdecl _getmaxstdio(void);
 char * __cdecl gets(char *);
 int __cdecl _getw(FILE *);
 void __cdecl perror(const char *);
 int __cdecl _pclose(FILE *);
 FILE * __cdecl _popen(const char *, const char *);
 int __cdecl printf(const char *, ...);
 int __cdecl putc(int, FILE *);
 int __cdecl putchar(int);
 int __cdecl puts(const char *);
 int __cdecl _putw(int, FILE *);
 int __cdecl remove(const char *);
 int __cdecl rename(const char *, const char *);
 void __cdecl rewind(FILE *);
 int __cdecl _rmtmp(void);
 int __cdecl scanf(const char *, ...);
 void __cdecl setbuf(FILE *, char *);
 int __cdecl _setmaxstdio(int);
 int __cdecl setvbuf(FILE *, char *, int, size_t);
 int __cdecl _snprintf(char *, size_t, const char *, ...);
 int __cdecl sprintf(char *, const char *, ...);
 int __cdecl _scprintf(const char *, ...);
 int __cdecl sscanf(const char *, const char *, ...);
 int __cdecl _snscanf(const char *, size_t, const char *, ...);
 char * __cdecl _tempnam(const char *, const char *);
 FILE * __cdecl tmpfile(void);
 char * __cdecl tmpnam(char *);
 int __cdecl ungetc(int, FILE *);
 int __cdecl _unlink(const char *);
 int __cdecl vfprintf(FILE *, const char *, va_list);
 int __cdecl vprintf(const char *, va_list);
 int __cdecl _vsnprintf(char *, size_t, const char *, va_list);
 int __cdecl vsprintf(char *, const char *, va_list);
 int __cdecl _vscprintf(const char *, va_list);







#line 337 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"




 FILE * __cdecl _wfsopen(const wchar_t *, const wchar_t *, int);
#line 343 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

 wint_t __cdecl fgetwc(FILE *);
 wint_t __cdecl _fgetwchar(void);
 wint_t __cdecl fputwc(wchar_t, FILE *);
 wint_t __cdecl _fputwchar(wchar_t);
 wint_t __cdecl getwc(FILE *);
 wint_t __cdecl getwchar(void);
 wint_t __cdecl putwc(wchar_t, FILE *);
 wint_t __cdecl putwchar(wchar_t);
 wint_t __cdecl ungetwc(wint_t, FILE *);

 wchar_t * __cdecl fgetws(wchar_t *, int, FILE *);
 int __cdecl fputws(const wchar_t *, FILE *);
 wchar_t * __cdecl _getws(wchar_t *);
 int __cdecl _putws(const wchar_t *);

 int __cdecl fwprintf(FILE *, const wchar_t *, ...);
 int __cdecl wprintf(const wchar_t *, ...);
 int __cdecl _snwprintf(wchar_t *, size_t, const wchar_t *, ...);
 int __cdecl swprintf(wchar_t *, const wchar_t *, ...);
 int __cdecl _scwprintf(const wchar_t *, ...);
 int __cdecl vfwprintf(FILE *, const wchar_t *, va_list);
 int __cdecl vwprintf(const wchar_t *, va_list);
 int __cdecl _vsnwprintf(wchar_t *, size_t, const wchar_t *, va_list);
 int __cdecl vswprintf(wchar_t *, const wchar_t *, va_list);
 int __cdecl _vscwprintf(const wchar_t *, va_list);
 int __cdecl fwscanf(FILE *, const wchar_t *, ...);
 int __cdecl swscanf(const wchar_t *, const wchar_t *, ...);
 int __cdecl _snwscanf(const wchar_t *, size_t, const wchar_t *, ...);
 int __cdecl wscanf(const wchar_t *, ...);






 FILE * __cdecl _wfdopen(int, const wchar_t *);
 FILE * __cdecl _wfopen(const wchar_t *, const wchar_t *);
 FILE * __cdecl _wfreopen(const wchar_t *, const wchar_t *, FILE *);
 void __cdecl _wperror(const wchar_t *);
 FILE * __cdecl _wpopen(const wchar_t *, const wchar_t *);
 int __cdecl _wremove(const wchar_t *);
 wchar_t * __cdecl _wtempnam(const wchar_t *, const wchar_t *);
 wchar_t * __cdecl _wtmpnam(wchar_t *);



#line 391 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


#line 394 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"





















#line 416 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"










 int __cdecl fcloseall(void);
 FILE * __cdecl fdopen(int, const char *);
 int __cdecl fgetchar(void);
 int __cdecl fileno(FILE *);
 int __cdecl flushall(void);
 int __cdecl fputchar(int);
 int __cdecl getw(FILE *);
 int __cdecl putw(int, FILE *);
 int __cdecl rmtmp(void);
 char * __cdecl tempnam(const char *, const char *);
 int __cdecl unlink(const char *);

#line 439 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


}
#line 443 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"


#pragma pack(pop)
#line 447 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"

#line 449 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdio.h"
#line 8 "d:\\liuxiong\\bombman\\gamemanager\\stdafx.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"


























#line 28 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"





#pragma once
#line 35 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

















































#line 85 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"




















#line 106 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#line 110 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#line 114 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#line 118 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#line 122 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"





#line 128 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"




#line 133 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 134 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"







#line 142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 143 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#pragma warning(disable:4514)

#pragma warning(disable:4103)
#line 150 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#pragma warning(push)
#line 153 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#pragma warning(disable:4001)
#pragma warning(disable:4201)
#pragma warning(disable:4214)
#line 157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"







#pragma pack(push,8)
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"


extern "C" {
#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"


















#line 57 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"





typedef enum _EXCEPTION_DISPOSITION {
    ExceptionContinueExecution,
    ExceptionContinueSearch,
    ExceptionNestedException,
    ExceptionCollidedUnwind
} EXCEPTION_DISPOSITION;











struct _EXCEPTION_RECORD;
struct _CONTEXT;

EXCEPTION_DISPOSITION __cdecl _except_handler (
    struct _EXCEPTION_RECORD *ExceptionRecord,
    void * EstablisherFrame,
    struct _CONTEXT *ContextRecord,
    void * DispatcherContext
    );






























#line 119 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"















unsigned long __cdecl _exception_code(void);
void *        __cdecl _exception_info(void);
int           __cdecl _abnormal_termination(void);

#line 139 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"













}
#line 154 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"


#pragma pack(pop)
#line 158 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"

#line 160 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\excpt.h"
#line 158 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"







#pragma pack(push,8)
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"


extern "C" {
#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"








#line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"





typedef __w64 unsigned int   uintptr_t;
#line 54 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"

#line 56 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"

















#line 74 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"











#line 86 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"


#line 89 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"



extern void __cdecl __va_start(va_list*, ...);
extern void * __cdecl __va_arg(va_list*, ...);
extern void __cdecl __va_end(va_list*);









































































































#line 201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"


}
#line 205 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"


#pragma pack(pop)
#line 209 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"

#line 211 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdarg.h"
#line 159 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 160 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"















#line 17 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"












extern "C" {
#line 32 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"











typedef unsigned long ULONG;
typedef ULONG *PULONG;
typedef unsigned short USHORT;
typedef USHORT *PUSHORT;
typedef unsigned char UCHAR;
typedef UCHAR *PUCHAR;
typedef char *PSZ;
#line 51 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"













#line 65 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 69 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 73 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 77 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 81 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"











#line 93 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"






#line 100 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
#line 105 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"


























#line 132 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"







#line 140 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

typedef unsigned long       DWORD;
typedef int                 BOOL;
typedef unsigned char       BYTE;
typedef unsigned short      WORD;
typedef float               FLOAT;
typedef FLOAT               *PFLOAT;
typedef BOOL            *PBOOL;
typedef BOOL             *LPBOOL;
typedef BYTE            *PBYTE;
typedef BYTE             *LPBYTE;
typedef int             *PINT;
typedef int              *LPINT;
typedef WORD            *PWORD;
typedef WORD             *LPWORD;
typedef long             *LPLONG;
typedef DWORD           *PDWORD;
typedef DWORD            *LPDWORD;
typedef void             *LPVOID;
typedef const void       *LPCVOID;

typedef int                 INT;
typedef unsigned int        UINT;
typedef unsigned int        *PUINT;


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





















extern "C" {
#line 24 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"














#pragma once
#line 17 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"






#line 24 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"



extern "C" {
#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"


















#line 48 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"

















 extern const unsigned short _ctype[];
 extern const unsigned short _wctype[];
 extern const unsigned short *_pctype;
 extern const wctype_t *_pwctype;
#line 70 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"










                                













 int __cdecl _isctype(int, int);
 int __cdecl isalpha(int);
 int __cdecl isupper(int);
 int __cdecl islower(int);
 int __cdecl isdigit(int);
 int __cdecl isxdigit(int);
 int __cdecl isspace(int);
 int __cdecl ispunct(int);
 int __cdecl isalnum(int);
 int __cdecl isprint(int);
 int __cdecl isgraph(int);
 int __cdecl iscntrl(int);
 int __cdecl toupper(int);
 int __cdecl tolower(int);
 int __cdecl _tolower(int);
 int __cdecl _toupper(int);
 int __cdecl __isascii(int);
 int __cdecl __toascii(int);
 int __cdecl __iscsymf(int);
 int __cdecl __iscsym(int);

#line 116 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"







 int __cdecl iswalpha(wint_t);
 int __cdecl iswupper(wint_t);
 int __cdecl iswlower(wint_t);
 int __cdecl iswdigit(wint_t);
 int __cdecl iswxdigit(wint_t);
 int __cdecl iswspace(wint_t);
 int __cdecl iswpunct(wint_t);
 int __cdecl iswalnum(wint_t);
 int __cdecl iswprint(wint_t);
 int __cdecl iswgraph(wint_t);
 int __cdecl iswcntrl(wint_t);
 int __cdecl iswascii(wint_t);
 int __cdecl isleadbyte(int);

 wchar_t __cdecl towupper(wchar_t);
 wchar_t __cdecl towlower(wchar_t);

 int __cdecl iswctype(wint_t, wctype_t);


 int __cdecl is_wctype(wint_t, wctype_t);



#line 148 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"











 extern int __mb_cur_max;

 int __cdecl ___mb_cur_max_func(void);
#line 163 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"





 int __cdecl _chvalidator(int, int);



#line 173 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"






















































































#line 260 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"

#line 262 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"








#line 271 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"
















#line 288 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"

#line 290 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"


}
#line 294 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"


#line 297 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ctype.h"
#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"








#line 42 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


#line 45 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





#line 51 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


#line 54 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"









#line 64 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 68 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"








#line 77 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 81 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


















#line 100 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef unsigned long POINTER_64_INT;
#line 107 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 113 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 115 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"






















#pragma once
#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"


extern "C" {
#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"

typedef signed char         INT8, *PINT8;
typedef signed short        INT16, *PINT16;
typedef signed int          INT32, *PINT32;
typedef signed __int64      INT64, *PINT64;
typedef unsigned char       UINT8, *PUINT8;
typedef unsigned short      UINT16, *PUINT16;
typedef unsigned int        UINT32, *PUINT32;
typedef unsigned __int64    UINT64, *PUINT64;





typedef signed int LONG32, *PLONG32;





typedef unsigned int ULONG32, *PULONG32;
typedef unsigned int DWORD32, *PDWORD32;







#line 59 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"

















#line 77 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"











#line 89 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"
    typedef __w64 int INT_PTR, *PINT_PTR;
    typedef __w64 unsigned int UINT_PTR, *PUINT_PTR;

    typedef __w64 long LONG_PTR, *PLONG_PTR;
    typedef __w64 unsigned long ULONG_PTR, *PULONG_PTR;

    

#line 98 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"
#line 99 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"



























































































































































typedef unsigned short UHALF_PTR, *PUHALF_PTR;
typedef short HALF_PTR, *PHALF_PTR;
typedef __w64 long SHANDLE_PTR;
typedef __w64 unsigned long HANDLE_PTR;
















#line 275 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"























typedef ULONG_PTR SIZE_T, *PSIZE_T;
typedef LONG_PTR SSIZE_T, *PSSIZE_T;





typedef ULONG_PTR DWORD_PTR, *PDWORD_PTR;





typedef __int64 LONG64, *PLONG64;






typedef unsigned __int64 ULONG64, *PULONG64;
typedef unsigned __int64 DWORD64, *PDWORD64;





typedef ULONG_PTR KAFFINITY;
typedef KAFFINITY *PKAFFINITY;


}
#line 331 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"

#line 333 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\basetsd.h"
#line 117 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 124 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 131 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 132 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 139 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 140 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 144 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 151 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 152 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 159 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 160 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 167 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 168 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 175 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 176 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#line 181 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 183 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 184 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






#line 191 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 192 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"








#line 201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


typedef void *PVOID;
typedef void *  PVOID64;







#line 214 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
















#line 231 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"








typedef char CHAR;
typedef short SHORT;
typedef long LONG;
#line 243 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






typedef wchar_t WCHAR;    



#line 254 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef WCHAR *PWCHAR;
typedef WCHAR *LPWCH, *PWCH;
typedef const WCHAR *LPCWCH, *PCWCH;
typedef WCHAR *NWPSTR;
typedef WCHAR *LPWSTR, *PWSTR;
typedef WCHAR  *LPUWSTR, *PUWSTR;

typedef const WCHAR *LPCWSTR, *PCWSTR;
typedef const WCHAR  *LPCUWSTR, *PCUWSTR;




typedef CHAR *PCHAR;
typedef CHAR *LPCH, *PCH;

typedef const CHAR *LPCCH, *PCCH;
typedef CHAR *NPSTR;
typedef CHAR *LPSTR, *PSTR;
typedef const CHAR *LPCSTR, *PCSTR;























typedef char TCHAR, *PTCHAR;
typedef unsigned char TBYTE , *PTBYTE ;

#line 302 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef LPSTR LPTCH, PTCH;
typedef LPSTR PTSTR, LPTSTR, PUTSTR, LPUTSTR;
typedef LPCSTR PCTSTR, LPCTSTR, PCUTSTR, LPCUTSTR;


#line 309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



typedef SHORT *PSHORT;  
typedef LONG *PLONG;    


typedef void *HANDLE;




#line 322 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
typedef HANDLE *PHANDLE;





typedef BYTE   FCHAR;
typedef WORD   FSHORT;
typedef DWORD  FLONG;





typedef LONG HRESULT;

#line 339 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


    


#line 345 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"









#line 355 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"













#line 369 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
















typedef char CCHAR;          
typedef DWORD LCID;         
typedef PDWORD PLCID;       
typedef WORD   LANGID;      






















#line 412 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
typedef struct _FLOAT128 {
    __int64 LowPart;
    __int64 HighPart;
} FLOAT128;

typedef FLOAT128 *PFLOAT128;









typedef __int64 LONGLONG;
typedef unsigned __int64 ULONGLONG;














#line 444 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef LONGLONG *PLONGLONG;
typedef ULONGLONG *PULONGLONG;



typedef LONGLONG USN;



#line 455 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
typedef union _LARGE_INTEGER {
    struct {
        DWORD LowPart;
        LONG HighPart;
    };
    struct {
        DWORD LowPart;
        LONG HighPart;
    } u;
#line 465 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
    LONGLONG QuadPart;
} LARGE_INTEGER;

typedef LARGE_INTEGER *PLARGE_INTEGER;



#line 473 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
typedef union _ULARGE_INTEGER {
    struct {
        DWORD LowPart;
        DWORD HighPart;
    };
    struct {
        DWORD LowPart;
        DWORD HighPart;
    } u;
#line 483 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
    ULONGLONG QuadPart;
} ULARGE_INTEGER;

typedef ULARGE_INTEGER *PULARGE_INTEGER;








typedef struct _LUID {
    DWORD LowPart;
    LONG HighPart;
} LUID, *PLUID;


typedef ULONGLONG  DWORDLONG;
typedef DWORDLONG *PDWORDLONG;






















#line 526 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"































































#line 590 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"











ULONGLONG
__stdcall
Int64ShllMod32 (
    ULONGLONG Value,
    DWORD ShiftCount
    );

LONGLONG
__stdcall
Int64ShraMod32 (
    LONGLONG Value,
    DWORD ShiftCount
    );

ULONGLONG
__stdcall
Int64ShrlMod32 (
    ULONGLONG Value,
    DWORD ShiftCount
    );


#pragma warning(push)
#line 625 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#pragma warning(disable:4035)               

__inline ULONGLONG
__stdcall
Int64ShllMod32 (
    ULONGLONG Value,
    DWORD ShiftCount
    )
{
    __asm    {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shld    edx, eax, cl
        shl     eax, cl
    }
}

__inline LONGLONG
__stdcall
Int64ShraMod32 (
    LONGLONG Value,
    DWORD ShiftCount
    )
{
    __asm {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shrd    eax, edx, cl
        sar     edx, cl
    }
}

__inline ULONGLONG
__stdcall
Int64ShrlMod32 (
    ULONGLONG Value,
    DWORD ShiftCount
    )
{
    __asm    {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shrd    eax, edx, cl
        shr     edx, cl
    }
}


#pragma warning(pop)


#line 680 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




























































#line 741 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef BYTE  BOOLEAN;           
typedef BOOLEAN *PBOOLEAN;       





typedef struct _LIST_ENTRY {
   struct _LIST_ENTRY *Flink;
   struct _LIST_ENTRY *Blink;
} LIST_ENTRY, *PLIST_ENTRY, * PRLIST_ENTRY;






typedef struct _SINGLE_LIST_ENTRY {
    struct _SINGLE_LIST_ENTRY *Next;
} SINGLE_LIST_ENTRY, *PSINGLE_LIST_ENTRY;





typedef struct LIST_ENTRY32 {
    DWORD Flink;
    DWORD Blink;
} LIST_ENTRY32;
typedef LIST_ENTRY32 *PLIST_ENTRY32;

typedef struct LIST_ENTRY64 {
    ULONGLONG Flink;
    ULONGLONG Blink;
} LIST_ENTRY64;
typedef LIST_ENTRY64 *PLIST_ENTRY64;


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"




















#line 22 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
typedef struct _GUID {
    unsigned long  Data1;
    unsigned short Data2;
    unsigned short Data3;
    unsigned char  Data4[ 8 ];
} GUID;
#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"




































#line 67 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"








typedef GUID *LPGUID;
#line 77 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"



typedef const GUID *LPCGUID;
#line 82 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"




typedef GUID IID;
typedef IID *LPIID;


typedef GUID CLSID;
typedef CLSID *LPCLSID;


typedef GUID FMTID;
typedef FMTID *LPFMTID;







#line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"







#line 112 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 113 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"







#line 121 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 122 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"







#line 130 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 131 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"







#line 139 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 140 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"

#line 142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"




#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"



extern "C" {
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"








#line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"















#line 55 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"




















#line 76 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"
























        void *  __cdecl memcpy(void *, const void *, size_t);
        int     __cdecl memcmp(const void *, const void *, size_t);
        void *  __cdecl memset(void *, int, size_t);
        char *  __cdecl _strset(char *, int);
        char *  __cdecl strcpy(char *, const char *);
        char *  __cdecl strcat(char *, const char *);
        int     __cdecl strcmp(const char *, const char *);
        size_t  __cdecl strlen(const char *);
#line 109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"
 void *  __cdecl _memccpy(void *, const void *, int, size_t);
 void *  __cdecl memchr(const void *, int, size_t);
 int     __cdecl _memicmp(const void *, const void *, size_t);



#line 116 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"
 void *  __cdecl memmove(void *, const void *, size_t);
#line 118 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"


 char *  __cdecl strchr(const char *, int);
 int     __cdecl _strcmpi(const char *, const char *);
 int     __cdecl _stricmp(const char *, const char *);
 int     __cdecl strcoll(const char *, const char *);
 int     __cdecl _stricoll(const char *, const char *);
 int     __cdecl _strncoll(const char *, const char *, size_t);
 int     __cdecl _strnicoll(const char *, const char *, size_t);
 size_t  __cdecl strcspn(const char *, const char *);
 char *  __cdecl _strdup(const char *);
 char *  __cdecl _strerror(const char *);
 char *  __cdecl strerror(int);
 char *  __cdecl _strlwr(char *);
 char *  __cdecl strncat(char *, const char *, size_t);
 int     __cdecl strncmp(const char *, const char *, size_t);
 int     __cdecl _strnicmp(const char *, const char *, size_t);
 char *  __cdecl strncpy(char *, const char *, size_t);
 char *  __cdecl _strnset(char *, int, size_t);
 char *  __cdecl strpbrk(const char *, const char *);
 char *  __cdecl strrchr(const char *, int);
 char *  __cdecl _strrev(char *);
 size_t  __cdecl strspn(const char *, const char *);
 char *  __cdecl strstr(const char *, const char *);
 char *  __cdecl strtok(char *, const char *);
 char *  __cdecl _strupr(char *);
 size_t  __cdecl strxfrm (char *, const char *, size_t);





 void * __cdecl memccpy(void *, const void *, int, size_t);
 int __cdecl memicmp(const void *, const void *, size_t);
 int __cdecl strcmpi(const char *, const char *);
 int __cdecl stricmp(const char *, const char *);
 char * __cdecl strdup(const char *);
 char * __cdecl strlwr(char *);
 int __cdecl strnicmp(const char *, const char *, size_t);
 char * __cdecl strnset(char *, int, size_t);
 char * __cdecl strrev(char *);
        char * __cdecl strset(char *, int);
 char * __cdecl strupr(char *);

#line 163 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"






 wchar_t * __cdecl wcscat(wchar_t *, const wchar_t *);
 wchar_t * __cdecl wcschr(const wchar_t *, wchar_t);
 int __cdecl wcscmp(const wchar_t *, const wchar_t *);
 wchar_t * __cdecl wcscpy(wchar_t *, const wchar_t *);
 size_t __cdecl wcscspn(const wchar_t *, const wchar_t *);
 size_t __cdecl wcslen(const wchar_t *);
 wchar_t * __cdecl wcsncat(wchar_t *, const wchar_t *, size_t);
 int __cdecl wcsncmp(const wchar_t *, const wchar_t *, size_t);
 wchar_t * __cdecl wcsncpy(wchar_t *, const wchar_t *, size_t);
 wchar_t * __cdecl wcspbrk(const wchar_t *, const wchar_t *);
 wchar_t * __cdecl wcsrchr(const wchar_t *, wchar_t);
 size_t __cdecl wcsspn(const wchar_t *, const wchar_t *);
 wchar_t * __cdecl wcsstr(const wchar_t *, const wchar_t *);
 wchar_t * __cdecl wcstok(wchar_t *, const wchar_t *);
 wchar_t * __cdecl _wcserror(int);
 wchar_t * __cdecl __wcserror(const wchar_t *);

 wchar_t * __cdecl _wcsdup(const wchar_t *);
 int __cdecl _wcsicmp(const wchar_t *, const wchar_t *);
 int __cdecl _wcsnicmp(const wchar_t *, const wchar_t *, size_t);
 wchar_t * __cdecl _wcsnset(wchar_t *, wchar_t, size_t);
 wchar_t * __cdecl _wcsrev(wchar_t *);
 wchar_t * __cdecl _wcsset(wchar_t *, wchar_t);

 wchar_t * __cdecl _wcslwr(wchar_t *);
 wchar_t * __cdecl _wcsupr(wchar_t *);
 size_t __cdecl wcsxfrm(wchar_t *, const wchar_t *, size_t);
 int __cdecl wcscoll(const wchar_t *, const wchar_t *);
 int __cdecl _wcsicoll(const wchar_t *, const wchar_t *);
 int __cdecl _wcsncoll(const wchar_t *, const wchar_t *, size_t);
 int __cdecl _wcsnicoll(const wchar_t *, const wchar_t *, size_t);







 wchar_t * __cdecl wcsdup(const wchar_t *);
 int __cdecl wcsicmp(const wchar_t *, const wchar_t *);
 int __cdecl wcsnicmp(const wchar_t *, const wchar_t *, size_t);
 wchar_t * __cdecl wcsnset(wchar_t *, wchar_t, size_t);
 wchar_t * __cdecl wcsrev(wchar_t *);
 wchar_t * __cdecl wcsset(wchar_t *, wchar_t);
 wchar_t * __cdecl wcslwr(wchar_t *);
 wchar_t * __cdecl wcsupr(wchar_t *);
 int __cdecl wcsicoll(const wchar_t *, const wchar_t *);

#line 218 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"


#line 221 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"



}
#line 226 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"

#line 228 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\string.h"
#line 147 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"



__inline int InlineIsEqualGUID(const GUID & rguid1, const GUID & rguid2)
{
   return (
      ((unsigned long *) &rguid1)[0] == ((unsigned long *) &rguid2)[0] &&
      ((unsigned long *) &rguid1)[1] == ((unsigned long *) &rguid2)[1] &&
      ((unsigned long *) &rguid1)[2] == ((unsigned long *) &rguid2)[2] &&
      ((unsigned long *) &rguid1)[3] == ((unsigned long *) &rguid2)[3]);
}

__inline int IsEqualGUID(const GUID & rguid1, const GUID & rguid2)
{
    return !memcmp(&rguid1, &rguid2, sizeof(GUID));
}











#line 175 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"

















__inline int operator==(const GUID & guidOne, const GUID & guidOther)
{
    return IsEqualGUID(guidOne,guidOther);
}

__inline int operator!=(const GUID & guidOne, const GUID & guidOther)
{
    return !(guidOne == guidOther);
}
#line 202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 203 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 204 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 205 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 206 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\guiddef.h"
#line 785 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




typedef struct  _OBJECTID {     
    GUID Lineage;
    DWORD Uniquifier;
} OBJECTID;
#line 794 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"























































































#line 882 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




























































































































































































#line 1071 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




























































































































































































#line 1260 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
























#line 1285 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


  











































#line 1332 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
  
#line 1334 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




typedef ULONG_PTR KSPIN_LOCK;
typedef KSPIN_LOCK *PKSPIN_LOCK;



















































































































































































































































































































































#line 1680 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"














#line 1695 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
struct _TEB *
NtCurrentTeb(void);
#line 1698 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"











































































































































































































#pragma warning(push)
#line 1903 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#pragma warning(disable:4164)   
                                

#pragma function(_enable)
#pragma function(_disable)
#line 1909 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


#pragma warning(pop)


#line 1915 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 1917 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 1918 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#pragma warning(push)
#line 1924 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#pragma warning (disable:4035)        
_inline PVOID GetFiberData( void ) { __asm {
                                        mov eax, fs:[0x10]
                                        mov eax,[eax]
                                        }
                                     }
_inline PVOID GetCurrentFiber( void ) { __asm mov eax, fs:[0x10] }


#pragma warning(pop)


#line 1937 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 1938 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
































#line 1971 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



typedef struct _FLOATING_SAVE_AREA {
    DWORD   ControlWord;
    DWORD   StatusWord;
    DWORD   TagWord;
    DWORD   ErrorOffset;
    DWORD   ErrorSelector;
    DWORD   DataOffset;
    DWORD   DataSelector;
    BYTE    RegisterArea[80];
    DWORD   Cr0NpxState;
} FLOATING_SAVE_AREA;

typedef FLOATING_SAVE_AREA *PFLOATING_SAVE_AREA;











typedef struct _CONTEXT {

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    DWORD ContextFlags;

    
    
    
    
    

    DWORD   Dr0;
    DWORD   Dr1;
    DWORD   Dr2;
    DWORD   Dr3;
    DWORD   Dr6;
    DWORD   Dr7;

    
    
    
    

    FLOATING_SAVE_AREA FloatSave;

    
    
    
    

    DWORD   SegGs;
    DWORD   SegFs;
    DWORD   SegEs;
    DWORD   SegDs;

    
    
    
    

    DWORD   Edi;
    DWORD   Esi;
    DWORD   Ebx;
    DWORD   Edx;
    DWORD   Ecx;
    DWORD   Eax;

    
    
    
    

    DWORD   Ebp;
    DWORD   Eip;
    DWORD   SegCs;              
    DWORD   EFlags;             
    DWORD   Esp;
    DWORD   SegSs;

    
    
    
    
    

    BYTE    ExtendedRegisters[512];

} CONTEXT;



typedef CONTEXT *PCONTEXT;



#line 2091 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef struct _LDT_ENTRY {
    WORD    LimitLow;
    WORD    BaseLow;
    union {
        struct {
            BYTE    BaseMid;
            BYTE    Flags1;     
            BYTE    Flags2;     
            BYTE    BaseHi;
        } Bytes;
        struct {
            DWORD   BaseMid : 8;
            DWORD   Type : 5;
            DWORD   Dpl : 2;
            DWORD   Pres : 1;
            DWORD   LimitHi : 4;
            DWORD   Sys : 1;
            DWORD   Reserved_0 : 1;
            DWORD   Default_Big : 1;
            DWORD   Granularity : 1;
            DWORD   BaseHi : 8;
        } Bits;
    } HighWord;
} LDT_ENTRY, *PLDT_ENTRY;

#line 2122 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

























































































































































































































































































































































#line 2468 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"










#line 2479 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





































































































































































































































#line 2709 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




































































































































































































































#line 2938 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
























#line 2963 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"













































































































































































































































































































































































typedef struct _EXCEPTION_RECORD {
    DWORD    ExceptionCode;
    DWORD ExceptionFlags;
    struct _EXCEPTION_RECORD *ExceptionRecord;
    PVOID ExceptionAddress;
    DWORD NumberParameters;
    ULONG_PTR ExceptionInformation[15];
    } EXCEPTION_RECORD;

typedef EXCEPTION_RECORD *PEXCEPTION_RECORD;

typedef struct _EXCEPTION_RECORD32 {
    DWORD    ExceptionCode;
    DWORD ExceptionFlags;
    DWORD ExceptionRecord;
    DWORD ExceptionAddress;
    DWORD NumberParameters;
    DWORD ExceptionInformation[15];
} EXCEPTION_RECORD32, *PEXCEPTION_RECORD32;

typedef struct _EXCEPTION_RECORD64 {
    DWORD    ExceptionCode;
    DWORD ExceptionFlags;
    DWORD64 ExceptionRecord;
    DWORD64 ExceptionAddress;
    DWORD NumberParameters;
    DWORD __unusedAlignment;
    DWORD64 ExceptionInformation[15];
} EXCEPTION_RECORD64, *PEXCEPTION_RECORD64;





typedef struct _EXCEPTION_POINTERS {
    PEXCEPTION_RECORD ExceptionRecord;
    PCONTEXT ContextRecord;
} EXCEPTION_POINTERS, *PEXCEPTION_POINTERS;
typedef PVOID PACCESS_TOKEN;            
typedef PVOID PSECURITY_DESCRIPTOR;     
typedef PVOID PSID;     







































typedef DWORD ACCESS_MASK;
typedef ACCESS_MASK *PACCESS_MASK;
























































typedef struct _GENERIC_MAPPING {
    ACCESS_MASK GenericRead;
    ACCESS_MASK GenericWrite;
    ACCESS_MASK GenericExecute;
    ACCESS_MASK GenericAll;
} GENERIC_MAPPING;
typedef GENERIC_MAPPING *PGENERIC_MAPPING;












#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"























#pragma warning(disable:4103)

#pragma pack(push,4)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 3486 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _LUID_AND_ATTRIBUTES {
    LUID Luid;
    DWORD Attributes;
    } LUID_AND_ATTRIBUTES, * PLUID_AND_ATTRIBUTES;
typedef LUID_AND_ATTRIBUTES LUID_AND_ATTRIBUTES_ARRAY[1];
typedef LUID_AND_ATTRIBUTES_ARRAY *PLUID_AND_ATTRIBUTES_ARRAY;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 3495 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


































typedef struct _SID_IDENTIFIER_AUTHORITY {
    BYTE  Value[6];
} SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
#line 3533 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




typedef struct _SID {
   BYTE  Revision;
   BYTE  SubAuthorityCount;
   SID_IDENTIFIER_AUTHORITY IdentifierAuthority;



   DWORD SubAuthority[1];
#line 3546 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
} SID, *PISID;
#line 3548 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





                                                



#line 3558 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


typedef enum _SID_NAME_USE {
    SidTypeUser = 1,
    SidTypeGroup,
    SidTypeDomain,
    SidTypeAlias,
    SidTypeWellKnownGroup,
    SidTypeDeletedAccount,
    SidTypeInvalid,
    SidTypeUnknown,
    SidTypeComputer
} SID_NAME_USE, *PSID_NAME_USE;

typedef struct _SID_AND_ATTRIBUTES {
    PSID Sid;
    DWORD Attributes;
    } SID_AND_ATTRIBUTES, * PSID_AND_ATTRIBUTES;

typedef SID_AND_ATTRIBUTES SID_AND_ATTRIBUTES_ARRAY[1];
typedef SID_AND_ATTRIBUTES_ARRAY *PSID_AND_ATTRIBUTES_ARRAY;








































































































































































































































typedef struct _ACL {
    BYTE  AclRevision;
    BYTE  Sbz1;
    WORD   AclSize;
    WORD   AceCount;
    WORD   Sbz2;
} ACL;
typedef ACL *PACL;





















typedef struct _ACE_HEADER {
    BYTE  AceType;
    BYTE  AceFlags;
    WORD   AceSize;
} ACE_HEADER;
typedef ACE_HEADER *PACE_HEADER;








































































































typedef struct _ACCESS_ALLOWED_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
} ACCESS_ALLOWED_ACE;

typedef ACCESS_ALLOWED_ACE *PACCESS_ALLOWED_ACE;

typedef struct _ACCESS_DENIED_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
} ACCESS_DENIED_ACE;
typedef ACCESS_DENIED_ACE *PACCESS_DENIED_ACE;

typedef struct _SYSTEM_AUDIT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
} SYSTEM_AUDIT_ACE;
typedef SYSTEM_AUDIT_ACE *PSYSTEM_AUDIT_ACE;

typedef struct _SYSTEM_ALARM_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
} SYSTEM_ALARM_ACE;
typedef SYSTEM_ALARM_ACE *PSYSTEM_ALARM_ACE;




typedef struct _ACCESS_ALLOWED_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
} ACCESS_ALLOWED_OBJECT_ACE, *PACCESS_ALLOWED_OBJECT_ACE;

typedef struct _ACCESS_DENIED_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
} ACCESS_DENIED_OBJECT_ACE, *PACCESS_DENIED_OBJECT_ACE;

typedef struct _SYSTEM_AUDIT_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
} SYSTEM_AUDIT_OBJECT_ACE, *PSYSTEM_AUDIT_OBJECT_ACE;

typedef struct _SYSTEM_ALARM_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
} SYSTEM_ALARM_OBJECT_ACE, *PSYSTEM_ALARM_OBJECT_ACE;






typedef struct _ACCESS_ALLOWED_CALLBACK_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
    
} ACCESS_ALLOWED_CALLBACK_ACE, *PACCESS_ALLOWED_CALLBACK_ACE;

typedef struct _ACCESS_DENIED_CALLBACK_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
    
} ACCESS_DENIED_CALLBACK_ACE, *PACCESS_DENIED_CALLBACK_ACE;

typedef struct _SYSTEM_AUDIT_CALLBACK_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
    
} SYSTEM_AUDIT_CALLBACK_ACE, *PSYSTEM_AUDIT_CALLBACK_ACE;

typedef struct _SYSTEM_ALARM_CALLBACK_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD SidStart;
    
} SYSTEM_ALARM_CALLBACK_ACE, *PSYSTEM_ALARM_CALLBACK_ACE;

typedef struct _ACCESS_ALLOWED_CALLBACK_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
    
} ACCESS_ALLOWED_CALLBACK_OBJECT_ACE, *PACCESS_ALLOWED_CALLBACK_OBJECT_ACE;

typedef struct _ACCESS_DENIED_CALLBACK_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
    
} ACCESS_DENIED_CALLBACK_OBJECT_ACE, *PACCESS_DENIED_CALLBACK_OBJECT_ACE;

typedef struct _SYSTEM_AUDIT_CALLBACK_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
    
} SYSTEM_AUDIT_CALLBACK_OBJECT_ACE, *PSYSTEM_AUDIT_CALLBACK_OBJECT_ACE;

typedef struct _SYSTEM_ALARM_CALLBACK_OBJECT_ACE {
    ACE_HEADER Header;
    ACCESS_MASK Mask;
    DWORD Flags;
    GUID ObjectType;
    GUID InheritedObjectType;
    DWORD SidStart;
    
} SYSTEM_ALARM_CALLBACK_OBJECT_ACE, *PSYSTEM_ALARM_CALLBACK_OBJECT_ACE;















typedef enum _ACL_INFORMATION_CLASS {
    AclRevisionInformation = 1,
    AclSizeInformation
} ACL_INFORMATION_CLASS;






typedef struct _ACL_REVISION_INFORMATION {
    DWORD AclRevision;
} ACL_REVISION_INFORMATION;
typedef ACL_REVISION_INFORMATION *PACL_REVISION_INFORMATION;





typedef struct _ACL_SIZE_INFORMATION {
    DWORD AceCount;
    DWORD AclBytesInUse;
    DWORD AclBytesFree;
} ACL_SIZE_INFORMATION;
typedef ACL_SIZE_INFORMATION *PACL_SIZE_INFORMATION;


























typedef WORD   SECURITY_DESCRIPTOR_CONTROL, *PSECURITY_DESCRIPTOR_CONTROL;

























































































typedef struct _SECURITY_DESCRIPTOR_RELATIVE {
    BYTE  Revision;
    BYTE  Sbz1;
    SECURITY_DESCRIPTOR_CONTROL Control;
    DWORD Owner;
    DWORD Group;
    DWORD Sacl;
    DWORD Dacl;
    } SECURITY_DESCRIPTOR_RELATIVE, *PISECURITY_DESCRIPTOR_RELATIVE;

typedef struct _SECURITY_DESCRIPTOR {
   BYTE  Revision;
   BYTE  Sbz1;
   SECURITY_DESCRIPTOR_CONTROL Control;
   PSID Owner;
   PSID Group;
   PACL Sacl;
   PACL Dacl;

   } SECURITY_DESCRIPTOR, *PISECURITY_DESCRIPTOR;


















































typedef struct _OBJECT_TYPE_LIST {
    WORD   Level;
    WORD   Sbz;
    GUID *ObjectType;
} OBJECT_TYPE_LIST, *POBJECT_TYPE_LIST;















typedef enum _AUDIT_EVENT_TYPE {
    AuditEventObjectAccess,
    AuditEventDirectoryServiceAccess
} AUDIT_EVENT_TYPE, *PAUDIT_EVENT_TYPE;












































typedef struct _PRIVILEGE_SET {
    DWORD PrivilegeCount;
    DWORD Control;
    LUID_AND_ATTRIBUTES Privilege[1];
    } PRIVILEGE_SET, * PPRIVILEGE_SET;






















































typedef enum _SECURITY_IMPERSONATION_LEVEL {
    SecurityAnonymous,
    SecurityIdentification,
    SecurityImpersonation,
    SecurityDelegation
    } SECURITY_IMPERSONATION_LEVEL, * PSECURITY_IMPERSONATION_LEVEL;











































#line 4493 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


















typedef enum _TOKEN_TYPE {
    TokenPrimary = 1,
    TokenImpersonation
    } TOKEN_TYPE;
typedef TOKEN_TYPE *PTOKEN_TYPE;







typedef enum _TOKEN_INFORMATION_CLASS {
    TokenUser = 1,
    TokenGroups,
    TokenPrivileges,
    TokenOwner,
    TokenPrimaryGroup,
    TokenDefaultDacl,
    TokenSource,
    TokenType,
    TokenImpersonationLevel,
    TokenStatistics,
    TokenRestrictedSids,
    TokenSessionId,
    TokenGroupsAndPrivileges,
    TokenSessionReference,
    TokenSandBoxInert
} TOKEN_INFORMATION_CLASS, *PTOKEN_INFORMATION_CLASS;






typedef struct _TOKEN_USER {
    SID_AND_ATTRIBUTES User;
} TOKEN_USER, *PTOKEN_USER;

typedef struct _TOKEN_GROUPS {
    DWORD GroupCount;
    SID_AND_ATTRIBUTES Groups[1];
} TOKEN_GROUPS, *PTOKEN_GROUPS;


typedef struct _TOKEN_PRIVILEGES {
    DWORD PrivilegeCount;
    LUID_AND_ATTRIBUTES Privileges[1];
} TOKEN_PRIVILEGES, *PTOKEN_PRIVILEGES;


typedef struct _TOKEN_OWNER {
    PSID Owner;
} TOKEN_OWNER, *PTOKEN_OWNER;


typedef struct _TOKEN_PRIMARY_GROUP {
    PSID PrimaryGroup;
} TOKEN_PRIMARY_GROUP, *PTOKEN_PRIMARY_GROUP;


typedef struct _TOKEN_DEFAULT_DACL {
    PACL DefaultDacl;
} TOKEN_DEFAULT_DACL, *PTOKEN_DEFAULT_DACL;

typedef struct _TOKEN_GROUPS_AND_PRIVILEGES {
    DWORD SidCount;
    DWORD SidLength;
    PSID_AND_ATTRIBUTES Sids;
    DWORD RestrictedSidCount;
    DWORD RestrictedSidLength;
    PSID_AND_ATTRIBUTES RestrictedSids;
    DWORD PrivilegeCount;
    DWORD PrivilegeLength;
    PLUID_AND_ATTRIBUTES Privileges;
    LUID AuthenticationId;
} TOKEN_GROUPS_AND_PRIVILEGES, *PTOKEN_GROUPS_AND_PRIVILEGES;




typedef struct _TOKEN_SOURCE {
    CHAR SourceName[8];
    LUID SourceIdentifier;
} TOKEN_SOURCE, *PTOKEN_SOURCE;


typedef struct _TOKEN_STATISTICS {
    LUID TokenId;
    LUID AuthenticationId;
    LARGE_INTEGER ExpirationTime;
    TOKEN_TYPE TokenType;
    SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
    DWORD DynamicCharged;
    DWORD DynamicAvailable;
    DWORD GroupCount;
    DWORD PrivilegeCount;
    LUID ModifiedId;
} TOKEN_STATISTICS, *PTOKEN_STATISTICS;



typedef struct _TOKEN_CONTROL {
    LUID TokenId;
    LUID AuthenticationId;
    LUID ModifiedId;
    TOKEN_SOURCE TokenSource;
    } TOKEN_CONTROL, *PTOKEN_CONTROL;








typedef BOOLEAN SECURITY_CONTEXT_TRACKING_MODE,
                    * PSECURITY_CONTEXT_TRACKING_MODE;







typedef struct _SECURITY_QUALITY_OF_SERVICE {
    DWORD Length;
    SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
    SECURITY_CONTEXT_TRACKING_MODE ContextTrackingMode;
    BOOLEAN EffectiveOnly;
    } SECURITY_QUALITY_OF_SERVICE, * PSECURITY_QUALITY_OF_SERVICE;






typedef struct _SE_IMPERSONATION_STATE {
    PACCESS_TOKEN Token;
    BOOLEAN CopyOnOpen;
    BOOLEAN EffectiveOnly;
    SECURITY_IMPERSONATION_LEVEL Level;
} SE_IMPERSONATION_STATE, *PSE_IMPERSONATION_STATE;




typedef DWORD SECURITY_INFORMATION, *PSECURITY_INFORMATION;































#line 4691 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 4695 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


























typedef struct _JOB_SET_ARRAY {
    HANDLE JobHandle;   
    DWORD MemberLevel;  
    DWORD Flags;        
} JOB_SET_ARRAY, *PJOB_SET_ARRAY;



typedef struct _NT_TIB {
    struct _EXCEPTION_REGISTRATION_RECORD *ExceptionList;
    PVOID StackBase;
    PVOID StackLimit;
    PVOID SubSystemTib;
    union {
        PVOID FiberData;
        DWORD Version;
    };
    PVOID ArbitraryUserPointer;
    struct _NT_TIB *Self;
} NT_TIB;
typedef NT_TIB *PNT_TIB;




typedef struct _NT_TIB32 {
    DWORD ExceptionList;
    DWORD StackBase;
    DWORD StackLimit;
    DWORD SubSystemTib;
    union {
        DWORD FiberData;
        DWORD Version;
    };
    DWORD ArbitraryUserPointer;
    DWORD Self;
} NT_TIB32, *PNT_TIB32;

typedef struct _NT_TIB64 {
    DWORD64 ExceptionList;
    DWORD64 StackBase;
    DWORD64 StackLimit;
    DWORD64 SubSystemTib;
    union {
        DWORD64 FiberData;
        DWORD Version;
    };
    DWORD64 ArbitraryUserPointer;
    DWORD64 Self;
} NT_TIB64, *PNT_TIB64;




#line 4776 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"






typedef struct _QUOTA_LIMITS {
    SIZE_T PagedPoolLimit;
    SIZE_T NonPagedPoolLimit;
    SIZE_T MinimumWorkingSetSize;
    SIZE_T MaximumWorkingSetSize;
    SIZE_T PagefileLimit;
    LARGE_INTEGER TimeLimit;
} QUOTA_LIMITS;
typedef QUOTA_LIMITS *PQUOTA_LIMITS;

typedef struct _IO_COUNTERS {
    ULONGLONG  ReadOperationCount;
    ULONGLONG  WriteOperationCount;
    ULONGLONG  OtherOperationCount;
    ULONGLONG ReadTransferCount;
    ULONGLONG WriteTransferCount;
    ULONGLONG OtherTransferCount;
} IO_COUNTERS;
typedef IO_COUNTERS *PIO_COUNTERS;


typedef struct _JOBOBJECT_BASIC_ACCOUNTING_INFORMATION {
    LARGE_INTEGER TotalUserTime;
    LARGE_INTEGER TotalKernelTime;
    LARGE_INTEGER ThisPeriodTotalUserTime;
    LARGE_INTEGER ThisPeriodTotalKernelTime;
    DWORD TotalPageFaultCount;
    DWORD TotalProcesses;
    DWORD ActiveProcesses;
    DWORD TotalTerminatedProcesses;
} JOBOBJECT_BASIC_ACCOUNTING_INFORMATION, *PJOBOBJECT_BASIC_ACCOUNTING_INFORMATION;

typedef struct _JOBOBJECT_BASIC_LIMIT_INFORMATION {
    LARGE_INTEGER PerProcessUserTimeLimit;
    LARGE_INTEGER PerJobUserTimeLimit;
    DWORD LimitFlags;
    SIZE_T MinimumWorkingSetSize;
    SIZE_T MaximumWorkingSetSize;
    DWORD ActiveProcessLimit;
    ULONG_PTR Affinity;
    DWORD PriorityClass;
    DWORD SchedulingClass;
} JOBOBJECT_BASIC_LIMIT_INFORMATION, *PJOBOBJECT_BASIC_LIMIT_INFORMATION;

typedef struct _JOBOBJECT_EXTENDED_LIMIT_INFORMATION {
    JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
    IO_COUNTERS IoInfo;
    SIZE_T ProcessMemoryLimit;
    SIZE_T JobMemoryLimit;
    SIZE_T PeakProcessMemoryUsed;
    SIZE_T PeakJobMemoryUsed;
} JOBOBJECT_EXTENDED_LIMIT_INFORMATION, *PJOBOBJECT_EXTENDED_LIMIT_INFORMATION;

typedef struct _JOBOBJECT_BASIC_PROCESS_ID_LIST {
    DWORD NumberOfAssignedProcesses;
    DWORD NumberOfProcessIdsInList;
    ULONG_PTR ProcessIdList[1];
} JOBOBJECT_BASIC_PROCESS_ID_LIST, *PJOBOBJECT_BASIC_PROCESS_ID_LIST;

typedef struct _JOBOBJECT_BASIC_UI_RESTRICTIONS {
    DWORD UIRestrictionsClass;
} JOBOBJECT_BASIC_UI_RESTRICTIONS, *PJOBOBJECT_BASIC_UI_RESTRICTIONS;

typedef struct _JOBOBJECT_SECURITY_LIMIT_INFORMATION {
    DWORD SecurityLimitFlags ;
    HANDLE JobToken ;
    PTOKEN_GROUPS SidsToDisable ;
    PTOKEN_PRIVILEGES PrivilegesToDelete ;
    PTOKEN_GROUPS RestrictedSids ;
} JOBOBJECT_SECURITY_LIMIT_INFORMATION, *PJOBOBJECT_SECURITY_LIMIT_INFORMATION ;

typedef struct _JOBOBJECT_END_OF_JOB_TIME_INFORMATION {
    DWORD EndOfJobTimeAction;
} JOBOBJECT_END_OF_JOB_TIME_INFORMATION, *PJOBOBJECT_END_OF_JOB_TIME_INFORMATION;

typedef struct _JOBOBJECT_ASSOCIATE_COMPLETION_PORT {
    PVOID CompletionKey;
    HANDLE CompletionPort;
} JOBOBJECT_ASSOCIATE_COMPLETION_PORT, *PJOBOBJECT_ASSOCIATE_COMPLETION_PORT;

typedef struct _JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION {
    JOBOBJECT_BASIC_ACCOUNTING_INFORMATION BasicInfo;
    IO_COUNTERS IoInfo;
} JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION, *PJOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION;

typedef struct _JOBOBJECT_JOBSET_INFORMATION {
    DWORD MemberLevel;
} JOBOBJECT_JOBSET_INFORMATION, *PJOBOBJECT_JOBSET_INFORMATION;


















































































typedef enum _JOBOBJECTINFOCLASS {
    JobObjectBasicAccountingInformation = 1,
    JobObjectBasicLimitInformation,
    JobObjectBasicProcessIdList,
    JobObjectBasicUIRestrictions,
    JobObjectSecurityLimitInformation,
    JobObjectEndOfJobTimeInformation,
    JobObjectAssociateCompletionPortInformation,
    JobObjectBasicAndIoAccountingInformation,
    JobObjectExtendedLimitInformation,
    JobObjectJobSetInformation,
    MaxJobObjectInfoClass
    } JOBOBJECTINFOCLASS;


























typedef struct _SYSTEM_NUMA_INFORMATION {
    DWORD       HighestNodeNumber;
    DWORD       Reserved;
    union {
        ULONGLONG   ActiveProcessorsAffinityMask[16];
        ULONGLONG   AvailableMemory[16];
    };
} SYSTEM_NUMA_INFORMATION, *PSYSTEM_NUMA_INFORMATION;



















































typedef struct _MEMORY_BASIC_INFORMATION {
    PVOID BaseAddress;
    PVOID AllocationBase;
    DWORD AllocationProtect;
    SIZE_T RegionSize;
    DWORD State;
    DWORD Protect;
    DWORD Type;
} MEMORY_BASIC_INFORMATION, *PMEMORY_BASIC_INFORMATION;

typedef struct _MEMORY_BASIC_INFORMATION32 {
    DWORD BaseAddress;
    DWORD AllocationBase;
    DWORD AllocationProtect;
    DWORD RegionSize;
    DWORD State;
    DWORD Protect;
    DWORD Type;
} MEMORY_BASIC_INFORMATION32, *PMEMORY_BASIC_INFORMATION32;

typedef struct _MEMORY_BASIC_INFORMATION64 {
    ULONGLONG BaseAddress;
    ULONGLONG AllocationBase;
    DWORD     AllocationProtect;
    DWORD     __alignment1;
    ULONGLONG RegionSize;
    DWORD     State;
    DWORD     Protect;
    DWORD     Type;
    DWORD     __alignment2;
} MEMORY_BASIC_INFORMATION64, *PMEMORY_BASIC_INFORMATION64;
























































































































































typedef struct _FILE_NOTIFY_INFORMATION {
    DWORD NextEntryOffset;
    DWORD Action;
    DWORD FileNameLength;
    WCHAR FileName[1];
} FILE_NOTIFY_INFORMATION, *PFILE_NOTIFY_INFORMATION;






typedef union _FILE_SEGMENT_ELEMENT {
    PVOID64 Buffer;
    ULONGLONG Alignment;
}FILE_SEGMENT_ELEMENT, *PFILE_SEGMENT_ELEMENT;









typedef struct _REPARSE_GUID_DATA_BUFFER {
    DWORD  ReparseTag;
    WORD   ReparseDataLength;
    WORD   Reserved;
    GUID   ReparseGuid;
    struct {
        BYTE   DataBuffer[1];
    } GenericReparseBuffer;
} REPARSE_GUID_DATA_BUFFER, *PREPARSE_GUID_DATA_BUFFER;












































































typedef enum _SYSTEM_POWER_STATE {
    PowerSystemUnspecified = 0,
    PowerSystemWorking     = 1,
    PowerSystemSleeping1   = 2,
    PowerSystemSleeping2   = 3,
    PowerSystemSleeping3   = 4,
    PowerSystemHibernate   = 5,
    PowerSystemShutdown    = 6,
    PowerSystemMaximum     = 7
} SYSTEM_POWER_STATE, *PSYSTEM_POWER_STATE;



typedef enum {
    PowerActionNone = 0,
    PowerActionReserved,
    PowerActionSleep,
    PowerActionHibernate,
    PowerActionShutdown,
    PowerActionShutdownReset,
    PowerActionShutdownOff,
    PowerActionWarmEject
} POWER_ACTION, *PPOWER_ACTION;

typedef enum _DEVICE_POWER_STATE {
    PowerDeviceUnspecified = 0,
    PowerDeviceD0,
    PowerDeviceD1,
    PowerDeviceD2,
    PowerDeviceD3,
    PowerDeviceMaximum
} DEVICE_POWER_STATE, *PDEVICE_POWER_STATE;







typedef DWORD EXECUTION_STATE;

typedef enum {
    LT_DONT_CARE,
    LT_LOWEST_LATENCY
} LATENCY_TIME;

















typedef struct CM_Power_Data_s {
    DWORD               PD_Size;
    DEVICE_POWER_STATE  PD_MostRecentPowerState;
    DWORD               PD_Capabilities;
    DWORD               PD_D1Latency;
    DWORD               PD_D2Latency;
    DWORD               PD_D3Latency;
    DEVICE_POWER_STATE  PD_PowerStateMapping[7];
    SYSTEM_POWER_STATE  PD_DeepestSystemWake;
} CM_POWER_DATA, *PCM_POWER_DATA;



typedef enum {
    SystemPowerPolicyAc,
    SystemPowerPolicyDc,
    VerifySystemPolicyAc,
    VerifySystemPolicyDc,
    SystemPowerCapabilities,
    SystemBatteryState,
    SystemPowerStateHandler,
    ProcessorStateHandler,
    SystemPowerPolicyCurrent,
    AdministratorPowerPolicy,
    SystemReserveHiberFile,
    ProcessorInformation,
    SystemPowerInformation,
    ProcessorStateHandler2,
    LastWakeTime,                                   
    LastSleepTime,                                  
    SystemExecutionState,
    SystemPowerStateNotifyHandler,
    ProcessorPowerPolicyAc,
    ProcessorPowerPolicyDc,
    VerifyProcessorPowerPolicyAc,
    VerifyProcessorPowerPolicyDc,
    ProcessorPowerPolicyCurrent
} POWER_INFORMATION_LEVEL;







typedef struct {
    DWORD       Granularity;
    DWORD       Capacity;
} BATTERY_REPORTING_SCALE, *PBATTERY_REPORTING_SCALE;






typedef struct {
    POWER_ACTION    Action;
    DWORD           Flags;
    DWORD           EventCode;
} POWER_ACTION_POLICY, *PPOWER_ACTION_POLICY;



















typedef struct {
    BOOLEAN                 Enable;
    BYTE                    Spare[3];
    DWORD                   BatteryLevel;
    POWER_ACTION_POLICY     PowerPolicy;
    SYSTEM_POWER_STATE      MinSystemState;
} SYSTEM_POWER_LEVEL, *PSYSTEM_POWER_LEVEL;
















typedef struct _SYSTEM_POWER_POLICY {
    DWORD                   Revision;       

    
    POWER_ACTION_POLICY     PowerButton;
    POWER_ACTION_POLICY     SleepButton;
    POWER_ACTION_POLICY     LidClose;
    SYSTEM_POWER_STATE      LidOpenWake;
    DWORD                   Reserved;

    
    POWER_ACTION_POLICY     Idle;
    DWORD                   IdleTimeout;
    BYTE                    IdleSensitivity;

    
    
    BYTE                    DynamicThrottle;

    BYTE                    Spare2[2];

    
    SYSTEM_POWER_STATE      MinSleep;
    SYSTEM_POWER_STATE      MaxSleep;
    SYSTEM_POWER_STATE      ReducedLatencySleep;
    DWORD                   WinLogonFlags;

    
    DWORD                   Spare3;
    DWORD                   DozeS4Timeout;

    
    DWORD                   BroadcastCapacityResolution;
    SYSTEM_POWER_LEVEL      DischargePolicy[4];

    
    DWORD                   VideoTimeout;
    BOOLEAN                 VideoDimDisplay;
    DWORD                   VideoReserved[3];

    
    DWORD                   SpindownTimeout;

    
    BOOLEAN                 OptimizeForPower;
    BYTE                    FanThrottleTolerance;
    BYTE                    ForcedThrottle;
    BYTE                    MinThrottle;
    POWER_ACTION_POLICY     OverThrottled;

} SYSTEM_POWER_POLICY, *PSYSTEM_POWER_POLICY;


typedef struct _PROCESSOR_POWER_POLICY_INFO {

    
    DWORD                   TimeCheck;                      
    DWORD                   DemoteLimit;                    
    DWORD                   PromoteLimit;                   

    
    BYTE                    DemotePercent;
    BYTE                    PromotePercent;
    BYTE                    Spare[2];

    
    DWORD                   AllowDemotion:1;
    DWORD                   AllowPromotion:1;
    DWORD                   Reserved:30;

} PROCESSOR_POWER_POLICY_INFO, *PPROCESSOR_POWER_POLICY_INFO;


typedef struct _PROCESSOR_POWER_POLICY {
    DWORD                       Revision;       

    
    BYTE                        DynamicThrottle;
    BYTE                        Spare[3];

    
    DWORD                       Reserved;

    
    
    
    DWORD                       PolicyCount;
    PROCESSOR_POWER_POLICY_INFO Policy[3];

} PROCESSOR_POWER_POLICY, *PPROCESSOR_POWER_POLICY;


typedef struct _ADMINISTRATOR_POWER_POLICY {

    
    SYSTEM_POWER_STATE      MinSleep;
    SYSTEM_POWER_STATE      MaxSleep;

    
    DWORD                   MinVideoTimeout;
    DWORD                   MaxVideoTimeout;

    
    DWORD                   MinSpindownTimeout;
    DWORD                   MaxSpindownTimeout;
} ADMINISTRATOR_POWER_POLICY, *PADMINISTRATOR_POWER_POLICY;


typedef struct {
    
    BOOLEAN             PowerButtonPresent;
    BOOLEAN             SleepButtonPresent;
    BOOLEAN             LidPresent;
    BOOLEAN             SystemS1;
    BOOLEAN             SystemS2;
    BOOLEAN             SystemS3;
    BOOLEAN             SystemS4;           
    BOOLEAN             SystemS5;           
    BOOLEAN             HiberFilePresent;
    BOOLEAN             FullWake;
    BOOLEAN             VideoDimPresent;
    BOOLEAN             ApmPresent;
    BOOLEAN             UpsPresent;

    
    BOOLEAN             ThermalControl;
    BOOLEAN             ProcessorThrottle;
    BYTE                ProcessorMinThrottle;
    BYTE                ProcessorMaxThrottle;
    BYTE                spare2[4];

    
    BOOLEAN             DiskSpinDown;
    BYTE                spare3[8];

    
    BOOLEAN             SystemBatteriesPresent;
    BOOLEAN             BatteriesAreShortTerm;
    BATTERY_REPORTING_SCALE BatteryScale[3];

    
    SYSTEM_POWER_STATE  AcOnLineWake;
    SYSTEM_POWER_STATE  SoftLidWake;
    SYSTEM_POWER_STATE  RtcWake;
    SYSTEM_POWER_STATE  MinDeviceWakeState; 
    SYSTEM_POWER_STATE  DefaultLowLatencyWake;
} SYSTEM_POWER_CAPABILITIES, *PSYSTEM_POWER_CAPABILITIES;

typedef struct {
    BOOLEAN             AcOnLine;
    BOOLEAN             BatteryPresent;
    BOOLEAN             Charging;
    BOOLEAN             Discharging;
    BOOLEAN             Spare1[4];

    DWORD               MaxCapacity;
    DWORD               RemainingCapacity;
    DWORD               Rate;
    DWORD               EstimatedTime;

    DWORD               DefaultAlert1;
    DWORD               DefaultAlert2;
} SYSTEM_BATTERY_STATE, *PSYSTEM_BATTERY_STATE;










#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack4.h"























#pragma warning(disable:4103)

#pragma pack(push,4)


#line 30 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack4.h"


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack4.h"
#line 34 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack4.h"
#line 5681 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"







#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"
#line 34 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"
#line 5689 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"









#line 5699 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _IMAGE_DOS_HEADER {      
    WORD   e_magic;                     
    WORD   e_cblp;                      
    WORD   e_cp;                        
    WORD   e_crlc;                      
    WORD   e_cparhdr;                   
    WORD   e_minalloc;                  
    WORD   e_maxalloc;                  
    WORD   e_ss;                        
    WORD   e_sp;                        
    WORD   e_csum;                      
    WORD   e_ip;                        
    WORD   e_cs;                        
    WORD   e_lfarlc;                    
    WORD   e_ovno;                      
    WORD   e_res[4];                    
    WORD   e_oemid;                     
    WORD   e_oeminfo;                   
    WORD   e_res2[10];                  
    LONG   e_lfanew;                    
  } IMAGE_DOS_HEADER, *PIMAGE_DOS_HEADER;

typedef struct _IMAGE_OS2_HEADER {      
    WORD   ne_magic;                    
    CHAR   ne_ver;                      
    CHAR   ne_rev;                      
    WORD   ne_enttab;                   
    WORD   ne_cbenttab;                 
    LONG   ne_crc;                      
    WORD   ne_flags;                    
    WORD   ne_autodata;                 
    WORD   ne_heap;                     
    WORD   ne_stack;                    
    LONG   ne_csip;                     
    LONG   ne_sssp;                     
    WORD   ne_cseg;                     
    WORD   ne_cmod;                     
    WORD   ne_cbnrestab;                
    WORD   ne_segtab;                   
    WORD   ne_rsrctab;                  
    WORD   ne_restab;                   
    WORD   ne_modtab;                   
    WORD   ne_imptab;                   
    LONG   ne_nrestab;                  
    WORD   ne_cmovent;                  
    WORD   ne_align;                    
    WORD   ne_cres;                     
    BYTE   ne_exetyp;                   
    BYTE   ne_flagsothers;              
    WORD   ne_pretthunks;               
    WORD   ne_psegrefbytes;             
    WORD   ne_swaparea;                 
    WORD   ne_expver;                   
  } IMAGE_OS2_HEADER, *PIMAGE_OS2_HEADER;

typedef struct _IMAGE_VXD_HEADER {      
    WORD   e32_magic;                   
    BYTE   e32_border;                  
    BYTE   e32_worder;                  
    DWORD  e32_level;                   
    WORD   e32_cpu;                     
    WORD   e32_os;                      
    DWORD  e32_ver;                     
    DWORD  e32_mflags;                  
    DWORD  e32_mpages;                  
    DWORD  e32_startobj;                
    DWORD  e32_eip;                     
    DWORD  e32_stackobj;                
    DWORD  e32_esp;                     
    DWORD  e32_pagesize;                
    DWORD  e32_lastpagesize;            
    DWORD  e32_fixupsize;               
    DWORD  e32_fixupsum;                
    DWORD  e32_ldrsize;                 
    DWORD  e32_ldrsum;                  
    DWORD  e32_objtab;                  
    DWORD  e32_objcnt;                  
    DWORD  e32_objmap;                  
    DWORD  e32_itermap;                 
    DWORD  e32_rsrctab;                 
    DWORD  e32_rsrccnt;                 
    DWORD  e32_restab;                  
    DWORD  e32_enttab;                  
    DWORD  e32_dirtab;                  
    DWORD  e32_dircnt;                  
    DWORD  e32_fpagetab;                
    DWORD  e32_frectab;                 
    DWORD  e32_impmod;                  
    DWORD  e32_impmodcnt;               
    DWORD  e32_impproc;                 
    DWORD  e32_pagesum;                 
    DWORD  e32_datapage;                
    DWORD  e32_preload;                 
    DWORD  e32_nrestab;                 
    DWORD  e32_cbnrestab;               
    DWORD  e32_nressum;                 
    DWORD  e32_autodata;                
    DWORD  e32_debuginfo;               
    DWORD  e32_debuglen;                
    DWORD  e32_instpreload;             
    DWORD  e32_instdemand;              
    DWORD  e32_heapsize;                
    BYTE   e32_res3[12];                
    DWORD  e32_winresoff;
    DWORD  e32_winreslen;
    WORD   e32_devid;                   
    WORD   e32_ddkver;                  
  } IMAGE_VXD_HEADER, *PIMAGE_VXD_HEADER;


#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


#line 36 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 37 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 5811 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 5812 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef struct _IMAGE_FILE_HEADER {
    WORD    Machine;
    WORD    NumberOfSections;
    DWORD   TimeDateStamp;
    DWORD   PointerToSymbolTable;
    DWORD   NumberOfSymbols;
    WORD    SizeOfOptionalHeader;
    WORD    Characteristics;
} IMAGE_FILE_HEADER, *PIMAGE_FILE_HEADER;






















































typedef struct _IMAGE_DATA_DIRECTORY {
    DWORD   VirtualAddress;
    DWORD   Size;
} IMAGE_DATA_DIRECTORY, *PIMAGE_DATA_DIRECTORY;







typedef struct _IMAGE_OPTIONAL_HEADER {
    
    
    

    WORD    Magic;
    BYTE    MajorLinkerVersion;
    BYTE    MinorLinkerVersion;
    DWORD   SizeOfCode;
    DWORD   SizeOfInitializedData;
    DWORD   SizeOfUninitializedData;
    DWORD   AddressOfEntryPoint;
    DWORD   BaseOfCode;
    DWORD   BaseOfData;

    
    
    

    DWORD   ImageBase;
    DWORD   SectionAlignment;
    DWORD   FileAlignment;
    WORD    MajorOperatingSystemVersion;
    WORD    MinorOperatingSystemVersion;
    WORD    MajorImageVersion;
    WORD    MinorImageVersion;
    WORD    MajorSubsystemVersion;
    WORD    MinorSubsystemVersion;
    DWORD   Win32VersionValue;
    DWORD   SizeOfImage;
    DWORD   SizeOfHeaders;
    DWORD   CheckSum;
    WORD    Subsystem;
    WORD    DllCharacteristics;
    DWORD   SizeOfStackReserve;
    DWORD   SizeOfStackCommit;
    DWORD   SizeOfHeapReserve;
    DWORD   SizeOfHeapCommit;
    DWORD   LoaderFlags;
    DWORD   NumberOfRvaAndSizes;
    IMAGE_DATA_DIRECTORY DataDirectory[16];
} IMAGE_OPTIONAL_HEADER32, *PIMAGE_OPTIONAL_HEADER32;

typedef struct _IMAGE_ROM_OPTIONAL_HEADER {
    WORD   Magic;
    BYTE   MajorLinkerVersion;
    BYTE   MinorLinkerVersion;
    DWORD  SizeOfCode;
    DWORD  SizeOfInitializedData;
    DWORD  SizeOfUninitializedData;
    DWORD  AddressOfEntryPoint;
    DWORD  BaseOfCode;
    DWORD  BaseOfData;
    DWORD  BaseOfBss;
    DWORD  GprMask;
    DWORD  CprMask[4];
    DWORD  GpValue;
} IMAGE_ROM_OPTIONAL_HEADER, *PIMAGE_ROM_OPTIONAL_HEADER;

typedef struct _IMAGE_OPTIONAL_HEADER64 {
    WORD        Magic;
    BYTE        MajorLinkerVersion;
    BYTE        MinorLinkerVersion;
    DWORD       SizeOfCode;
    DWORD       SizeOfInitializedData;
    DWORD       SizeOfUninitializedData;
    DWORD       AddressOfEntryPoint;
    DWORD       BaseOfCode;
    ULONGLONG   ImageBase;
    DWORD       SectionAlignment;
    DWORD       FileAlignment;
    WORD        MajorOperatingSystemVersion;
    WORD        MinorOperatingSystemVersion;
    WORD        MajorImageVersion;
    WORD        MinorImageVersion;
    WORD        MajorSubsystemVersion;
    WORD        MinorSubsystemVersion;
    DWORD       Win32VersionValue;
    DWORD       SizeOfImage;
    DWORD       SizeOfHeaders;
    DWORD       CheckSum;
    WORD        Subsystem;
    WORD        DllCharacteristics;
    ULONGLONG   SizeOfStackReserve;
    ULONGLONG   SizeOfStackCommit;
    ULONGLONG   SizeOfHeapReserve;
    ULONGLONG   SizeOfHeapCommit;
    DWORD       LoaderFlags;
    DWORD       NumberOfRvaAndSizes;
    IMAGE_DATA_DIRECTORY DataDirectory[16];
} IMAGE_OPTIONAL_HEADER64, *PIMAGE_OPTIONAL_HEADER64;
















typedef IMAGE_OPTIONAL_HEADER32             IMAGE_OPTIONAL_HEADER;
typedef PIMAGE_OPTIONAL_HEADER32            PIMAGE_OPTIONAL_HEADER;


#line 6003 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _IMAGE_NT_HEADERS64 {
    DWORD Signature;
    IMAGE_FILE_HEADER FileHeader;
    IMAGE_OPTIONAL_HEADER64 OptionalHeader;
} IMAGE_NT_HEADERS64, *PIMAGE_NT_HEADERS64;

typedef struct _IMAGE_NT_HEADERS {
    DWORD Signature;
    IMAGE_FILE_HEADER FileHeader;
    IMAGE_OPTIONAL_HEADER32 OptionalHeader;
} IMAGE_NT_HEADERS32, *PIMAGE_NT_HEADERS32;

typedef struct _IMAGE_ROM_HEADERS {
    IMAGE_FILE_HEADER FileHeader;
    IMAGE_ROM_OPTIONAL_HEADER OptionalHeader;
} IMAGE_ROM_HEADERS, *PIMAGE_ROM_HEADERS;





typedef IMAGE_NT_HEADERS32                  IMAGE_NT_HEADERS;
typedef PIMAGE_NT_HEADERS32                 PIMAGE_NT_HEADERS;
#line 6028 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




























































typedef struct ANON_OBJECT_HEADER {
    WORD    Sig1;            
    WORD    Sig2;            
    WORD    Version;         
    WORD    Machine;
    DWORD   TimeDateStamp;
    CLSID   ClassID;         
    DWORD   SizeOfData;      
} ANON_OBJECT_HEADER;







typedef struct _IMAGE_SECTION_HEADER {
    BYTE    Name[8];
    union {
            DWORD   PhysicalAddress;
            DWORD   VirtualSize;
    } Misc;
    DWORD   VirtualAddress;
    DWORD   SizeOfRawData;
    DWORD   PointerToRawData;
    DWORD   PointerToRelocations;
    DWORD   PointerToLinenumbers;
    WORD    NumberOfRelocations;
    WORD    NumberOfLinenumbers;
    DWORD   Characteristics;
} IMAGE_SECTION_HEADER, *PIMAGE_SECTION_HEADER;

































































#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"
#line 34 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack2.h"
#line 6185 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 6186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef struct _IMAGE_SYMBOL {
    union {
        BYTE    ShortName[8];
        struct {
            DWORD   Short;     
            DWORD   Long;      
        } Name;
        DWORD   LongName[2];    
    } N;
    DWORD   Value;
    SHORT   SectionNumber;
    WORD    Type;
    BYTE    StorageClass;
    BYTE    NumberOfAuxSymbols;
} IMAGE_SYMBOL;
typedef IMAGE_SYMBOL  *PIMAGE_SYMBOL;


































































































#line 6306 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#line 6311 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





#line 6317 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#line 6322 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



#line 6326 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


#line 6329 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef union _IMAGE_AUX_SYMBOL {
    struct {
        DWORD    TagIndex;                      
        union {
            struct {
                WORD    Linenumber;             
                WORD    Size;                   
            } LnSz;
           DWORD    TotalSize;
        } Misc;
        union {
            struct {                            
                DWORD    PointerToLinenumber;
                DWORD    PointerToNextFunction;
            } Function;
            struct {                            
                WORD     Dimension[4];
            } Array;
        } FcnAry;
        WORD    TvIndex;                        
    } Sym;
    struct {
        BYTE    Name[18];
    } File;
    struct {
        DWORD   Length;                         
        WORD    NumberOfRelocations;            
        WORD    NumberOfLinenumbers;            
        DWORD   CheckSum;                       
        SHORT   Number;                         
        BYTE    Selection;                      
    } Section;
} IMAGE_AUX_SYMBOL;
typedef IMAGE_AUX_SYMBOL  *PIMAGE_AUX_SYMBOL;



typedef enum IMAGE_AUX_SYMBOL_TYPE {
    IMAGE_AUX_SYMBOL_TYPE_TOKEN_DEF = 1,
} IMAGE_AUX_SYMBOL_TYPE;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 6376 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct IMAGE_AUX_SYMBOL_TOKEN_DEF {
    BYTE  bAuxType;                  
    BYTE  bReserved;                 
    DWORD SymbolTableIndex;
    BYTE  rgbReserved[12];           
} IMAGE_AUX_SYMBOL_TOKEN_DEF;

typedef IMAGE_AUX_SYMBOL_TOKEN_DEF  *PIMAGE_AUX_SYMBOL_TOKEN_DEF;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 6387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





















typedef struct _IMAGE_RELOCATION {
    union {
        DWORD   VirtualAddress;
        DWORD   RelocCount;             
    };
    DWORD   SymbolTableIndex;
    WORD    Type;
} IMAGE_RELOCATION;
typedef IMAGE_RELOCATION  *PIMAGE_RELOCATION;






































































































































































































































































































typedef struct _IMAGE_LINENUMBER {
    union {
        DWORD   SymbolTableIndex;               
        DWORD   VirtualAddress;                 
    } Type;
    WORD    Linenumber;                         
} IMAGE_LINENUMBER;
typedef IMAGE_LINENUMBER  *PIMAGE_LINENUMBER;




#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


#line 36 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 37 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 6724 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#line 6725 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef struct _IMAGE_BASE_RELOCATION {
    DWORD   VirtualAddress;
    DWORD   SizeOfBlock;

} IMAGE_BASE_RELOCATION;
typedef IMAGE_BASE_RELOCATION  * PIMAGE_BASE_RELOCATION;





























typedef struct _IMAGE_ARCHIVE_MEMBER_HEADER {
    BYTE     Name[16];                          
    BYTE     Date[12];                          
    BYTE     UserID[6];                         
    BYTE     GroupID[6];                        
    BYTE     Mode[8];                           
    BYTE     Size[10];                          
    BYTE     EndHeader[2];                      
} IMAGE_ARCHIVE_MEMBER_HEADER, *PIMAGE_ARCHIVE_MEMBER_HEADER;











typedef struct _IMAGE_EXPORT_DIRECTORY {
    DWORD   Characteristics;
    DWORD   TimeDateStamp;
    WORD    MajorVersion;
    WORD    MinorVersion;
    DWORD   Name;
    DWORD   Base;
    DWORD   NumberOfFunctions;
    DWORD   NumberOfNames;
    DWORD   AddressOfFunctions;     
    DWORD   AddressOfNames;         
    DWORD   AddressOfNameOrdinals;  
} IMAGE_EXPORT_DIRECTORY, *PIMAGE_EXPORT_DIRECTORY;





typedef struct _IMAGE_IMPORT_BY_NAME {
    WORD    Hint;
    BYTE    Name[1];
} IMAGE_IMPORT_BY_NAME, *PIMAGE_IMPORT_BY_NAME;

#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack8.h"























#pragma warning(disable:4103)

#pragma pack(push,8)


#line 30 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack8.h"


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack8.h"
#line 34 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\pshpack8.h"
#line 6809 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _IMAGE_THUNK_DATA64 {
    union {
        ULONGLONG ForwarderString;  
        ULONGLONG Function;         
        ULONGLONG Ordinal;
        ULONGLONG AddressOfData;    
    } u1;
} IMAGE_THUNK_DATA64;
typedef IMAGE_THUNK_DATA64 * PIMAGE_THUNK_DATA64;

#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


#line 36 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 37 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 6821 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _IMAGE_THUNK_DATA32 {
    union {
        DWORD ForwarderString;      
        DWORD Function;             
        DWORD Ordinal;
        DWORD AddressOfData;        
    } u1;
} IMAGE_THUNK_DATA32;
typedef IMAGE_THUNK_DATA32 * PIMAGE_THUNK_DATA32;












typedef void
(__stdcall *PIMAGE_TLS_CALLBACK) (
    PVOID DllHandle,
    DWORD Reason,
    PVOID Reserved
    );

typedef struct _IMAGE_TLS_DIRECTORY64 {
    ULONGLONG   StartAddressOfRawData;
    ULONGLONG   EndAddressOfRawData;
    ULONGLONG   AddressOfIndex;         
    ULONGLONG   AddressOfCallBacks;     
    DWORD   SizeOfZeroFill;
    DWORD   Characteristics;
} IMAGE_TLS_DIRECTORY64;
typedef IMAGE_TLS_DIRECTORY64 * PIMAGE_TLS_DIRECTORY64;

typedef struct _IMAGE_TLS_DIRECTORY32 {
    DWORD   StartAddressOfRawData;
    DWORD   EndAddressOfRawData;
    DWORD   AddressOfIndex;             
    DWORD   AddressOfCallBacks;         
    DWORD   SizeOfZeroFill;
    DWORD   Characteristics;
} IMAGE_TLS_DIRECTORY32;
typedef IMAGE_TLS_DIRECTORY32 * PIMAGE_TLS_DIRECTORY32;












typedef IMAGE_THUNK_DATA32              IMAGE_THUNK_DATA;
typedef PIMAGE_THUNK_DATA32             PIMAGE_THUNK_DATA;

typedef IMAGE_TLS_DIRECTORY32           IMAGE_TLS_DIRECTORY;
typedef PIMAGE_TLS_DIRECTORY32          PIMAGE_TLS_DIRECTORY;
#line 6887 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _IMAGE_IMPORT_DESCRIPTOR {
    union {
        DWORD   Characteristics;            
        DWORD   OriginalFirstThunk;         
    };
    DWORD   TimeDateStamp;                  
                                            
                                            
                                            

    DWORD   ForwarderChain;                 
    DWORD   Name;
    DWORD   FirstThunk;                     
} IMAGE_IMPORT_DESCRIPTOR;
typedef IMAGE_IMPORT_DESCRIPTOR  *PIMAGE_IMPORT_DESCRIPTOR;





typedef struct _IMAGE_BOUND_IMPORT_DESCRIPTOR {
    DWORD   TimeDateStamp;
    WORD    OffsetModuleName;
    WORD    NumberOfModuleForwarderRefs;

} IMAGE_BOUND_IMPORT_DESCRIPTOR,  *PIMAGE_BOUND_IMPORT_DESCRIPTOR;

typedef struct _IMAGE_BOUND_FORWARDER_REF {
    DWORD   TimeDateStamp;
    WORD    OffsetModuleName;
    WORD    Reserved;
} IMAGE_BOUND_FORWARDER_REF, *PIMAGE_BOUND_FORWARDER_REF;



















typedef struct _IMAGE_RESOURCE_DIRECTORY {
    DWORD   Characteristics;
    DWORD   TimeDateStamp;
    WORD    MajorVersion;
    WORD    MinorVersion;
    WORD    NumberOfNamedEntries;
    WORD    NumberOfIdEntries;

} IMAGE_RESOURCE_DIRECTORY, *PIMAGE_RESOURCE_DIRECTORY;


















typedef struct _IMAGE_RESOURCE_DIRECTORY_ENTRY {
    union {
        struct {
            DWORD NameOffset:31;
            DWORD NameIsString:1;
        };
        DWORD   Name;
        WORD    Id;
    };
    union {
        DWORD   OffsetToData;
        struct {
            DWORD   OffsetToDirectory:31;
            DWORD   DataIsDirectory:1;
        };
    };
} IMAGE_RESOURCE_DIRECTORY_ENTRY, *PIMAGE_RESOURCE_DIRECTORY_ENTRY;










typedef struct _IMAGE_RESOURCE_DIRECTORY_STRING {
    WORD    Length;
    CHAR    NameString[ 1 ];
} IMAGE_RESOURCE_DIRECTORY_STRING, *PIMAGE_RESOURCE_DIRECTORY_STRING;


typedef struct _IMAGE_RESOURCE_DIR_STRING_U {
    WORD    Length;
    WCHAR   NameString[ 1 ];
} IMAGE_RESOURCE_DIR_STRING_U, *PIMAGE_RESOURCE_DIR_STRING_U;











typedef struct _IMAGE_RESOURCE_DATA_ENTRY {
    DWORD   OffsetToData;
    DWORD   Size;
    DWORD   CodePage;
    DWORD   Reserved;
} IMAGE_RESOURCE_DATA_ENTRY, *PIMAGE_RESOURCE_DATA_ENTRY;





typedef struct {
    DWORD   Characteristics;
    DWORD   TimeDateStamp;
    WORD    MajorVersion;
    WORD    MinorVersion;
    DWORD   GlobalFlagsClear;
    DWORD   GlobalFlagsSet;
    DWORD   CriticalSectionDefaultTimeout;
    DWORD   DeCommitFreeBlockThreshold;
    DWORD   DeCommitTotalFreeThreshold;
    DWORD   LockPrefixTable;            
    DWORD   MaximumAllocationSize;
    DWORD   VirtualMemoryThreshold;
    DWORD   ProcessHeapFlags;
    DWORD   ProcessAffinityMask;
    WORD    CSDVersion;
    WORD    Reserved1;
    DWORD   EditList;                   
    DWORD   Reserved[ 1 ];
} IMAGE_LOAD_CONFIG_DIRECTORY32, *PIMAGE_LOAD_CONFIG_DIRECTORY32;

typedef struct {
    DWORD   Characteristics;
    DWORD   TimeDateStamp;
    WORD    MajorVersion;
    WORD    MinorVersion;
    DWORD   GlobalFlagsClear;
    DWORD   GlobalFlagsSet;
    DWORD   CriticalSectionDefaultTimeout;
    ULONGLONG  DeCommitFreeBlockThreshold;
    ULONGLONG  DeCommitTotalFreeThreshold;
    ULONGLONG  LockPrefixTable;         
    ULONGLONG  MaximumAllocationSize;
    ULONGLONG  VirtualMemoryThreshold;
    ULONGLONG  ProcessAffinityMask;
    DWORD   ProcessHeapFlags;
    WORD    CSDVersion;
    WORD    Reserved1;
    ULONGLONG  EditList;                
    DWORD   Reserved[ 2 ];
} IMAGE_LOAD_CONFIG_DIRECTORY64, *PIMAGE_LOAD_CONFIG_DIRECTORY64;





typedef IMAGE_LOAD_CONFIG_DIRECTORY32   IMAGE_LOAD_CONFIG_DIRECTORY;
typedef PIMAGE_LOAD_CONFIG_DIRECTORY32  PIMAGE_LOAD_CONFIG_DIRECTORY;
#line 7074 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"










typedef struct _IMAGE_CE_RUNTIME_FUNCTION_ENTRY {
    DWORD FuncStart;
    DWORD PrologLen : 8;
    DWORD FuncLen : 22;
    DWORD ThirtyTwoBit : 1;
    DWORD ExceptionFlag : 1;
} IMAGE_CE_RUNTIME_FUNCTION_ENTRY, * PIMAGE_CE_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY {
    ULONGLONG BeginAddress;
    ULONGLONG EndAddress;
    ULONGLONG ExceptionHandler;
    ULONGLONG HandlerData;
    ULONGLONG PrologEndAddress;
} IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY, *PIMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY {
    DWORD BeginAddress;
    DWORD EndAddress;
    DWORD ExceptionHandler;
    DWORD HandlerData;
    DWORD PrologEndAddress;
} IMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY, *PIMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_RUNTIME_FUNCTION_ENTRY {
    DWORD BeginAddress;
    DWORD EndAddress;
    DWORD UnwindInfoAddress;
} _IMAGE_RUNTIME_FUNCTION_ENTRY, *_PIMAGE_RUNTIME_FUNCTION_ENTRY;

typedef  _IMAGE_RUNTIME_FUNCTION_ENTRY  IMAGE_IA64_RUNTIME_FUNCTION_ENTRY;
typedef _PIMAGE_RUNTIME_FUNCTION_ENTRY PIMAGE_IA64_RUNTIME_FUNCTION_ENTRY;








#line 7125 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"




#line 7130 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef  _IMAGE_RUNTIME_FUNCTION_ENTRY  IMAGE_RUNTIME_FUNCTION_ENTRY;
typedef _PIMAGE_RUNTIME_FUNCTION_ENTRY PIMAGE_RUNTIME_FUNCTION_ENTRY;

#line 7135 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





typedef struct _IMAGE_DEBUG_DIRECTORY {
    DWORD   Characteristics;
    DWORD   TimeDateStamp;
    WORD    MajorVersion;
    WORD    MinorVersion;
    DWORD   Type;
    DWORD   SizeOfData;
    DWORD   AddressOfRawData;
    DWORD   PointerToRawData;
} IMAGE_DEBUG_DIRECTORY, *PIMAGE_DEBUG_DIRECTORY;















typedef struct _IMAGE_COFF_SYMBOLS_HEADER {
    DWORD   NumberOfSymbols;
    DWORD   LvaToFirstSymbol;
    DWORD   NumberOfLinenumbers;
    DWORD   LvaToFirstLinenumber;
    DWORD   RvaToFirstByteOfCode;
    DWORD   RvaToLastByteOfCode;
    DWORD   RvaToFirstByteOfData;
    DWORD   RvaToLastByteOfData;
} IMAGE_COFF_SYMBOLS_HEADER, *PIMAGE_COFF_SYMBOLS_HEADER;






typedef struct _FPO_DATA {
    DWORD       ulOffStart;             
    DWORD       cbProcSize;             
    DWORD       cdwLocals;              
    WORD        cdwParams;              
    WORD        cbProlog : 8;           
    WORD        cbRegs   : 3;           
    WORD        fHasSEH  : 1;           
    WORD        fUseBP   : 1;           
    WORD        reserved : 1;           
    WORD        cbFrame  : 2;           
} FPO_DATA, *PFPO_DATA;





typedef struct _IMAGE_DEBUG_MISC {
    DWORD       DataType;               
    DWORD       Length;                 
                                        
    BOOLEAN     Unicode;                
    BYTE        Reserved[ 3 ];
    BYTE        Data[ 1 ];              
} IMAGE_DEBUG_MISC, *PIMAGE_DEBUG_MISC;








typedef struct _IMAGE_FUNCTION_ENTRY {
    DWORD   StartingAddress;
    DWORD   EndingAddress;
    DWORD   EndOfPrologue;
} IMAGE_FUNCTION_ENTRY, *PIMAGE_FUNCTION_ENTRY;

typedef struct _IMAGE_FUNCTION_ENTRY64 {
    ULONGLONG   StartingAddress;
    ULONGLONG   EndingAddress;
    union {
        ULONGLONG   EndOfPrologue;
        ULONGLONG   UnwindInfoAddress;
    };
} IMAGE_FUNCTION_ENTRY64, *PIMAGE_FUNCTION_ENTRY64;





















typedef struct _IMAGE_SEPARATE_DEBUG_HEADER {
    WORD        Signature;
    WORD        Flags;
    WORD        Machine;
    WORD        Characteristics;
    DWORD       TimeDateStamp;
    DWORD       CheckSum;
    DWORD       ImageBase;
    DWORD       SizeOfImage;
    DWORD       NumberOfSections;
    DWORD       ExportedNamesSize;
    DWORD       DebugDirectorySize;
    DWORD       SectionAlignment;
    DWORD       Reserved[2];
} IMAGE_SEPARATE_DEBUG_HEADER, *PIMAGE_SEPARATE_DEBUG_HEADER;

typedef struct _NON_PAGED_DEBUG_INFO {
    WORD        Signature;
    WORD        Flags;
    DWORD       Size;
    WORD        Machine;
    WORD        Characteristics;
    DWORD       TimeDateStamp;
    DWORD       CheckSum;
    DWORD       SizeOfImage;
    ULONGLONG   ImageBase;
    
    
} NON_PAGED_DEBUG_INFO, *PNON_PAGED_DEBUG_INFO;







#line 7286 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"



                                                









typedef struct _ImageArchitectureHeader {
    unsigned int AmaskValue: 1;                 
                                                
    int :7;                                     
    unsigned int AmaskShift: 8;                 
    int :16;                                    
    DWORD FirstEntryRVA;                        
} IMAGE_ARCHITECTURE_HEADER, *PIMAGE_ARCHITECTURE_HEADER;

typedef struct _ImageArchitectureEntry {
    DWORD FixupInstRVA;                         
    DWORD NewInst;                              
} IMAGE_ARCHITECTURE_ENTRY, *PIMAGE_ARCHITECTURE_ENTRY;

#line 1 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"


#line 36 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 37 "d:\\program files\\microsoft visual studio .net\\vc7\\platformsdk\\include\\poppack.h"
#line 7314 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"








typedef struct IMPORT_OBJECT_HEADER {
    WORD    Sig1;                       
    WORD    Sig2;                       
    WORD    Version;
    WORD    Machine;
    DWORD   TimeDateStamp;              
    DWORD   SizeOfData;                 

    union {
        WORD    Ordinal;                
        WORD    Hint;
    };

    WORD    Type : 2;                   
    WORD    NameType : 3;               
    WORD    Reserved : 11;              
} IMPORT_OBJECT_HEADER;

typedef enum IMPORT_OBJECT_TYPE
{
    IMPORT_OBJECT_CODE = 0,
    IMPORT_OBJECT_DATA = 1,
    IMPORT_OBJECT_CONST = 2,
} IMPORT_OBJECT_TYPE;

typedef enum IMPORT_OBJECT_NAME_TYPE
{
    IMPORT_OBJECT_ORDINAL = 0,          
    IMPORT_OBJECT_NAME = 1,             
    IMPORT_OBJECT_NAME_NO_PREFIX = 2,   
    IMPORT_OBJECT_NAME_UNDECORATE = 3,  
                                        
} IMPORT_OBJECT_NAME_TYPE;





typedef enum ReplacesCorHdrNumericDefines
{

    COMIMAGE_FLAGS_ILONLY               =0x00000001,
    COMIMAGE_FLAGS_32BITREQUIRED        =0x00000002,
    COMIMAGE_FLAGS_IL_LIBRARY           =0x00000004,
    COMIMAGE_FLAGS_TRACKDEBUGDATA       =0x00010000,


    COR_VERSION_MAJOR_V2                =2,
    COR_VERSION_MAJOR                   =COR_VERSION_MAJOR_V2,
    COR_VERSION_MINOR                   =0,
    COR_DELETED_NAME_LENGTH             =8,
    COR_VTABLEGAP_NAME_LENGTH           =8,


    NATIVE_TYPE_MAX_CB                  =1,   
    COR_ILMETHOD_SECT_SMALL_MAX_DATASIZE=0xFF,


    IMAGE_COR_MIH_METHODRVA             =0x01,
    IMAGE_COR_MIH_EHRVA                 =0x02,    
    IMAGE_COR_MIH_BASICBLOCK            =0x08,


    COR_VTABLE_32BIT                    =0x01,          
    COR_VTABLE_64BIT                    =0x02,          
    COR_VTABLE_FROM_UNMANAGED           =0x04,          
    COR_VTABLE_CALL_MOST_DERIVED        =0x10,          


    IMAGE_COR_EATJ_THUNK_SIZE           =32,            


    
    MAX_CLASS_NAME                      =1024,
    MAX_PACKAGE_NAME                    =1024,
} ReplacesCorHdrNumericDefines;


typedef struct IMAGE_COR20_HEADER
{
    
    DWORD                   cb;              
    WORD                    MajorRuntimeVersion;
    WORD                    MinorRuntimeVersion;
    
    
    IMAGE_DATA_DIRECTORY    MetaData;        
    DWORD                   Flags;           
    DWORD                   EntryPointToken;
    
    
    IMAGE_DATA_DIRECTORY    Resources;
    IMAGE_DATA_DIRECTORY    StrongNameSignature;

    
    IMAGE_DATA_DIRECTORY    CodeManagerTable;
    IMAGE_DATA_DIRECTORY    VTableFixups;
    IMAGE_DATA_DIRECTORY    ExportAddressTableJumps;

    
    IMAGE_DATA_DIRECTORY    ManagedNativeHeader;
    
} IMAGE_COR20_HEADER, *PIMAGE_COR20_HEADER;

#line 7427 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"














#line 7442 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


















#line 7461 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef union _SLIST_HEADER {
    ULONGLONG Alignment;
    struct {
        SINGLE_LIST_ENTRY Next;
        WORD   Depth;
        WORD   Sequence;
    };
} SLIST_HEADER, *PSLIST_HEADER;

#line 7472 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 7474 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


__declspec(dllimport)
void
__stdcall
RtlInitializeSListHead (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
RtlFirstEntrySList (
     const SLIST_HEADER *ListHead
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
RtlInterlockedPopEntrySList (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
RtlInterlockedPushEntrySList (
     PSLIST_HEADER ListHead,
     PSINGLE_LIST_ENTRY ListEntry
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
RtlInterlockedFlushSList (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
WORD  
__stdcall
RtlQueryDepthSList (
     PSLIST_HEADER ListHead
    );













































__declspec(dllimport)
SIZE_T
__stdcall
RtlCompareMemory (
    const void *Source1,
    const void *Source2,
    SIZE_T Length
    );






















































#line 7625 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"







#line 7633 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


typedef struct _MESSAGE_RESOURCE_ENTRY {
    WORD   Length;
    WORD   Flags;
    BYTE  Text[ 1 ];
} MESSAGE_RESOURCE_ENTRY, *PMESSAGE_RESOURCE_ENTRY;



typedef struct _MESSAGE_RESOURCE_BLOCK {
    DWORD LowId;
    DWORD HighId;
    DWORD OffsetToEntries;
} MESSAGE_RESOURCE_BLOCK, *PMESSAGE_RESOURCE_BLOCK;

typedef struct _MESSAGE_RESOURCE_DATA {
    DWORD NumberOfBlocks;
    MESSAGE_RESOURCE_BLOCK Blocks[ 1 ];
} MESSAGE_RESOURCE_DATA, *PMESSAGE_RESOURCE_DATA;

typedef struct _OSVERSIONINFOA {
    DWORD dwOSVersionInfoSize;
    DWORD dwMajorVersion;
    DWORD dwMinorVersion;
    DWORD dwBuildNumber;
    DWORD dwPlatformId;
    CHAR   szCSDVersion[ 128 ];     
} OSVERSIONINFOA, *POSVERSIONINFOA, *LPOSVERSIONINFOA;

typedef struct _OSVERSIONINFOW {
    DWORD dwOSVersionInfoSize;
    DWORD dwMajorVersion;
    DWORD dwMinorVersion;
    DWORD dwBuildNumber;
    DWORD dwPlatformId;
    WCHAR  szCSDVersion[ 128 ];     
} OSVERSIONINFOW, *POSVERSIONINFOW, *LPOSVERSIONINFOW, RTL_OSVERSIONINFOW, *PRTL_OSVERSIONINFOW;





typedef OSVERSIONINFOA OSVERSIONINFO;
typedef POSVERSIONINFOA POSVERSIONINFO;
typedef LPOSVERSIONINFOA LPOSVERSIONINFO;
#line 7680 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

typedef struct _OSVERSIONINFOEXA {
    DWORD dwOSVersionInfoSize;
    DWORD dwMajorVersion;
    DWORD dwMinorVersion;
    DWORD dwBuildNumber;
    DWORD dwPlatformId;
    CHAR   szCSDVersion[ 128 ];     
    WORD   wServicePackMajor;
    WORD   wServicePackMinor;
    WORD   wSuiteMask;
    BYTE  wProductType;
    BYTE  wReserved;
} OSVERSIONINFOEXA, *POSVERSIONINFOEXA, *LPOSVERSIONINFOEXA;
typedef struct _OSVERSIONINFOEXW {
    DWORD dwOSVersionInfoSize;
    DWORD dwMajorVersion;
    DWORD dwMinorVersion;
    DWORD dwBuildNumber;
    DWORD dwPlatformId;
    WCHAR  szCSDVersion[ 128 ];     
    WORD   wServicePackMajor;
    WORD   wServicePackMinor;
    WORD   wSuiteMask;
    BYTE  wProductType;
    BYTE  wReserved;
} OSVERSIONINFOEXW, *POSVERSIONINFOEXW, *LPOSVERSIONINFOEXW, RTL_OSVERSIONINFOEXW, *PRTL_OSVERSIONINFOEXW;





typedef OSVERSIONINFOEXA OSVERSIONINFOEX;
typedef POSVERSIONINFOEXA POSVERSIONINFOEX;
typedef LPOSVERSIONINFOEXA LPOSVERSIONINFOEX;
#line 7716 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


























































ULONGLONG
__stdcall
VerSetConditionMask(
          ULONGLONG   ConditionMask,
          DWORD   TypeMask,
          BYTE    Condition
        );


typedef struct _RTL_CRITICAL_SECTION_DEBUG {
    WORD   Type;
    WORD   CreatorBackTraceIndex;
    struct _RTL_CRITICAL_SECTION *CriticalSection;
    LIST_ENTRY ProcessLocksList;
    DWORD EntryCount;
    DWORD ContentionCount;
    DWORD Spare[ 2 ];
} RTL_CRITICAL_SECTION_DEBUG, *PRTL_CRITICAL_SECTION_DEBUG, RTL_RESOURCE_DEBUG, *PRTL_RESOURCE_DEBUG;




typedef struct _RTL_CRITICAL_SECTION {
    PRTL_CRITICAL_SECTION_DEBUG DebugInfo;

    
    
    
    

    LONG LockCount;
    LONG RecursionCount;
    HANDLE OwningThread;        
    HANDLE LockSemaphore;
    ULONG_PTR SpinCount;        
} RTL_CRITICAL_SECTION, *PRTL_CRITICAL_SECTION;

typedef void (* RTL_VERIFIER_DLL_LOAD_CALLBACK) (
    PWSTR DllName,
    PVOID DllBase,
    SIZE_T DllSize,
    PVOID Reserved
    );

typedef void (* RTL_VERIFIER_DLL_UNLOAD_CALLBACK) (
    PWSTR DllName,
    PVOID DllBase,
    SIZE_T DllSize,
    PVOID Reserved
    );

typedef struct _RTL_VERIFIER_THUNK_DESCRIPTOR {

    PCHAR ThunkName;
    PVOID ThunkOldAddress;
    PVOID ThunkNewAddress;

} RTL_VERIFIER_THUNK_DESCRIPTOR, *PRTL_VERIFIER_THUNK_DESCRIPTOR;

typedef struct _RTL_VERIFIER_DLL_DESCRIPTOR {

    PWCHAR DllName;
    DWORD DllFlags;
    PVOID DllAddress;
    PRTL_VERIFIER_THUNK_DESCRIPTOR DllThunks;

} RTL_VERIFIER_DLL_DESCRIPTOR, *PRTL_VERIFIER_DLL_DESCRIPTOR;

typedef struct _RTL_VERIFIER_PROVIDER_DESCRIPTOR {

    
    
    

    DWORD Length;        
    PRTL_VERIFIER_DLL_DESCRIPTOR ProviderDlls;
    RTL_VERIFIER_DLL_LOAD_CALLBACK ProviderDllLoadCallback;
    RTL_VERIFIER_DLL_UNLOAD_CALLBACK ProviderDllUnloadCallback;
    
    
    
    
        
    PWSTR VerifierImage;
    DWORD VerifierFlags;
    DWORD VerifierDebug;

} RTL_VERIFIER_PROVIDER_DESCRIPTOR, *PRTL_VERIFIER_PROVIDER_DESCRIPTOR;

























































void
RtlApplicationVerifierStop (
    ULONG_PTR Code,
    PCHAR Message,
    ULONG_PTR Param1, PCHAR Description1,
    ULONG_PTR Param2, PCHAR Description2,
    ULONG_PTR Param3, PCHAR Description3,
    ULONG_PTR Param4, PCHAR Description4
    );

typedef LONG (__stdcall *PVECTORED_EXCEPTION_HANDLER)(
    struct _EXCEPTION_POINTERS *ExceptionInfo
    );








typedef enum _HEAP_INFORMATION_CLASS {

    HeapCompatibilityInformation

} HEAP_INFORMATION_CLASS;


DWORD   
RtlSetHeapInformation (
     PVOID HeapHandle,
     HEAP_INFORMATION_CLASS HeapInformationClass,
     PVOID HeapInformation ,
     SIZE_T HeapInformationLength 
    );

DWORD   
RtlQueryHeapInformation (
     PVOID HeapHandle,
     HEAP_INFORMATION_CLASS HeapInformationClass,
     PVOID HeapInformation ,
     SIZE_T HeapInformationLength ,
     PSIZE_T ReturnLength 
    );











typedef void (__stdcall * WAITORTIMERCALLBACKFUNC) (PVOID, BOOLEAN );   
typedef void (__stdcall * WORKERCALLBACKFUNC) (PVOID );                 
typedef void (__stdcall * APC_CALLBACK_FUNCTION) (DWORD   , PVOID, PVOID); 



typedef enum _ACTIVATION_CONTEXT_INFO_CLASS {
    ActivationContextBasicInformation                       = 1,
    ActivationContextDetailedInformation                    = 2,
    AssemblyDetailedInformationInActivationContext          = 3,
    FileInformationInAssemblyOfAssemblyInActivationContext  = 4,
    MaxActivationContextInfoClass,

    
    
    
    AssemblyDetailedInformationInActivationContxt           = 3,
    FileInformationInAssemblyOfAssemblyInActivationContxt   = 4
} ACTIVATION_CONTEXT_INFO_CLASS;




typedef struct _ACTIVATION_CONTEXT_QUERY_INDEX {
    DWORD ulAssemblyIndex; 
    DWORD ulFileIndexInAssembly; 
} ACTIVATION_CONTEXT_QUERY_INDEX, * PACTIVATION_CONTEXT_QUERY_INDEX;

typedef const struct _ACTIVATION_CONTEXT_QUERY_INDEX * PCACTIVATION_CONTEXT_QUERY_INDEX;







typedef struct _ASSEMBLY_FILE_DETAILED_INFORMATION {
    DWORD ulFlags;
    DWORD ulFilenameLength;
    DWORD ulPathLength; 

    PCWSTR lpFileName;
    PCWSTR lpFilePath;   
} ASSEMBLY_FILE_DETAILED_INFORMATION, *PASSEMBLY_FILE_DETAILED_INFORMATION;
typedef const ASSEMBLY_FILE_DETAILED_INFORMATION *PCASSEMBLY_FILE_DETAILED_INFORMATION;










typedef struct _ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION {
    DWORD ulFlags;
    DWORD ulEncodedAssemblyIdentityLength;      
    DWORD ulManifestPathType;                   
    DWORD ulManifestPathLength;                 
    LARGE_INTEGER liManifestLastWriteTime;      
    DWORD ulPolicyPathType;                     
    DWORD ulPolicyPathLength;                   
    LARGE_INTEGER liPolicyLastWriteTime;        
    DWORD ulMetadataSatelliteRosterIndex;
    
    DWORD ulManifestVersionMajor;               
    DWORD ulManifestVersionMinor;               
    DWORD ulPolicyVersionMajor;                 
    DWORD ulPolicyVersionMinor;                 
    DWORD ulAssemblyDirectoryNameLength;        

    PCWSTR lpAssemblyEncodedAssemblyIdentity;
    PCWSTR lpAssemblyManifestPath;
    PCWSTR lpAssemblyPolicyPath;
    PCWSTR lpAssemblyDirectoryName;

    DWORD  ulFileCount;
} ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION, * PACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION;

typedef const struct _ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION * PCACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION ;

typedef struct _ACTIVATION_CONTEXT_DETAILED_INFORMATION {
    DWORD dwFlags;
    DWORD ulFormatVersion;
    DWORD ulAssemblyCount;
    DWORD ulRootManifestPathType;
    DWORD ulRootManifestPathChars;
    DWORD ulRootConfigurationPathType;
    DWORD ulRootConfigurationPathChars;
    DWORD ulAppDirPathType;
    DWORD ulAppDirPathChars;
    PCWSTR lpRootManifestPath;
    PCWSTR lpRootConfigurationPath;
    PCWSTR lpAppDirPath;
} ACTIVATION_CONTEXT_DETAILED_INFORMATION, *PACTIVATION_CONTEXT_DETAILED_INFORMATION;

typedef const struct _ACTIVATION_CONTEXT_DETAILED_INFORMATION *PCACTIVATION_CONTEXT_DETAILED_INFORMATION;













































typedef struct _EVENTLOGRECORD {
    DWORD  Length;        
    DWORD  Reserved;      
    DWORD  RecordNumber;  
    DWORD  TimeGenerated; 
    DWORD  TimeWritten;   
    DWORD  EventID;
    WORD   EventType;
    WORD   NumStrings;
    WORD   EventCategory;
    WORD   ReservedFlags; 
    DWORD  ClosingRecordNumber; 
    DWORD  StringOffset;  
    DWORD  UserSidLength;
    DWORD  UserSidOffset;
    DWORD  DataLength;
    DWORD  DataOffset;    
    
    
    
    
    
    
    
    
    
    
    
} EVENTLOGRECORD, *PEVENTLOGRECORD;






#pragma warning(push)
#line 8154 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"
#pragma warning(disable : 4200)
typedef struct _EVENTSFORLOGFILE{
	DWORD			ulSize;
    WCHAR   		szLogicalLogFile[256];        
    DWORD			ulNumRecords;
	EVENTLOGRECORD 	pEventLogRecords[];
}EVENTSFORLOGFILE, *PEVENTSFORLOGFILE;

typedef struct _PACKEDEVENTINFO{
    DWORD               ulSize;  
    DWORD               ulNumEventsForLogFile; 
    DWORD 				ulOffsets[];           
}PACKEDEVENTINFO, *PPACKEDEVENTINFO;


#pragma warning(pop)


#line 8173 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"





















































                                                    


                                                    


                                                    


                                                    
                                                    


























































                                            






























































typedef enum _CM_SERVICE_NODE_TYPE {
    DriverType               = 0x00000001,
    FileSystemType           = 0x00000002,
    Win32ServiceOwnProcess   = 0x00000010,
    Win32ServiceShareProcess = 0x00000020,
    AdapterType              = 0x00000004,
    RecognizerType           = 0x00000008
} SERVICE_NODE_TYPE;

typedef enum _CM_SERVICE_LOAD_TYPE {
    BootLoad    = 0x00000000,
    SystemLoad  = 0x00000001,
    AutoLoad    = 0x00000002,
    DemandLoad  = 0x00000003,
    DisableLoad = 0x00000004
} SERVICE_LOAD_TYPE;

typedef enum _CM_ERROR_CONTROL_TYPE {
    IgnoreError   = 0x00000000,
    NormalError   = 0x00000001,
    SevereError   = 0x00000002,
    CriticalError = 0x00000003
} SERVICE_ERROR_TYPE;










typedef struct _TAPE_ERASE {
    DWORD Type;
    BOOLEAN Immediate;
} TAPE_ERASE, *PTAPE_ERASE;












typedef struct _TAPE_PREPARE {
    DWORD Operation;
    BOOLEAN Immediate;
} TAPE_PREPARE, *PTAPE_PREPARE;










typedef struct _TAPE_WRITE_MARKS {
    DWORD Type;
    DWORD Count;
    BOOLEAN Immediate;
} TAPE_WRITE_MARKS, *PTAPE_WRITE_MARKS;









typedef struct _TAPE_GET_POSITION {
    DWORD Type;
    DWORD Partition;
    LARGE_INTEGER Offset;
} TAPE_GET_POSITION, *PTAPE_GET_POSITION;
















typedef struct _TAPE_SET_POSITION {
    DWORD Method;
    DWORD Partition;
    LARGE_INTEGER Offset;
    BOOLEAN Immediate;
} TAPE_SET_POSITION, *PTAPE_SET_POSITION;























































































typedef struct _TAPE_GET_DRIVE_PARAMETERS {
    BOOLEAN ECC;
    BOOLEAN Compression;
    BOOLEAN DataPadding;
    BOOLEAN ReportSetmarks;
    DWORD DefaultBlockSize;
    DWORD MaximumBlockSize;
    DWORD MinimumBlockSize;
    DWORD MaximumPartitionCount;
    DWORD FeaturesLow;
    DWORD FeaturesHigh;
    DWORD EOTWarningZoneSize;
} TAPE_GET_DRIVE_PARAMETERS, *PTAPE_GET_DRIVE_PARAMETERS;





typedef struct _TAPE_SET_DRIVE_PARAMETERS {
    BOOLEAN ECC;
    BOOLEAN Compression;
    BOOLEAN DataPadding;
    BOOLEAN ReportSetmarks;
    DWORD EOTWarningZoneSize;
} TAPE_SET_DRIVE_PARAMETERS, *PTAPE_SET_DRIVE_PARAMETERS;





typedef struct _TAPE_GET_MEDIA_PARAMETERS {
    LARGE_INTEGER Capacity;
    LARGE_INTEGER Remaining;
    DWORD BlockSize;
    DWORD PartitionCount;
    BOOLEAN WriteProtected;
} TAPE_GET_MEDIA_PARAMETERS, *PTAPE_GET_MEDIA_PARAMETERS;





typedef struct _TAPE_SET_MEDIA_PARAMETERS {
    DWORD BlockSize;
} TAPE_SET_MEDIA_PARAMETERS, *PTAPE_SET_MEDIA_PARAMETERS;









typedef struct _TAPE_CREATE_PARTITION {
    DWORD Method;
    DWORD Count;
    DWORD Size;
} TAPE_CREATE_PARTITION, *PTAPE_CREATE_PARTITION;











typedef struct _TAPE_WMI_OPERATIONS {
   DWORD Method;
   DWORD DataBufferSize;
   PVOID DataBuffer;
} TAPE_WMI_OPERATIONS, *PTAPE_WMI_OPERATIONS;




typedef enum _TAPE_DRIVE_PROBLEM_TYPE {
   TapeDriveProblemNone, TapeDriveReadWriteWarning,
   TapeDriveReadWriteError, TapeDriveReadWarning,
   TapeDriveWriteWarning, TapeDriveReadError,
   TapeDriveWriteError, TapeDriveHardwareError,
   TapeDriveUnsupportedMedia, TapeDriveScsiConnectionError,
   TapeDriveTimetoClean, TapeDriveCleanDriveNow,
   TapeDriveMediaLifeExpired, TapeDriveSnappedTape
} TAPE_DRIVE_PROBLEM_TYPE;



























#line 8665 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"










#line 8676 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"


}
#line 8680 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 8682 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnt.h"

#line 167 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
#line 168 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"


typedef UINT_PTR            WPARAM;
typedef LONG_PTR            LPARAM;
typedef LONG_PTR            LRESULT;





#line 179 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



#line 183 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

#line 185 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"










struct HWND__ { int unused; }; typedef struct HWND__ *HWND;
struct HHOOK__ { int unused; }; typedef struct HHOOK__ *HHOOK;



#line 201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

typedef WORD                ATOM;

typedef HANDLE          *SPHANDLE;
typedef HANDLE           *LPHANDLE;
typedef HANDLE              HGLOBAL;
typedef HANDLE              HLOCAL;
typedef HANDLE              GLOBALHANDLE;
typedef HANDLE              LOCALHANDLE;






typedef int ( __stdcall *FARPROC)();
typedef int ( __stdcall *NEARPROC)();
typedef int (__stdcall *PROC)();
#line 220 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"




#line 225 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"



typedef void * HGDIOBJ;


#line 232 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
#line 233 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

struct HKEY__ { int unused; }; typedef struct HKEY__ *HKEY;
typedef HKEY *PHKEY;


struct HACCEL__ { int unused; }; typedef struct HACCEL__ *HACCEL;
#line 240 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

struct HBITMAP__ { int unused; }; typedef struct HBITMAP__ *HBITMAP;
struct HBRUSH__ { int unused; }; typedef struct HBRUSH__ *HBRUSH;
#line 244 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

struct HCOLORSPACE__ { int unused; }; typedef struct HCOLORSPACE__ *HCOLORSPACE;
#line 247 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

struct HDC__ { int unused; }; typedef struct HDC__ *HDC;
#line 250 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
struct HGLRC__ { int unused; }; typedef struct HGLRC__ *HGLRC;          
struct HDESK__ { int unused; }; typedef struct HDESK__ *HDESK;
struct HENHMETAFILE__ { int unused; }; typedef struct HENHMETAFILE__ *HENHMETAFILE;

struct HFONT__ { int unused; }; typedef struct HFONT__ *HFONT;
#line 256 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
struct HICON__ { int unused; }; typedef struct HICON__ *HICON;

struct HMENU__ { int unused; }; typedef struct HMENU__ *HMENU;
#line 260 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
struct HMETAFILE__ { int unused; }; typedef struct HMETAFILE__ *HMETAFILE;
struct HINSTANCE__ { int unused; }; typedef struct HINSTANCE__ *HINSTANCE;
typedef HINSTANCE HMODULE;      

struct HPALETTE__ { int unused; }; typedef struct HPALETTE__ *HPALETTE;
struct HPEN__ { int unused; }; typedef struct HPEN__ *HPEN;
#line 267 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
struct HRGN__ { int unused; }; typedef struct HRGN__ *HRGN;
struct HRSRC__ { int unused; }; typedef struct HRSRC__ *HRSRC;
struct HSTR__ { int unused; }; typedef struct HSTR__ *HSTR;
struct HTASK__ { int unused; }; typedef struct HTASK__ *HTASK;
struct HWINSTA__ { int unused; }; typedef struct HWINSTA__ *HWINSTA;
struct HKL__ { int unused; }; typedef struct HKL__ *HKL;



struct HMONITOR__ { int unused; }; typedef struct HMONITOR__ *HMONITOR;
struct HWINEVENTHOOK__ { int unused; }; typedef struct HWINEVENTHOOK__ *HWINEVENTHOOK;
#line 279 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
struct HUMPD__ { int unused; }; typedef struct HUMPD__ *HUMPD;
#line 281 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"


typedef int HFILE;
typedef HICON HCURSOR;      



#line 289 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

typedef DWORD   COLORREF;
typedef DWORD   *LPCOLORREF;



typedef struct tagRECT
{
    LONG    left;
    LONG    top;
    LONG    right;
    LONG    bottom;
} RECT, *PRECT,  *NPRECT,  *LPRECT;

typedef const RECT * LPCRECT;

typedef struct _RECTL       
{
    LONG    left;
    LONG    top;
    LONG    right;
    LONG    bottom;
} RECTL, *PRECTL, *LPRECTL;

typedef const RECTL * LPCRECTL;

typedef struct tagPOINT
{
    LONG  x;
    LONG  y;
} POINT, *PPOINT,  *NPPOINT,  *LPPOINT;

typedef struct _POINTL      
{
    LONG  x;
    LONG  y;
} POINTL, *PPOINTL;

typedef struct tagSIZE
{
    LONG        cx;
    LONG        cy;
} SIZE, *PSIZE, *LPSIZE;

typedef SIZE               SIZEL;
typedef SIZE               *PSIZEL, *LPSIZEL;

typedef struct tagPOINTS
{

    SHORT   x;
    SHORT   y;



#line 345 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"
} POINTS, *PPOINTS, *LPPOINTS;

































}
#line 381 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

#line 383 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windef.h"

#line 162 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"













#line 32 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





#line 44 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


extern "C" {
#line 48 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"













































































































#line 158 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"









#line 168 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


























































typedef struct _OVERLAPPED {
    ULONG_PTR Internal;
    ULONG_PTR InternalHigh;
    union {
        struct {
            DWORD Offset;
            DWORD OffsetHigh;
        };

        PVOID Pointer;
    };

    HANDLE  hEvent;
} OVERLAPPED, *LPOVERLAPPED;

typedef struct _SECURITY_ATTRIBUTES {
    DWORD nLength;
    LPVOID lpSecurityDescriptor;
    BOOL bInheritHandle;
} SECURITY_ATTRIBUTES, *PSECURITY_ATTRIBUTES, *LPSECURITY_ATTRIBUTES;

typedef struct _PROCESS_INFORMATION {
    HANDLE hProcess;
    HANDLE hThread;
    DWORD dwProcessId;
    DWORD dwThreadId;
} PROCESS_INFORMATION, *PPROCESS_INFORMATION, *LPPROCESS_INFORMATION;






typedef struct _FILETIME {
    DWORD dwLowDateTime;
    DWORD dwHighDateTime;
} FILETIME, *PFILETIME, *LPFILETIME;






typedef struct _SYSTEMTIME {
    WORD wYear;
    WORD wMonth;
    WORD wDayOfWeek;
    WORD wDay;
    WORD wHour;
    WORD wMinute;
    WORD wSecond;
    WORD wMilliseconds;
} SYSTEMTIME, *PSYSTEMTIME, *LPSYSTEMTIME;


typedef DWORD (__stdcall *PTHREAD_START_ROUTINE)(
    LPVOID lpThreadParameter
    );
typedef PTHREAD_START_ROUTINE LPTHREAD_START_ROUTINE;






#line 292 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

typedef RTL_CRITICAL_SECTION CRITICAL_SECTION;
typedef PRTL_CRITICAL_SECTION PCRITICAL_SECTION;
typedef PRTL_CRITICAL_SECTION LPCRITICAL_SECTION;

typedef RTL_CRITICAL_SECTION_DEBUG CRITICAL_SECTION_DEBUG;
typedef PRTL_CRITICAL_SECTION_DEBUG PCRITICAL_SECTION_DEBUG;
typedef PRTL_CRITICAL_SECTION_DEBUG LPCRITICAL_SECTION_DEBUG;


typedef PLDT_ENTRY LPLDT_ENTRY;


#line 306 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"









































































































typedef struct _COMMPROP {
    WORD wPacketLength;
    WORD wPacketVersion;
    DWORD dwServiceMask;
    DWORD dwReserved1;
    DWORD dwMaxTxQueue;
    DWORD dwMaxRxQueue;
    DWORD dwMaxBaud;
    DWORD dwProvSubType;
    DWORD dwProvCapabilities;
    DWORD dwSettableParams;
    DWORD dwSettableBaud;
    WORD wSettableData;
    WORD wSettableStopParity;
    DWORD dwCurrentTxQueue;
    DWORD dwCurrentRxQueue;
    DWORD dwProvSpec1;
    DWORD dwProvSpec2;
    WCHAR wcProvChar[1];
} COMMPROP,*LPCOMMPROP;







typedef struct _COMSTAT {
    DWORD fCtsHold : 1;
    DWORD fDsrHold : 1;
    DWORD fRlsdHold : 1;
    DWORD fXoffHold : 1;
    DWORD fXoffSent : 1;
    DWORD fEof : 1;
    DWORD fTxim : 1;
    DWORD fReserved : 25;
    DWORD cbInQue;
    DWORD cbOutQue;
} COMSTAT, *LPCOMSTAT;
















typedef struct _DCB {
    DWORD DCBlength;      
    DWORD BaudRate;       
    DWORD fBinary: 1;     
    DWORD fParity: 1;     
    DWORD fOutxCtsFlow:1; 
    DWORD fOutxDsrFlow:1; 
    DWORD fDtrControl:2;  
    DWORD fDsrSensitivity:1; 
    DWORD fTXContinueOnXoff: 1; 
    DWORD fOutX: 1;       
    DWORD fInX: 1;        
    DWORD fErrorChar: 1;  
    DWORD fNull: 1;       
    DWORD fRtsControl:2;  
    DWORD fAbortOnError:1; 
    DWORD fDummy2:17;     
    WORD wReserved;       
    WORD XonLim;          
    WORD XoffLim;         
    BYTE ByteSize;        
    BYTE Parity;          
    BYTE StopBits;        
    char XonChar;         
    char XoffChar;        
    char ErrorChar;       
    char EofChar;         
    char EvtChar;         
    WORD wReserved1;      
} DCB, *LPDCB;

typedef struct _COMMTIMEOUTS {
    DWORD ReadIntervalTimeout;          
    DWORD ReadTotalTimeoutMultiplier;   
    DWORD ReadTotalTimeoutConstant;     
    DWORD WriteTotalTimeoutMultiplier;  
    DWORD WriteTotalTimeoutConstant;    
} COMMTIMEOUTS,*LPCOMMTIMEOUTS;

typedef struct _COMMCONFIG {
    DWORD dwSize;               
    WORD wVersion;              
    WORD wReserved;             
    DCB dcb;                    
    DWORD dwProviderSubType;    

    DWORD dwProviderOffset;     

    DWORD dwProviderSize;       
    WCHAR wcProviderData[1];    
} COMMCONFIG,*LPCOMMCONFIG;

typedef struct _SYSTEM_INFO {
    union {
        DWORD dwOemId;          
        struct {
            WORD wProcessorArchitecture;
            WORD wReserved;
        };
    };
    DWORD dwPageSize;
    LPVOID lpMinimumApplicationAddress;
    LPVOID lpMaximumApplicationAddress;
    DWORD_PTR dwActiveProcessorMask;
    DWORD dwNumberOfProcessors;
    DWORD dwProcessorType;
    DWORD dwAllocationGranularity;
    WORD wProcessorLevel;
    WORD wProcessorRevision;
} SYSTEM_INFO, *LPSYSTEM_INFO;




































typedef struct _MEMORYSTATUS {
    DWORD dwLength;
    DWORD dwMemoryLoad;
    SIZE_T dwTotalPhys;
    SIZE_T dwAvailPhys;
    SIZE_T dwTotalPageFile;
    SIZE_T dwAvailPageFile;
    SIZE_T dwTotalVirtual;
    SIZE_T dwAvailVirtual;
} MEMORYSTATUS, *LPMEMORYSTATUS;
























































































typedef struct _EXCEPTION_DEBUG_INFO {
    EXCEPTION_RECORD ExceptionRecord;
    DWORD dwFirstChance;
} EXCEPTION_DEBUG_INFO, *LPEXCEPTION_DEBUG_INFO;

typedef struct _CREATE_THREAD_DEBUG_INFO {
    HANDLE hThread;
    LPVOID lpThreadLocalBase;
    LPTHREAD_START_ROUTINE lpStartAddress;
} CREATE_THREAD_DEBUG_INFO, *LPCREATE_THREAD_DEBUG_INFO;

typedef struct _CREATE_PROCESS_DEBUG_INFO {
    HANDLE hFile;
    HANDLE hProcess;
    HANDLE hThread;
    LPVOID lpBaseOfImage;
    DWORD dwDebugInfoFileOffset;
    DWORD nDebugInfoSize;
    LPVOID lpThreadLocalBase;
    LPTHREAD_START_ROUTINE lpStartAddress;
    LPVOID lpImageName;
    WORD fUnicode;
} CREATE_PROCESS_DEBUG_INFO, *LPCREATE_PROCESS_DEBUG_INFO;

typedef struct _EXIT_THREAD_DEBUG_INFO {
    DWORD dwExitCode;
} EXIT_THREAD_DEBUG_INFO, *LPEXIT_THREAD_DEBUG_INFO;

typedef struct _EXIT_PROCESS_DEBUG_INFO {
    DWORD dwExitCode;
} EXIT_PROCESS_DEBUG_INFO, *LPEXIT_PROCESS_DEBUG_INFO;

typedef struct _LOAD_DLL_DEBUG_INFO {
    HANDLE hFile;
    LPVOID lpBaseOfDll;
    DWORD dwDebugInfoFileOffset;
    DWORD nDebugInfoSize;
    LPVOID lpImageName;
    WORD fUnicode;
} LOAD_DLL_DEBUG_INFO, *LPLOAD_DLL_DEBUG_INFO;

typedef struct _UNLOAD_DLL_DEBUG_INFO {
    LPVOID lpBaseOfDll;
} UNLOAD_DLL_DEBUG_INFO, *LPUNLOAD_DLL_DEBUG_INFO;

typedef struct _OUTPUT_DEBUG_STRING_INFO {
    LPSTR lpDebugStringData;
    WORD fUnicode;
    WORD nDebugStringLength;
} OUTPUT_DEBUG_STRING_INFO, *LPOUTPUT_DEBUG_STRING_INFO;

typedef struct _RIP_INFO {
    DWORD dwError;
    DWORD dwType;
} RIP_INFO, *LPRIP_INFO;


typedef struct _DEBUG_EVENT {
    DWORD dwDebugEventCode;
    DWORD dwProcessId;
    DWORD dwThreadId;
    union {
        EXCEPTION_DEBUG_INFO Exception;
        CREATE_THREAD_DEBUG_INFO CreateThread;
        CREATE_PROCESS_DEBUG_INFO CreateProcessInfo;
        EXIT_THREAD_DEBUG_INFO ExitThread;
        EXIT_PROCESS_DEBUG_INFO ExitProcess;
        LOAD_DLL_DEBUG_INFO LoadDll;
        UNLOAD_DLL_DEBUG_INFO UnloadDll;
        OUTPUT_DEBUG_STRING_INFO DebugString;
        RIP_INFO RipInfo;
    } u;
} DEBUG_EVENT, *LPDEBUG_EVENT;


typedef PCONTEXT LPCONTEXT;
typedef PEXCEPTION_RECORD LPEXCEPTION_RECORD;
typedef PEXCEPTION_POINTERS LPEXCEPTION_POINTERS;
#line 749 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"














#line 764 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"















































































































































































































typedef struct _OFSTRUCT {
    BYTE cBytes;
    BYTE fFixedDisk;
    WORD nErrCode;
    WORD Reserved1;
    WORD Reserved2;
    CHAR szPathName[128];
} OFSTRUCT, *LPOFSTRUCT, *POFSTRUCT;













































































#line 1057 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



























































#line 1117 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
LONG
__stdcall
InterlockedIncrement(
      LONG volatile *lpAddend
    );

__declspec(dllimport)
LONG
__stdcall
InterlockedDecrement(
      LONG volatile *lpAddend
    );

__declspec(dllimport)
LONG
__stdcall
InterlockedExchange(
      LONG volatile *Target,
     LONG Value
    );




__declspec(dllimport)
LONG
__stdcall
InterlockedExchangeAdd(
      LONG volatile *Addend,
     LONG Value
    );

__declspec(dllimport)
LONG
__stdcall
InterlockedCompareExchange (
      LONG volatile *Destination,
     LONG Exchange,
     LONG Comperand
    );







__forceinline
PVOID
__cdecl
__InlineInterlockedCompareExchangePointer (
      PVOID volatile *Destination,
     PVOID ExChange,
     PVOID Comperand
    )
{
    return((PVOID)(LONG_PTR)InterlockedCompareExchange((LONG volatile *)Destination, (LONG)(LONG_PTR)ExChange, (LONG)(LONG_PTR)Comperand));
}








#line 1186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

#line 1188 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
void
__stdcall
InitializeSListHead (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
InterlockedPopEntrySList (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
InterlockedPushEntrySList (
     PSLIST_HEADER ListHead,
     PSINGLE_LIST_ENTRY ListEntry
    );

__declspec(dllimport)
PSINGLE_LIST_ENTRY
__stdcall
InterlockedFlushSList (
     PSLIST_HEADER ListHead
    );

__declspec(dllimport)
USHORT
__stdcall
QueryDepthSList (
     PSLIST_HEADER ListHead
    );

#line 1228 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 1229 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

#line 1231 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
FreeResource(
         HGLOBAL hResData
        );

__declspec(dllimport)
LPVOID
__stdcall
LockResource(
         HGLOBAL hResData
        );







int
__stdcall



#line 1258 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
WinMain(
     HINSTANCE hInstance,
     HINSTANCE hPrevInstance,
     LPSTR lpCmdLine,
     int nShowCmd
    );

__declspec(dllimport)
BOOL
__stdcall
FreeLibrary(
      HMODULE hLibModule
    );


__declspec(dllimport)
__declspec(noreturn)
void
__stdcall
FreeLibraryAndExitThread(
     HMODULE hLibModule,
     DWORD dwExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
DisableThreadLibraryCalls(
     HMODULE hLibModule
    );

__declspec(dllimport)
FARPROC
__stdcall
GetProcAddress(
     HMODULE hModule,
     LPCSTR lpProcName
    );

__declspec(dllimport)
DWORD
__stdcall
GetVersion( void );

__declspec(dllimport)
HGLOBAL
__stdcall
GlobalAlloc(
     UINT uFlags,
     SIZE_T dwBytes
    );

__declspec(dllimport)
HGLOBAL
__stdcall
GlobalReAlloc(
     HGLOBAL hMem,
     SIZE_T dwBytes,
     UINT uFlags
    );

__declspec(dllimport)
SIZE_T
__stdcall
GlobalSize(
     HGLOBAL hMem
    );

__declspec(dllimport)
UINT
__stdcall
GlobalFlags(
     HGLOBAL hMem
    );


__declspec(dllimport)
LPVOID
__stdcall
GlobalLock(
     HGLOBAL hMem
    );


__declspec(dllimport)
HGLOBAL
__stdcall
GlobalHandle(
     LPCVOID pMem
    );


__declspec(dllimport)
BOOL
__stdcall
GlobalUnlock(
     HGLOBAL hMem
    );


__declspec(dllimport)
HGLOBAL
__stdcall
GlobalFree(
     HGLOBAL hMem
    );

__declspec(dllimport)
SIZE_T
__stdcall
GlobalCompact(
     DWORD dwMinFree
    );

__declspec(dllimport)
void
__stdcall
GlobalFix(
     HGLOBAL hMem
    );

__declspec(dllimport)
void
__stdcall
GlobalUnfix(
     HGLOBAL hMem
    );

__declspec(dllimport)
LPVOID
__stdcall
GlobalWire(
     HGLOBAL hMem
    );

__declspec(dllimport)
BOOL
__stdcall
GlobalUnWire(
     HGLOBAL hMem
    );

__declspec(dllimport)
void
__stdcall
GlobalMemoryStatus(
      LPMEMORYSTATUS lpBuffer
    );

typedef struct _MEMORYSTATUSEX {
    DWORD dwLength;
    DWORD dwMemoryLoad;
    DWORDLONG ullTotalPhys;
    DWORDLONG ullAvailPhys;
    DWORDLONG ullTotalPageFile;
    DWORDLONG ullAvailPageFile;
    DWORDLONG ullTotalVirtual;
    DWORDLONG ullAvailVirtual;
    DWORDLONG ullAvailExtendedVirtual;
} MEMORYSTATUSEX, *LPMEMORYSTATUSEX;

__declspec(dllimport)
BOOL
__stdcall
GlobalMemoryStatusEx(
      LPMEMORYSTATUSEX lpBuffer
    );

__declspec(dllimport)
HLOCAL
__stdcall
LocalAlloc(
     UINT uFlags,
     SIZE_T uBytes
    );

__declspec(dllimport)
HLOCAL
__stdcall
LocalReAlloc(
     HLOCAL hMem,
     SIZE_T uBytes,
     UINT uFlags
    );

__declspec(dllimport)
LPVOID
__stdcall
LocalLock(
     HLOCAL hMem
    );

__declspec(dllimport)
HLOCAL
__stdcall
LocalHandle(
     LPCVOID pMem
    );

__declspec(dllimport)
BOOL
__stdcall
LocalUnlock(
     HLOCAL hMem
    );

__declspec(dllimport)
SIZE_T
__stdcall
LocalSize(
     HLOCAL hMem
    );

__declspec(dllimport)
UINT
__stdcall
LocalFlags(
     HLOCAL hMem
    );

__declspec(dllimport)
HLOCAL
__stdcall
LocalFree(
     HLOCAL hMem
    );

__declspec(dllimport)
SIZE_T
__stdcall
LocalShrink(
     HLOCAL hMem,
     UINT cbNewSize
    );

__declspec(dllimport)
SIZE_T
__stdcall
LocalCompact(
     UINT uMinFree
    );

__declspec(dllimport)
BOOL
__stdcall
FlushInstructionCache(
     HANDLE hProcess,
     LPCVOID lpBaseAddress,
     SIZE_T dwSize
    );

__declspec(dllimport)
LPVOID
__stdcall
VirtualAlloc(
     LPVOID lpAddress,
     SIZE_T dwSize,
     DWORD flAllocationType,
     DWORD flProtect
    );

__declspec(dllimport)
BOOL
__stdcall
VirtualFree(
     LPVOID lpAddress,
     SIZE_T dwSize,
     DWORD dwFreeType
    );

__declspec(dllimport)
BOOL
__stdcall
VirtualProtect(
      LPVOID lpAddress,
      SIZE_T dwSize,
      DWORD flNewProtect,
     PDWORD lpflOldProtect
    );

__declspec(dllimport)
SIZE_T
__stdcall
VirtualQuery(
     LPCVOID lpAddress,
     PMEMORY_BASIC_INFORMATION lpBuffer,
     SIZE_T dwLength
    );

__declspec(dllimport)
LPVOID
__stdcall
VirtualAllocEx(
     HANDLE hProcess,
     LPVOID lpAddress,
     SIZE_T dwSize,
     DWORD flAllocationType,
     DWORD flProtect
    );

__declspec(dllimport)
UINT
__stdcall
GetWriteWatch(
     DWORD  dwFlags,
     PVOID  lpBaseAddress,
     SIZE_T dwRegionSize,
      PVOID *lpAddresses,
      PULONG_PTR lpdwCount,
     PULONG lpdwGranularity
    );

__declspec(dllimport)
UINT
__stdcall
ResetWriteWatch(
     LPVOID lpBaseAddress,
     SIZE_T dwRegionSize
    );

__declspec(dllimport)
BOOL
__stdcall
VirtualFreeEx(
     HANDLE hProcess,
     LPVOID lpAddress,
     SIZE_T dwSize,
     DWORD dwFreeType
    );

__declspec(dllimport)
BOOL
__stdcall
VirtualProtectEx(
      HANDLE hProcess,
      LPVOID lpAddress,
      SIZE_T dwSize,
      DWORD flNewProtect,
     PDWORD lpflOldProtect
    );

__declspec(dllimport)
SIZE_T
__stdcall
VirtualQueryEx(
     HANDLE hProcess,
     LPCVOID lpAddress,
     PMEMORY_BASIC_INFORMATION lpBuffer,
     SIZE_T dwLength
    );

__declspec(dllimport)
HANDLE
__stdcall
HeapCreate(
     DWORD flOptions,
     SIZE_T dwInitialSize,
     SIZE_T dwMaximumSize
    );

__declspec(dllimport)
BOOL
__stdcall
HeapDestroy(
      HANDLE hHeap
    );


__declspec(dllimport)
LPVOID
__stdcall
HeapAlloc(
     HANDLE hHeap,
     DWORD dwFlags,
     SIZE_T dwBytes
    );

__declspec(dllimport)
LPVOID
__stdcall
HeapReAlloc(
     HANDLE hHeap,
     DWORD dwFlags,
     LPVOID lpMem,
     SIZE_T dwBytes
    );

__declspec(dllimport)
BOOL
__stdcall
HeapFree(
     HANDLE hHeap,
     DWORD dwFlags,
     LPVOID lpMem
    );

__declspec(dllimport)
SIZE_T
__stdcall
HeapSize(
     HANDLE hHeap,
     DWORD dwFlags,
     LPCVOID lpMem
    );

__declspec(dllimport)
BOOL
__stdcall
HeapValidate(
     HANDLE hHeap,
     DWORD dwFlags,
     LPCVOID lpMem
    );

__declspec(dllimport)
SIZE_T
__stdcall
HeapCompact(
     HANDLE hHeap,
     DWORD dwFlags
    );

__declspec(dllimport)
HANDLE
__stdcall
GetProcessHeap( void );

__declspec(dllimport)
DWORD
__stdcall
GetProcessHeaps(
     DWORD NumberOfHeaps,
     PHANDLE ProcessHeaps
    );

typedef struct _PROCESS_HEAP_ENTRY {
    PVOID lpData;
    DWORD cbData;
    BYTE cbOverhead;
    BYTE iRegionIndex;
    WORD wFlags;
    union {
        struct {
            HANDLE hMem;
            DWORD dwReserved[ 3 ];
        } Block;
        struct {
            DWORD dwCommittedSize;
            DWORD dwUnCommittedSize;
            LPVOID lpFirstBlock;
            LPVOID lpLastBlock;
        } Region;
    };
} PROCESS_HEAP_ENTRY, *LPPROCESS_HEAP_ENTRY, *PPROCESS_HEAP_ENTRY;







__declspec(dllimport)
BOOL
__stdcall
HeapLock(
     HANDLE hHeap
    );

__declspec(dllimport)
BOOL
__stdcall
HeapUnlock(
     HANDLE hHeap
    );


__declspec(dllimport)
BOOL
__stdcall
HeapWalk(
     HANDLE hHeap,
      LPPROCESS_HEAP_ENTRY lpEntry
    );


__declspec(dllimport)
BOOL
__stdcall
HeapSetInformation (
     PVOID HeapHandle, 
     HEAP_INFORMATION_CLASS HeapInformationClass,
     PVOID HeapInformation ,
     SIZE_T HeapInformationLength 
    );

__declspec(dllimport)
BOOL
__stdcall
HeapQueryInformation (
     PVOID HeapHandle, 
     HEAP_INFORMATION_CLASS HeapInformationClass,
     PVOID HeapInformation ,
     SIZE_T HeapInformationLength ,
     PSIZE_T ReturnLength 
    );













#line 1777 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

#line 1779 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetBinaryTypeA(
     LPCSTR lpApplicationName,
     LPDWORD lpBinaryType
    );
__declspec(dllimport)
BOOL
__stdcall
GetBinaryTypeW(
     LPCWSTR lpApplicationName,
     LPDWORD lpBinaryType
    );




#line 1799 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetShortPathNameA(
     LPCSTR lpszLongPath,
     LPSTR  lpszShortPath,
     DWORD    cchBuffer
    );
__declspec(dllimport)
DWORD
__stdcall
GetShortPathNameW(
     LPCWSTR lpszLongPath,
     LPWSTR  lpszShortPath,
     DWORD    cchBuffer
    );




#line 1821 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetLongPathNameA(
     LPCSTR lpszShortPath,
     LPSTR  lpszLongPath,
     DWORD    cchBuffer
    );
__declspec(dllimport)
DWORD
__stdcall
GetLongPathNameW(
     LPCWSTR lpszShortPath,
     LPWSTR  lpszLongPath,
     DWORD    cchBuffer
    );




#line 1843 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetProcessAffinityMask(
     HANDLE hProcess,
     PDWORD_PTR lpProcessAffinityMask,
     PDWORD_PTR lpSystemAffinityMask
    );

__declspec(dllimport)
BOOL
__stdcall
SetProcessAffinityMask(
     HANDLE hProcess,
     DWORD_PTR dwProcessAffinityMask
    );


__declspec(dllimport)
BOOL
__stdcall
GetProcessTimes(
     HANDLE hProcess,
     LPFILETIME lpCreationTime,
     LPFILETIME lpExitTime,
     LPFILETIME lpKernelTime,
     LPFILETIME lpUserTime
    );

__declspec(dllimport)
BOOL
__stdcall
GetProcessIoCounters(
     HANDLE hProcess,
     PIO_COUNTERS lpIoCounters
    );

__declspec(dllimport)
BOOL
__stdcall
GetProcessWorkingSetSize(
     HANDLE hProcess,
     PSIZE_T lpMinimumWorkingSetSize,
     PSIZE_T lpMaximumWorkingSetSize
    );

__declspec(dllimport)
BOOL
__stdcall
SetProcessWorkingSetSize(
     HANDLE hProcess,
     SIZE_T dwMinimumWorkingSetSize,
     SIZE_T dwMaximumWorkingSetSize
    );

__declspec(dllimport)
HANDLE
__stdcall
OpenProcess(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     DWORD dwProcessId
    );

__declspec(dllimport)
HANDLE
__stdcall
GetCurrentProcess(
    void
    );

__declspec(dllimport)
DWORD
__stdcall
GetCurrentProcessId(
    void
    );

__declspec(dllimport)
__declspec(noreturn)
void
__stdcall
ExitProcess(
     UINT uExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
TerminateProcess(
     HANDLE hProcess,
     UINT uExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
GetExitCodeProcess(
     HANDLE hProcess,
     LPDWORD lpExitCode
    );


__declspec(dllimport)
void
__stdcall
FatalExit(
     int ExitCode
    );

__declspec(dllimport)
LPSTR
__stdcall
GetEnvironmentStrings(
    void
    );

__declspec(dllimport)
LPWSTR
__stdcall
GetEnvironmentStringsW(
    void
    );





#line 1973 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
FreeEnvironmentStringsA(
     LPSTR
    );
__declspec(dllimport)
BOOL
__stdcall
FreeEnvironmentStringsW(
     LPWSTR
    );




#line 1991 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
void
__stdcall
RaiseException(
     DWORD dwExceptionCode,
     DWORD dwExceptionFlags,
     DWORD nNumberOfArguments,
     const ULONG_PTR *lpArguments
    );

__declspec(dllimport)
LONG
__stdcall
UnhandledExceptionFilter(
     struct _EXCEPTION_POINTERS *ExceptionInfo
    );

typedef LONG (__stdcall *PTOP_LEVEL_EXCEPTION_FILTER)(
    struct _EXCEPTION_POINTERS *ExceptionInfo
    );
typedef PTOP_LEVEL_EXCEPTION_FILTER LPTOP_LEVEL_EXCEPTION_FILTER;

__declspec(dllimport)
LPTOP_LEVEL_EXCEPTION_FILTER
__stdcall
SetUnhandledExceptionFilter(
     LPTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter
    );

























































#line 2078 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
CreateThread(
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     SIZE_T dwStackSize,
     LPTHREAD_START_ROUTINE lpStartAddress,
     LPVOID lpParameter,
     DWORD dwCreationFlags,
     LPDWORD lpThreadId
    );

__declspec(dllimport)
HANDLE
__stdcall
CreateRemoteThread(
     HANDLE hProcess,
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     SIZE_T dwStackSize,
     LPTHREAD_START_ROUTINE lpStartAddress,
     LPVOID lpParameter,
     DWORD dwCreationFlags,
     LPDWORD lpThreadId
    );

__declspec(dllimport)
HANDLE
__stdcall
GetCurrentThread(
    void
    );

__declspec(dllimport)
DWORD
__stdcall
GetCurrentThreadId(
    void
    );

__declspec(dllimport)
DWORD_PTR
__stdcall
SetThreadAffinityMask(
     HANDLE hThread,
     DWORD_PTR dwThreadAffinityMask
    );









#line 2135 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetProcessPriorityBoost(
     HANDLE hProcess,
     BOOL bDisablePriorityBoost
    );

__declspec(dllimport)
BOOL
__stdcall
GetProcessPriorityBoost(
     HANDLE hProcess,
     PBOOL pDisablePriorityBoost
    );

__declspec(dllimport)
BOOL
__stdcall
RequestWakeupLatency(
     LATENCY_TIME latency
    );

__declspec(dllimport)
BOOL
__stdcall
IsSystemResumeAutomatic(
    void
    );

__declspec(dllimport)
HANDLE
__stdcall
OpenThread(
    DWORD dwDesiredAccess,
    BOOL bInheritHandle,
    DWORD dwThreadId
    );

__declspec(dllimport)
BOOL
__stdcall
SetThreadPriority(
     HANDLE hThread,
     int nPriority
    );

__declspec(dllimport)
BOOL
__stdcall
SetThreadPriorityBoost(
     HANDLE hThread,
     BOOL bDisablePriorityBoost
    );

__declspec(dllimport)
BOOL
__stdcall
GetThreadPriorityBoost(
     HANDLE hThread,
     PBOOL pDisablePriorityBoost
    );

__declspec(dllimport)
int
__stdcall
GetThreadPriority(
     HANDLE hThread
    );

__declspec(dllimport)
BOOL
__stdcall
GetThreadTimes(
     HANDLE hThread,
     LPFILETIME lpCreationTime,
     LPFILETIME lpExitTime,
     LPFILETIME lpKernelTime,
     LPFILETIME lpUserTime
    );

__declspec(dllimport)
__declspec(noreturn)
void
__stdcall
ExitThread(
     DWORD dwExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
TerminateThread(
      HANDLE hThread,
     DWORD dwExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
GetExitCodeThread(
     HANDLE hThread,
     LPDWORD lpExitCode
    );

__declspec(dllimport)
BOOL
__stdcall
GetThreadSelectorEntry(
     HANDLE hThread,
     DWORD dwSelector,
     LPLDT_ENTRY lpSelectorEntry
    );

__declspec(dllimport)
EXECUTION_STATE
__stdcall
SetThreadExecutionState(
     EXECUTION_STATE esFlags
    );

__declspec(dllimport)
DWORD
__stdcall
GetLastError(
    void
    );

__declspec(dllimport)
void
__stdcall
SetLastError(
     DWORD dwErrCode
    );

















#line 2288 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 2289 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
BOOL
__stdcall
GetOverlappedResult(
     HANDLE hFile,
     LPOVERLAPPED lpOverlapped,
     LPDWORD lpNumberOfBytesTransferred,
     BOOL bWait
    );

__declspec(dllimport)
HANDLE
__stdcall
CreateIoCompletionPort(
     HANDLE FileHandle,
     HANDLE ExistingCompletionPort,
     ULONG_PTR CompletionKey,
     DWORD NumberOfConcurrentThreads
    );

__declspec(dllimport)
BOOL
__stdcall
GetQueuedCompletionStatus(
      HANDLE CompletionPort,
     LPDWORD lpNumberOfBytesTransferred,
     PULONG_PTR lpCompletionKey,
     LPOVERLAPPED *lpOverlapped,
      DWORD dwMilliseconds
    );

__declspec(dllimport)
BOOL
__stdcall
PostQueuedCompletionStatus(
     HANDLE CompletionPort,
     DWORD dwNumberOfBytesTransferred,
     ULONG_PTR dwCompletionKey,
     LPOVERLAPPED lpOverlapped
    );






__declspec(dllimport)
UINT
__stdcall
SetErrorMode(
     UINT uMode
    );

__declspec(dllimport)
BOOL
__stdcall
ReadProcessMemory(
     HANDLE hProcess,
     LPCVOID lpBaseAddress,
     LPVOID lpBuffer,
     SIZE_T nSize,
     SIZE_T * lpNumberOfBytesRead
    );

__declspec(dllimport)
BOOL
__stdcall
WriteProcessMemory(
     HANDLE hProcess,
     LPVOID lpBaseAddress,
     LPCVOID lpBuffer,
     SIZE_T nSize,
     SIZE_T * lpNumberOfBytesWritten
    );


__declspec(dllimport)
BOOL
__stdcall
GetThreadContext(
     HANDLE hThread,
      LPCONTEXT lpContext
    );

__declspec(dllimport)
BOOL
__stdcall
SetThreadContext(
     HANDLE hThread,
     const CONTEXT *lpContext
    );
#line 2384 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
SuspendThread(
     HANDLE hThread
    );

__declspec(dllimport)
DWORD
__stdcall
ResumeThread(
     HANDLE hThread
    );



















#line 2418 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








#line 2427 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
void
__stdcall
DebugBreak(
    void
    );

__declspec(dllimport)
BOOL
__stdcall
WaitForDebugEvent(
     LPDEBUG_EVENT lpDebugEvent,
     DWORD dwMilliseconds
    );

__declspec(dllimport)
BOOL
__stdcall
ContinueDebugEvent(
     DWORD dwProcessId,
     DWORD dwThreadId,
     DWORD dwContinueStatus
    );

__declspec(dllimport)
BOOL
__stdcall
DebugActiveProcess(
     DWORD dwProcessId
    );

__declspec(dllimport)
BOOL
__stdcall
DebugActiveProcessStop(
     DWORD dwProcessId
    );

__declspec(dllimport)
BOOL
__stdcall
DebugSetProcessKillOnExit(
     BOOL KillOnExit
    );

__declspec(dllimport)
BOOL
__stdcall
DebugBreakProcess (
     HANDLE Process
    );

__declspec(dllimport)
void
__stdcall
InitializeCriticalSection(
     LPCRITICAL_SECTION lpCriticalSection
    );

__declspec(dllimport)
void
__stdcall
EnterCriticalSection(
      LPCRITICAL_SECTION lpCriticalSection
    );

__declspec(dllimport)
void
__stdcall
LeaveCriticalSection(
      LPCRITICAL_SECTION lpCriticalSection
    );

















#line 2518 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








#line 2527 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
void
__stdcall
DeleteCriticalSection(
      LPCRITICAL_SECTION lpCriticalSection
    );

__declspec(dllimport)
BOOL
__stdcall
SetEvent(
     HANDLE hEvent
    );

__declspec(dllimport)
BOOL
__stdcall
ResetEvent(
     HANDLE hEvent
    );

__declspec(dllimport)
BOOL
__stdcall
PulseEvent(
     HANDLE hEvent
    );

__declspec(dllimport)
BOOL
__stdcall
ReleaseSemaphore(
     HANDLE hSemaphore,
     LONG lReleaseCount,
     LPLONG lpPreviousCount
    );

__declspec(dllimport)
BOOL
__stdcall
ReleaseMutex(
     HANDLE hMutex
    );

__declspec(dllimport)
DWORD
__stdcall
WaitForSingleObject(
     HANDLE hHandle,
     DWORD dwMilliseconds
    );

__declspec(dllimport)
DWORD
__stdcall
WaitForMultipleObjects(
     DWORD nCount,
     const HANDLE *lpHandles,
     BOOL bWaitAll,
     DWORD dwMilliseconds
    );

__declspec(dllimport)
void
__stdcall
Sleep(
     DWORD dwMilliseconds
    );

__declspec(dllimport)
HGLOBAL
__stdcall
LoadResource(
     HMODULE hModule,
     HRSRC hResInfo
    );

__declspec(dllimport)
DWORD
__stdcall
SizeofResource(
     HMODULE hModule,
     HRSRC hResInfo
    );


__declspec(dllimport)
ATOM
__stdcall
GlobalDeleteAtom(
     ATOM nAtom
    );

__declspec(dllimport)
BOOL
__stdcall
InitAtomTable(
     DWORD nSize
    );

__declspec(dllimport)
ATOM
__stdcall
DeleteAtom(
     ATOM nAtom
    );

__declspec(dllimport)
UINT
__stdcall
SetHandleCount(
     UINT uNumber
    );

__declspec(dllimport)
DWORD
__stdcall
GetLogicalDrives(
    void
    );

__declspec(dllimport)
BOOL
__stdcall
LockFile(
     HANDLE hFile,
     DWORD dwFileOffsetLow,
     DWORD dwFileOffsetHigh,
     DWORD nNumberOfBytesToLockLow,
     DWORD nNumberOfBytesToLockHigh
    );

__declspec(dllimport)
BOOL
__stdcall
UnlockFile(
     HANDLE hFile,
     DWORD dwFileOffsetLow,
     DWORD dwFileOffsetHigh,
     DWORD nNumberOfBytesToUnlockLow,
     DWORD nNumberOfBytesToUnlockHigh
    );

__declspec(dllimport)
BOOL
__stdcall
LockFileEx(
     HANDLE hFile,
     DWORD dwFlags,
     DWORD dwReserved,
     DWORD nNumberOfBytesToLockLow,
     DWORD nNumberOfBytesToLockHigh,
     LPOVERLAPPED lpOverlapped
    );




__declspec(dllimport)
BOOL
__stdcall
UnlockFileEx(
     HANDLE hFile,
     DWORD dwReserved,
     DWORD nNumberOfBytesToUnlockLow,
     DWORD nNumberOfBytesToUnlockHigh,
     LPOVERLAPPED lpOverlapped
    );

typedef struct _BY_HANDLE_FILE_INFORMATION {
    DWORD dwFileAttributes;
    FILETIME ftCreationTime;
    FILETIME ftLastAccessTime;
    FILETIME ftLastWriteTime;
    DWORD dwVolumeSerialNumber;
    DWORD nFileSizeHigh;
    DWORD nFileSizeLow;
    DWORD nNumberOfLinks;
    DWORD nFileIndexHigh;
    DWORD nFileIndexLow;
} BY_HANDLE_FILE_INFORMATION, *PBY_HANDLE_FILE_INFORMATION, *LPBY_HANDLE_FILE_INFORMATION;

__declspec(dllimport)
BOOL
__stdcall
GetFileInformationByHandle(
     HANDLE hFile,
     LPBY_HANDLE_FILE_INFORMATION lpFileInformation
    );

__declspec(dllimport)
DWORD
__stdcall
GetFileType(
     HANDLE hFile
    );

__declspec(dllimport)
DWORD
__stdcall
GetFileSize(
     HANDLE hFile,
     LPDWORD lpFileSizeHigh
    );

__declspec(dllimport)
BOOL
__stdcall
GetFileSizeEx(
    HANDLE hFile,
    PLARGE_INTEGER lpFileSize
    );


__declspec(dllimport)
HANDLE
__stdcall
GetStdHandle(
     DWORD nStdHandle
    );

__declspec(dllimport)
BOOL
__stdcall
SetStdHandle(
     DWORD nStdHandle,
     HANDLE hHandle
    );

__declspec(dllimport)
BOOL
__stdcall
WriteFile(
     HANDLE hFile,
     LPCVOID lpBuffer,
     DWORD nNumberOfBytesToWrite,
     LPDWORD lpNumberOfBytesWritten,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
BOOL
__stdcall
ReadFile(
     HANDLE hFile,
     LPVOID lpBuffer,
     DWORD nNumberOfBytesToRead,
     LPDWORD lpNumberOfBytesRead,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
BOOL
__stdcall
FlushFileBuffers(
     HANDLE hFile
    );

__declspec(dllimport)
BOOL
__stdcall
DeviceIoControl(
     HANDLE hDevice,
     DWORD dwIoControlCode,
     LPVOID lpInBuffer,
     DWORD nInBufferSize,
     LPVOID lpOutBuffer,
     DWORD nOutBufferSize,
     LPDWORD lpBytesReturned,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
BOOL
__stdcall
RequestDeviceWakeup(
     HANDLE hDevice
    );

__declspec(dllimport)
BOOL
__stdcall
CancelDeviceWakeupRequest(
     HANDLE hDevice
    );

__declspec(dllimport)
BOOL
__stdcall
GetDevicePowerState(
     HANDLE hDevice,
     BOOL *pfOn
    );

__declspec(dllimport)
BOOL
__stdcall
SetMessageWaitingIndicator(
     HANDLE hMsgIndicator,
     ULONG ulMsgCount
    );

__declspec(dllimport)
BOOL
__stdcall
SetEndOfFile(
     HANDLE hFile
    );

__declspec(dllimport)
DWORD
__stdcall
SetFilePointer(
     HANDLE hFile,
     LONG lDistanceToMove,
     PLONG lpDistanceToMoveHigh,
     DWORD dwMoveMethod
    );

__declspec(dllimport)
BOOL
__stdcall
SetFilePointerEx(
    HANDLE hFile,
    LARGE_INTEGER liDistanceToMove,
    PLARGE_INTEGER lpNewFilePointer,
    DWORD dwMoveMethod
    );

__declspec(dllimport)
BOOL
__stdcall
FindClose(
      HANDLE hFindFile
    );

__declspec(dllimport)
BOOL
__stdcall
GetFileTime(
     HANDLE hFile,
     LPFILETIME lpCreationTime,
     LPFILETIME lpLastAccessTime,
     LPFILETIME lpLastWriteTime
    );

__declspec(dllimport)
BOOL
__stdcall
SetFileTime(
     HANDLE hFile,
     const FILETIME *lpCreationTime,
     const FILETIME *lpLastAccessTime,
     const FILETIME *lpLastWriteTime
    );

__declspec(dllimport)
BOOL
__stdcall
SetFileValidData(
     HANDLE hFile,
     LONGLONG ValidDataLength
    );

__declspec(dllimport)
BOOL
__stdcall
SetFileShortNameA(
     HANDLE hFile,
     LPCSTR lpShortName
    );
__declspec(dllimport)
BOOL
__stdcall
SetFileShortNameW(
     HANDLE hFile,
     LPCWSTR lpShortName
    );




#line 2911 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CloseHandle(
      HANDLE hObject
    );

__declspec(dllimport)
BOOL
__stdcall
DuplicateHandle(
     HANDLE hSourceProcessHandle,
     HANDLE hSourceHandle,
     HANDLE hTargetProcessHandle,
     LPHANDLE lpTargetHandle,
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     DWORD dwOptions
    );

__declspec(dllimport)
BOOL
__stdcall
GetHandleInformation(
     HANDLE hObject,
     LPDWORD lpdwFlags
    );

__declspec(dllimport)
BOOL
__stdcall
SetHandleInformation(
     HANDLE hObject,
     DWORD dwMask,
     DWORD dwFlags
    );






__declspec(dllimport)
DWORD
__stdcall
LoadModule(
     LPCSTR lpModuleName,
     LPVOID lpParameterBlock
    );

__declspec(dllimport)
UINT
__stdcall
WinExec(
     LPCSTR lpCmdLine,
     UINT uCmdShow
    );

__declspec(dllimport)
BOOL
__stdcall
ClearCommBreak(
     HANDLE hFile
    );

__declspec(dllimport)
BOOL
__stdcall
ClearCommError(
     HANDLE hFile,
     LPDWORD lpErrors,
     LPCOMSTAT lpStat
    );

__declspec(dllimport)
BOOL
__stdcall
SetupComm(
     HANDLE hFile,
     DWORD dwInQueue,
     DWORD dwOutQueue
    );

__declspec(dllimport)
BOOL
__stdcall
EscapeCommFunction(
     HANDLE hFile,
     DWORD dwFunc
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommConfig(
     HANDLE hCommDev,
     LPCOMMCONFIG lpCC,
      LPDWORD lpdwSize
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommMask(
     HANDLE hFile,
     LPDWORD lpEvtMask
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommProperties(
     HANDLE hFile,
     LPCOMMPROP lpCommProp
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommModemStatus(
     HANDLE hFile,
     LPDWORD lpModemStat
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommState(
     HANDLE hFile,
     LPDCB lpDCB
    );

__declspec(dllimport)
BOOL
__stdcall
GetCommTimeouts(
     HANDLE hFile,
     LPCOMMTIMEOUTS lpCommTimeouts
    );

__declspec(dllimport)
BOOL
__stdcall
PurgeComm(
     HANDLE hFile,
     DWORD dwFlags
    );

__declspec(dllimport)
BOOL
__stdcall
SetCommBreak(
     HANDLE hFile
    );

__declspec(dllimport)
BOOL
__stdcall
SetCommConfig(
     HANDLE hCommDev,
     LPCOMMCONFIG lpCC,
     DWORD dwSize
    );

__declspec(dllimport)
BOOL
__stdcall
SetCommMask(
     HANDLE hFile,
     DWORD dwEvtMask
    );

__declspec(dllimport)
BOOL
__stdcall
SetCommState(
     HANDLE hFile,
     LPDCB lpDCB
    );

__declspec(dllimport)
BOOL
__stdcall
SetCommTimeouts(
     HANDLE hFile,
     LPCOMMTIMEOUTS lpCommTimeouts
    );

__declspec(dllimport)
BOOL
__stdcall
TransmitCommChar(
     HANDLE hFile,
     char cChar
    );

__declspec(dllimport)
BOOL
__stdcall
WaitCommEvent(
     HANDLE hFile,
     LPDWORD lpEvtMask,
     LPOVERLAPPED lpOverlapped
    );


__declspec(dllimport)
DWORD
__stdcall
SetTapePosition(
     HANDLE hDevice,
     DWORD dwPositionMethod,
     DWORD dwPartition,
     DWORD dwOffsetLow,
     DWORD dwOffsetHigh,
     BOOL bImmediate
    );

__declspec(dllimport)
DWORD
__stdcall
GetTapePosition(
     HANDLE hDevice,
     DWORD dwPositionType,
     LPDWORD lpdwPartition,
     LPDWORD lpdwOffsetLow,
     LPDWORD lpdwOffsetHigh
    );

__declspec(dllimport)
DWORD
__stdcall
PrepareTape(
     HANDLE hDevice,
     DWORD dwOperation,
     BOOL bImmediate
    );

__declspec(dllimport)
DWORD
__stdcall
EraseTape(
     HANDLE hDevice,
     DWORD dwEraseType,
     BOOL bImmediate
    );

__declspec(dllimport)
DWORD
__stdcall
CreateTapePartition(
     HANDLE hDevice,
     DWORD dwPartitionMethod,
     DWORD dwCount,
     DWORD dwSize
    );

__declspec(dllimport)
DWORD
__stdcall
WriteTapemark(
     HANDLE hDevice,
     DWORD dwTapemarkType,
     DWORD dwTapemarkCount,
     BOOL bImmediate
    );

__declspec(dllimport)
DWORD
__stdcall
GetTapeStatus(
     HANDLE hDevice
    );

__declspec(dllimport)
DWORD
__stdcall
GetTapeParameters(
     HANDLE hDevice,
     DWORD dwOperation,
     LPDWORD lpdwSize,
     LPVOID lpTapeInformation
    );




__declspec(dllimport)
DWORD
__stdcall
SetTapeParameters(
     HANDLE hDevice,
     DWORD dwOperation,
     LPVOID lpTapeInformation
    );




__declspec(dllimport)
BOOL
__stdcall
Beep(
     DWORD dwFreq,
     DWORD dwDuration
    );

__declspec(dllimport)
int
__stdcall
MulDiv(
     int nNumber,
     int nNumerator,
     int nDenominator
    );

__declspec(dllimport)
void
__stdcall
GetSystemTime(
     LPSYSTEMTIME lpSystemTime
    );

__declspec(dllimport)
void
__stdcall
GetSystemTimeAsFileTime(
     LPFILETIME lpSystemTimeAsFileTime
    );

__declspec(dllimport)
BOOL
__stdcall
SetSystemTime(
     const SYSTEMTIME *lpSystemTime
    );

__declspec(dllimport)
void
__stdcall
GetLocalTime(
     LPSYSTEMTIME lpSystemTime
    );

__declspec(dllimport)
BOOL
__stdcall
SetLocalTime(
     const SYSTEMTIME *lpSystemTime
    );

__declspec(dllimport)
void
__stdcall
GetSystemInfo(
     LPSYSTEM_INFO lpSystemInfo
    );









#line 3279 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
IsProcessorFeaturePresent(
     DWORD ProcessorFeature
    );

typedef struct _TIME_ZONE_INFORMATION {
    LONG Bias;
    WCHAR StandardName[ 32 ];
    SYSTEMTIME StandardDate;
    LONG StandardBias;
    WCHAR DaylightName[ 32 ];
    SYSTEMTIME DaylightDate;
    LONG DaylightBias;
} TIME_ZONE_INFORMATION, *PTIME_ZONE_INFORMATION, *LPTIME_ZONE_INFORMATION;

__declspec(dllimport)
BOOL
__stdcall
SystemTimeToTzSpecificLocalTime(
     LPTIME_ZONE_INFORMATION lpTimeZoneInformation,
     LPSYSTEMTIME lpUniversalTime,
     LPSYSTEMTIME lpLocalTime
    );

__declspec(dllimport)
BOOL
__stdcall
TzSpecificLocalTimeToSystemTime(
     LPTIME_ZONE_INFORMATION lpTimeZoneInformation,
     LPSYSTEMTIME lpLocalTime,
     LPSYSTEMTIME lpUniversalTime
    );

__declspec(dllimport)
DWORD
__stdcall
GetTimeZoneInformation(
     LPTIME_ZONE_INFORMATION lpTimeZoneInformation
    );

__declspec(dllimport)
BOOL
__stdcall
SetTimeZoneInformation(
     const TIME_ZONE_INFORMATION *lpTimeZoneInformation
    );






__declspec(dllimport)
BOOL
__stdcall
SystemTimeToFileTime(
     const SYSTEMTIME *lpSystemTime,
     LPFILETIME lpFileTime
    );

__declspec(dllimport)
BOOL
__stdcall
FileTimeToLocalFileTime(
     const FILETIME *lpFileTime,
     LPFILETIME lpLocalFileTime
    );

__declspec(dllimport)
BOOL
__stdcall
LocalFileTimeToFileTime(
     const FILETIME *lpLocalFileTime,
     LPFILETIME lpFileTime
    );

__declspec(dllimport)
BOOL
__stdcall
FileTimeToSystemTime(
     const FILETIME *lpFileTime,
     LPSYSTEMTIME lpSystemTime
    );

__declspec(dllimport)
LONG
__stdcall
CompareFileTime(
     const FILETIME *lpFileTime1,
     const FILETIME *lpFileTime2
    );

__declspec(dllimport)
BOOL
__stdcall
FileTimeToDosDateTime(
     const FILETIME *lpFileTime,
     LPWORD lpFatDate,
     LPWORD lpFatTime
    );

__declspec(dllimport)
BOOL
__stdcall
DosDateTimeToFileTime(
     WORD wFatDate,
     WORD wFatTime,
     LPFILETIME lpFileTime
    );

__declspec(dllimport)
DWORD
__stdcall
GetTickCount(
    void
    );

__declspec(dllimport)
BOOL
__stdcall
SetSystemTimeAdjustment(
     DWORD dwTimeAdjustment,
     BOOL  bTimeAdjustmentDisabled
    );

__declspec(dllimport)
BOOL
__stdcall
GetSystemTimeAdjustment(
     PDWORD lpTimeAdjustment,
     PDWORD lpTimeIncrement,
     PBOOL  lpTimeAdjustmentDisabled
    );


__declspec(dllimport)
DWORD
__stdcall
FormatMessageA(
     DWORD dwFlags,
     LPCVOID lpSource,
     DWORD dwMessageId,
     DWORD dwLanguageId,
     LPSTR lpBuffer,
     DWORD nSize,
     va_list *Arguments
    );
__declspec(dllimport)
DWORD
__stdcall
FormatMessageW(
     DWORD dwFlags,
     LPCVOID lpSource,
     DWORD dwMessageId,
     DWORD dwLanguageId,
     LPWSTR lpBuffer,
     DWORD nSize,
     va_list *Arguments
    );




#line 3446 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 3447 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"










__declspec(dllimport)
BOOL
__stdcall
CreatePipe(
     PHANDLE hReadPipe,
     PHANDLE hWritePipe,
     LPSECURITY_ATTRIBUTES lpPipeAttributes,
     DWORD nSize
    );

__declspec(dllimport)
BOOL
__stdcall
ConnectNamedPipe(
     HANDLE hNamedPipe,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
BOOL
__stdcall
DisconnectNamedPipe(
     HANDLE hNamedPipe
    );

__declspec(dllimport)
BOOL
__stdcall
SetNamedPipeHandleState(
     HANDLE hNamedPipe,
     LPDWORD lpMode,
     LPDWORD lpMaxCollectionCount,
     LPDWORD lpCollectDataTimeout
    );

__declspec(dllimport)
BOOL
__stdcall
GetNamedPipeInfo(
     HANDLE hNamedPipe,
     LPDWORD lpFlags,
     LPDWORD lpOutBufferSize,
     LPDWORD lpInBufferSize,
     LPDWORD lpMaxInstances
    );

__declspec(dllimport)
BOOL
__stdcall
PeekNamedPipe(
     HANDLE hNamedPipe,
     LPVOID lpBuffer,
     DWORD nBufferSize,
     LPDWORD lpBytesRead,
     LPDWORD lpTotalBytesAvail,
     LPDWORD lpBytesLeftThisMessage
    );

__declspec(dllimport)
BOOL
__stdcall
TransactNamedPipe(
     HANDLE hNamedPipe,
     LPVOID lpInBuffer,
     DWORD nInBufferSize,
     LPVOID lpOutBuffer,
     DWORD nOutBufferSize,
     LPDWORD lpBytesRead,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
HANDLE
__stdcall
CreateMailslotA(
     LPCSTR lpName,
     DWORD nMaxMessageSize,
     DWORD lReadTimeout,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateMailslotW(
     LPCWSTR lpName,
     DWORD nMaxMessageSize,
     DWORD lReadTimeout,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );




#line 3551 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetMailslotInfo(
     HANDLE hMailslot,
     LPDWORD lpMaxMessageSize,
     LPDWORD lpNextSize,
     LPDWORD lpMessageCount,
     LPDWORD lpReadTimeout
    );

__declspec(dllimport)
BOOL
__stdcall
SetMailslotInfo(
     HANDLE hMailslot,
     DWORD lReadTimeout
    );

__declspec(dllimport)
LPVOID
__stdcall
MapViewOfFile(
     HANDLE hFileMappingObject,
     DWORD dwDesiredAccess,
     DWORD dwFileOffsetHigh,
     DWORD dwFileOffsetLow,
     SIZE_T dwNumberOfBytesToMap
    );

__declspec(dllimport)
BOOL
__stdcall
FlushViewOfFile(
     LPCVOID lpBaseAddress,
     SIZE_T dwNumberOfBytesToFlush
    );

__declspec(dllimport)
BOOL
__stdcall
UnmapViewOfFile(
     LPCVOID lpBaseAddress
    );





__declspec(dllimport)
BOOL
__stdcall
EncryptFileA(
     LPCSTR lpFileName
    );
__declspec(dllimport)
BOOL
__stdcall
EncryptFileW(
     LPCWSTR lpFileName
    );




#line 3618 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
DecryptFileA(
     LPCSTR lpFileName,
     DWORD    dwReserved
    );
__declspec(dllimport)
BOOL
__stdcall
DecryptFileW(
     LPCWSTR lpFileName,
     DWORD    dwReserved
    );




#line 3638 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
















__declspec(dllimport)
BOOL
__stdcall
FileEncryptionStatusA(
    LPCSTR lpFileName,
    LPDWORD  lpStatus
    );
__declspec(dllimport)
BOOL
__stdcall
FileEncryptionStatusW(
    LPCWSTR lpFileName,
    LPDWORD  lpStatus
    );




#line 3673 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"







typedef
DWORD
(__stdcall *PFE_EXPORT_FUNC)(
    PBYTE pbData,
    PVOID pvCallbackContext,
    ULONG ulLength
    );

typedef
DWORD
(__stdcall *PFE_IMPORT_FUNC)(
    PBYTE pbData,
    PVOID pvCallbackContext,
    PULONG ulLength
    );











__declspec(dllimport)
DWORD
__stdcall
OpenEncryptedFileRawA(
     LPCSTR        lpFileName,
     ULONG           ulFlags,
     PVOID *         pvContext
    );
__declspec(dllimport)
DWORD
__stdcall
OpenEncryptedFileRawW(
     LPCWSTR        lpFileName,
     ULONG           ulFlags,
     PVOID *         pvContext
    );




#line 3727 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
ReadEncryptedFileRaw(
     PFE_EXPORT_FUNC pfExportCallback,
     PVOID           pvCallbackContext,
     PVOID           pvContext
    );

__declspec(dllimport)
DWORD
__stdcall
WriteEncryptedFileRaw(
     PFE_IMPORT_FUNC pfImportCallback,
     PVOID           pvCallbackContext,
     PVOID           pvContext
    );

__declspec(dllimport)
void
__stdcall
CloseEncryptedFileRaw(
     PVOID           pvContext
    );





__declspec(dllimport)
int
__stdcall
lstrcmpA(
     LPCSTR lpString1,
     LPCSTR lpString2
    );
__declspec(dllimport)
int
__stdcall
lstrcmpW(
     LPCWSTR lpString1,
     LPCWSTR lpString2
    );




#line 3776 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
int
__stdcall
lstrcmpiA(
     LPCSTR lpString1,
     LPCSTR lpString2
    );
__declspec(dllimport)
int
__stdcall
lstrcmpiW(
     LPCWSTR lpString1,
     LPCWSTR lpString2
    );




#line 3796 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
LPSTR
__stdcall
lstrcpynA(
     LPSTR lpString1,
     LPCSTR lpString2,
     int iMaxLength
    );
__declspec(dllimport)
LPWSTR
__stdcall
lstrcpynW(
     LPWSTR lpString1,
     LPCWSTR lpString2,
     int iMaxLength
    );




#line 3818 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
LPSTR
__stdcall
lstrcpyA(
     LPSTR lpString1,
     LPCSTR lpString2
    );
__declspec(dllimport)
LPWSTR
__stdcall
lstrcpyW(
     LPWSTR lpString1,
     LPCWSTR lpString2
    );




#line 3838 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
LPSTR
__stdcall
lstrcatA(
      LPSTR lpString1,
     LPCSTR lpString2
    );
__declspec(dllimport)
LPWSTR
__stdcall
lstrcatW(
      LPWSTR lpString1,
     LPCWSTR lpString2
    );




#line 3858 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
int
__stdcall
lstrlenA(
     LPCSTR lpString
    );
__declspec(dllimport)
int
__stdcall
lstrlenW(
     LPCWSTR lpString
    );




#line 3876 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HFILE
__stdcall
OpenFile(
     LPCSTR lpFileName,
     LPOFSTRUCT lpReOpenBuff,
     UINT uStyle
    );

__declspec(dllimport)
HFILE
__stdcall
_lopen(
     LPCSTR lpPathName,
     int iReadWrite
    );

__declspec(dllimport)
HFILE
__stdcall
_lcreat(
     LPCSTR lpPathName,
     int  iAttribute
    );

__declspec(dllimport)
UINT
__stdcall
_lread(
     HFILE hFile,
     LPVOID lpBuffer,
     UINT uBytes
    );

__declspec(dllimport)
UINT
__stdcall
_lwrite(
     HFILE hFile,
     LPCSTR lpBuffer,
     UINT uBytes
    );

__declspec(dllimport)
long
__stdcall
_hread(
     HFILE hFile,
     LPVOID lpBuffer,
     long lBytes
    );

__declspec(dllimport)
long
__stdcall
_hwrite(
     HFILE hFile,
     LPCSTR lpBuffer,
     long lBytes
    );

__declspec(dllimport)
HFILE
__stdcall
_lclose(
      HFILE hFile
    );

__declspec(dllimport)
LONG
__stdcall
_llseek(
     HFILE hFile,
     LONG lOffset,
     int iOrigin
    );

__declspec(dllimport)
BOOL
__stdcall
IsTextUnicode(
     const void* lpBuffer,
     int cb,
      LPINT lpi
    );

__declspec(dllimport)
DWORD
__stdcall
TlsAlloc(
    void
    );



__declspec(dllimport)
LPVOID
__stdcall
TlsGetValue(
     DWORD dwTlsIndex
    );

__declspec(dllimport)
BOOL
__stdcall
TlsSetValue(
     DWORD dwTlsIndex,
     LPVOID lpTlsValue
    );

__declspec(dllimport)
BOOL
__stdcall
TlsFree(
     DWORD dwTlsIndex
    );

typedef
void
(__stdcall *LPOVERLAPPED_COMPLETION_ROUTINE)(
    DWORD dwErrorCode,
    DWORD dwNumberOfBytesTransfered,
    LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
DWORD
__stdcall
SleepEx(
     DWORD dwMilliseconds,
     BOOL bAlertable
    );

__declspec(dllimport)
DWORD
__stdcall
WaitForSingleObjectEx(
     HANDLE hHandle,
     DWORD dwMilliseconds,
     BOOL bAlertable
    );

__declspec(dllimport)
DWORD
__stdcall
WaitForMultipleObjectsEx(
     DWORD nCount,
     const HANDLE *lpHandles,
     BOOL bWaitAll,
     DWORD dwMilliseconds,
     BOOL bAlertable
    );











#line 4041 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
ReadFileEx(
     HANDLE hFile,
     LPVOID lpBuffer,
     DWORD nNumberOfBytesToRead,
     LPOVERLAPPED lpOverlapped,
     LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );

__declspec(dllimport)
BOOL
__stdcall
WriteFileEx(
     HANDLE hFile,
     LPCVOID lpBuffer,
     DWORD nNumberOfBytesToWrite,
     LPOVERLAPPED lpOverlapped,
     LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );

__declspec(dllimport)
BOOL
__stdcall
BackupRead(
     HANDLE hFile,
     LPBYTE lpBuffer,
     DWORD nNumberOfBytesToRead,
     LPDWORD lpNumberOfBytesRead,
     BOOL bAbort,
     BOOL bProcessSecurity,
     LPVOID *lpContext
    );

__declspec(dllimport)
BOOL
__stdcall
BackupSeek(
     HANDLE hFile,
     DWORD  dwLowBytesToSeek,
     DWORD  dwHighBytesToSeek,
     LPDWORD lpdwLowByteSeeked,
     LPDWORD lpdwHighByteSeeked,
     LPVOID *lpContext
    );

__declspec(dllimport)
BOOL
__stdcall
BackupWrite(
     HANDLE hFile,
     LPBYTE lpBuffer,
     DWORD nNumberOfBytesToWrite,
     LPDWORD lpNumberOfBytesWritten,
     BOOL bAbort,
     BOOL bProcessSecurity,
     LPVOID *lpContext
    );




typedef struct _WIN32_STREAM_ID {
        DWORD          dwStreamId ;
        DWORD          dwStreamAttributes ;
        LARGE_INTEGER  Size ;
        DWORD          dwStreamNameSize ;
        WCHAR          cStreamName[ 1 ] ;
} WIN32_STREAM_ID, *LPWIN32_STREAM_ID ;



























__declspec(dllimport)
BOOL
__stdcall
ReadFileScatter(
     HANDLE hFile,
     FILE_SEGMENT_ELEMENT aSegmentArray[],
     DWORD nNumberOfBytesToRead,
     LPDWORD lpReserved,
     LPOVERLAPPED lpOverlapped
    );

__declspec(dllimport)
BOOL
__stdcall
WriteFileGather(
     HANDLE hFile,
     FILE_SEGMENT_ELEMENT aSegmentArray[],
     DWORD nNumberOfBytesToWrite,
     LPDWORD lpReserved,
     LPOVERLAPPED lpOverlapped
    );


















#line 4179 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

typedef struct _STARTUPINFOA {
    DWORD   cb;
    LPSTR   lpReserved;
    LPSTR   lpDesktop;
    LPSTR   lpTitle;
    DWORD   dwX;
    DWORD   dwY;
    DWORD   dwXSize;
    DWORD   dwYSize;
    DWORD   dwXCountChars;
    DWORD   dwYCountChars;
    DWORD   dwFillAttribute;
    DWORD   dwFlags;
    WORD    wShowWindow;
    WORD    cbReserved2;
    LPBYTE  lpReserved2;
    HANDLE  hStdInput;
    HANDLE  hStdOutput;
    HANDLE  hStdError;
} STARTUPINFOA, *LPSTARTUPINFOA;
typedef struct _STARTUPINFOW {
    DWORD   cb;
    LPWSTR  lpReserved;
    LPWSTR  lpDesktop;
    LPWSTR  lpTitle;
    DWORD   dwX;
    DWORD   dwY;
    DWORD   dwXSize;
    DWORD   dwYSize;
    DWORD   dwXCountChars;
    DWORD   dwYCountChars;
    DWORD   dwFillAttribute;
    DWORD   dwFlags;
    WORD    wShowWindow;
    WORD    cbReserved2;
    LPBYTE  lpReserved2;
    HANDLE  hStdInput;
    HANDLE  hStdOutput;
    HANDLE  hStdError;
} STARTUPINFOW, *LPSTARTUPINFOW;




typedef STARTUPINFOA STARTUPINFO;
typedef LPSTARTUPINFOA LPSTARTUPINFO;
#line 4227 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



typedef struct _WIN32_FIND_DATAA {
    DWORD dwFileAttributes;
    FILETIME ftCreationTime;
    FILETIME ftLastAccessTime;
    FILETIME ftLastWriteTime;
    DWORD nFileSizeHigh;
    DWORD nFileSizeLow;
    DWORD dwReserved0;
    DWORD dwReserved1;
    CHAR   cFileName[ 260 ];
    CHAR   cAlternateFileName[ 14 ];





} WIN32_FIND_DATAA, *PWIN32_FIND_DATAA, *LPWIN32_FIND_DATAA;
typedef struct _WIN32_FIND_DATAW {
    DWORD dwFileAttributes;
    FILETIME ftCreationTime;
    FILETIME ftLastAccessTime;
    FILETIME ftLastWriteTime;
    DWORD nFileSizeHigh;
    DWORD nFileSizeLow;
    DWORD dwReserved0;
    DWORD dwReserved1;
    WCHAR  cFileName[ 260 ];
    WCHAR  cAlternateFileName[ 14 ];





} WIN32_FIND_DATAW, *PWIN32_FIND_DATAW, *LPWIN32_FIND_DATAW;





typedef WIN32_FIND_DATAA WIN32_FIND_DATA;
typedef PWIN32_FIND_DATAA PWIN32_FIND_DATA;
typedef LPWIN32_FIND_DATAA LPWIN32_FIND_DATA;
#line 4273 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

typedef struct _WIN32_FILE_ATTRIBUTE_DATA {
    DWORD dwFileAttributes;
    FILETIME ftCreationTime;
    FILETIME ftLastAccessTime;
    FILETIME ftLastWriteTime;
    DWORD nFileSizeHigh;
    DWORD nFileSizeLow;
} WIN32_FILE_ATTRIBUTE_DATA, *LPWIN32_FILE_ATTRIBUTE_DATA;

__declspec(dllimport)
HANDLE
__stdcall
CreateMutexA(
     LPSECURITY_ATTRIBUTES lpMutexAttributes,
     BOOL bInitialOwner,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateMutexW(
     LPSECURITY_ATTRIBUTES lpMutexAttributes,
     BOOL bInitialOwner,
     LPCWSTR lpName
    );




#line 4304 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
OpenMutexA(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenMutexW(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCWSTR lpName
    );




#line 4326 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
CreateEventA(
     LPSECURITY_ATTRIBUTES lpEventAttributes,
     BOOL bManualReset,
     BOOL bInitialState,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateEventW(
     LPSECURITY_ATTRIBUTES lpEventAttributes,
     BOOL bManualReset,
     BOOL bInitialState,
     LPCWSTR lpName
    );




#line 4350 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
OpenEventA(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenEventW(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCWSTR lpName
    );




#line 4372 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
CreateSemaphoreA(
     LPSECURITY_ATTRIBUTES lpSemaphoreAttributes,
     LONG lInitialCount,
     LONG lMaximumCount,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateSemaphoreW(
     LPSECURITY_ATTRIBUTES lpSemaphoreAttributes,
     LONG lInitialCount,
     LONG lMaximumCount,
     LPCWSTR lpName
    );




#line 4396 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
OpenSemaphoreA(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenSemaphoreW(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCWSTR lpName
    );




#line 4418 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








































































#line 4491 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
CreateFileMappingA(
     HANDLE hFile,
     LPSECURITY_ATTRIBUTES lpFileMappingAttributes,
     DWORD flProtect,
     DWORD dwMaximumSizeHigh,
     DWORD dwMaximumSizeLow,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateFileMappingW(
     HANDLE hFile,
     LPSECURITY_ATTRIBUTES lpFileMappingAttributes,
     DWORD flProtect,
     DWORD dwMaximumSizeHigh,
     DWORD dwMaximumSizeLow,
     LPCWSTR lpName
    );




#line 4519 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
OpenFileMappingA(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCSTR lpName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenFileMappingW(
     DWORD dwDesiredAccess,
     BOOL bInheritHandle,
     LPCWSTR lpName
    );




#line 4541 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetLogicalDriveStringsA(
     DWORD nBufferLength,
     LPSTR lpBuffer
    );
__declspec(dllimport)
DWORD
__stdcall
GetLogicalDriveStringsW(
     DWORD nBufferLength,
     LPWSTR lpBuffer
    );




#line 4561 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"























#line 4585 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
HMODULE
__stdcall
LoadLibraryA(
     LPCSTR lpLibFileName
    );
__declspec(dllimport)
HMODULE
__stdcall
LoadLibraryW(
     LPCWSTR lpLibFileName
    );




#line 4605 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HMODULE
__stdcall
LoadLibraryExA(
     LPCSTR lpLibFileName,
     HANDLE hFile,
     DWORD dwFlags
    );
__declspec(dllimport)
HMODULE
__stdcall
LoadLibraryExW(
     LPCWSTR lpLibFileName,
     HANDLE hFile,
     DWORD dwFlags
    );




#line 4627 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








__declspec(dllimport)
DWORD
__stdcall
GetModuleFileNameA(
     HMODULE hModule,
     LPSTR lpFilename,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetModuleFileNameW(
     HMODULE hModule,
     LPWSTR lpFilename,
     DWORD nSize
    );




#line 4656 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HMODULE
__stdcall
GetModuleHandleA(
     LPCSTR lpModuleName
    );
__declspec(dllimport)
HMODULE
__stdcall
GetModuleHandleW(
     LPCWSTR lpModuleName
    );




#line 4674 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




















































#line 4727 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 4728 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CreateProcessA(
     LPCSTR lpApplicationName,
     LPSTR lpCommandLine,
     LPSECURITY_ATTRIBUTES lpProcessAttributes,
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     BOOL bInheritHandles,
     DWORD dwCreationFlags,
     LPVOID lpEnvironment,
     LPCSTR lpCurrentDirectory,
     LPSTARTUPINFOA lpStartupInfo,
     LPPROCESS_INFORMATION lpProcessInformation
    );
__declspec(dllimport)
BOOL
__stdcall
CreateProcessW(
     LPCWSTR lpApplicationName,
     LPWSTR lpCommandLine,
     LPSECURITY_ATTRIBUTES lpProcessAttributes,
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     BOOL bInheritHandles,
     DWORD dwCreationFlags,
     LPVOID lpEnvironment,
     LPCWSTR lpCurrentDirectory,
     LPSTARTUPINFOW lpStartupInfo,
     LPPROCESS_INFORMATION lpProcessInformation
    );




#line 4764 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
BOOL
__stdcall
SetProcessShutdownParameters(
     DWORD dwLevel,
     DWORD dwFlags
    );

__declspec(dllimport)
BOOL
__stdcall
GetProcessShutdownParameters(
     LPDWORD lpdwLevel,
     LPDWORD lpdwFlags
    );

__declspec(dllimport)
DWORD
__stdcall
GetProcessVersion(
     DWORD ProcessId
    );

__declspec(dllimport)
void
__stdcall
FatalAppExitA(
     UINT uAction,
     LPCSTR lpMessageText
    );
__declspec(dllimport)
void
__stdcall
FatalAppExitW(
     UINT uAction,
     LPCWSTR lpMessageText
    );




#line 4809 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
void
__stdcall
GetStartupInfoA(
     LPSTARTUPINFOA lpStartupInfo
    );
__declspec(dllimport)
void
__stdcall
GetStartupInfoW(
     LPSTARTUPINFOW lpStartupInfo
    );




#line 4827 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
LPSTR
__stdcall
GetCommandLineA(
    void
    );
__declspec(dllimport)
LPWSTR
__stdcall
GetCommandLineW(
    void
    );




#line 4845 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetEnvironmentVariableA(
     LPCSTR lpName,
     LPSTR lpBuffer,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetEnvironmentVariableW(
     LPCWSTR lpName,
     LPWSTR lpBuffer,
     DWORD nSize
    );




#line 4867 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetEnvironmentVariableA(
     LPCSTR lpName,
     LPCSTR lpValue
    );
__declspec(dllimport)
BOOL
__stdcall
SetEnvironmentVariableW(
     LPCWSTR lpName,
     LPCWSTR lpValue
    );




#line 4887 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
ExpandEnvironmentStringsA(
     LPCSTR lpSrc,
     LPSTR lpDst,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
ExpandEnvironmentStringsW(
     LPCWSTR lpSrc,
     LPWSTR lpDst,
     DWORD nSize
    );




#line 4909 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetFirmwareEnvironmentVariableA(
     LPCSTR lpName,
     LPCSTR lpGuid,
     PVOID   pBuffer,
     DWORD    nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetFirmwareEnvironmentVariableW(
     LPCWSTR lpName,
     LPCWSTR lpGuid,
     PVOID   pBuffer,
     DWORD    nSize
    );




#line 4933 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetFirmwareEnvironmentVariableA(
     LPCSTR lpName,
     LPCSTR lpGuid,
     PVOID    pValue,
     DWORD    nSize
    );
__declspec(dllimport)
BOOL
__stdcall
SetFirmwareEnvironmentVariableW(
     LPCWSTR lpName,
     LPCWSTR lpGuid,
     PVOID    pValue,
     DWORD    nSize
    );




#line 4957 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
void
__stdcall
OutputDebugStringA(
     LPCSTR lpOutputString
    );
__declspec(dllimport)
void
__stdcall
OutputDebugStringW(
     LPCWSTR lpOutputString
    );




#line 4976 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HRSRC
__stdcall
FindResourceA(
     HMODULE hModule,
     LPCSTR lpName,
     LPCSTR lpType
    );
__declspec(dllimport)
HRSRC
__stdcall
FindResourceW(
     HMODULE hModule,
     LPCWSTR lpName,
     LPCWSTR lpType
    );




#line 4998 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HRSRC
__stdcall
FindResourceExA(
     HMODULE hModule,
     LPCSTR lpType,
     LPCSTR lpName,
     WORD    wLanguage
    );
__declspec(dllimport)
HRSRC
__stdcall
FindResourceExW(
     HMODULE hModule,
     LPCWSTR lpType,
     LPCWSTR lpName,
     WORD    wLanguage
    );




#line 5022 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


typedef BOOL (__stdcall* ENUMRESTYPEPROCA)(HMODULE hModule, LPSTR lpType,
        LONG_PTR lParam);
typedef BOOL (__stdcall* ENUMRESTYPEPROCW)(HMODULE hModule, LPWSTR lpType,
        LONG_PTR lParam);




#line 5033 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
typedef BOOL (__stdcall* ENUMRESNAMEPROCA)(HMODULE hModule, LPCSTR lpType,
        LPSTR lpName, LONG_PTR lParam);
typedef BOOL (__stdcall* ENUMRESNAMEPROCW)(HMODULE hModule, LPCWSTR lpType,
        LPWSTR lpName, LONG_PTR lParam);




#line 5042 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
typedef BOOL (__stdcall* ENUMRESLANGPROCA)(HMODULE hModule, LPCSTR lpType,
        LPCSTR lpName, WORD  wLanguage, LONG_PTR lParam);
typedef BOOL (__stdcall* ENUMRESLANGPROCW)(HMODULE hModule, LPCWSTR lpType,
        LPCWSTR lpName, WORD  wLanguage, LONG_PTR lParam);




#line 5051 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"






















#line 5074 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
EnumResourceTypesA(
     HMODULE hModule,
     ENUMRESTYPEPROCA lpEnumFunc,
     LONG_PTR lParam
    );
__declspec(dllimport)
BOOL
__stdcall
EnumResourceTypesW(
     HMODULE hModule,
     ENUMRESTYPEPROCW lpEnumFunc,
     LONG_PTR lParam
    );




#line 5096 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
EnumResourceNamesA(
     HMODULE hModule,
     LPCSTR lpType,
     ENUMRESNAMEPROCA lpEnumFunc,
     LONG_PTR lParam
    );
__declspec(dllimport)
BOOL
__stdcall
EnumResourceNamesW(
     HMODULE hModule,
     LPCWSTR lpType,
     ENUMRESNAMEPROCW lpEnumFunc,
     LONG_PTR lParam
    );




#line 5121 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
EnumResourceLanguagesA(
     HMODULE hModule,
     LPCSTR lpType,
     LPCSTR lpName,
     ENUMRESLANGPROCA lpEnumFunc,
     LONG_PTR lParam
    );
__declspec(dllimport)
BOOL
__stdcall
EnumResourceLanguagesW(
     HMODULE hModule,
     LPCWSTR lpType,
     LPCWSTR lpName,
     ENUMRESLANGPROCW lpEnumFunc,
     LONG_PTR lParam
    );




#line 5147 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
BeginUpdateResourceA(
     LPCSTR pFileName,
     BOOL bDeleteExistingResources
    );
__declspec(dllimport)
HANDLE
__stdcall
BeginUpdateResourceW(
     LPCWSTR pFileName,
     BOOL bDeleteExistingResources
    );




#line 5167 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
UpdateResourceA(
     HANDLE      hUpdate,
     LPCSTR     lpType,
     LPCSTR     lpName,
     WORD        wLanguage,
     LPVOID      lpData,
     DWORD       cbData
    );
__declspec(dllimport)
BOOL
__stdcall
UpdateResourceW(
     HANDLE      hUpdate,
     LPCWSTR     lpType,
     LPCWSTR     lpName,
     WORD        wLanguage,
     LPVOID      lpData,
     DWORD       cbData
    );




#line 5195 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
EndUpdateResourceA(
     HANDLE      hUpdate,
     BOOL        fDiscard
    );
__declspec(dllimport)
BOOL
__stdcall
EndUpdateResourceW(
     HANDLE      hUpdate,
     BOOL        fDiscard
    );




#line 5215 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
ATOM
__stdcall
GlobalAddAtomA(
     LPCSTR lpString
    );
__declspec(dllimport)
ATOM
__stdcall
GlobalAddAtomW(
     LPCWSTR lpString
    );




#line 5233 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
ATOM
__stdcall
GlobalFindAtomA(
     LPCSTR lpString
    );
__declspec(dllimport)
ATOM
__stdcall
GlobalFindAtomW(
     LPCWSTR lpString
    );




#line 5251 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GlobalGetAtomNameA(
     ATOM nAtom,
     LPSTR lpBuffer,
     int nSize
    );
__declspec(dllimport)
UINT
__stdcall
GlobalGetAtomNameW(
     ATOM nAtom,
     LPWSTR lpBuffer,
     int nSize
    );




#line 5273 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
ATOM
__stdcall
AddAtomA(
     LPCSTR lpString
    );
__declspec(dllimport)
ATOM
__stdcall
AddAtomW(
     LPCWSTR lpString
    );




#line 5291 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
ATOM
__stdcall
FindAtomA(
     LPCSTR lpString
    );
__declspec(dllimport)
ATOM
__stdcall
FindAtomW(
     LPCWSTR lpString
    );




#line 5309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetAtomNameA(
     ATOM nAtom,
     LPSTR lpBuffer,
     int nSize
    );
__declspec(dllimport)
UINT
__stdcall
GetAtomNameW(
     ATOM nAtom,
     LPWSTR lpBuffer,
     int nSize
    );




#line 5331 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetProfileIntA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     INT nDefault
    );
__declspec(dllimport)
UINT
__stdcall
GetProfileIntW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     INT nDefault
    );




#line 5353 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetProfileStringA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     LPCSTR lpDefault,
     LPSTR lpReturnedString,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetProfileStringW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     LPCWSTR lpDefault,
     LPWSTR lpReturnedString,
     DWORD nSize
    );




#line 5379 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WriteProfileStringA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     LPCSTR lpString
    );
__declspec(dllimport)
BOOL
__stdcall
WriteProfileStringW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     LPCWSTR lpString
    );




#line 5401 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetProfileSectionA(
     LPCSTR lpAppName,
     LPSTR lpReturnedString,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetProfileSectionW(
     LPCWSTR lpAppName,
     LPWSTR lpReturnedString,
     DWORD nSize
    );




#line 5423 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WriteProfileSectionA(
     LPCSTR lpAppName,
     LPCSTR lpString
    );
__declspec(dllimport)
BOOL
__stdcall
WriteProfileSectionW(
     LPCWSTR lpAppName,
     LPCWSTR lpString
    );




#line 5443 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetPrivateProfileIntA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     INT nDefault,
     LPCSTR lpFileName
    );
__declspec(dllimport)
UINT
__stdcall
GetPrivateProfileIntW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     INT nDefault,
     LPCWSTR lpFileName
    );




#line 5467 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileStringA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     LPCSTR lpDefault,
     LPSTR lpReturnedString,
     DWORD nSize,
     LPCSTR lpFileName
    );
__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileStringW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     LPCWSTR lpDefault,
     LPWSTR lpReturnedString,
     DWORD nSize,
     LPCWSTR lpFileName
    );




#line 5495 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileStringA(
     LPCSTR lpAppName,
     LPCSTR lpKeyName,
     LPCSTR lpString,
     LPCSTR lpFileName
    );
__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileStringW(
     LPCWSTR lpAppName,
     LPCWSTR lpKeyName,
     LPCWSTR lpString,
     LPCWSTR lpFileName
    );




#line 5519 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileSectionA(
     LPCSTR lpAppName,
     LPSTR lpReturnedString,
     DWORD nSize,
     LPCSTR lpFileName
    );
__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileSectionW(
     LPCWSTR lpAppName,
     LPWSTR lpReturnedString,
     DWORD nSize,
     LPCWSTR lpFileName
    );




#line 5543 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileSectionA(
     LPCSTR lpAppName,
     LPCSTR lpString,
     LPCSTR lpFileName
    );
__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileSectionW(
     LPCWSTR lpAppName,
     LPCWSTR lpString,
     LPCWSTR lpFileName
    );




#line 5565 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileSectionNamesA(
     LPSTR lpszReturnBuffer,
     DWORD nSize,
     LPCSTR lpFileName
    );
__declspec(dllimport)
DWORD
__stdcall
GetPrivateProfileSectionNamesW(
     LPWSTR lpszReturnBuffer,
     DWORD nSize,
     LPCWSTR lpFileName
    );




#line 5588 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetPrivateProfileStructA(
     LPCSTR lpszSection,
     LPCSTR lpszKey,
     LPVOID   lpStruct,
     UINT     uSizeStruct,
     LPCSTR szFile
    );
__declspec(dllimport)
BOOL
__stdcall
GetPrivateProfileStructW(
     LPCWSTR lpszSection,
     LPCWSTR lpszKey,
     LPVOID   lpStruct,
     UINT     uSizeStruct,
     LPCWSTR szFile
    );




#line 5614 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileStructA(
     LPCSTR lpszSection,
     LPCSTR lpszKey,
     LPVOID   lpStruct,
     UINT     uSizeStruct,
     LPCSTR szFile
    );
__declspec(dllimport)
BOOL
__stdcall
WritePrivateProfileStructW(
     LPCWSTR lpszSection,
     LPCWSTR lpszKey,
     LPVOID   lpStruct,
     UINT     uSizeStruct,
     LPCWSTR szFile
    );




#line 5640 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
UINT
__stdcall
GetDriveTypeA(
     LPCSTR lpRootPathName
    );
__declspec(dllimport)
UINT
__stdcall
GetDriveTypeW(
     LPCWSTR lpRootPathName
    );




#line 5659 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetSystemDirectoryA(
     LPSTR lpBuffer,
     UINT uSize
    );
__declspec(dllimport)
UINT
__stdcall
GetSystemDirectoryW(
     LPWSTR lpBuffer,
     UINT uSize
    );




#line 5679 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetTempPathA(
     DWORD nBufferLength,
     LPSTR lpBuffer
    );
__declspec(dllimport)
DWORD
__stdcall
GetTempPathW(
     DWORD nBufferLength,
     LPWSTR lpBuffer
    );




#line 5699 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetTempFileNameA(
     LPCSTR lpPathName,
     LPCSTR lpPrefixString,
     UINT uUnique,
     LPSTR lpTempFileName
    );
__declspec(dllimport)
UINT
__stdcall
GetTempFileNameW(
     LPCWSTR lpPathName,
     LPCWSTR lpPrefixString,
     UINT uUnique,
     LPWSTR lpTempFileName
    );




#line 5723 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetWindowsDirectoryA(
     LPSTR lpBuffer,
     UINT uSize
    );
__declspec(dllimport)
UINT
__stdcall
GetWindowsDirectoryW(
     LPWSTR lpBuffer,
     UINT uSize
    );




#line 5743 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
UINT
__stdcall
GetSystemWindowsDirectoryA(
     LPSTR lpBuffer,
     UINT uSize
    );
__declspec(dllimport)
UINT
__stdcall
GetSystemWindowsDirectoryW(
     LPWSTR lpBuffer,
     UINT uSize
    );




#line 5763 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




















































#line 5816 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 5817 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetCurrentDirectoryA(
     LPCSTR lpPathName
    );
__declspec(dllimport)
BOOL
__stdcall
SetCurrentDirectoryW(
     LPCWSTR lpPathName
    );




#line 5835 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetCurrentDirectoryA(
     DWORD nBufferLength,
     LPSTR lpBuffer
    );
__declspec(dllimport)
DWORD
__stdcall
GetCurrentDirectoryW(
     DWORD nBufferLength,
     LPWSTR lpBuffer
    );




#line 5855 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetDiskFreeSpaceA(
     LPCSTR lpRootPathName,
     LPDWORD lpSectorsPerCluster,
     LPDWORD lpBytesPerSector,
     LPDWORD lpNumberOfFreeClusters,
     LPDWORD lpTotalNumberOfClusters
    );
__declspec(dllimport)
BOOL
__stdcall
GetDiskFreeSpaceW(
     LPCWSTR lpRootPathName,
     LPDWORD lpSectorsPerCluster,
     LPDWORD lpBytesPerSector,
     LPDWORD lpNumberOfFreeClusters,
     LPDWORD lpTotalNumberOfClusters
    );




#line 5881 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetDiskFreeSpaceExA(
     LPCSTR lpDirectoryName,
     PULARGE_INTEGER lpFreeBytesAvailableToCaller,
     PULARGE_INTEGER lpTotalNumberOfBytes,
     PULARGE_INTEGER lpTotalNumberOfFreeBytes
    );
__declspec(dllimport)
BOOL
__stdcall
GetDiskFreeSpaceExW(
     LPCWSTR lpDirectoryName,
     PULARGE_INTEGER lpFreeBytesAvailableToCaller,
     PULARGE_INTEGER lpTotalNumberOfBytes,
     PULARGE_INTEGER lpTotalNumberOfFreeBytes
    );




#line 5905 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CreateDirectoryA(
     LPCSTR lpPathName,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );
__declspec(dllimport)
BOOL
__stdcall
CreateDirectoryW(
     LPCWSTR lpPathName,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );




#line 5925 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CreateDirectoryExA(
     LPCSTR lpTemplateDirectory,
     LPCSTR lpNewDirectory,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );
__declspec(dllimport)
BOOL
__stdcall
CreateDirectoryExW(
     LPCWSTR lpTemplateDirectory,
     LPCWSTR lpNewDirectory,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );




#line 5947 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
RemoveDirectoryA(
     LPCSTR lpPathName
    );
__declspec(dllimport)
BOOL
__stdcall
RemoveDirectoryW(
     LPCWSTR lpPathName
    );




#line 5965 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetFullPathNameA(
     LPCSTR lpFileName,
     DWORD nBufferLength,
     LPSTR lpBuffer,
     LPSTR *lpFilePart
    );
__declspec(dllimport)
DWORD
__stdcall
GetFullPathNameW(
     LPCWSTR lpFileName,
     DWORD nBufferLength,
     LPWSTR lpBuffer,
     LPWSTR *lpFilePart
    );




#line 5989 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








__declspec(dllimport)
BOOL
__stdcall
DefineDosDeviceA(
     DWORD dwFlags,
     LPCSTR lpDeviceName,
     LPCSTR lpTargetPath
    );
__declspec(dllimport)
BOOL
__stdcall
DefineDosDeviceW(
     DWORD dwFlags,
     LPCWSTR lpDeviceName,
     LPCWSTR lpTargetPath
    );




#line 6018 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
QueryDosDeviceA(
     LPCSTR lpDeviceName,
     LPSTR lpTargetPath,
     DWORD ucchMax
    );
__declspec(dllimport)
DWORD
__stdcall
QueryDosDeviceW(
     LPCWSTR lpDeviceName,
     LPWSTR lpTargetPath,
     DWORD ucchMax
    );




#line 6040 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
HANDLE
__stdcall
CreateFileA(
     LPCSTR lpFileName,
     DWORD dwDesiredAccess,
     DWORD dwShareMode,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     DWORD dwCreationDisposition,
     DWORD dwFlagsAndAttributes,
     HANDLE hTemplateFile
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateFileW(
     LPCWSTR lpFileName,
     DWORD dwDesiredAccess,
     DWORD dwShareMode,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     DWORD dwCreationDisposition,
     DWORD dwFlagsAndAttributes,
     HANDLE hTemplateFile
    );




#line 6072 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetFileAttributesA(
     LPCSTR lpFileName,
     DWORD dwFileAttributes
    );
__declspec(dllimport)
BOOL
__stdcall
SetFileAttributesW(
     LPCWSTR lpFileName,
     DWORD dwFileAttributes
    );




#line 6092 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetFileAttributesA(
     LPCSTR lpFileName
    );
__declspec(dllimport)
DWORD
__stdcall
GetFileAttributesW(
     LPCWSTR lpFileName
    );




#line 6110 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

typedef enum _GET_FILEEX_INFO_LEVELS {
    GetFileExInfoStandard,
    GetFileExMaxInfoLevel
} GET_FILEEX_INFO_LEVELS;

__declspec(dllimport)
BOOL
__stdcall
GetFileAttributesExA(
     LPCSTR lpFileName,
     GET_FILEEX_INFO_LEVELS fInfoLevelId,
     LPVOID lpFileInformation
    );
__declspec(dllimport)
BOOL
__stdcall
GetFileAttributesExW(
     LPCWSTR lpFileName,
     GET_FILEEX_INFO_LEVELS fInfoLevelId,
     LPVOID lpFileInformation
    );




#line 6137 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
DWORD
__stdcall
GetCompressedFileSizeA(
     LPCSTR lpFileName,
     LPDWORD lpFileSizeHigh
    );
__declspec(dllimport)
DWORD
__stdcall
GetCompressedFileSizeW(
     LPCWSTR lpFileName,
     LPDWORD lpFileSizeHigh
    );




#line 6157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
DeleteFileA(
     LPCSTR lpFileName
    );
__declspec(dllimport)
BOOL
__stdcall
DeleteFileW(
     LPCWSTR lpFileName
    );




#line 6175 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"











































#line 6219 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
FindFirstFileA(
     LPCSTR lpFileName,
     LPWIN32_FIND_DATAA lpFindFileData
    );
__declspec(dllimport)
HANDLE
__stdcall
FindFirstFileW(
     LPCWSTR lpFileName,
     LPWIN32_FIND_DATAW lpFindFileData
    );




#line 6239 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
FindNextFileA(
     HANDLE hFindFile,
     LPWIN32_FIND_DATAA lpFindFileData
    );
__declspec(dllimport)
BOOL
__stdcall
FindNextFileW(
     HANDLE hFindFile,
     LPWIN32_FIND_DATAW lpFindFileData
    );




#line 6259 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
DWORD
__stdcall
SearchPathA(
     LPCSTR lpPath,
     LPCSTR lpFileName,
     LPCSTR lpExtension,
     DWORD nBufferLength,
     LPSTR lpBuffer,
     LPSTR *lpFilePart
    );
__declspec(dllimport)
DWORD
__stdcall
SearchPathW(
     LPCWSTR lpPath,
     LPCWSTR lpFileName,
     LPCWSTR lpExtension,
     DWORD nBufferLength,
     LPWSTR lpBuffer,
     LPWSTR *lpFilePart
    );




#line 6289 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CopyFileA(
     LPCSTR lpExistingFileName,
     LPCSTR lpNewFileName,
     BOOL bFailIfExists
    );
__declspec(dllimport)
BOOL
__stdcall
CopyFileW(
     LPCWSTR lpExistingFileName,
     LPCWSTR lpNewFileName,
     BOOL bFailIfExists
    );




#line 6311 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"











































#line 6355 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
MoveFileA(
     LPCSTR lpExistingFileName,
     LPCSTR lpNewFileName
    );
__declspec(dllimport)
BOOL
__stdcall
MoveFileW(
     LPCWSTR lpExistingFileName,
     LPCWSTR lpNewFileName
    );




#line 6375 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
MoveFileExA(
     LPCSTR lpExistingFileName,
     LPCSTR lpNewFileName,
     DWORD dwFlags
    );
__declspec(dllimport)
BOOL
__stdcall
MoveFileExW(
     LPCWSTR lpExistingFileName,
     LPCWSTR lpNewFileName,
     DWORD dwFlags
    );




#line 6397 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



























#line 6425 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"








#line 6434 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"































#line 6466 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





























#line 6496 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
HANDLE
__stdcall
CreateNamedPipeA(
     LPCSTR lpName,
     DWORD dwOpenMode,
     DWORD dwPipeMode,
     DWORD nMaxInstances,
     DWORD nOutBufferSize,
     DWORD nInBufferSize,
     DWORD nDefaultTimeOut,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );
__declspec(dllimport)
HANDLE
__stdcall
CreateNamedPipeW(
     LPCWSTR lpName,
     DWORD dwOpenMode,
     DWORD dwPipeMode,
     DWORD nMaxInstances,
     DWORD nOutBufferSize,
     DWORD nInBufferSize,
     DWORD nDefaultTimeOut,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );




#line 6529 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetNamedPipeHandleStateA(
     HANDLE hNamedPipe,
     LPDWORD lpState,
     LPDWORD lpCurInstances,
     LPDWORD lpMaxCollectionCount,
     LPDWORD lpCollectDataTimeout,
     LPSTR lpUserName,
     DWORD nMaxUserNameSize
    );
__declspec(dllimport)
BOOL
__stdcall
GetNamedPipeHandleStateW(
     HANDLE hNamedPipe,
     LPDWORD lpState,
     LPDWORD lpCurInstances,
     LPDWORD lpMaxCollectionCount,
     LPDWORD lpCollectDataTimeout,
     LPWSTR lpUserName,
     DWORD nMaxUserNameSize
    );




#line 6559 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CallNamedPipeA(
     LPCSTR lpNamedPipeName,
     LPVOID lpInBuffer,
     DWORD nInBufferSize,
     LPVOID lpOutBuffer,
     DWORD nOutBufferSize,
     LPDWORD lpBytesRead,
     DWORD nTimeOut
    );
__declspec(dllimport)
BOOL
__stdcall
CallNamedPipeW(
     LPCWSTR lpNamedPipeName,
     LPVOID lpInBuffer,
     DWORD nInBufferSize,
     LPVOID lpOutBuffer,
     DWORD nOutBufferSize,
     LPDWORD lpBytesRead,
     DWORD nTimeOut
    );




#line 6589 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
WaitNamedPipeA(
     LPCSTR lpNamedPipeName,
     DWORD nTimeOut
    );
__declspec(dllimport)
BOOL
__stdcall
WaitNamedPipeW(
     LPCWSTR lpNamedPipeName,
     DWORD nTimeOut
    );




#line 6609 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetVolumeLabelA(
     LPCSTR lpRootPathName,
     LPCSTR lpVolumeName
    );
__declspec(dllimport)
BOOL
__stdcall
SetVolumeLabelW(
     LPCWSTR lpRootPathName,
     LPCWSTR lpVolumeName
    );




#line 6629 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
void
__stdcall
SetFileApisToOEM( void );

__declspec(dllimport)
void
__stdcall
SetFileApisToANSI( void );

__declspec(dllimport)
BOOL
__stdcall
AreFileApisANSI( void );

__declspec(dllimport)
BOOL
__stdcall
GetVolumeInformationA(
     LPCSTR lpRootPathName,
     LPSTR lpVolumeNameBuffer,
     DWORD nVolumeNameSize,
     LPDWORD lpVolumeSerialNumber,
     LPDWORD lpMaximumComponentLength,
     LPDWORD lpFileSystemFlags,
     LPSTR lpFileSystemNameBuffer,
     DWORD nFileSystemNameSize
    );
__declspec(dllimport)
BOOL
__stdcall
GetVolumeInformationW(
     LPCWSTR lpRootPathName,
     LPWSTR lpVolumeNameBuffer,
     DWORD nVolumeNameSize,
     LPDWORD lpVolumeSerialNumber,
     LPDWORD lpMaximumComponentLength,
     LPDWORD lpFileSystemFlags,
     LPWSTR lpFileSystemNameBuffer,
     DWORD nFileSystemNameSize
    );




#line 6676 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CancelIo(
     HANDLE hFile
    );





__declspec(dllimport)
BOOL
__stdcall
ClearEventLogA (
     HANDLE hEventLog,
     LPCSTR lpBackupFileName
    );
__declspec(dllimport)
BOOL
__stdcall
ClearEventLogW (
     HANDLE hEventLog,
     LPCWSTR lpBackupFileName
    );




#line 6707 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
BackupEventLogA (
     HANDLE hEventLog,
     LPCSTR lpBackupFileName
    );
__declspec(dllimport)
BOOL
__stdcall
BackupEventLogW (
     HANDLE hEventLog,
     LPCWSTR lpBackupFileName
    );




#line 6727 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CloseEventLog (
      HANDLE hEventLog
    );

__declspec(dllimport)
BOOL
__stdcall
DeregisterEventSource (
      HANDLE hEventLog
    );

__declspec(dllimport)
BOOL
__stdcall
NotifyChangeEventLog(
     HANDLE  hEventLog,
     HANDLE  hEvent
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumberOfEventLogRecords (
     HANDLE hEventLog,
     PDWORD NumberOfRecords
    );

__declspec(dllimport)
BOOL
__stdcall
GetOldestEventLogRecord (
     HANDLE hEventLog,
     PDWORD OldestRecord
    );

__declspec(dllimport)
HANDLE
__stdcall
OpenEventLogA (
     LPCSTR lpUNCServerName,
     LPCSTR lpSourceName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenEventLogW (
     LPCWSTR lpUNCServerName,
     LPCWSTR lpSourceName
    );




#line 6785 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
RegisterEventSourceA (
     LPCSTR lpUNCServerName,
     LPCSTR lpSourceName
    );
__declspec(dllimport)
HANDLE
__stdcall
RegisterEventSourceW (
     LPCWSTR lpUNCServerName,
     LPCWSTR lpSourceName
    );




#line 6805 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
HANDLE
__stdcall
OpenBackupEventLogA (
     LPCSTR lpUNCServerName,
     LPCSTR lpFileName
    );
__declspec(dllimport)
HANDLE
__stdcall
OpenBackupEventLogW (
     LPCWSTR lpUNCServerName,
     LPCWSTR lpFileName
    );




#line 6825 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
ReadEventLogA (
      HANDLE     hEventLog,
      DWORD      dwReadFlags,
      DWORD      dwRecordOffset,
      LPVOID     lpBuffer,
      DWORD      nNumberOfBytesToRead,
      DWORD      *pnBytesRead,
      DWORD      *pnMinNumberOfBytesNeeded
    );
__declspec(dllimport)
BOOL
__stdcall
ReadEventLogW (
      HANDLE     hEventLog,
      DWORD      dwReadFlags,
      DWORD      dwRecordOffset,
      LPVOID     lpBuffer,
      DWORD      nNumberOfBytesToRead,
      DWORD      *pnBytesRead,
      DWORD      *pnMinNumberOfBytesNeeded
    );




#line 6855 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
ReportEventA (
      HANDLE     hEventLog,
      WORD       wType,
      WORD       wCategory,
      DWORD      dwEventID,
      PSID       lpUserSid,
      WORD       wNumStrings,
      DWORD      dwDataSize,
      LPCSTR   *lpStrings,
      LPVOID     lpRawData
    );
__declspec(dllimport)
BOOL
__stdcall
ReportEventW (
      HANDLE     hEventLog,
      WORD       wType,
      WORD       wCategory,
      DWORD      dwEventID,
      PSID       lpUserSid,
      WORD       wNumStrings,
      DWORD      dwDataSize,
      LPCWSTR   *lpStrings,
      LPVOID     lpRawData
    );




#line 6889 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




typedef struct _EVENTLOG_FULL_INFORMATION
{
    DWORD    dwFull;
}
EVENTLOG_FULL_INFORMATION, *LPEVENTLOG_FULL_INFORMATION;

__declspec(dllimport)
BOOL
__stdcall
GetEventLogInformation (
       HANDLE     hEventLog,
       DWORD      dwInfoLevel,
      LPVOID     lpBuffer,
       DWORD      cbBufSize,
      LPDWORD    pcbBytesNeeded
    );







__declspec(dllimport)
BOOL
__stdcall
DuplicateToken(
     HANDLE ExistingTokenHandle,
     SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
     PHANDLE DuplicateTokenHandle
    );

__declspec(dllimport)
BOOL
__stdcall
GetKernelObjectSecurity (
     HANDLE Handle,
     SECURITY_INFORMATION RequestedInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     DWORD nLength,
     LPDWORD lpnLengthNeeded
    );

__declspec(dllimport)
BOOL
__stdcall
ImpersonateNamedPipeClient(
     HANDLE hNamedPipe
    );

__declspec(dllimport)
BOOL
__stdcall
ImpersonateSelf(
     SECURITY_IMPERSONATION_LEVEL ImpersonationLevel
    );


__declspec(dllimport)
BOOL
__stdcall
RevertToSelf (
    void
    );

__declspec(dllimport)
BOOL
__stdcall
SetThreadToken (
     PHANDLE Thread,
     HANDLE Token
    );

__declspec(dllimport)
BOOL
__stdcall
AccessCheck (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     HANDLE ClientToken,
     DWORD DesiredAccess,
     PGENERIC_MAPPING GenericMapping,
     PPRIVILEGE_SET PrivilegeSet,
     LPDWORD PrivilegeSetLength,
     LPDWORD GrantedAccess,
     LPBOOL AccessStatus
    );



































#line 7015 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
OpenProcessToken (
     HANDLE ProcessHandle,
     DWORD DesiredAccess,
     PHANDLE TokenHandle
    );


__declspec(dllimport)
BOOL
__stdcall
OpenThreadToken (
     HANDLE ThreadHandle,
     DWORD DesiredAccess,
     BOOL OpenAsSelf,
     PHANDLE TokenHandle
    );


__declspec(dllimport)
BOOL
__stdcall
GetTokenInformation (
     HANDLE TokenHandle,
     TOKEN_INFORMATION_CLASS TokenInformationClass,
     LPVOID TokenInformation,
     DWORD TokenInformationLength,
     PDWORD ReturnLength
    );


__declspec(dllimport)
BOOL
__stdcall
SetTokenInformation (
     HANDLE TokenHandle,
     TOKEN_INFORMATION_CLASS TokenInformationClass,
     LPVOID TokenInformation,
     DWORD TokenInformationLength
    );


__declspec(dllimport)
BOOL
__stdcall
AdjustTokenPrivileges (
     HANDLE TokenHandle,
     BOOL DisableAllPrivileges,
     PTOKEN_PRIVILEGES NewState,
     DWORD BufferLength,
     PTOKEN_PRIVILEGES PreviousState,
     PDWORD ReturnLength
    );


__declspec(dllimport)
BOOL
__stdcall
AdjustTokenGroups (
     HANDLE TokenHandle,
     BOOL ResetToDefault,
     PTOKEN_GROUPS NewState,
     DWORD BufferLength,
     PTOKEN_GROUPS PreviousState,
     PDWORD ReturnLength
    );


__declspec(dllimport)
BOOL
__stdcall
PrivilegeCheck (
     HANDLE ClientToken,
     PPRIVILEGE_SET RequiredPrivileges,
     LPBOOL pfResult
    );


__declspec(dllimport)
BOOL
__stdcall
AccessCheckAndAuditAlarmA (
     LPCSTR SubsystemName,
     LPVOID HandleId,
     LPSTR ObjectTypeName,
     LPSTR ObjectName,
     PSECURITY_DESCRIPTOR SecurityDescriptor,
     DWORD DesiredAccess,
     PGENERIC_MAPPING GenericMapping,
     BOOL ObjectCreation,
     LPDWORD GrantedAccess,
     LPBOOL AccessStatus,
     LPBOOL pfGenerateOnClose
    );
__declspec(dllimport)
BOOL
__stdcall
AccessCheckAndAuditAlarmW (
     LPCWSTR SubsystemName,
     LPVOID HandleId,
     LPWSTR ObjectTypeName,
     LPWSTR ObjectName,
     PSECURITY_DESCRIPTOR SecurityDescriptor,
     DWORD DesiredAccess,
     PGENERIC_MAPPING GenericMapping,
     BOOL ObjectCreation,
     LPDWORD GrantedAccess,
     LPBOOL AccessStatus,
     LPBOOL pfGenerateOnClose
    );




#line 7134 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





















































































































































#line 7284 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
ObjectOpenAuditAlarmA (
     LPCSTR SubsystemName,
     LPVOID HandleId,
     LPSTR ObjectTypeName,
     LPSTR ObjectName,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     HANDLE ClientToken,
     DWORD DesiredAccess,
     DWORD GrantedAccess,
     PPRIVILEGE_SET Privileges,
     BOOL ObjectCreation,
     BOOL AccessGranted,
     LPBOOL GenerateOnClose
    );
__declspec(dllimport)
BOOL
__stdcall
ObjectOpenAuditAlarmW (
     LPCWSTR SubsystemName,
     LPVOID HandleId,
     LPWSTR ObjectTypeName,
     LPWSTR ObjectName,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     HANDLE ClientToken,
     DWORD DesiredAccess,
     DWORD GrantedAccess,
     PPRIVILEGE_SET Privileges,
     BOOL ObjectCreation,
     BOOL AccessGranted,
     LPBOOL GenerateOnClose
    );




#line 7325 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
ObjectPrivilegeAuditAlarmA (
     LPCSTR SubsystemName,
     LPVOID HandleId,
     HANDLE ClientToken,
     DWORD DesiredAccess,
     PPRIVILEGE_SET Privileges,
     BOOL AccessGranted
    );
__declspec(dllimport)
BOOL
__stdcall
ObjectPrivilegeAuditAlarmW (
     LPCWSTR SubsystemName,
     LPVOID HandleId,
     HANDLE ClientToken,
     DWORD DesiredAccess,
     PPRIVILEGE_SET Privileges,
     BOOL AccessGranted
    );




#line 7354 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
ObjectCloseAuditAlarmA (
     LPCSTR SubsystemName,
     LPVOID HandleId,
     BOOL GenerateOnClose
    );
__declspec(dllimport)
BOOL
__stdcall
ObjectCloseAuditAlarmW (
     LPCWSTR SubsystemName,
     LPVOID HandleId,
     BOOL GenerateOnClose
    );




#line 7377 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
ObjectDeleteAuditAlarmA (
     LPCSTR SubsystemName,
     LPVOID HandleId,
     BOOL GenerateOnClose
    );
__declspec(dllimport)
BOOL
__stdcall
ObjectDeleteAuditAlarmW (
     LPCWSTR SubsystemName,
     LPVOID HandleId,
     BOOL GenerateOnClose
    );




#line 7400 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
PrivilegedServiceAuditAlarmA (
     LPCSTR SubsystemName,
     LPCSTR ServiceName,
     HANDLE ClientToken,
     PPRIVILEGE_SET Privileges,
     BOOL AccessGranted
    );
__declspec(dllimport)
BOOL
__stdcall
PrivilegedServiceAuditAlarmW (
     LPCWSTR SubsystemName,
     LPCWSTR ServiceName,
     HANDLE ClientToken,
     PPRIVILEGE_SET Privileges,
     BOOL AccessGranted
    );




#line 7427 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

































































































#line 7525 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
IsValidSid (
     PSID pSid
    );


__declspec(dllimport)
BOOL
__stdcall
EqualSid (
     PSID pSid1,
     PSID pSid2
    );


__declspec(dllimport)
BOOL
__stdcall
EqualPrefixSid (
    PSID pSid1,
    PSID pSid2
    );


__declspec(dllimport)
DWORD
__stdcall
GetSidLengthRequired (
     UCHAR nSubAuthorityCount
    );


__declspec(dllimport)
BOOL
__stdcall
AllocateAndInitializeSid (
     PSID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
     BYTE nSubAuthorityCount,
     DWORD nSubAuthority0,
     DWORD nSubAuthority1,
     DWORD nSubAuthority2,
     DWORD nSubAuthority3,
     DWORD nSubAuthority4,
     DWORD nSubAuthority5,
     DWORD nSubAuthority6,
     DWORD nSubAuthority7,
     PSID *pSid
    );

__declspec(dllimport)
PVOID
__stdcall
FreeSid(
     PSID pSid
    );

__declspec(dllimport)
BOOL
__stdcall
InitializeSid (
     PSID Sid,
     PSID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
     BYTE nSubAuthorityCount
    );


__declspec(dllimport)
PSID_IDENTIFIER_AUTHORITY
__stdcall
GetSidIdentifierAuthority (
     PSID pSid
    );


__declspec(dllimport)
PDWORD
__stdcall
GetSidSubAuthority (
     PSID pSid,
     DWORD nSubAuthority
    );


__declspec(dllimport)
PUCHAR
__stdcall
GetSidSubAuthorityCount (
     PSID pSid
    );


__declspec(dllimport)
DWORD
__stdcall
GetLengthSid (
     PSID pSid
    );


__declspec(dllimport)
BOOL
__stdcall
CopySid (
     DWORD nDestinationSidLength,
     PSID pDestinationSid,
     PSID pSourceSid
    );


__declspec(dllimport)
BOOL
__stdcall
AreAllAccessesGranted (
     DWORD GrantedAccess,
     DWORD DesiredAccess
    );


__declspec(dllimport)
BOOL
__stdcall
AreAnyAccessesGranted (
     DWORD GrantedAccess,
     DWORD DesiredAccess
    );


__declspec(dllimport)
void
__stdcall
MapGenericMask (
     PDWORD AccessMask,
     PGENERIC_MAPPING GenericMapping
    );


__declspec(dllimport)
BOOL
__stdcall
IsValidAcl (
     PACL pAcl
    );


__declspec(dllimport)
BOOL
__stdcall
InitializeAcl (
     PACL pAcl,
     DWORD nAclLength,
     DWORD dwAclRevision
    );


__declspec(dllimport)
BOOL
__stdcall
GetAclInformation (
     PACL pAcl,
     LPVOID pAclInformation,
     DWORD nAclInformationLength,
     ACL_INFORMATION_CLASS dwAclInformationClass
    );


__declspec(dllimport)
BOOL
__stdcall
SetAclInformation (
     PACL pAcl,
     LPVOID pAclInformation,
     DWORD nAclInformationLength,
     ACL_INFORMATION_CLASS dwAclInformationClass
    );


__declspec(dllimport)
BOOL
__stdcall
AddAce (
      PACL pAcl,
     DWORD dwAceRevision,
     DWORD dwStartingAceIndex,
     LPVOID pAceList,
     DWORD nAceListLength
    );


__declspec(dllimport)
BOOL
__stdcall
DeleteAce (
      PACL pAcl,
     DWORD dwAceIndex
    );


__declspec(dllimport)
BOOL
__stdcall
GetAce (
     PACL pAcl,
     DWORD dwAceIndex,
     LPVOID *pAce
    );


__declspec(dllimport)
BOOL
__stdcall
AddAccessAllowedAce (
      PACL pAcl,
     DWORD dwAceRevision,
     DWORD AccessMask,
     PSID pSid
    );












#line 7757 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
AddAccessDeniedAce (
      PACL pAcl,
     DWORD dwAceRevision,
     DWORD AccessMask,
     PSID pSid
    );












#line 7781 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
AddAuditAccessAce(
      PACL pAcl,
     DWORD dwAceRevision,
     DWORD dwAccessMask,
     PSID pSid,
     BOOL bAuditSuccess,
     BOOL bAuditFailure
    );























































#line 7849 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
FindFirstFreeAce (
     PACL pAcl,
     LPVOID *pAce
    );


__declspec(dllimport)
BOOL
__stdcall
InitializeSecurityDescriptor (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     DWORD dwRevision
    );


__declspec(dllimport)
BOOL
__stdcall
IsValidSecurityDescriptor (
     PSECURITY_DESCRIPTOR pSecurityDescriptor
    );


__declspec(dllimport)
DWORD
__stdcall
GetSecurityDescriptorLength (
     PSECURITY_DESCRIPTOR pSecurityDescriptor
    );


__declspec(dllimport)
BOOL
__stdcall
GetSecurityDescriptorControl (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     PSECURITY_DESCRIPTOR_CONTROL pControl,
     LPDWORD lpdwRevision
    );










#line 7903 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetSecurityDescriptorDacl (
      PSECURITY_DESCRIPTOR pSecurityDescriptor,
     BOOL bDaclPresent,
     PACL pDacl,
     BOOL bDaclDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
GetSecurityDescriptorDacl (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     LPBOOL lpbDaclPresent,
     PACL *pDacl,
     LPBOOL lpbDaclDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
SetSecurityDescriptorSacl (
      PSECURITY_DESCRIPTOR pSecurityDescriptor,
     BOOL bSaclPresent,
     PACL pSacl,
     BOOL bSaclDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
GetSecurityDescriptorSacl (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     LPBOOL lpbSaclPresent,
     PACL *pSacl,
     LPBOOL lpbSaclDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
SetSecurityDescriptorOwner (
      PSECURITY_DESCRIPTOR pSecurityDescriptor,
     PSID pOwner,
     BOOL bOwnerDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
GetSecurityDescriptorOwner (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     PSID *pOwner,
     LPBOOL lpbOwnerDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
SetSecurityDescriptorGroup (
      PSECURITY_DESCRIPTOR pSecurityDescriptor,
     PSID pGroup,
     BOOL bGroupDefaulted
    );


__declspec(dllimport)
BOOL
__stdcall
GetSecurityDescriptorGroup (
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     PSID *pGroup,
     LPBOOL lpbGroupDefaulted
    );


__declspec(dllimport)
DWORD
__stdcall
SetSecurityDescriptorRMControl(
      PSECURITY_DESCRIPTOR SecurityDescriptor,
     PUCHAR RMControl 
    );

__declspec(dllimport)
DWORD
__stdcall
GetSecurityDescriptorRMControl(
     PSECURITY_DESCRIPTOR SecurityDescriptor,
     PUCHAR RMControl
    );

__declspec(dllimport)
BOOL
__stdcall
CreatePrivateObjectSecurity (
     PSECURITY_DESCRIPTOR ParentDescriptor,
     PSECURITY_DESCRIPTOR CreatorDescriptor,
     PSECURITY_DESCRIPTOR * NewDescriptor,
     BOOL IsDirectoryObject,
     HANDLE Token,
     PGENERIC_MAPPING GenericMapping
    );










































#line 8058 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetPrivateObjectSecurity (
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR ModificationDescriptor,
     PSECURITY_DESCRIPTOR *ObjectsSecurityDescriptor,
     PGENERIC_MAPPING GenericMapping,
     HANDLE Token
    );













#line 8083 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetPrivateObjectSecurity (
     PSECURITY_DESCRIPTOR ObjectDescriptor,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR ResultantDescriptor,
     DWORD DescriptorLength,
     PDWORD ReturnLength
    );


__declspec(dllimport)
BOOL
__stdcall
DestroyPrivateObjectSecurity (
      PSECURITY_DESCRIPTOR * ObjectDescriptor
    );


__declspec(dllimport)
BOOL
__stdcall
MakeSelfRelativeSD (
     PSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor,
     PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor,
     LPDWORD lpdwBufferLength
    );


__declspec(dllimport)
BOOL
__stdcall
MakeAbsoluteSD (
     PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor,
     PSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor,
     LPDWORD lpdwAbsoluteSecurityDescriptorSize,
     PACL pDacl,
     LPDWORD lpdwDaclSize,
     PACL pSacl,
     LPDWORD lpdwSaclSize,
     PSID pOwner,
     LPDWORD lpdwOwnerSize,
     PSID pPrimaryGroup,
     LPDWORD lpdwPrimaryGroupSize
    );


__declspec(dllimport)
BOOL
__stdcall
MakeAbsoluteSD2 (
     PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor,
     LPDWORD lpdwBufferSize
    );

__declspec(dllimport)
BOOL
__stdcall
SetFileSecurityA (
     LPCSTR lpFileName,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor
    );
__declspec(dllimport)
BOOL
__stdcall
SetFileSecurityW (
     LPCWSTR lpFileName,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor
    );




#line 8161 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
GetFileSecurityA (
     LPCSTR lpFileName,
     SECURITY_INFORMATION RequestedInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     DWORD nLength,
     LPDWORD lpnLengthNeeded
    );
__declspec(dllimport)
BOOL
__stdcall
GetFileSecurityW (
     LPCWSTR lpFileName,
     SECURITY_INFORMATION RequestedInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
     DWORD nLength,
     LPDWORD lpnLengthNeeded
    );




#line 8188 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
SetKernelObjectSecurity (
     HANDLE Handle,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR SecurityDescriptor
    );

__declspec(dllimport)
HANDLE
__stdcall
FindFirstChangeNotificationA(
     LPCSTR lpPathName,
     BOOL bWatchSubtree,
     DWORD dwNotifyFilter
    );
__declspec(dllimport)
HANDLE
__stdcall
FindFirstChangeNotificationW(
     LPCWSTR lpPathName,
     BOOL bWatchSubtree,
     DWORD dwNotifyFilter
    );




#line 8220 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
FindNextChangeNotification(
     HANDLE hChangeHandle
    );

__declspec(dllimport)
BOOL
__stdcall
FindCloseChangeNotification(
     HANDLE hChangeHandle
    );















#line 8250 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
VirtualLock(
     LPVOID lpAddress,
     SIZE_T dwSize
    );

__declspec(dllimport)
BOOL
__stdcall
VirtualUnlock(
     LPVOID lpAddress,
     SIZE_T dwSize
    );

__declspec(dllimport)
LPVOID
__stdcall
MapViewOfFileEx(
     HANDLE hFileMappingObject,
     DWORD dwDesiredAccess,
     DWORD dwFileOffsetHigh,
     DWORD dwFileOffsetLow,
     SIZE_T dwNumberOfBytesToMap,
     LPVOID lpBaseAddress
    );

__declspec(dllimport)
BOOL
__stdcall
SetPriorityClass(
     HANDLE hProcess,
     DWORD dwPriorityClass
    );

__declspec(dllimport)
DWORD
__stdcall
GetPriorityClass(
     HANDLE hProcess
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadReadPtr(
     const void *lp,
     UINT_PTR ucb
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadWritePtr(
     LPVOID lp,
     UINT_PTR ucb
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadHugeReadPtr(
     const void *lp,
     UINT_PTR ucb
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadHugeWritePtr(
     LPVOID lp,
     UINT_PTR ucb
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadCodePtr(
     FARPROC lpfn
    );

__declspec(dllimport)
BOOL
__stdcall
IsBadStringPtrA(
     LPCSTR lpsz,
     UINT_PTR ucchMax
    );
__declspec(dllimport)
BOOL
__stdcall
IsBadStringPtrW(
     LPCWSTR lpsz,
     UINT_PTR ucchMax
    );




#line 8352 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LookupAccountSidA(
     LPCSTR lpSystemName,
     PSID Sid,
     LPSTR Name,
      LPDWORD cbName,
     LPSTR ReferencedDomainName,
      LPDWORD cbReferencedDomainName,
     PSID_NAME_USE peUse
    );
__declspec(dllimport)
BOOL
__stdcall
LookupAccountSidW(
     LPCWSTR lpSystemName,
     PSID Sid,
     LPWSTR Name,
      LPDWORD cbName,
     LPWSTR ReferencedDomainName,
      LPDWORD cbReferencedDomainName,
     PSID_NAME_USE peUse
    );




#line 8382 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LookupAccountNameA(
     LPCSTR lpSystemName,
     LPCSTR lpAccountName,
     PSID Sid,
      LPDWORD cbSid,
     LPSTR ReferencedDomainName,
      LPDWORD cbReferencedDomainName,
     PSID_NAME_USE peUse
    );
__declspec(dllimport)
BOOL
__stdcall
LookupAccountNameW(
     LPCWSTR lpSystemName,
     LPCWSTR lpAccountName,
     PSID Sid,
      LPDWORD cbSid,
     LPWSTR ReferencedDomainName,
      LPDWORD cbReferencedDomainName,
     PSID_NAME_USE peUse
    );




#line 8412 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeValueA(
     LPCSTR lpSystemName,
     LPCSTR lpName,
     PLUID   lpLuid
    );
__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeValueW(
     LPCWSTR lpSystemName,
     LPCWSTR lpName,
     PLUID   lpLuid
    );




#line 8434 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeNameA(
     LPCSTR lpSystemName,
     PLUID   lpLuid,
     LPSTR lpName,
      LPDWORD cbName
    );
__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeNameW(
     LPCWSTR lpSystemName,
     PLUID   lpLuid,
     LPWSTR lpName,
      LPDWORD cbName
    );




#line 8458 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeDisplayNameA(
     LPCSTR lpSystemName,
     LPCSTR lpName,
     LPSTR lpDisplayName,
      LPDWORD cbDisplayName,
     LPDWORD lpLanguageId
    );
__declspec(dllimport)
BOOL
__stdcall
LookupPrivilegeDisplayNameW(
     LPCWSTR lpSystemName,
     LPCWSTR lpName,
     LPWSTR lpDisplayName,
      LPDWORD cbDisplayName,
     LPDWORD lpLanguageId
    );




#line 8484 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
AllocateLocallyUniqueId(
     PLUID Luid
    );

__declspec(dllimport)
BOOL
__stdcall
BuildCommDCBA(
     LPCSTR lpDef,
     LPDCB lpDCB
    );
__declspec(dllimport)
BOOL
__stdcall
BuildCommDCBW(
     LPCWSTR lpDef,
     LPDCB lpDCB
    );




#line 8511 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
BuildCommDCBAndTimeoutsA(
     LPCSTR lpDef,
     LPDCB lpDCB,
     LPCOMMTIMEOUTS lpCommTimeouts
    );
__declspec(dllimport)
BOOL
__stdcall
BuildCommDCBAndTimeoutsW(
     LPCWSTR lpDef,
     LPDCB lpDCB,
     LPCOMMTIMEOUTS lpCommTimeouts
    );




#line 8533 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
CommConfigDialogA(
     LPCSTR lpszName,
     HWND hWnd,
      LPCOMMCONFIG lpCC
    );
__declspec(dllimport)
BOOL
__stdcall
CommConfigDialogW(
     LPCWSTR lpszName,
     HWND hWnd,
      LPCOMMCONFIG lpCC
    );




#line 8555 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetDefaultCommConfigA(
     LPCSTR lpszName,
     LPCOMMCONFIG lpCC,
      LPDWORD lpdwSize
    );
__declspec(dllimport)
BOOL
__stdcall
GetDefaultCommConfigW(
     LPCWSTR lpszName,
     LPCOMMCONFIG lpCC,
      LPDWORD lpdwSize
    );




#line 8577 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetDefaultCommConfigA(
     LPCSTR lpszName,
     LPCOMMCONFIG lpCC,
     DWORD dwSize
    );
__declspec(dllimport)
BOOL
__stdcall
SetDefaultCommConfigW(
     LPCWSTR lpszName,
     LPCOMMCONFIG lpCC,
     DWORD dwSize
    );




#line 8599 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





#line 8605 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetComputerNameA (
     LPSTR lpBuffer,
      LPDWORD nSize
    );
__declspec(dllimport)
BOOL
__stdcall
GetComputerNameW (
     LPWSTR lpBuffer,
      LPDWORD nSize
    );




#line 8625 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
SetComputerNameA (
     LPCSTR lpComputerName
    );
__declspec(dllimport)
BOOL
__stdcall
SetComputerNameW (
     LPCWSTR lpComputerName
    );




#line 8643 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"











































































































































































#line 8815 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
GetUserNameA (
     LPSTR lpBuffer,
      LPDWORD nSize
    );
__declspec(dllimport)
BOOL
__stdcall
GetUserNameW (
     LPWSTR lpBuffer,
      LPDWORD nSize
    );




#line 8835 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"













#line 8849 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





#line 8855 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


#line 8858 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
BOOL
__stdcall
LogonUserA (
     LPSTR lpszUsername,
     LPSTR lpszDomain,
     LPSTR lpszPassword,
     DWORD dwLogonType,
     DWORD dwLogonProvider,
     PHANDLE phToken
    );
__declspec(dllimport)
BOOL
__stdcall
LogonUserW (
     LPWSTR lpszUsername,
     LPWSTR lpszDomain,
     LPWSTR lpszPassword,
     DWORD dwLogonType,
     DWORD dwLogonProvider,
     PHANDLE phToken
    );




#line 8888 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
LogonUserExA (
     LPSTR lpszUsername,
     LPSTR lpszDomain,
     LPSTR lpszPassword,
     DWORD dwLogonType,
     DWORD dwLogonProvider,
     PHANDLE phToken           ,
     PSID  *ppLogonSid       ,
     PVOID *ppProfileBuffer  ,
     LPDWORD pdwProfileLength  ,
     PQUOTA_LIMITS pQuotaLimits 
    );
__declspec(dllimport)
BOOL
__stdcall
LogonUserExW (
     LPWSTR lpszUsername,
     LPWSTR lpszDomain,
     LPWSTR lpszPassword,
     DWORD dwLogonType,
     DWORD dwLogonProvider,
     PHANDLE phToken           ,
     PSID  *ppLogonSid       ,
     PVOID *ppProfileBuffer  ,
     LPDWORD pdwProfileLength  ,
     PQUOTA_LIMITS pQuotaLimits 
    );




#line 8924 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
ImpersonateLoggedOnUser(
     HANDLE  hToken
    );

__declspec(dllimport)
BOOL
__stdcall
CreateProcessAsUserA (
     HANDLE hToken,
     LPCSTR lpApplicationName,
     LPSTR lpCommandLine,
     LPSECURITY_ATTRIBUTES lpProcessAttributes,
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     BOOL bInheritHandles,
     DWORD dwCreationFlags,
     LPVOID lpEnvironment,
     LPCSTR lpCurrentDirectory,
     LPSTARTUPINFOA lpStartupInfo,
     LPPROCESS_INFORMATION lpProcessInformation
    );
__declspec(dllimport)
BOOL
__stdcall
CreateProcessAsUserW (
     HANDLE hToken,
     LPCWSTR lpApplicationName,
     LPWSTR lpCommandLine,
     LPSECURITY_ATTRIBUTES lpProcessAttributes,
     LPSECURITY_ATTRIBUTES lpThreadAttributes,
     BOOL bInheritHandles,
     DWORD dwCreationFlags,
     LPVOID lpEnvironment,
     LPCWSTR lpCurrentDirectory,
     LPSTARTUPINFOW lpStartupInfo,
     LPPROCESS_INFORMATION lpProcessInformation
    );




#line 8969 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



























#line 8997 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

__declspec(dllimport)
BOOL
__stdcall
ImpersonateAnonymousToken(
     HANDLE ThreadHandle
    );

__declspec(dllimport)
BOOL
__stdcall
DuplicateTokenEx(
     HANDLE hExistingToken,
     DWORD dwDesiredAccess,
     LPSECURITY_ATTRIBUTES lpTokenAttributes,
     SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
     TOKEN_TYPE TokenType,
     PHANDLE phNewToken);

__declspec(dllimport)
BOOL
__stdcall
CreateRestrictedToken(
     HANDLE ExistingTokenHandle,
     DWORD Flags,
     DWORD DisableSidCount,
     PSID_AND_ATTRIBUTES SidsToDisable ,
     DWORD DeletePrivilegeCount,
     PLUID_AND_ATTRIBUTES PrivilegesToDelete ,
     DWORD RestrictedSidCount,
     PSID_AND_ATTRIBUTES SidsToRestrict ,
     PHANDLE NewTokenHandle
    );


__declspec(dllimport)
BOOL
__stdcall
IsTokenRestricted(
     HANDLE TokenHandle
    );

__declspec(dllimport)
BOOL
__stdcall
IsTokenUntrusted(
     HANDLE TokenHandle
    );


BOOL
__stdcall
CheckTokenMembership(
     HANDLE TokenHandle ,
     PSID SidToCheck,
     PBOOL IsMember
    );











































































































































#line 9194 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




















































#line 9247 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





__declspec(dllimport)
BOOL
__stdcall
QueryPerformanceCounter(
     LARGE_INTEGER *lpPerformanceCount
    );

__declspec(dllimport)
BOOL
__stdcall
QueryPerformanceFrequency(
     LARGE_INTEGER *lpFrequency
    );



__declspec(dllimport)
BOOL
__stdcall
GetVersionExA(
      LPOSVERSIONINFOA lpVersionInformation
    );
__declspec(dllimport)
BOOL
__stdcall
GetVersionExW(
      LPOSVERSIONINFOW lpVersionInformation
    );




#line 9285 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



__declspec(dllimport)
BOOL
__stdcall
VerifyVersionInfoA(
     LPOSVERSIONINFOEXA lpVersionInformation,
     DWORD dwTypeMask,
     DWORDLONG dwlConditionMask
    );
__declspec(dllimport)
BOOL
__stdcall
VerifyVersionInfoW(
     LPOSVERSIONINFOEXW lpVersionInformation,
     DWORD dwTypeMask,
     DWORDLONG dwlConditionMask
    );




#line 9309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"












#pragma once
#line 15 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"























































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































#line 14887 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"

































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































#line 16745 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"







































#line 16785 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"


























































































































































































#line 16972 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"













































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































 
 
 
 
 

























































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































#line 26648 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winerror.h"
#line 9315 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"





























typedef struct _SYSTEM_POWER_STATUS {
    BYTE ACLineStatus;
    BYTE BatteryFlag;
    BYTE BatteryLifePercent;
    BYTE Reserved1;
    DWORD BatteryLifeTime;
    DWORD BatteryFullLifeTime;
}   SYSTEM_POWER_STATUS, *LPSYSTEM_POWER_STATUS;

BOOL
__stdcall
GetSystemPowerStatus(
     LPSYSTEM_POWER_STATUS lpSystemPowerStatus
    );

BOOL
__stdcall
SetSystemPowerState(
     BOOL fSuspend,
     BOOL fForce
    );

#line 9367 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"













































































































































































































































































































































































#line 9733 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




















































#line 9786 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"










































































#line 9861 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


















#line 9880 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"










































#line 9923 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"























#line 9947 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"




















































#line 10000 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


__declspec(dllimport)
BOOL
__stdcall
ProcessIdToSessionId(
      DWORD dwProcessId,
     DWORD *pSessionId
    );
















#line 10026 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"






__declspec(dllimport)
BOOL
__stdcall
GetNumaHighestNodeNumber(
    PULONG HighestNodeNumber
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumaProcessorNode(
    UCHAR Processor,
    PUCHAR NodeNumber
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumaNodeProcessorMask(
    UCHAR Node,
    PULONGLONG ProcessorMask
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumaProcessorMap(
    PSYSTEM_NUMA_INFORMATION Map,
    ULONG Length,
    PULONG ReturnedLength
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumaAvailableMemory(
    PSYSTEM_NUMA_INFORMATION Memory,
    ULONG Length,
    PULONG ReturnedLength
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumaAvailableMemoryNode(
    UCHAR Node,
    PULONGLONG AvailableBytes
    );

__declspec(dllimport)
ULONGLONG
__stdcall
NumaVirtualQueryNode(
      ULONG       NumberOfRanges,
      PULONG_PTR  RangeList,
     PULONG_PTR  VirtualPageAndNode,
      SIZE_T      MaximumOutputLength
    );







#line 10098 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"
#line 10099 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"


}
#line 10103 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"



#line 10107 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winbase.h"

#line 163 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"























#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"









#line 35 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


extern "C" {
#line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
















































#line 88 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




#line 93 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

































#line 127 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"













#line 141 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

















#line 159 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
















#line 176 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


#line 179 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"














































































#line 258 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"









typedef struct _DRAWPATRECT {
        POINT ptPosition;
        POINT ptSize;
        WORD wStyle;
        WORD wPattern;
} DRAWPATRECT, *PDRAWPATRECT;
#line 274 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 276 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"







































































































typedef struct _PSINJECTDATA {

    DWORD   DataBytes;      
    WORD    InjectionPoint; 
    WORD    PageNumber;     

    

} PSINJECTDATA, *PPSINJECTDATA;

































































typedef struct _PSFEATURE_OUTPUT {

    BOOL bPageIndependent;
    BOOL bSetPageDevice;

} PSFEATURE_OUTPUT, *PPSFEATURE_OUTPUT;





typedef struct _PSFEATURE_CUSTPAPER {

    LONG lOrientation;
    LONG lWidth;
    LONG lHeight;
    LONG lWidthOffset;
    LONG lHeightOffset;

} PSFEATURE_CUSTPAPER, *PPSFEATURE_CUSTPAPER;
















































typedef struct  tagXFORM
  {
    FLOAT   eM11;
    FLOAT   eM12;
    FLOAT   eM21;
    FLOAT   eM22;
    FLOAT   eDx;
    FLOAT   eDy;
  } XFORM, *PXFORM,  *LPXFORM;


typedef struct tagBITMAP
  {
    LONG        bmType;
    LONG        bmWidth;
    LONG        bmHeight;
    LONG        bmWidthBytes;
    WORD        bmPlanes;
    WORD        bmBitsPixel;
    LPVOID      bmBits;
  } BITMAP, *PBITMAP,  *NPBITMAP,  *LPBITMAP;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack1.h"























#pragma warning(disable:4103)

#pragma pack(push,1)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack1.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack1.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack1.h"
#line 544 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
typedef struct tagRGBTRIPLE {
        BYTE    rgbtBlue;
        BYTE    rgbtGreen;
        BYTE    rgbtRed;
} RGBTRIPLE;
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 550 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct tagRGBQUAD {
        BYTE    rgbBlue;
        BYTE    rgbGreen;
        BYTE    rgbRed;
        BYTE    rgbReserved;
} RGBQUAD;
typedef RGBQUAD * LPRGBQUAD;


















typedef LONG   LCSCSTYPE;


typedef LONG    LCSGAMUTMATCH;


























typedef long            FXPT16DOT16,  *LPFXPT16DOT16;
typedef long            FXPT2DOT30,  *LPFXPT2DOT30;




typedef struct tagCIEXYZ
{
        FXPT2DOT30 ciexyzX;
        FXPT2DOT30 ciexyzY;
        FXPT2DOT30 ciexyzZ;
} CIEXYZ;
typedef CIEXYZ   *LPCIEXYZ;

typedef struct tagICEXYZTRIPLE
{
        CIEXYZ  ciexyzRed;
        CIEXYZ  ciexyzGreen;
        CIEXYZ  ciexyzBlue;
} CIEXYZTRIPLE;
typedef CIEXYZTRIPLE     *LPCIEXYZTRIPLE;






typedef struct tagLOGCOLORSPACEA {
    DWORD lcsSignature;
    DWORD lcsVersion;
    DWORD lcsSize;
    LCSCSTYPE lcsCSType;
    LCSGAMUTMATCH lcsIntent;
    CIEXYZTRIPLE lcsEndpoints;
    DWORD lcsGammaRed;
    DWORD lcsGammaGreen;
    DWORD lcsGammaBlue;
    CHAR   lcsFilename[260];
} LOGCOLORSPACEA, *LPLOGCOLORSPACEA;
typedef struct tagLOGCOLORSPACEW {
    DWORD lcsSignature;
    DWORD lcsVersion;
    DWORD lcsSize;
    LCSCSTYPE lcsCSType;
    LCSGAMUTMATCH lcsIntent;
    CIEXYZTRIPLE lcsEndpoints;
    DWORD lcsGammaRed;
    DWORD lcsGammaGreen;
    DWORD lcsGammaBlue;
    WCHAR  lcsFilename[260];
} LOGCOLORSPACEW, *LPLOGCOLORSPACEW;




typedef LOGCOLORSPACEA LOGCOLORSPACE;
typedef LPLOGCOLORSPACEA LPLOGCOLORSPACE;
#line 664 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 666 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagBITMAPCOREHEADER {
        DWORD   bcSize;                 
        WORD    bcWidth;
        WORD    bcHeight;
        WORD    bcPlanes;
        WORD    bcBitCount;
} BITMAPCOREHEADER,  *LPBITMAPCOREHEADER, *PBITMAPCOREHEADER;

typedef struct tagBITMAPINFOHEADER{
        DWORD      biSize;
        LONG       biWidth;
        LONG       biHeight;
        WORD       biPlanes;
        WORD       biBitCount;
        DWORD      biCompression;
        DWORD      biSizeImage;
        LONG       biXPelsPerMeter;
        LONG       biYPelsPerMeter;
        DWORD      biClrUsed;
        DWORD      biClrImportant;
} BITMAPINFOHEADER,  *LPBITMAPINFOHEADER, *PBITMAPINFOHEADER;


typedef struct {
        DWORD        bV4Size;
        LONG         bV4Width;
        LONG         bV4Height;
        WORD         bV4Planes;
        WORD         bV4BitCount;
        DWORD        bV4V4Compression;
        DWORD        bV4SizeImage;
        LONG         bV4XPelsPerMeter;
        LONG         bV4YPelsPerMeter;
        DWORD        bV4ClrUsed;
        DWORD        bV4ClrImportant;
        DWORD        bV4RedMask;
        DWORD        bV4GreenMask;
        DWORD        bV4BlueMask;
        DWORD        bV4AlphaMask;
        DWORD        bV4CSType;
        CIEXYZTRIPLE bV4Endpoints;
        DWORD        bV4GammaRed;
        DWORD        bV4GammaGreen;
        DWORD        bV4GammaBlue;
} BITMAPV4HEADER,  *LPBITMAPV4HEADER, *PBITMAPV4HEADER;
#line 714 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct {
        DWORD        bV5Size;
        LONG         bV5Width;
        LONG         bV5Height;
        WORD         bV5Planes;
        WORD         bV5BitCount;
        DWORD        bV5Compression;
        DWORD        bV5SizeImage;
        LONG         bV5XPelsPerMeter;
        LONG         bV5YPelsPerMeter;
        DWORD        bV5ClrUsed;
        DWORD        bV5ClrImportant;
        DWORD        bV5RedMask;
        DWORD        bV5GreenMask;
        DWORD        bV5BlueMask;
        DWORD        bV5AlphaMask;
        DWORD        bV5CSType;
        CIEXYZTRIPLE bV5Endpoints;
        DWORD        bV5GammaRed;
        DWORD        bV5GammaGreen;
        DWORD        bV5GammaBlue;
        DWORD        bV5Intent;
        DWORD        bV5ProfileData;
        DWORD        bV5ProfileSize;
        DWORD        bV5Reserved;
} BITMAPV5HEADER,  *LPBITMAPV5HEADER, *PBITMAPV5HEADER;




#line 747 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"









#line 757 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct tagBITMAPINFO {
    BITMAPINFOHEADER    bmiHeader;
    RGBQUAD             bmiColors[1];
} BITMAPINFO,  *LPBITMAPINFO, *PBITMAPINFO;

typedef struct tagBITMAPCOREINFO {
    BITMAPCOREHEADER    bmciHeader;
    RGBTRIPLE           bmciColors[1];
} BITMAPCOREINFO,  *LPBITMAPCOREINFO, *PBITMAPCOREINFO;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 769 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
typedef struct tagBITMAPFILEHEADER {
        WORD    bfType;
        DWORD   bfSize;
        WORD    bfReserved1;
        WORD    bfReserved2;
        DWORD   bfOffBits;
} BITMAPFILEHEADER,  *LPBITMAPFILEHEADER, *PBITMAPFILEHEADER;
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 777 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"





typedef struct tagFONTSIGNATURE
{
    DWORD fsUsb[4];
    DWORD fsCsb[2];
} FONTSIGNATURE, *PFONTSIGNATURE, *LPFONTSIGNATURE;

typedef struct tagCHARSETINFO
{
    UINT ciCharset;
    UINT ciACP;
    FONTSIGNATURE fs;
} CHARSETINFO, *PCHARSETINFO,  *NPCHARSETINFO,  *LPCHARSETINFO;





typedef struct tagLOCALESIGNATURE
{
    DWORD lsUsb[4];
    DWORD lsCsbDefault[2];
    DWORD lsCsbSupported[2];
} LOCALESIGNATURE, *PLOCALESIGNATURE, *LPLOCALESIGNATURE;


#line 808 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 809 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




typedef struct tagHANDLETABLE
  {
    HGDIOBJ     objectHandle[1];
  } HANDLETABLE, *PHANDLETABLE,  *LPHANDLETABLE;

typedef struct tagMETARECORD
  {
    DWORD       rdSize;
    WORD        rdFunction;
    WORD        rdParm[1];
  } METARECORD;
typedef struct tagMETARECORD  *PMETARECORD;
typedef struct tagMETARECORD   *LPMETARECORD;

typedef struct tagMETAFILEPICT
  {
    LONG        mm;
    LONG        xExt;
    LONG        yExt;
    HMETAFILE   hMF;
  } METAFILEPICT,  *LPMETAFILEPICT;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 836 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
typedef struct tagMETAHEADER
{
    WORD        mtType;
    WORD        mtHeaderSize;
    WORD        mtVersion;
    DWORD       mtSize;
    WORD        mtNoObjects;
    DWORD       mtMaxRecord;
    WORD        mtNoParameters;
} METAHEADER;
typedef struct tagMETAHEADER  *PMETAHEADER;
typedef struct tagMETAHEADER   *LPMETAHEADER;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 850 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagENHMETARECORD
{
    DWORD   iType;              
    DWORD   nSize;              
    DWORD   dParm[1];           
} ENHMETARECORD, *PENHMETARECORD, *LPENHMETARECORD;

typedef struct tagENHMETAHEADER
{
    DWORD   iType;              
    DWORD   nSize;              
                                
    RECTL   rclBounds;          
    RECTL   rclFrame;           
    DWORD   dSignature;         
    DWORD   nVersion;           
    DWORD   nBytes;             
    DWORD   nRecords;           
    WORD    nHandles;           
                                
    WORD    sReserved;          
    DWORD   nDescription;       
                                
    DWORD   offDescription;     
                                
    DWORD   nPalEntries;        
    SIZEL   szlDevice;          
    SIZEL   szlMillimeters;     

    DWORD   cbPixelFormat;      
                                
    DWORD   offPixelFormat;     
                                
    DWORD   bOpenGL;            
                                
#line 888 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

    SIZEL   szlMicrometers;     
#line 891 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

} ENHMETAHEADER, *PENHMETAHEADER, *LPENHMETAHEADER;

#line 895 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"















    typedef BYTE BCHAR;
#line 912 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagTEXTMETRICA
{
    LONG        tmHeight;
    LONG        tmAscent;
    LONG        tmDescent;
    LONG        tmInternalLeading;
    LONG        tmExternalLeading;
    LONG        tmAveCharWidth;
    LONG        tmMaxCharWidth;
    LONG        tmWeight;
    LONG        tmOverhang;
    LONG        tmDigitizedAspectX;
    LONG        tmDigitizedAspectY;
    BYTE        tmFirstChar;
    BYTE        tmLastChar;
    BYTE        tmDefaultChar;
    BYTE        tmBreakChar;
    BYTE        tmItalic;
    BYTE        tmUnderlined;
    BYTE        tmStruckOut;
    BYTE        tmPitchAndFamily;
    BYTE        tmCharSet;
} TEXTMETRICA, *PTEXTMETRICA,  *NPTEXTMETRICA,  *LPTEXTMETRICA;
typedef struct tagTEXTMETRICW
{
    LONG        tmHeight;
    LONG        tmAscent;
    LONG        tmDescent;
    LONG        tmInternalLeading;
    LONG        tmExternalLeading;
    LONG        tmAveCharWidth;
    LONG        tmMaxCharWidth;
    LONG        tmWeight;
    LONG        tmOverhang;
    LONG        tmDigitizedAspectX;
    LONG        tmDigitizedAspectY;
    WCHAR       tmFirstChar;
    WCHAR       tmLastChar;
    WCHAR       tmDefaultChar;
    WCHAR       tmBreakChar;
    BYTE        tmItalic;
    BYTE        tmUnderlined;
    BYTE        tmStruckOut;
    BYTE        tmPitchAndFamily;
    BYTE        tmCharSet;
} TEXTMETRICW, *PTEXTMETRICW,  *NPTEXTMETRICW,  *LPTEXTMETRICW;






typedef TEXTMETRICA TEXTMETRIC;
typedef PTEXTMETRICA PTEXTMETRIC;
typedef NPTEXTMETRICA NPTEXTMETRIC;
typedef LPTEXTMETRICA LPTEXTMETRIC;
#line 972 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 973 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"















#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"























#pragma warning(disable:4103)

#pragma pack(push,4)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 989 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
typedef struct tagNEWTEXTMETRICA
{
    LONG        tmHeight;
    LONG        tmAscent;
    LONG        tmDescent;
    LONG        tmInternalLeading;
    LONG        tmExternalLeading;
    LONG        tmAveCharWidth;
    LONG        tmMaxCharWidth;
    LONG        tmWeight;
    LONG        tmOverhang;
    LONG        tmDigitizedAspectX;
    LONG        tmDigitizedAspectY;
    BYTE        tmFirstChar;
    BYTE        tmLastChar;
    BYTE        tmDefaultChar;
    BYTE        tmBreakChar;
    BYTE        tmItalic;
    BYTE        tmUnderlined;
    BYTE        tmStruckOut;
    BYTE        tmPitchAndFamily;
    BYTE        tmCharSet;
    DWORD   ntmFlags;
    UINT    ntmSizeEM;
    UINT    ntmCellHeight;
    UINT    ntmAvgWidth;
} NEWTEXTMETRICA, *PNEWTEXTMETRICA,  *NPNEWTEXTMETRICA,  *LPNEWTEXTMETRICA;
typedef struct tagNEWTEXTMETRICW
{
    LONG        tmHeight;
    LONG        tmAscent;
    LONG        tmDescent;
    LONG        tmInternalLeading;
    LONG        tmExternalLeading;
    LONG        tmAveCharWidth;
    LONG        tmMaxCharWidth;
    LONG        tmWeight;
    LONG        tmOverhang;
    LONG        tmDigitizedAspectX;
    LONG        tmDigitizedAspectY;
    WCHAR       tmFirstChar;
    WCHAR       tmLastChar;
    WCHAR       tmDefaultChar;
    WCHAR       tmBreakChar;
    BYTE        tmItalic;
    BYTE        tmUnderlined;
    BYTE        tmStruckOut;
    BYTE        tmPitchAndFamily;
    BYTE        tmCharSet;
    DWORD   ntmFlags;
    UINT    ntmSizeEM;
    UINT    ntmCellHeight;
    UINT    ntmAvgWidth;
} NEWTEXTMETRICW, *PNEWTEXTMETRICW,  *NPNEWTEXTMETRICW,  *LPNEWTEXTMETRICW;






typedef NEWTEXTMETRICA NEWTEXTMETRIC;
typedef PNEWTEXTMETRICA PNEWTEXTMETRIC;
typedef NPNEWTEXTMETRICA NPNEWTEXTMETRIC;
typedef LPNEWTEXTMETRICA LPNEWTEXTMETRIC;
#line 1054 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 1055 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagNEWTEXTMETRICEXA
{
    NEWTEXTMETRICA  ntmTm;
    FONTSIGNATURE   ntmFontSig;
}NEWTEXTMETRICEXA;
typedef struct tagNEWTEXTMETRICEXW
{
    NEWTEXTMETRICW  ntmTm;
    FONTSIGNATURE   ntmFontSig;
}NEWTEXTMETRICEXW;



typedef NEWTEXTMETRICEXA NEWTEXTMETRICEX;
#line 1072 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 1073 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 1075 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagPELARRAY
  {
    LONG        paXCount;
    LONG        paYCount;
    LONG        paXExt;
    LONG        paYExt;
    BYTE        paRGBs;
  } PELARRAY, *PPELARRAY,  *NPPELARRAY,  *LPPELARRAY;


typedef struct tagLOGBRUSH
  {
    UINT        lbStyle;
    COLORREF    lbColor;
    ULONG_PTR    lbHatch;    
  } LOGBRUSH, *PLOGBRUSH,  *NPLOGBRUSH,  *LPLOGBRUSH;

typedef struct tagLOGBRUSH32
  {
    UINT        lbStyle;
    COLORREF    lbColor;
    ULONG       lbHatch;
  } LOGBRUSH32, *PLOGBRUSH32,  *NPLOGBRUSH32,  *LPLOGBRUSH32;

typedef LOGBRUSH            PATTERN;
typedef PATTERN             *PPATTERN;
typedef PATTERN         *NPPATTERN;
typedef PATTERN          *LPPATTERN;


typedef struct tagLOGPEN
  {
    UINT        lopnStyle;
    POINT       lopnWidth;
    COLORREF    lopnColor;
  } LOGPEN, *PLOGPEN,  *NPLOGPEN,  *LPLOGPEN;

typedef struct tagEXTLOGPEN {
    DWORD       elpPenStyle;
    DWORD       elpWidth;
    UINT        elpBrushStyle;
    COLORREF    elpColor;
    ULONG_PTR    elpHatch;     
    DWORD       elpNumEntries;
    DWORD       elpStyleEntry[1];
} EXTLOGPEN, *PEXTLOGPEN,  *NPEXTLOGPEN,  *LPEXTLOGPEN;



typedef struct tagPALETTEENTRY {
    BYTE        peRed;
    BYTE        peGreen;
    BYTE        peBlue;
    BYTE        peFlags;
} PALETTEENTRY, *PPALETTEENTRY,  *LPPALETTEENTRY;
#line 1134 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




typedef struct tagLOGPALETTE {
    WORD        palVersion;
    WORD        palNumEntries;
    PALETTEENTRY        palPalEntry[1];
} LOGPALETTE, *PLOGPALETTE,  *NPLOGPALETTE,  *LPLOGPALETTE;
#line 1144 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"





typedef struct tagLOGFONTA
{
    LONG      lfHeight;
    LONG      lfWidth;
    LONG      lfEscapement;
    LONG      lfOrientation;
    LONG      lfWeight;
    BYTE      lfItalic;
    BYTE      lfUnderline;
    BYTE      lfStrikeOut;
    BYTE      lfCharSet;
    BYTE      lfOutPrecision;
    BYTE      lfClipPrecision;
    BYTE      lfQuality;
    BYTE      lfPitchAndFamily;
    CHAR      lfFaceName[32];
} LOGFONTA, *PLOGFONTA,  *NPLOGFONTA,  *LPLOGFONTA;
typedef struct tagLOGFONTW
{
    LONG      lfHeight;
    LONG      lfWidth;
    LONG      lfEscapement;
    LONG      lfOrientation;
    LONG      lfWeight;
    BYTE      lfItalic;
    BYTE      lfUnderline;
    BYTE      lfStrikeOut;
    BYTE      lfCharSet;
    BYTE      lfOutPrecision;
    BYTE      lfClipPrecision;
    BYTE      lfQuality;
    BYTE      lfPitchAndFamily;
    WCHAR     lfFaceName[32];
} LOGFONTW, *PLOGFONTW,  *NPLOGFONTW,  *LPLOGFONTW;






typedef LOGFONTA LOGFONT;
typedef PLOGFONTA PLOGFONT;
typedef NPLOGFONTA NPLOGFONT;
typedef LPLOGFONTA LPLOGFONT;
#line 1194 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




typedef struct tagENUMLOGFONTA
{
    LOGFONTA elfLogFont;
    BYTE     elfFullName[64];
    BYTE     elfStyle[32];
} ENUMLOGFONTA, * LPENUMLOGFONTA;

typedef struct tagENUMLOGFONTW
{
    LOGFONTW elfLogFont;
    WCHAR    elfFullName[64];
    WCHAR    elfStyle[32];
} ENUMLOGFONTW, * LPENUMLOGFONTW;




typedef ENUMLOGFONTA ENUMLOGFONT;
typedef LPENUMLOGFONTA LPENUMLOGFONT;
#line 1218 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagENUMLOGFONTEXA
{
    LOGFONTA    elfLogFont;
    BYTE        elfFullName[64];
    BYTE        elfStyle[32];
    BYTE        elfScript[32];
} ENUMLOGFONTEXA,  *LPENUMLOGFONTEXA;
typedef struct tagENUMLOGFONTEXW
{
    LOGFONTW    elfLogFont;
    WCHAR       elfFullName[64];
    WCHAR       elfStyle[32];
    WCHAR       elfScript[32];
} ENUMLOGFONTEXW,  *LPENUMLOGFONTEXW;




typedef ENUMLOGFONTEXA ENUMLOGFONTEX;
typedef LPENUMLOGFONTEXA LPENUMLOGFONTEX;
#line 1241 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 1242 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



























#line 1270 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



#line 1274 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"






#line 1281 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"








































#line 1322 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




                                    

                                    

                                    



































typedef struct tagPANOSE
{
    BYTE    bFamilyType;
    BYTE    bSerifStyle;
    BYTE    bWeight;
    BYTE    bProportion;
    BYTE    bContrast;
    BYTE    bStrokeVariation;
    BYTE    bArmStyle;
    BYTE    bLetterform;
    BYTE    bMidline;
    BYTE    bXHeight;
} PANOSE, * LPPANOSE;

















































































































typedef struct tagEXTLOGFONTA {
    LOGFONTA    elfLogFont;
    BYTE        elfFullName[64];
    BYTE        elfStyle[32];
    DWORD       elfVersion;     
    DWORD       elfStyleSize;
    DWORD       elfMatch;
    DWORD       elfReserved;
    BYTE        elfVendorId[4];
    DWORD       elfCulture;     
    PANOSE      elfPanose;
} EXTLOGFONTA, *PEXTLOGFONTA,  *NPEXTLOGFONTA,  *LPEXTLOGFONTA;
typedef struct tagEXTLOGFONTW {
    LOGFONTW    elfLogFont;
    WCHAR       elfFullName[64];
    WCHAR       elfStyle[32];
    DWORD       elfVersion;     
    DWORD       elfStyleSize;
    DWORD       elfMatch;
    DWORD       elfReserved;
    BYTE        elfVendorId[4];
    DWORD       elfCulture;     
    PANOSE      elfPanose;
} EXTLOGFONTW, *PEXTLOGFONTW,  *NPEXTLOGFONTW,  *LPEXTLOGFONTW;






typedef EXTLOGFONTA EXTLOGFONT;
typedef PEXTLOGFONTA PEXTLOGFONT;
typedef NPEXTLOGFONTA NPEXTLOGFONT;
typedef LPEXTLOGFONTA LPEXTLOGFONT;
#line 1527 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
















































































#line 1608 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




#line 1613 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



#line 1617 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



#line 1621 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

































































































                             

                             

                             





#line 1729 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"










































































#line 1804 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"





































#line 1842 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



























typedef struct _devicemodeA {
    BYTE   dmDeviceName[32];
    WORD dmSpecVersion;
    WORD dmDriverVersion;
    WORD dmSize;
    WORD dmDriverExtra;
    DWORD dmFields;
    union {
      struct {
        short dmOrientation;
        short dmPaperSize;
        short dmPaperLength;
        short dmPaperWidth;
      };
      POINTL dmPosition;
    };
    short dmScale;
    short dmCopies;
    short dmDefaultSource;
    short dmPrintQuality;
    short dmColor;
    short dmDuplex;
    short dmYResolution;
    short dmTTOption;
    short dmCollate;
    BYTE   dmFormName[32];
    WORD   dmLogPixels;
    DWORD  dmBitsPerPel;
    DWORD  dmPelsWidth;
    DWORD  dmPelsHeight;
    union {
        DWORD  dmDisplayFlags;
        DWORD  dmNup;
    };
    DWORD  dmDisplayFrequency;

    DWORD  dmICMMethod;
    DWORD  dmICMIntent;
    DWORD  dmMediaType;
    DWORD  dmDitherType;
    DWORD  dmReserved1;
    DWORD  dmReserved2;

    DWORD  dmPanningWidth;
    DWORD  dmPanningHeight;
#line 1915 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 1916 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
} DEVMODEA, *PDEVMODEA, *NPDEVMODEA, *LPDEVMODEA;
typedef struct _devicemodeW {
    WCHAR  dmDeviceName[32];
    WORD dmSpecVersion;
    WORD dmDriverVersion;
    WORD dmSize;
    WORD dmDriverExtra;
    DWORD dmFields;
    union {
      struct {
        short dmOrientation;
        short dmPaperSize;
        short dmPaperLength;
        short dmPaperWidth;
      };
      POINTL dmPosition;
    };
    short dmScale;
    short dmCopies;
    short dmDefaultSource;
    short dmPrintQuality;
    short dmColor;
    short dmDuplex;
    short dmYResolution;
    short dmTTOption;
    short dmCollate;
    WCHAR  dmFormName[32];
    WORD   dmLogPixels;
    DWORD  dmBitsPerPel;
    DWORD  dmPelsWidth;
    DWORD  dmPelsHeight;
    union {
        DWORD  dmDisplayFlags;
        DWORD  dmNup;
    };
    DWORD  dmDisplayFrequency;

    DWORD  dmICMMethod;
    DWORD  dmICMIntent;
    DWORD  dmMediaType;
    DWORD  dmDitherType;
    DWORD  dmReserved1;
    DWORD  dmReserved2;

    DWORD  dmPanningWidth;
    DWORD  dmPanningHeight;
#line 1963 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 1964 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
} DEVMODEW, *PDEVMODEW, *NPDEVMODEW, *LPDEVMODEW;






typedef DEVMODEA DEVMODE;
typedef PDEVMODEA PDEVMODE;
typedef NPDEVMODEA NPDEVMODE;
typedef LPDEVMODEA LPDEVMODE;
#line 1976 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"








#line 1985 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"










#line 1996 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"






















#line 2019 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"












































































#line 2096 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




















































#line 2149 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"







#line 2157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"












































#line 2202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"





















































#line 2256 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct _DISPLAY_DEVICEA {
    DWORD  cb;
    CHAR   DeviceName[32];
    CHAR   DeviceString[128];
    DWORD  StateFlags;
    CHAR   DeviceID[128];
    CHAR   DeviceKey[128];
} DISPLAY_DEVICEA, *PDISPLAY_DEVICEA, *LPDISPLAY_DEVICEA;
typedef struct _DISPLAY_DEVICEW {
    DWORD  cb;
    WCHAR  DeviceName[32];
    WCHAR  DeviceString[128];
    DWORD  StateFlags;
    WCHAR  DeviceID[128];
    WCHAR  DeviceKey[128];
} DISPLAY_DEVICEW, *PDISPLAY_DEVICEW, *LPDISPLAY_DEVICEW;





typedef DISPLAY_DEVICEA DISPLAY_DEVICE;
typedef PDISPLAY_DEVICEA PDISPLAY_DEVICE;
typedef LPDISPLAY_DEVICEA LPDISPLAY_DEVICE;
#line 2282 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




















typedef struct _RGNDATAHEADER {
    DWORD   dwSize;
    DWORD   iType;
    DWORD   nCount;
    DWORD   nRgnSize;
    RECT    rcBound;
} RGNDATAHEADER, *PRGNDATAHEADER;

typedef struct _RGNDATA {
    RGNDATAHEADER   rdh;
    char            Buffer[1];
} RGNDATA, *PRGNDATA,  *NPRGNDATA,  *LPRGNDATA;





typedef struct _ABC {
    int     abcA;
    UINT    abcB;
    int     abcC;
} ABC, *PABC,  *NPABC,  *LPABC;

typedef struct _ABCFLOAT {
    FLOAT   abcfA;
    FLOAT   abcfB;
    FLOAT   abcfC;
} ABCFLOAT, *PABCFLOAT,  *NPABCFLOAT,  *LPABCFLOAT;






typedef struct _OUTLINETEXTMETRICA {
    UINT    otmSize;
    TEXTMETRICA otmTextMetrics;
    BYTE    otmFiller;
    PANOSE  otmPanoseNumber;
    UINT    otmfsSelection;
    UINT    otmfsType;
     int    otmsCharSlopeRise;
     int    otmsCharSlopeRun;
     int    otmItalicAngle;
    UINT    otmEMSquare;
     int    otmAscent;
     int    otmDescent;
    UINT    otmLineGap;
    UINT    otmsCapEmHeight;
    UINT    otmsXHeight;
    RECT    otmrcFontBox;
     int    otmMacAscent;
     int    otmMacDescent;
    UINT    otmMacLineGap;
    UINT    otmusMinimumPPEM;
    POINT   otmptSubscriptSize;
    POINT   otmptSubscriptOffset;
    POINT   otmptSuperscriptSize;
    POINT   otmptSuperscriptOffset;
    UINT    otmsStrikeoutSize;
     int    otmsStrikeoutPosition;
     int    otmsUnderscoreSize;
     int    otmsUnderscorePosition;
    PSTR    otmpFamilyName;
    PSTR    otmpFaceName;
    PSTR    otmpStyleName;
    PSTR    otmpFullName;
} OUTLINETEXTMETRICA, *POUTLINETEXTMETRICA,  *NPOUTLINETEXTMETRICA,  *LPOUTLINETEXTMETRICA;
typedef struct _OUTLINETEXTMETRICW {
    UINT    otmSize;
    TEXTMETRICW otmTextMetrics;
    BYTE    otmFiller;
    PANOSE  otmPanoseNumber;
    UINT    otmfsSelection;
    UINT    otmfsType;
     int    otmsCharSlopeRise;
     int    otmsCharSlopeRun;
     int    otmItalicAngle;
    UINT    otmEMSquare;
     int    otmAscent;
     int    otmDescent;
    UINT    otmLineGap;
    UINT    otmsCapEmHeight;
    UINT    otmsXHeight;
    RECT    otmrcFontBox;
     int    otmMacAscent;
     int    otmMacDescent;
    UINT    otmMacLineGap;
    UINT    otmusMinimumPPEM;
    POINT   otmptSubscriptSize;
    POINT   otmptSubscriptOffset;
    POINT   otmptSuperscriptSize;
    POINT   otmptSuperscriptOffset;
    UINT    otmsStrikeoutSize;
     int    otmsStrikeoutPosition;
     int    otmsUnderscoreSize;
     int    otmsUnderscorePosition;
    PSTR    otmpFamilyName;
    PSTR    otmpFaceName;
    PSTR    otmpStyleName;
    PSTR    otmpFullName;
} OUTLINETEXTMETRICW, *POUTLINETEXTMETRICW,  *NPOUTLINETEXTMETRICW,  *LPOUTLINETEXTMETRICW;






typedef OUTLINETEXTMETRICA OUTLINETEXTMETRIC;
typedef POUTLINETEXTMETRICA POUTLINETEXTMETRIC;
typedef NPOUTLINETEXTMETRICA NPOUTLINETEXTMETRIC;
typedef LPOUTLINETEXTMETRICA LPOUTLINETEXTMETRIC;
#line 2415 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"





#line 2421 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagPOLYTEXTA
{
    int       x;
    int       y;
    UINT      n;
    LPCSTR    lpstr;
    UINT      uiFlags;
    RECT      rcl;
    int      *pdx;
} POLYTEXTA, *PPOLYTEXTA,  *NPPOLYTEXTA,  *LPPOLYTEXTA;
typedef struct tagPOLYTEXTW
{
    int       x;
    int       y;
    UINT      n;
    LPCWSTR   lpstr;
    UINT      uiFlags;
    RECT      rcl;
    int      *pdx;
} POLYTEXTW, *PPOLYTEXTW,  *NPPOLYTEXTW,  *LPPOLYTEXTW;






typedef POLYTEXTA POLYTEXT;
typedef PPOLYTEXTA PPOLYTEXT;
typedef NPPOLYTEXTA NPPOLYTEXT;
typedef LPPOLYTEXTA LPPOLYTEXT;
#line 2454 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct _FIXED {

    WORD    fract;
    short   value;



#line 2463 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
} FIXED;


typedef struct _MAT2 {
     FIXED  eM11;
     FIXED  eM12;
     FIXED  eM21;
     FIXED  eM22;
} MAT2,  *LPMAT2;



typedef struct _GLYPHMETRICS {
    UINT    gmBlackBoxX;
    UINT    gmBlackBoxY;
    POINT   gmptGlyphOrigin;
    short   gmCellIncX;
    short   gmCellIncY;
} GLYPHMETRICS,  *LPGLYPHMETRICS;













#line 2496 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



#line 2500 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"







typedef struct tagPOINTFX
{
    FIXED x;
    FIXED y;
} POINTFX, * LPPOINTFX;

typedef struct tagTTPOLYCURVE
{
    WORD    wType;
    WORD    cpfx;
    POINTFX apfx[1];
} TTPOLYCURVE, * LPTTPOLYCURVE;

typedef struct tagTTPOLYGONHEADER
{
    DWORD   cb;
    DWORD   dwType;
    POINTFX pfxStart;
} TTPOLYGONHEADER, * LPTTPOLYGONHEADER;













































typedef struct tagGCP_RESULTSA
    {
    DWORD   lStructSize;
    LPSTR     lpOutString;
    UINT  *lpOrder;
    int   *lpDx;
    int   *lpCaretPos;
    LPSTR   lpClass;
    LPWSTR  lpGlyphs;
    UINT    nGlyphs;
    int     nMaxFit;
    } GCP_RESULTSA, * LPGCP_RESULTSA;
typedef struct tagGCP_RESULTSW
    {
    DWORD   lStructSize;
    LPWSTR    lpOutString;
    UINT  *lpOrder;
    int   *lpDx;
    int   *lpCaretPos;
    LPSTR   lpClass;
    LPWSTR  lpGlyphs;
    UINT    nGlyphs;
    int     nMaxFit;
    } GCP_RESULTSW, * LPGCP_RESULTSW;




typedef GCP_RESULTSA GCP_RESULTS;
typedef LPGCP_RESULTSA LPGCP_RESULTS;
#line 2602 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 2603 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct _RASTERIZER_STATUS {
    short   nSize;
    short   wFlags;
    short   nLanguageID;
} RASTERIZER_STATUS,  *LPRASTERIZER_STATUS;






typedef struct tagPIXELFORMATDESCRIPTOR
{
    WORD  nSize;
    WORD  nVersion;
    DWORD dwFlags;
    BYTE  iPixelType;
    BYTE  cColorBits;
    BYTE  cRedBits;
    BYTE  cRedShift;
    BYTE  cGreenBits;
    BYTE  cGreenShift;
    BYTE  cBlueBits;
    BYTE  cBlueShift;
    BYTE  cAlphaBits;
    BYTE  cAlphaShift;
    BYTE  cAccumBits;
    BYTE  cAccumRedBits;
    BYTE  cAccumGreenBits;
    BYTE  cAccumBlueBits;
    BYTE  cAccumAlphaBits;
    BYTE  cDepthBits;
    BYTE  cStencilBits;
    BYTE  cAuxBuffers;
    BYTE  iLayerType;
    BYTE  bReserved;
    DWORD dwLayerMask;
    DWORD dwVisibleMask;
    DWORD dwDamageMask;
} PIXELFORMATDESCRIPTOR, *PPIXELFORMATDESCRIPTOR,  *LPPIXELFORMATDESCRIPTOR;

































typedef int (__stdcall* OLDFONTENUMPROCA)(const LOGFONTA *, const TEXTMETRICA *, DWORD, LPARAM);
typedef int (__stdcall* OLDFONTENUMPROCW)(const LOGFONTW *, const TEXTMETRICW *, DWORD, LPARAM);




#line 2684 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"








#line 2693 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef OLDFONTENUMPROCA    FONTENUMPROCA;
typedef OLDFONTENUMPROCW    FONTENUMPROCW;



typedef FONTENUMPROCA FONTENUMPROC;
#line 2701 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef int (__stdcall* GOBJENUMPROC)(LPVOID, LPARAM);
typedef void (__stdcall* LINEDDAPROC)(int, int, LPARAM);











#line 2716 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



__declspec(dllimport) int __stdcall AddFontResourceA( LPCSTR);
__declspec(dllimport) int __stdcall AddFontResourceW( LPCWSTR);




#line 2726 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) BOOL  __stdcall AnimatePalette(  HPALETTE,  UINT,   UINT,  const PALETTEENTRY *);
__declspec(dllimport) BOOL  __stdcall Arc(  HDC,  int,  int,  int,  int,  int,  int,  int,  int);
__declspec(dllimport) BOOL  __stdcall BitBlt(  HDC,  int,  int,  int,  int,  HDC,  int,  int,  DWORD);
__declspec(dllimport) BOOL  __stdcall CancelDC(  HDC);
__declspec(dllimport) BOOL  __stdcall Chord(  HDC,  int,  int,  int,  int,  int,  int,  int,  int);
__declspec(dllimport) int   __stdcall ChoosePixelFormat(  HDC,  const PIXELFORMATDESCRIPTOR *);
__declspec(dllimport) HMETAFILE  __stdcall CloseMetaFile(  HDC);
__declspec(dllimport) int     __stdcall CombineRgn(  HRGN,  HRGN,  HRGN,  int);
__declspec(dllimport) HMETAFILE __stdcall CopyMetaFileA(  HMETAFILE,  LPCSTR);
__declspec(dllimport) HMETAFILE __stdcall CopyMetaFileW(  HMETAFILE,  LPCWSTR);




#line 2743 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HBITMAP __stdcall CreateBitmap(  int,  int,  UINT,  UINT,  const void *);
__declspec(dllimport) HBITMAP __stdcall CreateBitmapIndirect(  const BITMAP *);
__declspec(dllimport) HBRUSH  __stdcall CreateBrushIndirect(  const LOGBRUSH *);
__declspec(dllimport) HBITMAP __stdcall CreateCompatibleBitmap(  HDC,  int,  int);
__declspec(dllimport) HBITMAP __stdcall CreateDiscardableBitmap(  HDC,  int,  int);
__declspec(dllimport) HDC     __stdcall CreateCompatibleDC(  HDC);
__declspec(dllimport) HDC     __stdcall CreateDCA(  LPCSTR,  LPCSTR,  LPCSTR,  const DEVMODEA *);
__declspec(dllimport) HDC     __stdcall CreateDCW(  LPCWSTR,  LPCWSTR,  LPCWSTR,  const DEVMODEW *);




#line 2756 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HBITMAP __stdcall CreateDIBitmap(  HDC,  const BITMAPINFOHEADER *,  DWORD,  const void *,  const BITMAPINFO *,  UINT);
__declspec(dllimport) HBRUSH  __stdcall CreateDIBPatternBrush(  HGLOBAL,  UINT);
__declspec(dllimport) HBRUSH  __stdcall CreateDIBPatternBrushPt(  const void *,  UINT);
__declspec(dllimport) HRGN    __stdcall CreateEllipticRgn(  int,  int,  int,  int);
__declspec(dllimport) HRGN    __stdcall CreateEllipticRgnIndirect(  const RECT *);
__declspec(dllimport) HFONT   __stdcall CreateFontIndirectA(  const LOGFONTA *);
__declspec(dllimport) HFONT   __stdcall CreateFontIndirectW(  const LOGFONTW *);




#line 2768 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HFONT   __stdcall CreateFontA(  int,  int,  int,  int,  int,  DWORD,
                              DWORD,  DWORD,  DWORD,  DWORD,  DWORD,
                              DWORD,  DWORD,  LPCSTR);
__declspec(dllimport) HFONT   __stdcall CreateFontW(  int,  int,  int,  int,  int,  DWORD,
                              DWORD,  DWORD,  DWORD,  DWORD,  DWORD,
                              DWORD,  DWORD,  LPCWSTR);




#line 2779 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) HBRUSH  __stdcall CreateHatchBrush(  int,  COLORREF);
__declspec(dllimport) HDC     __stdcall CreateICA(  LPCSTR,  LPCSTR,  LPCSTR,  const DEVMODEA *);
__declspec(dllimport) HDC     __stdcall CreateICW(  LPCWSTR,  LPCWSTR,  LPCWSTR,  const DEVMODEW *);




#line 2788 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HDC     __stdcall CreateMetaFileA(  LPCSTR);
__declspec(dllimport) HDC     __stdcall CreateMetaFileW(  LPCWSTR);




#line 2795 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HPALETTE __stdcall CreatePalette(  const LOGPALETTE *);
__declspec(dllimport) HPEN    __stdcall CreatePen(  int,  int,  COLORREF);
__declspec(dllimport) HPEN    __stdcall CreatePenIndirect(  const LOGPEN *);
__declspec(dllimport) HRGN    __stdcall CreatePolyPolygonRgn(  const POINT *,  const INT *,  int,  int);
__declspec(dllimport) HBRUSH  __stdcall CreatePatternBrush(  HBITMAP);
__declspec(dllimport) HRGN    __stdcall CreateRectRgn(  int,  int,  int,  int);
__declspec(dllimport) HRGN    __stdcall CreateRectRgnIndirect(  const RECT *);
__declspec(dllimport) HRGN    __stdcall CreateRoundRectRgn(  int,  int,  int,  int,  int,  int);
__declspec(dllimport) BOOL    __stdcall CreateScalableFontResourceA(  DWORD,  LPCSTR,  LPCSTR,  LPCSTR);
__declspec(dllimport) BOOL    __stdcall CreateScalableFontResourceW(  DWORD,  LPCWSTR,  LPCWSTR,  LPCWSTR);




#line 2810 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HBRUSH  __stdcall CreateSolidBrush(  COLORREF);

__declspec(dllimport) BOOL __stdcall DeleteDC(  HDC);
__declspec(dllimport) BOOL __stdcall DeleteMetaFile(  HMETAFILE);
__declspec(dllimport) BOOL __stdcall DeleteObject(  HGDIOBJ);
__declspec(dllimport) int  __stdcall DescribePixelFormat(  HDC,  int,  UINT,  LPPIXELFORMATDESCRIPTOR);





typedef UINT   (__stdcall* LPFNDEVMODE)(HWND, HMODULE, LPDEVMODE, LPSTR, LPSTR, LPDEVMODE, LPSTR, UINT);

typedef DWORD  (__stdcall* LPFNDEVCAPS)(LPSTR, LPSTR, UINT, LPSTR, LPDEVMODE);






































#line 2863 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

















#line 2881 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

















#line 2899 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int  __stdcall DeviceCapabilitiesA(  LPCSTR,  LPCSTR,  WORD,
                                 LPSTR,  const DEVMODEA *);
__declspec(dllimport) int  __stdcall DeviceCapabilitiesW(  LPCWSTR,  LPCWSTR,  WORD,
                                 LPWSTR,  const DEVMODEW *);




#line 2909 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int  __stdcall DrawEscape(  HDC,  int,  int,  LPCSTR);
__declspec(dllimport) BOOL __stdcall Ellipse(  HDC,  int,  int,  int,  int);


__declspec(dllimport) int  __stdcall EnumFontFamiliesExA(  HDC,  LPLOGFONTA,  FONTENUMPROCA,  LPARAM,  DWORD);
__declspec(dllimport) int  __stdcall EnumFontFamiliesExW(  HDC,  LPLOGFONTW,  FONTENUMPROCW,  LPARAM,  DWORD);




#line 2921 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 2922 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int  __stdcall EnumFontFamiliesA(  HDC,  LPCSTR,  FONTENUMPROCA,  LPARAM);
__declspec(dllimport) int  __stdcall EnumFontFamiliesW(  HDC,  LPCWSTR,  FONTENUMPROCW,  LPARAM);




#line 2930 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) int  __stdcall EnumFontsA(  HDC,  LPCSTR,   FONTENUMPROCA,  LPARAM);
__declspec(dllimport) int  __stdcall EnumFontsW(  HDC,  LPCWSTR,   FONTENUMPROCW,  LPARAM);




#line 2937 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) int  __stdcall EnumObjects(  HDC,  int,  GOBJENUMPROC,  LPARAM);


#line 2943 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) BOOL __stdcall EqualRgn(  HRGN,  HRGN);
__declspec(dllimport) int  __stdcall Escape(  HDC,  int,  int,  LPCSTR,   LPVOID);
__declspec(dllimport) int  __stdcall ExtEscape(  HDC,  int,  int,  LPCSTR,   int,  LPSTR);
__declspec(dllimport) int  __stdcall ExcludeClipRect(  HDC,  int,  int,  int,  int);
__declspec(dllimport) HRGN __stdcall ExtCreateRegion(  const XFORM *,  DWORD,  const RGNDATA *);
__declspec(dllimport) BOOL  __stdcall ExtFloodFill(  HDC,  int,  int,  COLORREF,  UINT);
__declspec(dllimport) BOOL   __stdcall FillRgn(  HDC,  HRGN,  HBRUSH);
__declspec(dllimport) BOOL   __stdcall FloodFill(  HDC,  int,  int,  COLORREF);
__declspec(dllimport) BOOL   __stdcall FrameRgn(  HDC,  HRGN,  HBRUSH,  int,  int);
__declspec(dllimport) int   __stdcall GetROP2(  HDC);
__declspec(dllimport) BOOL  __stdcall GetAspectRatioFilterEx(  HDC,  LPSIZE);
__declspec(dllimport) COLORREF __stdcall GetBkColor(  HDC);




#line 2962 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int   __stdcall GetBkMode(  HDC);
__declspec(dllimport) LONG  __stdcall GetBitmapBits(  HBITMAP,  LONG,  LPVOID);
__declspec(dllimport) BOOL  __stdcall GetBitmapDimensionEx(  HBITMAP,  LPSIZE);
__declspec(dllimport) UINT  __stdcall GetBoundsRect(  HDC,  LPRECT,  UINT);

__declspec(dllimport) BOOL  __stdcall GetBrushOrgEx(  HDC,  LPPOINT);

__declspec(dllimport) BOOL  __stdcall GetCharWidthA(  HDC,  UINT,  UINT,  LPINT);
__declspec(dllimport) BOOL  __stdcall GetCharWidthW(  HDC,  UINT,  UINT,  LPINT);




#line 2977 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall GetCharWidth32A(  HDC,  UINT,  UINT,   LPINT);
__declspec(dllimport) BOOL  __stdcall GetCharWidth32W(  HDC,  UINT,  UINT,   LPINT);




#line 2984 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall GetCharWidthFloatA(  HDC,  UINT,  UINT,  PFLOAT);
__declspec(dllimport) BOOL  __stdcall GetCharWidthFloatW(  HDC,  UINT,  UINT,  PFLOAT);




#line 2991 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall GetCharABCWidthsA(  HDC,  UINT,  UINT,  LPABC);
__declspec(dllimport) BOOL  __stdcall GetCharABCWidthsW(  HDC,  UINT,  UINT,  LPABC);




#line 2998 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall GetCharABCWidthsFloatA(  HDC,  UINT,  UINT,  LPABCFLOAT);
__declspec(dllimport) BOOL  __stdcall GetCharABCWidthsFloatW(  HDC,  UINT,  UINT,  LPABCFLOAT);




#line 3005 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) int   __stdcall GetClipBox(  HDC,   LPRECT);
__declspec(dllimport) int   __stdcall GetClipRgn(  HDC,  HRGN);
__declspec(dllimport) int   __stdcall GetMetaRgn(  HDC,  HRGN);
__declspec(dllimport) HGDIOBJ __stdcall GetCurrentObject(  HDC,  UINT);
__declspec(dllimport) BOOL  __stdcall GetCurrentPositionEx(  HDC,   LPPOINT);
__declspec(dllimport) int   __stdcall GetDeviceCaps(  HDC,  int);
__declspec(dllimport) int   __stdcall GetDIBits(  HDC,  HBITMAP,  UINT,  UINT,   LPVOID,   LPBITMAPINFO,  UINT);
__declspec(dllimport) DWORD __stdcall GetFontData(  HDC,  DWORD,  DWORD,  LPVOID,  DWORD);
__declspec(dllimport) DWORD __stdcall GetGlyphOutlineA(  HDC,  UINT,  UINT,  LPGLYPHMETRICS,  DWORD,  LPVOID,  const MAT2 *);
__declspec(dllimport) DWORD __stdcall GetGlyphOutlineW(  HDC,  UINT,  UINT,  LPGLYPHMETRICS,  DWORD,  LPVOID,  const MAT2 *);




#line 3020 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) int   __stdcall GetGraphicsMode(  HDC);
__declspec(dllimport) int   __stdcall GetMapMode(  HDC);
__declspec(dllimport) UINT  __stdcall GetMetaFileBitsEx(  HMETAFILE,  UINT,   LPVOID);
__declspec(dllimport) HMETAFILE   __stdcall GetMetaFileA(  LPCSTR);
__declspec(dllimport) HMETAFILE   __stdcall GetMetaFileW(  LPCWSTR);




#line 3030 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) COLORREF __stdcall GetNearestColor(  HDC,  COLORREF);
__declspec(dllimport) UINT  __stdcall GetNearestPaletteIndex(  HPALETTE,  COLORREF);
__declspec(dllimport) DWORD __stdcall GetObjectType(  HGDIOBJ h);



__declspec(dllimport) UINT __stdcall GetOutlineTextMetricsA(  HDC,  UINT,  LPOUTLINETEXTMETRICA);
__declspec(dllimport) UINT __stdcall GetOutlineTextMetricsW(  HDC,  UINT,  LPOUTLINETEXTMETRICW);




#line 3043 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 3045 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) UINT  __stdcall GetPaletteEntries(  HPALETTE,  UINT,  UINT,  LPPALETTEENTRY);
__declspec(dllimport) COLORREF __stdcall GetPixel(  HDC,  int,  int);
__declspec(dllimport) int   __stdcall GetPixelFormat(  HDC);
__declspec(dllimport) int   __stdcall GetPolyFillMode(  HDC);
__declspec(dllimport) BOOL  __stdcall GetRasterizerCaps(  LPRASTERIZER_STATUS,  UINT);
__declspec(dllimport) int   __stdcall GetRandomRgn ( HDC,  HRGN,  INT);
__declspec(dllimport) DWORD __stdcall GetRegionData(  HRGN,  DWORD,   LPRGNDATA);
__declspec(dllimport) int   __stdcall GetRgnBox(  HRGN,   LPRECT);
__declspec(dllimport) HGDIOBJ __stdcall GetStockObject(  int);
__declspec(dllimport) int   __stdcall GetStretchBltMode(  HDC);
__declspec(dllimport) UINT  __stdcall GetSystemPaletteEntries(  HDC,  UINT,  UINT,  LPPALETTEENTRY);
__declspec(dllimport) UINT  __stdcall GetSystemPaletteUse(  HDC);
__declspec(dllimport) int   __stdcall GetTextCharacterExtra(  HDC);
__declspec(dllimport) UINT  __stdcall GetTextAlign(  HDC);
__declspec(dllimport) COLORREF __stdcall GetTextColor(  HDC);

__declspec(dllimport) BOOL  __stdcall GetTextExtentPointA(
                     HDC,
                     LPCSTR,
                     int,
                     LPSIZE
                    );
__declspec(dllimport) BOOL  __stdcall GetTextExtentPointW(
                     HDC,
                     LPCWSTR,
                     int,
                     LPSIZE
                    );




#line 3079 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) BOOL  __stdcall GetTextExtentPoint32A(
                     HDC,
                     LPCSTR,
                     int,
                     LPSIZE
                    );
__declspec(dllimport) BOOL  __stdcall GetTextExtentPoint32W(
                     HDC,
                     LPCWSTR,
                     int,
                     LPSIZE
                    );




#line 3097 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) BOOL  __stdcall GetTextExtentExPointA(
                     HDC,
                     LPCSTR,
                     int,
                     int,
                     LPINT,
                     LPINT,
                     LPSIZE
                    );
__declspec(dllimport) BOOL  __stdcall GetTextExtentExPointW(
                     HDC,
                     LPCWSTR,
                     int,
                     int,
                     LPINT,
                     LPINT,
                     LPSIZE
                    );




#line 3121 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int __stdcall GetTextCharset(  HDC hdc);
__declspec(dllimport) int __stdcall GetTextCharsetInfo(  HDC hdc,  LPFONTSIGNATURE lpSig,  DWORD dwFlags);
__declspec(dllimport) BOOL __stdcall TranslateCharsetInfo(   DWORD  *lpSrc,   LPCHARSETINFO lpCs,  DWORD dwFlags);
__declspec(dllimport) DWORD __stdcall GetFontLanguageInfo(  HDC );
__declspec(dllimport) DWORD __stdcall GetCharacterPlacementA(   HDC,  LPCSTR,  int,  int,   LPGCP_RESULTSA,  DWORD);
__declspec(dllimport) DWORD __stdcall GetCharacterPlacementW(   HDC,  LPCWSTR,  int,  int,   LPGCP_RESULTSW,  DWORD);




#line 3133 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 3134 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
















































































































































































#line 3311 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) BOOL  __stdcall GetViewportExtEx(  HDC,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall GetViewportOrgEx(  HDC,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall GetWindowExtEx(  HDC,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall GetWindowOrgEx(  HDC,  LPPOINT);

__declspec(dllimport) int  __stdcall IntersectClipRect(  HDC,  int,  int,  int,  int);
__declspec(dllimport) BOOL __stdcall InvertRgn(  HDC,  HRGN);
__declspec(dllimport) BOOL __stdcall LineDDA(  int,  int,  int,  int,  LINEDDAPROC,  LPARAM);
__declspec(dllimport) BOOL __stdcall LineTo(  HDC,  int,  int);
__declspec(dllimport) BOOL __stdcall MaskBlt(  HDC,  int,  int,  int,  int,
               HDC,  int,  int,  HBITMAP,  int,  int,  DWORD);
__declspec(dllimport) BOOL __stdcall PlgBlt(  HDC,  const POINT *,  HDC,  int,  int,  int,
                      int,  HBITMAP,  int,  int);

__declspec(dllimport) int  __stdcall OffsetClipRgn( HDC,  int,  int);
__declspec(dllimport) int  __stdcall OffsetRgn( HRGN,  int,  int);
__declspec(dllimport) BOOL __stdcall PatBlt( HDC,  int,  int,  int,  int,  DWORD);
__declspec(dllimport) BOOL __stdcall Pie( HDC,  int,  int,  int,  int,  int,  int,  int,  int);
__declspec(dllimport) BOOL __stdcall PlayMetaFile( HDC,  HMETAFILE);
__declspec(dllimport) BOOL __stdcall PaintRgn( HDC,  HRGN);
__declspec(dllimport) BOOL __stdcall PolyPolygon( HDC,  const POINT *,  const INT *,  int);
__declspec(dllimport) BOOL __stdcall PtInRegion( HRGN,  int,  int);
__declspec(dllimport) BOOL __stdcall PtVisible( HDC,  int,  int);
__declspec(dllimport) BOOL __stdcall RectInRegion( HRGN,  const RECT *);
__declspec(dllimport) BOOL __stdcall RectVisible( HDC,  const RECT *);
__declspec(dllimport) BOOL __stdcall Rectangle( HDC,  int,  int,  int,  int);
__declspec(dllimport) BOOL __stdcall RestoreDC( HDC,  int);
__declspec(dllimport) HDC  __stdcall ResetDCA( HDC,  const DEVMODEA *);
__declspec(dllimport) HDC  __stdcall ResetDCW( HDC,  const DEVMODEW *);




#line 3347 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) UINT __stdcall RealizePalette( HDC);
__declspec(dllimport) BOOL __stdcall RemoveFontResourceA( LPCSTR);
__declspec(dllimport) BOOL __stdcall RemoveFontResourceW( LPCWSTR);




#line 3355 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall RoundRect( HDC,  int,  int,  int,  int,  int,  int);
__declspec(dllimport) BOOL __stdcall ResizePalette( HPALETTE,  UINT);

__declspec(dllimport) int  __stdcall SaveDC( HDC);
__declspec(dllimport) int  __stdcall SelectClipRgn( HDC,  HRGN);
__declspec(dllimport) int  __stdcall ExtSelectClipRgn( HDC,  HRGN,  int);
__declspec(dllimport) int  __stdcall SetMetaRgn( HDC);
__declspec(dllimport) HGDIOBJ __stdcall SelectObject( HDC,  HGDIOBJ);
__declspec(dllimport) HPALETTE __stdcall SelectPalette( HDC,  HPALETTE,  BOOL);
__declspec(dllimport) COLORREF __stdcall SetBkColor( HDC,  COLORREF);




#line 3370 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) int   __stdcall SetBkMode( HDC,  int);
__declspec(dllimport) LONG  __stdcall SetBitmapBits( HBITMAP,  DWORD,  const void *);

__declspec(dllimport) UINT  __stdcall SetBoundsRect( HDC,  const RECT *,  UINT);
__declspec(dllimport) int   __stdcall SetDIBits( HDC,  HBITMAP,  UINT,  UINT,  const void *,  const BITMAPINFO *,  UINT);
__declspec(dllimport) int   __stdcall SetDIBitsToDevice( HDC,  int,  int,  DWORD,  DWORD,  int,
         int,  UINT,  UINT,  const void *,  const BITMAPINFO *,  UINT);
__declspec(dllimport) DWORD __stdcall SetMapperFlags( HDC,  DWORD);
__declspec(dllimport) int   __stdcall SetGraphicsMode( HDC hdc,  int iMode);
__declspec(dllimport) int   __stdcall SetMapMode( HDC,  int);


__declspec(dllimport) DWORD __stdcall SetLayout( HDC,  DWORD);
__declspec(dllimport) DWORD __stdcall GetLayout( HDC);
#line 3387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) HMETAFILE   __stdcall SetMetaFileBitsEx( UINT,  const BYTE *);
__declspec(dllimport) UINT  __stdcall SetPaletteEntries( HPALETTE,  UINT,  UINT,  const PALETTEENTRY *);
__declspec(dllimport) COLORREF __stdcall SetPixel( HDC,  int,  int,  COLORREF);
__declspec(dllimport) BOOL   __stdcall SetPixelV( HDC,  int,  int,  COLORREF);
__declspec(dllimport) BOOL  __stdcall SetPixelFormat( HDC,  int,  const PIXELFORMATDESCRIPTOR *);
__declspec(dllimport) int   __stdcall SetPolyFillMode( HDC,  int);
__declspec(dllimport) BOOL   __stdcall StretchBlt( HDC,  int,  int,  int,  int,  HDC,  int,  int,  int,  int,  DWORD);
__declspec(dllimport) BOOL   __stdcall SetRectRgn( HRGN,  int,  int,  int,  int);
__declspec(dllimport) int   __stdcall StretchDIBits( HDC,  int,  int,  int,  int,  int,  int,  int,  int,  const
        void *,  const BITMAPINFO *,  UINT,  DWORD);
__declspec(dllimport) int   __stdcall SetROP2( HDC,  int);
__declspec(dllimport) int   __stdcall SetStretchBltMode( HDC,  int);
__declspec(dllimport) UINT  __stdcall SetSystemPaletteUse( HDC,  UINT);
__declspec(dllimport) int   __stdcall SetTextCharacterExtra( HDC,  int);
__declspec(dllimport) COLORREF __stdcall SetTextColor( HDC,  COLORREF);
__declspec(dllimport) UINT  __stdcall SetTextAlign( HDC,  UINT);
__declspec(dllimport) BOOL  __stdcall SetTextJustification( HDC,  int,  int);
__declspec(dllimport) BOOL  __stdcall UpdateColors( HDC);








typedef USHORT COLOR16;

typedef struct _TRIVERTEX
{
    LONG    x;
    LONG    y;
    COLOR16 Red;
    COLOR16 Green;
    COLOR16 Blue;
    COLOR16 Alpha;
}TRIVERTEX,*PTRIVERTEX,*LPTRIVERTEX;

typedef struct _GRADIENT_TRIANGLE
{
    ULONG Vertex1;
    ULONG Vertex2;
    ULONG Vertex3;
} GRADIENT_TRIANGLE,*PGRADIENT_TRIANGLE,*LPGRADIENT_TRIANGLE;

typedef struct _GRADIENT_RECT
{
    ULONG UpperLeft;
    ULONG LowerRight;
}GRADIENT_RECT,*PGRADIENT_RECT,*LPGRADIENT_RECT;

typedef struct _BLENDFUNCTION
{
    BYTE   BlendOp;
    BYTE   BlendFlags;
    BYTE   SourceConstantAlpha;
    BYTE   AlphaFormat;
}BLENDFUNCTION,*PBLENDFUNCTION;














__declspec(dllimport) BOOL  __stdcall AlphaBlend(  HDC,  int,  int,  int,  int,  HDC,  int,  int,  int,  int,  BLENDFUNCTION);

__declspec(dllimport) BOOL  __stdcall TransparentBlt( HDC, int, int, int, int, HDC, int, int, int, int, UINT);











__declspec(dllimport) BOOL  __stdcall GradientFill(  HDC,  PTRIVERTEX,  ULONG,  PVOID,  ULONG,  ULONG);

#line 3477 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




__declspec(dllimport) BOOL  __stdcall PlayMetaFileRecord(  HDC,  LPHANDLETABLE,  LPMETARECORD,  UINT);
typedef int (__stdcall* MFENUMPROC)(  HDC,  HANDLETABLE *,  METARECORD *,  int,  LPARAM);
__declspec(dllimport) BOOL  __stdcall EnumMetaFile(   HDC,  HMETAFILE,  MFENUMPROC,  LPARAM);

typedef int (__stdcall* ENHMFENUMPROC)(HDC, HANDLETABLE *, const ENHMETARECORD *, int, LPARAM);



__declspec(dllimport) HENHMETAFILE __stdcall CloseEnhMetaFile(  HDC);
__declspec(dllimport) HENHMETAFILE __stdcall CopyEnhMetaFileA(  HENHMETAFILE,  LPCSTR);
__declspec(dllimport) HENHMETAFILE __stdcall CopyEnhMetaFileW(  HENHMETAFILE,  LPCWSTR);




#line 3497 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HDC   __stdcall CreateEnhMetaFileA(  HDC,  LPCSTR,  const RECT *,  LPCSTR);
__declspec(dllimport) HDC   __stdcall CreateEnhMetaFileW(  HDC,  LPCWSTR,  const RECT *,  LPCWSTR);




#line 3504 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall DeleteEnhMetaFile(  HENHMETAFILE);
__declspec(dllimport) BOOL  __stdcall EnumEnhMetaFile(  HDC,  HENHMETAFILE,  ENHMFENUMPROC,
                                         LPVOID,  const RECT *);
__declspec(dllimport) HENHMETAFILE  __stdcall GetEnhMetaFileA(  LPCSTR);
__declspec(dllimport) HENHMETAFILE  __stdcall GetEnhMetaFileW(  LPCWSTR);




#line 3514 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) UINT  __stdcall GetEnhMetaFileBits(  HENHMETAFILE,  UINT,  LPBYTE);
__declspec(dllimport) UINT  __stdcall GetEnhMetaFileDescriptionA(  HENHMETAFILE,  UINT,   LPSTR );
__declspec(dllimport) UINT  __stdcall GetEnhMetaFileDescriptionW(  HENHMETAFILE,  UINT,   LPWSTR );




#line 3522 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) UINT  __stdcall GetEnhMetaFileHeader(  HENHMETAFILE,  UINT,  LPENHMETAHEADER );
__declspec(dllimport) UINT  __stdcall GetEnhMetaFilePaletteEntries(  HENHMETAFILE,  UINT,  LPPALETTEENTRY );
__declspec(dllimport) UINT  __stdcall GetEnhMetaFilePixelFormat(  HENHMETAFILE,  UINT,
                                                   PIXELFORMATDESCRIPTOR *);
__declspec(dllimport) UINT  __stdcall GetWinMetaFileBits(  HENHMETAFILE,  UINT,  LPBYTE,  INT,  HDC);
__declspec(dllimport) BOOL  __stdcall PlayEnhMetaFile(  HDC,  HENHMETAFILE,  const RECT *);
__declspec(dllimport) BOOL  __stdcall PlayEnhMetaFileRecord(  HDC,  LPHANDLETABLE,  const ENHMETARECORD *,  UINT);
__declspec(dllimport) HENHMETAFILE  __stdcall SetEnhMetaFileBits(  UINT,  const BYTE *);
__declspec(dllimport) HENHMETAFILE  __stdcall SetWinMetaFileBits(  UINT,  const BYTE *,  HDC,  const METAFILEPICT *);
__declspec(dllimport) BOOL  __stdcall GdiComment(  HDC,  UINT,  const BYTE *);

#line 3534 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



__declspec(dllimport) BOOL __stdcall GetTextMetricsA(  HDC,  LPTEXTMETRICA);
__declspec(dllimport) BOOL __stdcall GetTextMetricsW(  HDC,  LPTEXTMETRICW);




#line 3544 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 3546 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagDIBSECTION {
    BITMAP              dsBm;
    BITMAPINFOHEADER    dsBmih;
    DWORD               dsBitfields[3];
    HANDLE              dshSection;
    DWORD               dsOffset;
} DIBSECTION,  *LPDIBSECTION, *PDIBSECTION;

__declspec(dllimport) BOOL __stdcall AngleArc(  HDC,  int,  int,  DWORD,  FLOAT,  FLOAT);
__declspec(dllimport) BOOL __stdcall PolyPolyline(  HDC,  const POINT *,  const DWORD *,  DWORD);
__declspec(dllimport) BOOL __stdcall GetWorldTransform(  HDC,  LPXFORM);
__declspec(dllimport) BOOL __stdcall SetWorldTransform(  HDC,  const XFORM *);
__declspec(dllimport) BOOL __stdcall ModifyWorldTransform(  HDC,  const XFORM *,  DWORD);
__declspec(dllimport) BOOL __stdcall CombineTransform(  LPXFORM,  const XFORM *,  const XFORM *);
__declspec(dllimport) HBITMAP __stdcall CreateDIBSection(  HDC,  const BITMAPINFO *,  UINT,  void **,  HANDLE,  DWORD);
__declspec(dllimport) UINT __stdcall GetDIBColorTable(  HDC,  UINT,  UINT,  RGBQUAD *);
__declspec(dllimport) UINT __stdcall SetDIBColorTable(  HDC,  UINT,  UINT,  const RGBQUAD *);




































typedef struct  tagCOLORADJUSTMENT {
    WORD   caSize;
    WORD   caFlags;
    WORD   caIlluminantIndex;
    WORD   caRedGamma;
    WORD   caGreenGamma;
    WORD   caBlueGamma;
    WORD   caReferenceBlack;
    WORD   caReferenceWhite;
    SHORT  caContrast;
    SHORT  caBrightness;
    SHORT  caColorfulness;
    SHORT  caRedGreenTint;
} COLORADJUSTMENT, *PCOLORADJUSTMENT,  *LPCOLORADJUSTMENT;

__declspec(dllimport) BOOL __stdcall SetColorAdjustment(  HDC,  const COLORADJUSTMENT *);
__declspec(dllimport) BOOL __stdcall GetColorAdjustment(  HDC,  LPCOLORADJUSTMENT);
__declspec(dllimport) HPALETTE __stdcall CreateHalftonePalette(  HDC);


typedef BOOL (__stdcall* ABORTPROC)(  HDC,  int);


#line 3626 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

typedef struct _DOCINFOA {
    int     cbSize;
    LPCSTR   lpszDocName;
    LPCSTR   lpszOutput;

    LPCSTR   lpszDatatype;
    DWORD    fwType;
#line 3635 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
} DOCINFOA, *LPDOCINFOA;
typedef struct _DOCINFOW {
    int     cbSize;
    LPCWSTR  lpszDocName;
    LPCWSTR  lpszOutput;

    LPCWSTR  lpszDatatype;
    DWORD    fwType;
#line 3644 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
} DOCINFOW, *LPDOCINFOW;




typedef DOCINFOA DOCINFO;
typedef LPDOCINFOA LPDOCINFO;
#line 3652 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




#line 3657 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int __stdcall StartDocA( HDC,  const DOCINFOA *);
__declspec(dllimport) int __stdcall StartDocW( HDC,  const DOCINFOW *);




#line 3665 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) int __stdcall EndDoc( HDC);
__declspec(dllimport) int __stdcall StartPage( HDC);
__declspec(dllimport) int __stdcall EndPage( HDC);
__declspec(dllimport) int __stdcall AbortDoc( HDC);
__declspec(dllimport) int __stdcall SetAbortProc( HDC,  ABORTPROC);

__declspec(dllimport) BOOL __stdcall AbortPath( HDC);
__declspec(dllimport) BOOL __stdcall ArcTo( HDC,  int,  int,  int,  int,  int,  int,  int,  int);
__declspec(dllimport) BOOL __stdcall BeginPath( HDC);
__declspec(dllimport) BOOL __stdcall CloseFigure( HDC);
__declspec(dllimport) BOOL __stdcall EndPath( HDC);
__declspec(dllimport) BOOL __stdcall FillPath( HDC);
__declspec(dllimport) BOOL __stdcall FlattenPath( HDC);
__declspec(dllimport) int  __stdcall GetPath( HDC,  LPPOINT,  LPBYTE,  int);
__declspec(dllimport) HRGN __stdcall PathToRegion( HDC);
__declspec(dllimport) BOOL __stdcall PolyDraw( HDC,  const POINT *,  const BYTE *,  int);
__declspec(dllimport) BOOL __stdcall SelectClipPath( HDC,  int);
__declspec(dllimport) int  __stdcall SetArcDirection( HDC,  int);
__declspec(dllimport) BOOL __stdcall SetMiterLimit( HDC,  FLOAT,  PFLOAT);
__declspec(dllimport) BOOL __stdcall StrokeAndFillPath( HDC);
__declspec(dllimport) BOOL __stdcall StrokePath( HDC);
__declspec(dllimport) BOOL __stdcall WidenPath( HDC);
__declspec(dllimport) HPEN __stdcall ExtCreatePen( DWORD,  DWORD,  const LOGBRUSH *,  DWORD,  const DWORD *);
__declspec(dllimport) BOOL __stdcall GetMiterLimit( HDC,  PFLOAT);
__declspec(dllimport) int  __stdcall GetArcDirection( HDC);

__declspec(dllimport) int   __stdcall GetObjectA(  HGDIOBJ,  int,  LPVOID);
__declspec(dllimport) int   __stdcall GetObjectW(  HGDIOBJ,  int,  LPVOID);




#line 3698 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall MoveToEx(  HDC,  int,  int,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall TextOutA(  HDC,  int,  int,  LPCSTR,  int);
__declspec(dllimport) BOOL  __stdcall TextOutW(  HDC,  int,  int,  LPCWSTR,  int);




#line 3706 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall ExtTextOutA(  HDC,  int,  int,  UINT,  const RECT *,  LPCSTR,  UINT,  const INT *);
__declspec(dllimport) BOOL  __stdcall ExtTextOutW(  HDC,  int,  int,  UINT,  const RECT *,  LPCWSTR,  UINT,  const INT *);




#line 3713 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall PolyTextOutA(  HDC,  const POLYTEXTA *,  int);
__declspec(dllimport) BOOL  __stdcall PolyTextOutW(  HDC,  const POLYTEXTW *,  int);




#line 3720 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) HRGN  __stdcall CreatePolygonRgn(  const POINT *,  int,  int);
__declspec(dllimport) BOOL  __stdcall DPtoLP(  HDC,   LPPOINT,  int);
__declspec(dllimport) BOOL  __stdcall LPtoDP(  HDC,   LPPOINT,  int);
__declspec(dllimport) BOOL  __stdcall Polygon(  HDC,  const POINT *,  int);
__declspec(dllimport) BOOL  __stdcall Polyline(  HDC,  const POINT *,  int);

__declspec(dllimport) BOOL  __stdcall PolyBezier(  HDC,  const POINT *,  DWORD);
__declspec(dllimport) BOOL  __stdcall PolyBezierTo(  HDC,  const POINT *,  DWORD);
__declspec(dllimport) BOOL  __stdcall PolylineTo(  HDC,  const POINT *,  DWORD);

__declspec(dllimport) BOOL  __stdcall SetViewportExtEx(  HDC,  int,  int,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall SetViewportOrgEx(  HDC,  int,  int,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall SetWindowExtEx(  HDC,  int,  int,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall SetWindowOrgEx(  HDC,  int,  int,  LPPOINT);

__declspec(dllimport) BOOL  __stdcall OffsetViewportOrgEx(  HDC,  int,  int,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall OffsetWindowOrgEx(  HDC,  int,  int,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall ScaleViewportExtEx(  HDC,  int,  int,  int,  int,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall ScaleWindowExtEx(  HDC,  int,  int,  int,  int,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall SetBitmapDimensionEx(  HBITMAP,  int,  int,  LPSIZE);
__declspec(dllimport) BOOL  __stdcall SetBrushOrgEx(  HDC,  int,  int,  LPPOINT);

__declspec(dllimport) int   __stdcall GetTextFaceA(  HDC,  int,  LPSTR);
__declspec(dllimport) int   __stdcall GetTextFaceW(  HDC,  int,  LPWSTR);




#line 3750 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagKERNINGPAIR {
   WORD wFirst;
   WORD wSecond;
   int  iKernAmount;
} KERNINGPAIR, *LPKERNINGPAIR;

__declspec(dllimport) DWORD __stdcall GetKerningPairsA(  HDC,  DWORD,  LPKERNINGPAIR);
__declspec(dllimport) DWORD __stdcall GetKerningPairsW(  HDC,  DWORD,  LPKERNINGPAIR);




#line 3766 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) BOOL  __stdcall GetDCOrgEx(  HDC,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall FixBrushOrgEx(  HDC,  int,  int,  LPPOINT);
__declspec(dllimport) BOOL  __stdcall UnrealizeObject(  HGDIOBJ);

__declspec(dllimport) BOOL  __stdcall GdiFlush();
__declspec(dllimport) DWORD __stdcall GdiSetBatchLimit(  DWORD);
__declspec(dllimport) DWORD __stdcall GdiGetBatchLimit();









typedef int (__stdcall* ICMENUMPROCA)(LPSTR, LPARAM);
typedef int (__stdcall* ICMENUMPROCW)(LPWSTR, LPARAM);




#line 3790 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

__declspec(dllimport) int         __stdcall SetICMMode(  HDC,  int);
__declspec(dllimport) BOOL        __stdcall CheckColorsInGamut(  HDC,  LPVOID,  LPVOID,  DWORD);
__declspec(dllimport) HCOLORSPACE __stdcall GetColorSpace(  HDC);
__declspec(dllimport) BOOL        __stdcall GetLogColorSpaceA(  HCOLORSPACE,  LPLOGCOLORSPACEA,  DWORD);
__declspec(dllimport) BOOL        __stdcall GetLogColorSpaceW(  HCOLORSPACE,  LPLOGCOLORSPACEW,  DWORD);




#line 3801 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HCOLORSPACE __stdcall CreateColorSpaceA(  LPLOGCOLORSPACEA);
__declspec(dllimport) HCOLORSPACE __stdcall CreateColorSpaceW(  LPLOGCOLORSPACEW);




#line 3808 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) HCOLORSPACE __stdcall SetColorSpace(  HDC,  HCOLORSPACE);
__declspec(dllimport) BOOL        __stdcall DeleteColorSpace(  HCOLORSPACE);
__declspec(dllimport) BOOL        __stdcall GetICMProfileA(  HDC,   LPDWORD,  LPSTR);
__declspec(dllimport) BOOL        __stdcall GetICMProfileW(  HDC,   LPDWORD,  LPWSTR);




#line 3817 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL        __stdcall SetICMProfileA(  HDC,  LPSTR);
__declspec(dllimport) BOOL        __stdcall SetICMProfileW(  HDC,  LPWSTR);




#line 3824 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL        __stdcall GetDeviceGammaRamp(  HDC,  LPVOID);
__declspec(dllimport) BOOL        __stdcall SetDeviceGammaRamp(  HDC,  LPVOID);
__declspec(dllimport) BOOL        __stdcall ColorMatchToTarget(  HDC,  HDC,  DWORD);
__declspec(dllimport) int         __stdcall EnumICMProfilesA(  HDC,  ICMENUMPROCA,  LPARAM);
__declspec(dllimport) int         __stdcall EnumICMProfilesW(  HDC,  ICMENUMPROCW,  LPARAM);




#line 3834 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL        __stdcall UpdateICMRegKeyA(  DWORD,  LPSTR,  LPSTR,  UINT);
__declspec(dllimport) BOOL        __stdcall UpdateICMRegKeyW(  DWORD,  LPWSTR,  LPWSTR,  UINT);




#line 3841 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
#line 3842 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


__declspec(dllimport) BOOL        __stdcall ColorCorrectPalette(  HDC,  HPALETTE,  DWORD,  DWORD);
#line 3846 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"









#line 3856 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




















































































































#line 3973 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




















#line 3994 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"









#line 4004 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagEMR
{
    DWORD   iType;              
    DWORD   nSize;              
                                
} EMR, *PEMR;



typedef struct tagEMRTEXT
{
    POINTL  ptlReference;
    DWORD   nChars;
    DWORD   offString;          
    DWORD   fOptions;
    RECTL   rcl;
    DWORD   offDx;              
                                
} EMRTEXT, *PEMRTEXT;



typedef struct tagABORTPATH
{
    EMR     emr;
} EMRABORTPATH,      *PEMRABORTPATH,
  EMRBEGINPATH,      *PEMRBEGINPATH,
  EMRENDPATH,        *PEMRENDPATH,
  EMRCLOSEFIGURE,    *PEMRCLOSEFIGURE,
  EMRFLATTENPATH,    *PEMRFLATTENPATH,
  EMRWIDENPATH,      *PEMRWIDENPATH,
  EMRSETMETARGN,     *PEMRSETMETARGN,
  EMRSAVEDC,         *PEMRSAVEDC,
  EMRREALIZEPALETTE, *PEMRREALIZEPALETTE;

typedef struct tagEMRSELECTCLIPPATH
{
    EMR     emr;
    DWORD   iMode;
} EMRSELECTCLIPPATH,    *PEMRSELECTCLIPPATH,
  EMRSETBKMODE,         *PEMRSETBKMODE,
  EMRSETMAPMODE,        *PEMRSETMAPMODE,

  EMRSETLAYOUT,         *PEMRSETLAYOUT,
#line 4052 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
  EMRSETPOLYFILLMODE,   *PEMRSETPOLYFILLMODE,
  EMRSETROP2,           *PEMRSETROP2,
  EMRSETSTRETCHBLTMODE, *PEMRSETSTRETCHBLTMODE,
  EMRSETICMMODE,        *PEMRSETICMMODE,
  EMRSETTEXTALIGN,      *PEMRSETTEXTALIGN;

typedef struct tagEMRSETMITERLIMIT
{
    EMR     emr;
    FLOAT   eMiterLimit;
} EMRSETMITERLIMIT, *PEMRSETMITERLIMIT;

typedef struct tagEMRRESTOREDC
{
    EMR     emr;
    LONG    iRelative;          
} EMRRESTOREDC, *PEMRRESTOREDC;

typedef struct tagEMRSETARCDIRECTION
{
    EMR     emr;
    DWORD   iArcDirection;      
                                
} EMRSETARCDIRECTION, *PEMRSETARCDIRECTION;

typedef struct tagEMRSETMAPPERFLAGS
{
    EMR     emr;
    DWORD   dwFlags;
} EMRSETMAPPERFLAGS, *PEMRSETMAPPERFLAGS;

typedef struct tagEMRSETTEXTCOLOR
{
    EMR     emr;
    COLORREF crColor;
} EMRSETBKCOLOR,   *PEMRSETBKCOLOR,
  EMRSETTEXTCOLOR, *PEMRSETTEXTCOLOR;

typedef struct tagEMRSELECTOBJECT
{
    EMR     emr;
    DWORD   ihObject;           
} EMRSELECTOBJECT, *PEMRSELECTOBJECT,
  EMRDELETEOBJECT, *PEMRDELETEOBJECT;

typedef struct tagEMRSELECTPALETTE
{
    EMR     emr;
    DWORD   ihPal;              
} EMRSELECTPALETTE, *PEMRSELECTPALETTE;

typedef struct tagEMRRESIZEPALETTE
{
    EMR     emr;
    DWORD   ihPal;              
    DWORD   cEntries;
} EMRRESIZEPALETTE, *PEMRRESIZEPALETTE;

typedef struct tagEMRSETPALETTEENTRIES
{
    EMR     emr;
    DWORD   ihPal;              
    DWORD   iStart;
    DWORD   cEntries;
    PALETTEENTRY aPalEntries[1];
} EMRSETPALETTEENTRIES, *PEMRSETPALETTEENTRIES;

typedef struct tagEMRSETCOLORADJUSTMENT
{
    EMR     emr;
    COLORADJUSTMENT ColorAdjustment;
} EMRSETCOLORADJUSTMENT, *PEMRSETCOLORADJUSTMENT;

typedef struct tagEMRGDICOMMENT
{
    EMR     emr;
    DWORD   cbData;             
    BYTE    Data[1];
} EMRGDICOMMENT, *PEMRGDICOMMENT;

typedef struct tagEMREOF
{
    EMR     emr;
    DWORD   nPalEntries;        
    DWORD   offPalEntries;      
    DWORD   nSizeLast;          
                                
                                
} EMREOF, *PEMREOF;

typedef struct tagEMRLINETO
{
    EMR     emr;
    POINTL  ptl;
} EMRLINETO,   *PEMRLINETO,
  EMRMOVETOEX, *PEMRMOVETOEX;

typedef struct tagEMROFFSETCLIPRGN
{
    EMR     emr;
    POINTL  ptlOffset;
} EMROFFSETCLIPRGN, *PEMROFFSETCLIPRGN;

typedef struct tagEMRFILLPATH
{
    EMR     emr;
    RECTL   rclBounds;          
} EMRFILLPATH,          *PEMRFILLPATH,
  EMRSTROKEANDFILLPATH, *PEMRSTROKEANDFILLPATH,
  EMRSTROKEPATH,        *PEMRSTROKEPATH;

typedef struct tagEMREXCLUDECLIPRECT
{
    EMR     emr;
    RECTL   rclClip;
} EMREXCLUDECLIPRECT,   *PEMREXCLUDECLIPRECT,
  EMRINTERSECTCLIPRECT, *PEMRINTERSECTCLIPRECT;

typedef struct tagEMRSETVIEWPORTORGEX
{
    EMR     emr;
    POINTL  ptlOrigin;
} EMRSETVIEWPORTORGEX, *PEMRSETVIEWPORTORGEX,
  EMRSETWINDOWORGEX,   *PEMRSETWINDOWORGEX,
  EMRSETBRUSHORGEX,    *PEMRSETBRUSHORGEX;

typedef struct tagEMRSETVIEWPORTEXTEX
{
    EMR     emr;
    SIZEL   szlExtent;
} EMRSETVIEWPORTEXTEX, *PEMRSETVIEWPORTEXTEX,
  EMRSETWINDOWEXTEX,   *PEMRSETWINDOWEXTEX;

typedef struct tagEMRSCALEVIEWPORTEXTEX
{
    EMR     emr;
    LONG    xNum;
    LONG    xDenom;
    LONG    yNum;
    LONG    yDenom;
} EMRSCALEVIEWPORTEXTEX, *PEMRSCALEVIEWPORTEXTEX,
  EMRSCALEWINDOWEXTEX,   *PEMRSCALEWINDOWEXTEX;

typedef struct tagEMRSETWORLDTRANSFORM
{
    EMR     emr;
    XFORM   xform;
} EMRSETWORLDTRANSFORM, *PEMRSETWORLDTRANSFORM;

typedef struct tagEMRMODIFYWORLDTRANSFORM
{
    EMR     emr;
    XFORM   xform;
    DWORD   iMode;
} EMRMODIFYWORLDTRANSFORM, *PEMRMODIFYWORLDTRANSFORM;

typedef struct tagEMRSETPIXELV
{
    EMR     emr;
    POINTL  ptlPixel;
    COLORREF crColor;
} EMRSETPIXELV, *PEMRSETPIXELV;

typedef struct tagEMREXTFLOODFILL
{
    EMR     emr;
    POINTL  ptlStart;
    COLORREF crColor;
    DWORD   iMode;
} EMREXTFLOODFILL, *PEMREXTFLOODFILL;

typedef struct tagEMRELLIPSE
{
    EMR     emr;
    RECTL   rclBox;             
} EMRELLIPSE,  *PEMRELLIPSE,
  EMRRECTANGLE, *PEMRRECTANGLE;


typedef struct tagEMRROUNDRECT
{
    EMR     emr;
    RECTL   rclBox;             
    SIZEL   szlCorner;
} EMRROUNDRECT, *PEMRROUNDRECT;

typedef struct tagEMRARC
{
    EMR     emr;
    RECTL   rclBox;             
    POINTL  ptlStart;
    POINTL  ptlEnd;
} EMRARC,   *PEMRARC,
  EMRARCTO, *PEMRARCTO,
  EMRCHORD, *PEMRCHORD,
  EMRPIE,   *PEMRPIE;

typedef struct tagEMRANGLEARC
{
    EMR     emr;
    POINTL  ptlCenter;
    DWORD   nRadius;
    FLOAT   eStartAngle;
    FLOAT   eSweepAngle;
} EMRANGLEARC, *PEMRANGLEARC;

typedef struct tagEMRPOLYLINE
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cptl;
    POINTL  aptl[1];
} EMRPOLYLINE,     *PEMRPOLYLINE,
  EMRPOLYBEZIER,   *PEMRPOLYBEZIER,
  EMRPOLYGON,      *PEMRPOLYGON,
  EMRPOLYBEZIERTO, *PEMRPOLYBEZIERTO,
  EMRPOLYLINETO,   *PEMRPOLYLINETO;

typedef struct tagEMRPOLYLINE16
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cpts;
    POINTS  apts[1];
} EMRPOLYLINE16,     *PEMRPOLYLINE16,
  EMRPOLYBEZIER16,   *PEMRPOLYBEZIER16,
  EMRPOLYGON16,      *PEMRPOLYGON16,
  EMRPOLYBEZIERTO16, *PEMRPOLYBEZIERTO16,
  EMRPOLYLINETO16,   *PEMRPOLYLINETO16;

typedef struct tagEMRPOLYDRAW
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cptl;               
    POINTL  aptl[1];            
    BYTE    abTypes[1];         
} EMRPOLYDRAW, *PEMRPOLYDRAW;

typedef struct tagEMRPOLYDRAW16
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cpts;               
    POINTS  apts[1];            
    BYTE    abTypes[1];         
} EMRPOLYDRAW16, *PEMRPOLYDRAW16;

typedef struct tagEMRPOLYPOLYLINE
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   nPolys;             
    DWORD   cptl;               
    DWORD   aPolyCounts[1];     
    POINTL  aptl[1];            
} EMRPOLYPOLYLINE, *PEMRPOLYPOLYLINE,
  EMRPOLYPOLYGON,  *PEMRPOLYPOLYGON;

typedef struct tagEMRPOLYPOLYLINE16
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   nPolys;             
    DWORD   cpts;               
    DWORD   aPolyCounts[1];     
    POINTS  apts[1];            
} EMRPOLYPOLYLINE16, *PEMRPOLYPOLYLINE16,
  EMRPOLYPOLYGON16,  *PEMRPOLYPOLYGON16;

typedef struct tagEMRINVERTRGN
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cbRgnData;          
    BYTE    RgnData[1];
} EMRINVERTRGN, *PEMRINVERTRGN,
  EMRPAINTRGN,  *PEMRPAINTRGN;

typedef struct tagEMRFILLRGN
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cbRgnData;          
    DWORD   ihBrush;            
    BYTE    RgnData[1];
} EMRFILLRGN, *PEMRFILLRGN;

typedef struct tagEMRFRAMERGN
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cbRgnData;          
    DWORD   ihBrush;            
    SIZEL   szlStroke;
    BYTE    RgnData[1];
} EMRFRAMERGN, *PEMRFRAMERGN;

typedef struct tagEMREXTSELECTCLIPRGN
{
    EMR     emr;
    DWORD   cbRgnData;          
    DWORD   iMode;
    BYTE    RgnData[1];
} EMREXTSELECTCLIPRGN, *PEMREXTSELECTCLIPRGN;

typedef struct tagEMREXTTEXTOUTA
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   iGraphicsMode;      
    FLOAT   exScale;            
    FLOAT   eyScale;            
    EMRTEXT emrtext;            
                                
} EMREXTTEXTOUTA, *PEMREXTTEXTOUTA,
  EMREXTTEXTOUTW, *PEMREXTTEXTOUTW;

typedef struct tagEMRPOLYTEXTOUTA
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   iGraphicsMode;      
    FLOAT   exScale;            
    FLOAT   eyScale;            
    LONG    cStrings;
    EMRTEXT aemrtext[1];        
                                
} EMRPOLYTEXTOUTA, *PEMRPOLYTEXTOUTA,
  EMRPOLYTEXTOUTW, *PEMRPOLYTEXTOUTW;

typedef struct tagEMRBITBLT
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    cxDest;
    LONG    cyDest;
    DWORD   dwRop;
    LONG    xSrc;
    LONG    ySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
} EMRBITBLT, *PEMRBITBLT;

typedef struct tagEMRSTRETCHBLT
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    cxDest;
    LONG    cyDest;
    DWORD   dwRop;
    LONG    xSrc;
    LONG    ySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    LONG    cxSrc;
    LONG    cySrc;
} EMRSTRETCHBLT, *PEMRSTRETCHBLT;

typedef struct tagEMRMASKBLT
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    cxDest;
    LONG    cyDest;
    DWORD   dwRop;
    LONG    xSrc;
    LONG    ySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    LONG    xMask;
    LONG    yMask;
    DWORD   iUsageMask;         
    DWORD   offBmiMask;         
    DWORD   cbBmiMask;          
    DWORD   offBitsMask;        
    DWORD   cbBitsMask;         
} EMRMASKBLT, *PEMRMASKBLT;

typedef struct tagEMRPLGBLT
{
    EMR     emr;
    RECTL   rclBounds;          
    POINTL  aptlDest[3];
    LONG    xSrc;
    LONG    ySrc;
    LONG    cxSrc;
    LONG    cySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    LONG    xMask;
    LONG    yMask;
    DWORD   iUsageMask;         
    DWORD   offBmiMask;         
    DWORD   cbBmiMask;          
    DWORD   offBitsMask;        
    DWORD   cbBitsMask;         
} EMRPLGBLT, *PEMRPLGBLT;

typedef struct tagEMRSETDIBITSTODEVICE
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    xSrc;
    LONG    ySrc;
    LONG    cxSrc;
    LONG    cySrc;
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    DWORD   iUsageSrc;          
    DWORD   iStartScan;
    DWORD   cScans;
} EMRSETDIBITSTODEVICE, *PEMRSETDIBITSTODEVICE;

typedef struct tagEMRSTRETCHDIBITS
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    xSrc;
    LONG    ySrc;
    LONG    cxSrc;
    LONG    cySrc;
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    DWORD   iUsageSrc;          
    DWORD   dwRop;
    LONG    cxDest;
    LONG    cyDest;
} EMRSTRETCHDIBITS, *PEMRSTRETCHDIBITS;

typedef struct tagEMREXTCREATEFONTINDIRECTW
{
    EMR     emr;
    DWORD   ihFont;             
    EXTLOGFONTW elfw;
} EMREXTCREATEFONTINDIRECTW, *PEMREXTCREATEFONTINDIRECTW;

typedef struct tagEMRCREATEPALETTE
{
    EMR     emr;
    DWORD   ihPal;              
    LOGPALETTE lgpl;            
                                
} EMRCREATEPALETTE, *PEMRCREATEPALETTE;

typedef struct tagEMRCREATEPEN
{
    EMR     emr;
    DWORD   ihPen;              
    LOGPEN  lopn;
} EMRCREATEPEN, *PEMRCREATEPEN;

typedef struct tagEMREXTCREATEPEN
{
    EMR     emr;
    DWORD   ihPen;              
    DWORD   offBmi;             
    DWORD   cbBmi;              
                                
                                
    DWORD   offBits;            
    DWORD   cbBits;             
    EXTLOGPEN elp;              
} EMREXTCREATEPEN, *PEMREXTCREATEPEN;

typedef struct tagEMRCREATEBRUSHINDIRECT
{
    EMR        emr;
    DWORD      ihBrush;          
    LOGBRUSH32 lb;               
                                 
} EMRCREATEBRUSHINDIRECT, *PEMRCREATEBRUSHINDIRECT;

typedef struct tagEMRCREATEMONOBRUSH
{
    EMR     emr;
    DWORD   ihBrush;            
    DWORD   iUsage;             
    DWORD   offBmi;             
    DWORD   cbBmi;              
    DWORD   offBits;            
    DWORD   cbBits;             
} EMRCREATEMONOBRUSH, *PEMRCREATEMONOBRUSH;

typedef struct tagEMRCREATEDIBPATTERNBRUSHPT
{
    EMR     emr;
    DWORD   ihBrush;            
    DWORD   iUsage;             
    DWORD   offBmi;             
    DWORD   cbBmi;              
                                
                                
    DWORD   offBits;            
    DWORD   cbBits;             
} EMRCREATEDIBPATTERNBRUSHPT, *PEMRCREATEDIBPATTERNBRUSHPT;

typedef struct tagEMRFORMAT
{
    DWORD   dSignature;         
    DWORD   nVersion;           
    DWORD   cbData;             
    DWORD   offData;            
                                
} EMRFORMAT, *PEMRFORMAT;



typedef struct tagEMRGLSRECORD
{
    EMR     emr;
    DWORD   cbData;             
    BYTE    Data[1];
} EMRGLSRECORD, *PEMRGLSRECORD;

typedef struct tagEMRGLSBOUNDEDRECORD
{
    EMR     emr;
    RECTL   rclBounds;          
    DWORD   cbData;             
    BYTE    Data[1];
} EMRGLSBOUNDEDRECORD, *PEMRGLSBOUNDEDRECORD;

typedef struct tagEMRPIXELFORMAT
{
    EMR     emr;
    PIXELFORMATDESCRIPTOR pfd;
} EMRPIXELFORMAT, *PEMRPIXELFORMAT;

typedef struct tagEMRCREATECOLORSPACE
{
    EMR             emr;
    DWORD           ihCS;       
    LOGCOLORSPACEA  lcs;        
} EMRCREATECOLORSPACE, *PEMRCREATECOLORSPACE;

typedef struct tagEMRSETCOLORSPACE
{
    EMR     emr;
    DWORD   ihCS;               
} EMRSETCOLORSPACE,    *PEMRSETCOLORSPACE,
  EMRSELECTCOLORSPACE, *PEMRSELECTCOLORSPACE,
  EMRDELETECOLORSPACE, *PEMRDELETECOLORSPACE;

#line 4635 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"



typedef struct tagEMREXTESCAPE
{
    EMR     emr;
    INT     iEscape;            
    INT     cbEscData;          
    BYTE    EscData[1];         
} EMREXTESCAPE,  *PEMREXTESCAPE,
  EMRDRAWESCAPE, *PEMRDRAWESCAPE;

typedef struct tagEMRNAMEDESCAPE
{
    EMR     emr;
    INT     iEscape;            
    INT     cbDriver;           
    INT     cbEscData;          
    BYTE    EscData[1];         
} EMRNAMEDESCAPE, *PEMRNAMEDESCAPE;



typedef struct tagEMRSETICMPROFILE
{
    EMR     emr;
    DWORD   dwFlags;            
    DWORD   cbName;             
    DWORD   cbData;             
    BYTE    Data[1];            
} EMRSETICMPROFILE,  *PEMRSETICMPROFILE,
  EMRSETICMPROFILEA, *PEMRSETICMPROFILEA,
  EMRSETICMPROFILEW, *PEMRSETICMPROFILEW;



typedef struct tagEMRCREATECOLORSPACEW
{
    EMR             emr;
    DWORD           ihCS;       
    LOGCOLORSPACEW  lcs;        
    DWORD           dwFlags;    
    DWORD           cbData;     
    BYTE            Data[1];    
} EMRCREATECOLORSPACEW, *PEMRCREATECOLORSPACEW;



typedef struct tagCOLORMATCHTOTARGET
{
    EMR     emr;
    DWORD   dwAction;           
    DWORD   dwFlags;            
    DWORD   cbName;             
    DWORD   cbData;             
    BYTE    Data[1];            
} EMRCOLORMATCHTOTARGET, *PEMRCOLORMATCHTOTARGET;

typedef struct tagCOLORCORRECTPALETTE
{
    EMR     emr;
    DWORD   ihPalette;          
    DWORD   nFirstEntry;        
    DWORD   nPalEntries;        
    DWORD   nReserved;          
} EMRCOLORCORRECTPALETTE, *PEMRCOLORCORRECTPALETTE;

typedef struct tagEMRALPHABLEND
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    cxDest;
    LONG    cyDest;
    DWORD   dwRop;
    LONG    xSrc;
    LONG    ySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    LONG    cxSrc;
    LONG    cySrc;
} EMRALPHABLEND, *PEMRALPHABLEND;

typedef struct tagEMRGRADIENTFILL
{
    EMR       emr;
    RECTL     rclBounds;          
    DWORD     nVer;
    DWORD     nTri;
    ULONG     ulMode;
    TRIVERTEX Ver[1];
}EMRGRADIENTFILL,*PEMRGRADIENTFILL;

typedef struct tagEMRTRANSPARENTBLT
{
    EMR     emr;
    RECTL   rclBounds;          
    LONG    xDest;
    LONG    yDest;
    LONG    cxDest;
    LONG    cyDest;
    DWORD   dwRop;
    LONG    xSrc;
    LONG    ySrc;
    XFORM   xformSrc;           
    COLORREF crBkColorSrc;      
    DWORD   iUsageSrc;          
                                
    DWORD   offBmiSrc;          
    DWORD   cbBmiSrc;           
    DWORD   offBitsSrc;         
    DWORD   cbBitsSrc;          
    LONG    cxSrc;
    LONG    cySrc;
} EMRTRANSPARENTBLT, *PEMRTRANSPARENTBLT;


#line 4760 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"










#line 4771 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"




__declspec(dllimport) BOOL  __stdcall wglCopyContext(HGLRC, HGLRC, UINT);
__declspec(dllimport) HGLRC __stdcall wglCreateContext(HDC);
__declspec(dllimport) HGLRC __stdcall wglCreateLayerContext(HDC, int);
__declspec(dllimport) BOOL  __stdcall wglDeleteContext(HGLRC);
__declspec(dllimport) HGLRC __stdcall wglGetCurrentContext(void);
__declspec(dllimport) HDC   __stdcall wglGetCurrentDC(void);
__declspec(dllimport) PROC  __stdcall wglGetProcAddress(LPCSTR);
__declspec(dllimport) BOOL  __stdcall wglMakeCurrent(HDC, HGLRC);
__declspec(dllimport) BOOL  __stdcall wglShareLists(HGLRC, HGLRC);
__declspec(dllimport) BOOL  __stdcall wglUseFontBitmapsA(HDC, DWORD, DWORD, DWORD);
__declspec(dllimport) BOOL  __stdcall wglUseFontBitmapsW(HDC, DWORD, DWORD, DWORD);




#line 4791 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"
__declspec(dllimport) BOOL  __stdcall SwapBuffers(HDC);

typedef struct _POINTFLOAT {
    FLOAT   x;
    FLOAT   y;
} POINTFLOAT, *PPOINTFLOAT;

typedef struct _GLYPHMETRICSFLOAT {
    FLOAT       gmfBlackBoxX;
    FLOAT       gmfBlackBoxY;
    POINTFLOAT  gmfptGlyphOrigin;
    FLOAT       gmfCellIncX;
    FLOAT       gmfCellIncY;
} GLYPHMETRICSFLOAT, *PGLYPHMETRICSFLOAT,  *LPGLYPHMETRICSFLOAT;



__declspec(dllimport) BOOL  __stdcall wglUseFontOutlinesA(HDC, DWORD, DWORD, DWORD, FLOAT,
                                           FLOAT, int, LPGLYPHMETRICSFLOAT);
__declspec(dllimport) BOOL  __stdcall wglUseFontOutlinesW(HDC, DWORD, DWORD, DWORD, FLOAT,
                                           FLOAT, int, LPGLYPHMETRICSFLOAT);




#line 4817 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


typedef struct tagLAYERPLANEDESCRIPTOR { 
    WORD  nSize;
    WORD  nVersion;
    DWORD dwFlags;
    BYTE  iPixelType;
    BYTE  cColorBits;
    BYTE  cRedBits;
    BYTE  cRedShift;
    BYTE  cGreenBits;
    BYTE  cGreenShift;
    BYTE  cBlueBits;
    BYTE  cBlueShift;
    BYTE  cAlphaBits;
    BYTE  cAlphaShift;
    BYTE  cAccumBits;
    BYTE  cAccumRedBits;
    BYTE  cAccumGreenBits;
    BYTE  cAccumBlueBits;
    BYTE  cAccumAlphaBits;
    BYTE  cDepthBits;
    BYTE  cStencilBits;
    BYTE  cAuxBuffers;
    BYTE  iLayerPlane;
    BYTE  bReserved;
    COLORREF crTransparent;
} LAYERPLANEDESCRIPTOR, *PLAYERPLANEDESCRIPTOR,  *LPLAYERPLANEDESCRIPTOR;

















































__declspec(dllimport) BOOL  __stdcall wglDescribeLayerPlane(HDC, int, int, UINT,
                                             LPLAYERPLANEDESCRIPTOR);
__declspec(dllimport) int   __stdcall wglSetLayerPaletteEntries(HDC, int, int, int,
                                                 const COLORREF *);
__declspec(dllimport) int   __stdcall wglGetLayerPaletteEntries(HDC, int, int, int,
                                                 COLORREF *);
__declspec(dllimport) BOOL  __stdcall wglRealizeLayerPalette(HDC, int, BOOL);
__declspec(dllimport) BOOL  __stdcall wglSwapLayerBuffers(HDC, UINT);



typedef struct _WGLSWAP
{
    HDC hdc;
    UINT uiFlags;
} WGLSWAP, *PWGLSWAP,  *LPWGLSWAP;



__declspec(dllimport) DWORD __stdcall wglSwapMultipleBuffers(UINT, const WGLSWAP *);

#line 4916 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 4918 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


}
#line 4922 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"


#line 4925 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wingdi.h"

#line 164 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
























#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






extern "C" {
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









typedef HANDLE HDWP;
typedef void MENUTEMPLATEA;
typedef void MENUTEMPLATEW;



typedef MENUTEMPLATEA MENUTEMPLATE;
#line 51 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
typedef PVOID LPMENUTEMPLATEA;
typedef PVOID LPMENUTEMPLATEW;



typedef LPMENUTEMPLATEA LPMENUTEMPLATE;
#line 58 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef LRESULT (__stdcall* WNDPROC)(HWND, UINT, WPARAM, LPARAM);



typedef INT_PTR (__stdcall* DLGPROC)(HWND, UINT, WPARAM, LPARAM);
typedef void (__stdcall* TIMERPROC)(HWND, UINT, UINT_PTR, DWORD);
typedef BOOL (__stdcall* GRAYSTRINGPROC)(HDC, LPARAM, int);
typedef BOOL (__stdcall* WNDENUMPROC)(HWND, LPARAM);
typedef LRESULT (__stdcall* HOOKPROC)(int code, WPARAM wParam, LPARAM lParam);
typedef void (__stdcall* SENDASYNCPROC)(HWND, UINT, ULONG_PTR, LRESULT);

typedef BOOL (__stdcall* PROPENUMPROCA)(HWND, LPCSTR, HANDLE);
typedef BOOL (__stdcall* PROPENUMPROCW)(HWND, LPCWSTR, HANDLE);

typedef BOOL (__stdcall* PROPENUMPROCEXA)(HWND, LPSTR, HANDLE, ULONG_PTR);
typedef BOOL (__stdcall* PROPENUMPROCEXW)(HWND, LPWSTR, HANDLE, ULONG_PTR);

typedef int (__stdcall* EDITWORDBREAKPROCA)(LPSTR lpch, int ichCurrent, int cch, int code);
typedef int (__stdcall* EDITWORDBREAKPROCW)(LPWSTR lpch, int ichCurrent, int cch, int code);


typedef BOOL (__stdcall* DRAWSTATEPROC)(HDC hdc, LPARAM lData, WPARAM wData, int cx, int cy);
#line 82 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





















#line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






typedef PROPENUMPROCA        PROPENUMPROC;
typedef PROPENUMPROCEXA      PROPENUMPROCEX;
typedef EDITWORDBREAKPROCA   EDITWORDBREAKPROC;
#line 114 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



typedef BOOL (__stdcall* NAMEENUMPROCA)(LPSTR, LPARAM);
typedef BOOL (__stdcall* NAMEENUMPROCW)(LPWSTR, LPARAM);

typedef NAMEENUMPROCA   WINSTAENUMPROCA;
typedef NAMEENUMPROCA   DESKTOPENUMPROCA;
typedef NAMEENUMPROCW   WINSTAENUMPROCW;
typedef NAMEENUMPROCW   DESKTOPENUMPROCW;












#line 137 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







typedef WINSTAENUMPROCA     WINSTAENUMPROC;
typedef DESKTOPENUMPROCA    DESKTOPENUMPROC;

#line 148 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




























#line 186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 205 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
wvsprintfA(
     LPSTR,
     LPCSTR,
     va_list arglist);
__declspec(dllimport)
int
__stdcall
wvsprintfW(
     LPWSTR,
     LPCWSTR,
     va_list arglist);




#line 225 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__cdecl
wsprintfA(
     LPSTR,
     LPCSTR,
    ...);
__declspec(dllimport)
int
__cdecl
wsprintfW(
     LPWSTR,
     LPCWSTR,
    ...);




#line 245 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




































#line 282 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









































#line 324 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 340 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


























#line 367 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








































































































































































#line 536 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









































#line 578 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 585 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





































#line 623 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


















#line 642 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 648 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 653 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 658 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 660 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 663 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
































typedef struct tagCBT_CREATEWNDA
{
    struct tagCREATESTRUCTA *lpcs;
    HWND           hwndInsertAfter;
} CBT_CREATEWNDA, *LPCBT_CREATEWNDA;



typedef struct tagCBT_CREATEWNDW
{
    struct tagCREATESTRUCTW *lpcs;
    HWND           hwndInsertAfter;
} CBT_CREATEWNDW, *LPCBT_CREATEWNDW;




typedef CBT_CREATEWNDA CBT_CREATEWND;
typedef LPCBT_CREATEWNDA LPCBT_CREATEWND;
#line 715 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct tagCBTACTIVATESTRUCT
{
    BOOL    fMouse;
    HWND    hWndActive;
} CBTACTIVATESTRUCT, *LPCBTACTIVATESTRUCT;

























#line 750 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

























#line 776 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 780 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 784 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



































































#line 852 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





typedef struct tagEVENTMSG {
    UINT    message;
    UINT    paramL;
    UINT    paramH;
    DWORD    time;
    HWND     hwnd;
} EVENTMSG, *PEVENTMSGMSG,  *NPEVENTMSGMSG,  *LPEVENTMSGMSG;

typedef struct tagEVENTMSG *PEVENTMSG,  *NPEVENTMSG,  *LPEVENTMSG;




typedef struct tagCWPSTRUCT {
    LPARAM  lParam;
    WPARAM  wParam;
    UINT    message;
    HWND    hwnd;
} CWPSTRUCT, *PCWPSTRUCT,  *NPCWPSTRUCT,  *LPCWPSTRUCT;





typedef struct tagCWPRETSTRUCT {
    LRESULT lResult;
    LPARAM  lParam;
    WPARAM  wParam;
    UINT    message;
    HWND    hwnd;
} CWPRETSTRUCT, *PCWPRETSTRUCT,  *NPCWPRETSTRUCT,  *LPCWPRETSTRUCT;

#line 890 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




































#line 927 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct tagDEBUGHOOKINFO
{
    DWORD   idThread;
    DWORD   idThreadInstaller;
    LPARAM  lParam;
    WPARAM  wParam;
    int     code;
} DEBUGHOOKINFO, *PDEBUGHOOKINFO,  *NPDEBUGHOOKINFO, * LPDEBUGHOOKINFO;




typedef struct tagMOUSEHOOKSTRUCT {
    POINT   pt;
    HWND    hwnd;
    UINT    wHitTestCode;
    ULONG_PTR dwExtraInfo;
} MOUSEHOOKSTRUCT,  *LPMOUSEHOOKSTRUCT, *PMOUSEHOOKSTRUCT;














#line 964 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





typedef struct tagHARDWAREHOOKSTRUCT {
    HWND    hwnd;
    UINT    message;
    WPARAM  wParam;
    LPARAM  lParam;
} HARDWAREHOOKSTRUCT,  *LPHARDWAREHOOKSTRUCT, *PHARDWAREHOOKSTRUCT;
#line 976 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 977 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"














#line 992 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 997 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 1007 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






__declspec(dllimport)
HKL
__stdcall
LoadKeyboardLayoutA(
     LPCSTR pwszKLID,
     UINT Flags);
__declspec(dllimport)
HKL
__stdcall
LoadKeyboardLayoutW(
     LPCWSTR pwszKLID,
     UINT Flags);




#line 1030 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
HKL
__stdcall
ActivateKeyboardLayout(
     HKL hkl,
     UINT Flags);







#line 1047 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
int
__stdcall
ToUnicodeEx(
     UINT wVirtKey,
     UINT wScanCode,
     const BYTE *lpKeyState,
     LPWSTR pwszBuff,
     int cchBuff,
     UINT wFlags,
     HKL dwhkl);
#line 1061 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UnloadKeyboardLayout(
     HKL hkl);

__declspec(dllimport)
BOOL
__stdcall
GetKeyboardLayoutNameA(
     LPSTR pwszKLID);
__declspec(dllimport)
BOOL
__stdcall
GetKeyboardLayoutNameW(
     LPWSTR pwszKLID);




#line 1083 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
int
__stdcall
GetKeyboardLayoutList(
         int nBuff,
         HKL  *lpList);

__declspec(dllimport)
HKL
__stdcall
GetKeyboardLayout(
     DWORD idThread
);
#line 1099 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



typedef struct tagMOUSEMOVEPOINT {
    int   x;
    int   y;
    DWORD time;
    ULONG_PTR dwExtraInfo;
} MOUSEMOVEPOINT, *PMOUSEMOVEPOINT, * LPMOUSEMOVEPOINT;







__declspec(dllimport)
int
__stdcall
GetMouseMovePointsEx(
     UINT             cbSize,
     LPMOUSEMOVEPOINT lppt,
     LPMOUSEMOVEPOINT lpptBuf,
     int              nBufPoints,
     DWORD            resolution
);

#line 1127 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"























__declspec(dllimport)
HDESK
__stdcall
CreateDesktopA(
     LPCSTR lpszDesktop,
     LPCSTR lpszDevice,
     LPDEVMODEA pDevmode,
     DWORD dwFlags,
     ACCESS_MASK dwDesiredAccess,
     LPSECURITY_ATTRIBUTES lpsa);
__declspec(dllimport)
HDESK
__stdcall
CreateDesktopW(
     LPCWSTR lpszDesktop,
     LPCWSTR lpszDevice,
     LPDEVMODEW pDevmode,
     DWORD dwFlags,
     ACCESS_MASK dwDesiredAccess,
     LPSECURITY_ATTRIBUTES lpsa);




#line 1175 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1177 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 1178 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HDESK
__stdcall
OpenDesktopA(
     LPCSTR lpszDesktop,
     DWORD dwFlags,
     BOOL fInherit,
     ACCESS_MASK dwDesiredAccess);
__declspec(dllimport)
HDESK
__stdcall
OpenDesktopW(
     LPCWSTR lpszDesktop,
     DWORD dwFlags,
     BOOL fInherit,
     ACCESS_MASK dwDesiredAccess);




#line 1200 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HDESK
__stdcall
OpenInputDesktop(
     DWORD dwFlags,
     BOOL fInherit,
     ACCESS_MASK dwDesiredAccess);

__declspec(dllimport)
BOOL
__stdcall
EnumDesktopsA(
     HWINSTA hwinsta,
     DESKTOPENUMPROCA lpEnumFunc,
     LPARAM lParam);
__declspec(dllimport)
BOOL
__stdcall
EnumDesktopsW(
     HWINSTA hwinsta,
     DESKTOPENUMPROCW lpEnumFunc,
     LPARAM lParam);




#line 1228 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
EnumDesktopWindows(
     HDESK hDesktop,
     WNDENUMPROC lpfn,
     LPARAM lParam);

__declspec(dllimport)
BOOL
__stdcall
SwitchDesktop(
     HDESK hDesktop);

__declspec(dllimport)
BOOL
__stdcall
SetThreadDesktop(
     HDESK hDesktop);

__declspec(dllimport)
BOOL
__stdcall
CloseDesktop(
     HDESK hDesktop);

__declspec(dllimport)
HDESK
__stdcall
GetThreadDesktop(
     DWORD dwThreadId);
#line 1261 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















__declspec(dllimport)
HWINSTA
__stdcall
CreateWindowStationA(
     LPCSTR              lpwinsta,
     DWORD                 dwReserved,
     ACCESS_MASK           dwDesiredAccess,
     LPSECURITY_ATTRIBUTES lpsa);
__declspec(dllimport)
HWINSTA
__stdcall
CreateWindowStationW(
     LPCWSTR              lpwinsta,
     DWORD                 dwReserved,
     ACCESS_MASK           dwDesiredAccess,
     LPSECURITY_ATTRIBUTES lpsa);




#line 1302 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWINSTA
__stdcall
OpenWindowStationA(
     LPCSTR lpszWinSta,
     BOOL fInherit,
     ACCESS_MASK dwDesiredAccess);
__declspec(dllimport)
HWINSTA
__stdcall
OpenWindowStationW(
     LPCWSTR lpszWinSta,
     BOOL fInherit,
     ACCESS_MASK dwDesiredAccess);




#line 1322 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
EnumWindowStationsA(
     WINSTAENUMPROCA lpEnumFunc,
     LPARAM lParam);
__declspec(dllimport)
BOOL
__stdcall
EnumWindowStationsW(
     WINSTAENUMPROCW lpEnumFunc,
     LPARAM lParam);




#line 1340 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
CloseWindowStation(
     HWINSTA hWinSta);

__declspec(dllimport)
BOOL
__stdcall
SetProcessWindowStation(
     HWINSTA hWinSta);

__declspec(dllimport)
HWINSTA
__stdcall
GetProcessWindowStation(
    void);
#line 1360 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
BOOL
__stdcall
SetUserObjectSecurity(
     HANDLE hObj,
     PSECURITY_INFORMATION pSIRequested,
     PSECURITY_DESCRIPTOR pSID);

__declspec(dllimport)
BOOL
__stdcall
GetUserObjectSecurity(
     HANDLE hObj,
     PSECURITY_INFORMATION pSIRequested,
      PSECURITY_DESCRIPTOR pSID,
     DWORD nLength,
     LPDWORD lpnLengthNeeded);






typedef struct tagUSEROBJECTFLAGS {
    BOOL fInherit;
    BOOL fReserved;
    DWORD dwFlags;
} USEROBJECTFLAGS, *PUSEROBJECTFLAGS;

__declspec(dllimport)
BOOL
__stdcall
GetUserObjectInformationA(
     HANDLE hObj,
     int nIndex,
     PVOID pvInfo,
     DWORD nLength,
     LPDWORD lpnLengthNeeded);
__declspec(dllimport)
BOOL
__stdcall
GetUserObjectInformationW(
     HANDLE hObj,
     int nIndex,
     PVOID pvInfo,
     DWORD nLength,
     LPDWORD lpnLengthNeeded);




#line 1415 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetUserObjectInformationA(
     HANDLE hObj,
     int nIndex,
     PVOID pvInfo,
     DWORD nLength);
__declspec(dllimport)
BOOL
__stdcall
SetUserObjectInformationW(
     HANDLE hObj,
     int nIndex,
     PVOID pvInfo,
     DWORD nLength);




#line 1437 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1439 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


typedef struct tagWNDCLASSEXA {
    UINT        cbSize;
    
    UINT        style;
    WNDPROC     lpfnWndProc;
    int         cbClsExtra;
    int         cbWndExtra;
    HINSTANCE   hInstance;
    HICON       hIcon;
    HCURSOR     hCursor;
    HBRUSH      hbrBackground;
    LPCSTR      lpszMenuName;
    LPCSTR      lpszClassName;
    
    HICON       hIconSm;
} WNDCLASSEXA, *PWNDCLASSEXA,  *NPWNDCLASSEXA,  *LPWNDCLASSEXA;
typedef struct tagWNDCLASSEXW {
    UINT        cbSize;
    
    UINT        style;
    WNDPROC     lpfnWndProc;
    int         cbClsExtra;
    int         cbWndExtra;
    HINSTANCE   hInstance;
    HICON       hIcon;
    HCURSOR     hCursor;
    HBRUSH      hbrBackground;
    LPCWSTR     lpszMenuName;
    LPCWSTR     lpszClassName;
    
    HICON       hIconSm;
} WNDCLASSEXW, *PWNDCLASSEXW,  *NPWNDCLASSEXW,  *LPWNDCLASSEXW;






typedef WNDCLASSEXA WNDCLASSEX;
typedef PWNDCLASSEXA PWNDCLASSEX;
typedef NPWNDCLASSEXA NPWNDCLASSEX;
typedef LPWNDCLASSEXA LPWNDCLASSEX;
#line 1484 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 1485 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagWNDCLASSA {
    UINT        style;
    WNDPROC     lpfnWndProc;
    int         cbClsExtra;
    int         cbWndExtra;
    HINSTANCE   hInstance;
    HICON       hIcon;
    HCURSOR     hCursor;
    HBRUSH      hbrBackground;
    LPCSTR      lpszMenuName;
    LPCSTR      lpszClassName;
} WNDCLASSA, *PWNDCLASSA,  *NPWNDCLASSA,  *LPWNDCLASSA;
typedef struct tagWNDCLASSW {
    UINT        style;
    WNDPROC     lpfnWndProc;
    int         cbClsExtra;
    int         cbWndExtra;
    HINSTANCE   hInstance;
    HICON       hIcon;
    HCURSOR     hCursor;
    HBRUSH      hbrBackground;
    LPCWSTR     lpszMenuName;
    LPCWSTR     lpszClassName;
} WNDCLASSW, *PWNDCLASSW,  *NPWNDCLASSW,  *LPWNDCLASSW;






typedef WNDCLASSA WNDCLASS;
typedef PWNDCLASSA PWNDCLASS;
typedef NPWNDCLASSA NPWNDCLASS;
typedef LPWNDCLASSA LPWNDCLASS;
#line 1521 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







typedef struct tagMSG {
    HWND        hwnd;
    UINT        message;
    WPARAM      wParam;
    LPARAM      lParam;
    DWORD       time;
    POINT       pt;



} MSG, *PMSG,  *NPMSG,  *LPMSG;











#line 1551 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"













































#line 1597 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





















#line 1619 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



































#line 1655 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 1663 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















typedef struct tagMINMAXINFO {
    POINT ptReserved;
    POINT ptMaxSize;
    POINT ptMaxPosition;
    POINT ptMinTrackSize;
    POINT ptMaxTrackSize;
} MINMAXINFO, *PMINMAXINFO, *LPMINMAXINFO;



















#line 1706 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 1707 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






















typedef struct tagCOPYDATASTRUCT {
    ULONG_PTR dwData;
    DWORD cbData;
    PVOID lpData;
} COPYDATASTRUCT, *PCOPYDATASTRUCT;


typedef struct tagMDINEXTMENU
{
    HMENU   hmenuIn;
    HMENU   hmenuNext;
    HWND    hwndNext;
} MDINEXTMENU, * PMDINEXTMENU,  * LPMDINEXTMENU;
#line 1743 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






















#line 1766 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










#line 1777 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















#line 1795 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 1800 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"














#line 1815 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1817 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 1824 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









































#line 1866 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 1867 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1869 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 1870 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






















#line 1893 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 1898 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 1901 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1903 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1905 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 1915 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










#line 1926 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










#line 1937 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



























#line 1965 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 1967 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 1971 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



























#line 1999 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2002 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2006 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 2011 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2015 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 2022 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
























#line 2047 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2051 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2055 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 2065 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 2073 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 2094 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




































#line 2131 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










#line 2142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 2143 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















#line 2160 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
UINT
__stdcall
RegisterWindowMessageA(
     LPCSTR lpString);
__declspec(dllimport)
UINT
__stdcall
RegisterWindowMessageW(
     LPCWSTR lpString);




#line 2177 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"























typedef struct tagWINDOWPOS {
    HWND    hwnd;
    HWND    hwndInsertAfter;
    int     x;
    int     y;
    int     cx;
    int     cy;
    UINT    flags;
} WINDOWPOS, *LPWINDOWPOS, *PWINDOWPOS;




typedef struct tagNCCALCSIZE_PARAMS {
    RECT       rgrc[3];
    PWINDOWPOS lppos;
} NCCALCSIZE_PARAMS, *LPNCCALCSIZE_PARAMS;




























#line 2246 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 2248 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



































#line 2284 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2287 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


































































#line 2354 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















#line 2372 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 2377 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 2383 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2390 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 2411 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 2415 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"























































__declspec(dllimport)
BOOL
__stdcall
DrawEdge(
     HDC hdc,
      LPRECT qrc,
     UINT edge,
     UINT grfFlags);









#line 2488 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

































#line 2522 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





__declspec(dllimport)
BOOL
__stdcall
DrawFrameControl(
     HDC,
      LPRECT,
     UINT,
     UINT);










#line 2546 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2549 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
DrawCaption( HWND,  HDC,  const RECT *,  UINT);





__declspec(dllimport)
BOOL
__stdcall
DrawAnimatedRects(
     HWND hwnd,
     int idAni,
     const RECT * lprcFrom,
     const RECT * lprcTo);

#line 2569 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
























#line 2594 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2597 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 2605 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 2626 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










typedef struct tagACCEL {

    BYTE   fVirt;               
    WORD   key;
    WORD   cmd;




#line 2646 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
} ACCEL, *LPACCEL;

typedef struct tagPAINTSTRUCT {
    HDC         hdc;
    BOOL        fErase;
    RECT        rcPaint;
    BOOL        fRestore;
    BOOL        fIncUpdate;
    BYTE        rgbReserved[32];
} PAINTSTRUCT, *PPAINTSTRUCT, *NPPAINTSTRUCT, *LPPAINTSTRUCT;

typedef struct tagCREATESTRUCTA {
    LPVOID      lpCreateParams;
    HINSTANCE   hInstance;
    HMENU       hMenu;
    HWND        hwndParent;
    int         cy;
    int         cx;
    int         y;
    int         x;
    LONG        style;
    LPCSTR      lpszName;
    LPCSTR      lpszClass;
    DWORD       dwExStyle;
} CREATESTRUCTA, *LPCREATESTRUCTA;
typedef struct tagCREATESTRUCTW {
    LPVOID      lpCreateParams;
    HINSTANCE   hInstance;
    HMENU       hMenu;
    HWND        hwndParent;
    int         cy;
    int         cx;
    int         y;
    int         x;
    LONG        style;
    LPCWSTR     lpszName;
    LPCWSTR     lpszClass;
    DWORD       dwExStyle;
} CREATESTRUCTW, *LPCREATESTRUCTW;




typedef CREATESTRUCTA CREATESTRUCT;
typedef LPCREATESTRUCTA LPCREATESTRUCT;
#line 2692 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagWINDOWPLACEMENT {
    UINT  length;
    UINT  flags;
    UINT  showCmd;
    POINT ptMinPosition;
    POINT ptMaxPosition;
    RECT  rcNormalPosition;



} WINDOWPLACEMENT;
typedef WINDOWPLACEMENT *PWINDOWPLACEMENT, *LPWINDOWPLACEMENT;





#line 2711 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


typedef struct tagNMHDR
{
    HWND      hwndFrom;
    UINT_PTR  idFrom;
    UINT      code;         
}   NMHDR;
typedef NMHDR  * LPNMHDR;

typedef struct tagSTYLESTRUCT
{
    DWORD   styleOld;
    DWORD   styleNew;
} STYLESTRUCT, * LPSTYLESTRUCT;
#line 2727 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 2739 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



















#line 2759 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 2766 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 2767 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct tagMEASUREITEMSTRUCT {
    UINT       CtlType;
    UINT       CtlID;
    UINT       itemID;
    UINT       itemWidth;
    UINT       itemHeight;
    ULONG_PTR  itemData;
} MEASUREITEMSTRUCT,  *PMEASUREITEMSTRUCT,  *LPMEASUREITEMSTRUCT;





typedef struct tagDRAWITEMSTRUCT {
    UINT        CtlType;
    UINT        CtlID;
    UINT        itemID;
    UINT        itemAction;
    UINT        itemState;
    HWND        hwndItem;
    HDC         hDC;
    RECT        rcItem;
    ULONG_PTR   itemData;
} DRAWITEMSTRUCT,  *PDRAWITEMSTRUCT,  *LPDRAWITEMSTRUCT;




typedef struct tagDELETEITEMSTRUCT {
    UINT       CtlType;
    UINT       CtlID;
    UINT       itemID;
    HWND       hwndItem;
    ULONG_PTR  itemData;
} DELETEITEMSTRUCT,  *PDELETEITEMSTRUCT,  *LPDELETEITEMSTRUCT;




typedef struct tagCOMPAREITEMSTRUCT {
    UINT        CtlType;
    UINT        CtlID;
    HWND        hwndItem;
    UINT        itemID1;
    ULONG_PTR   itemData1;
    UINT        itemID2;
    ULONG_PTR   itemData2;
    DWORD       dwLocaleId;
} COMPAREITEMSTRUCT,  *PCOMPAREITEMSTRUCT,  *LPCOMPAREITEMSTRUCT;







__declspec(dllimport)
BOOL
__stdcall
GetMessageA(
     LPMSG lpMsg,
     HWND hWnd,
     UINT wMsgFilterMin,
     UINT wMsgFilterMax);
__declspec(dllimport)
BOOL
__stdcall
GetMessageW(
     LPMSG lpMsg,
     HWND hWnd,
     UINT wMsgFilterMin,
     UINT wMsgFilterMax);




#line 2848 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
TranslateMessage(
     const MSG *lpMsg);

__declspec(dllimport)
LRESULT
__stdcall
DispatchMessageA(
     const MSG *lpMsg);
__declspec(dllimport)
LRESULT
__stdcall
DispatchMessageW(
     const MSG *lpMsg);




#line 2871 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetMessageQueue(
     int cMessagesMax);

__declspec(dllimport)
BOOL
__stdcall
PeekMessageA(
     LPMSG lpMsg,
     HWND hWnd,
     UINT wMsgFilterMin,
     UINT wMsgFilterMax,
     UINT wRemoveMsg);
__declspec(dllimport)
BOOL
__stdcall
PeekMessageW(
     LPMSG lpMsg,
     HWND hWnd,
     UINT wMsgFilterMin,
     UINT wMsgFilterMax,
     UINT wRemoveMsg);




#line 2901 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"













#line 2915 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 2918 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
RegisterHotKey(
     HWND hWnd,
     int id,
     UINT fsModifiers,
     UINT vk);

__declspec(dllimport)
BOOL
__stdcall
UnregisterHotKey(
     HWND hWnd,
     int id);






















#line 2957 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 2966 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
BOOL
__stdcall
ExitWindowsEx(
     UINT uFlags,
     DWORD dwReserved);

__declspec(dllimport)
BOOL
__stdcall
SwapMouseButton(
     BOOL fSwap);

__declspec(dllimport)
DWORD
__stdcall
GetMessagePos(
    void);

__declspec(dllimport)
LONG
__stdcall
GetMessageTime(
    void);

__declspec(dllimport)
LPARAM
__stdcall
GetMessageExtraInfo(
    void);


__declspec(dllimport)
LPARAM
__stdcall
SetMessageExtraInfo(
     LPARAM lParam);
#line 3008 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LRESULT
__stdcall
SendMessageA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
LRESULT
__stdcall
SendMessageW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3030 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LRESULT
__stdcall
SendMessageTimeoutA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam,
     UINT fuFlags,
     UINT uTimeout,
     PDWORD_PTR lpdwResult);
__declspec(dllimport)
LRESULT
__stdcall
SendMessageTimeoutW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam,
     UINT fuFlags,
     UINT uTimeout,
     PDWORD_PTR lpdwResult);




#line 3058 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SendNotifyMessageA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
BOOL
__stdcall
SendNotifyMessageW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3080 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SendMessageCallbackA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam,
     SENDASYNCPROC lpResultCallBack,
     ULONG_PTR dwData);
__declspec(dllimport)
BOOL
__stdcall
SendMessageCallbackW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam,
     SENDASYNCPROC lpResultCallBack,
     ULONG_PTR dwData);




#line 3106 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


































#line 3141 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



























#line 3169 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 3181 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 3202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 3206 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 3209 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef  PVOID           HDEVNOTIFY;
typedef  HDEVNOTIFY     *PHDEVNOTIFY;





#line 3221 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HDEVNOTIFY
__stdcall
RegisterDeviceNotificationA(
     HANDLE hRecipient,
     LPVOID NotificationFilter,
     DWORD Flags
    );
__declspec(dllimport)
HDEVNOTIFY
__stdcall
RegisterDeviceNotificationW(
     HANDLE hRecipient,
     LPVOID NotificationFilter,
     DWORD Flags
    );




#line 3243 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UnregisterDeviceNotification(
     HDEVNOTIFY Handle
    );
#line 3251 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
PostMessageA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
BOOL
__stdcall
PostMessageW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3274 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
PostThreadMessageA(
     DWORD idThread,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
BOOL
__stdcall
PostThreadMessageW(
     DWORD idThread,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3296 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 3306 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 3315 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
AttachThreadInput(
     DWORD idAttach,
     DWORD idAttachTo,
     BOOL fAttach);


__declspec(dllimport)
BOOL
__stdcall
ReplyMessage(
     LRESULT lResult);

__declspec(dllimport)
BOOL
__stdcall
WaitMessage(
    void);


__declspec(dllimport)
DWORD
__stdcall
WaitForInputIdle(
     HANDLE hProcess,
     DWORD dwMilliseconds);

__declspec(dllimport)

LRESULT
__stdcall



#line 3353 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefWindowProcA(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)

LRESULT
__stdcall



#line 3366 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefWindowProcW(
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3376 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
void
__stdcall
PostQuitMessage(
     int nExitCode);



__declspec(dllimport)
LRESULT
__stdcall
CallWindowProcA(
     WNDPROC lpPrevWndFunc,
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
LRESULT
__stdcall
CallWindowProcW(
     WNDPROC lpPrevWndFunc,
     HWND hWnd,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 3408 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



























#line 3436 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
InSendMessage(
    void);


__declspec(dllimport)
DWORD
__stdcall
InSendMessageEx(
     LPVOID lpReserved);









#line 3459 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
UINT
__stdcall
GetDoubleClickTime(
    void);

__declspec(dllimport)
BOOL
__stdcall
SetDoubleClickTime(
     UINT);

__declspec(dllimport)
ATOM
__stdcall
RegisterClassA(
     const WNDCLASSA *lpWndClass);
__declspec(dllimport)
ATOM
__stdcall
RegisterClassW(
     const WNDCLASSW *lpWndClass);




#line 3487 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UnregisterClassA(
     LPCSTR lpClassName,
     HINSTANCE hInstance);
__declspec(dllimport)
BOOL
__stdcall
UnregisterClassW(
     LPCWSTR lpClassName,
     HINSTANCE hInstance);




#line 3505 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetClassInfoA(
     HINSTANCE hInstance,
     LPCSTR lpClassName,
     LPWNDCLASSA lpWndClass);
__declspec(dllimport)
BOOL
__stdcall
GetClassInfoW(
     HINSTANCE hInstance,
     LPCWSTR lpClassName,
     LPWNDCLASSW lpWndClass);




#line 3525 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
ATOM
__stdcall
RegisterClassExA(
     const WNDCLASSEXA *);
__declspec(dllimport)
ATOM
__stdcall
RegisterClassExW(
     const WNDCLASSEXW *);




#line 3542 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetClassInfoExA(
     HINSTANCE,
     LPCSTR,
     LPWNDCLASSEXA);
__declspec(dllimport)
BOOL
__stdcall
GetClassInfoExW(
     HINSTANCE,
     LPCWSTR,
     LPWNDCLASSEXW);




#line 3562 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 3564 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










#line 3575 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
CreateWindowExA(
     DWORD dwExStyle,
     LPCSTR lpClassName,
     LPCSTR lpWindowName,
     DWORD dwStyle,
     int X,
     int Y,
     int nWidth,
     int nHeight,
     HWND hWndParent,
     HMENU hMenu,
     HINSTANCE hInstance,
     LPVOID lpParam);
__declspec(dllimport)
HWND
__stdcall
CreateWindowExW(
     DWORD dwExStyle,
     LPCWSTR lpClassName,
     LPCWSTR lpWindowName,
     DWORD dwStyle,
     int X,
     int Y,
     int nWidth,
     int nHeight,
     HWND hWndParent,
     HMENU hMenu,
     HINSTANCE hInstance,
     LPVOID lpParam);




#line 3613 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"













#line 3627 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
IsWindow(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
IsMenu(
     HMENU hMenu);

__declspec(dllimport)
BOOL
__stdcall
IsChild(
     HWND hWndParent,
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
DestroyWindow(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
ShowWindow(
     HWND hWnd,
     int nCmdShow);


__declspec(dllimport)
BOOL
__stdcall
AnimateWindow(
     HWND hWnd,
     DWORD dwTime,
     DWORD dwFlags);
#line 3669 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




























































#line 3730 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
ShowWindowAsync(
     HWND hWnd,
     int nCmdShow);
#line 3739 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
FlashWindow(
     HWND hWnd,
     BOOL bInvert);


typedef struct {
    UINT  cbSize;
    HWND  hwnd;
    DWORD dwFlags;
    UINT  uCount;
    DWORD dwTimeout;
} FLASHWINFO, *PFLASHWINFO;

__declspec(dllimport)
BOOL
__stdcall
FlashWindowEx(
    PFLASHWINFO pfwi);








#line 3770 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
ShowOwnedPopups(
     HWND hWnd,
     BOOL fShow);

__declspec(dllimport)
BOOL
__stdcall
OpenIcon(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
CloseWindow(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
MoveWindow(
     HWND hWnd,
     int X,
     int Y,
     int nWidth,
     int nHeight,
     BOOL bRepaint);

__declspec(dllimport)
BOOL
__stdcall
SetWindowPos(
     HWND hWnd,
     HWND hWndInsertAfter,
     int X,
     int Y,
     int cx,
     int cy,
     UINT uFlags);

__declspec(dllimport)
BOOL
__stdcall
GetWindowPlacement(
     HWND hWnd,
     WINDOWPLACEMENT *lpwndpl);

__declspec(dllimport)
BOOL
__stdcall
SetWindowPlacement(
     HWND hWnd,
     const WINDOWPLACEMENT *lpwndpl);




__declspec(dllimport)
HDWP
__stdcall
BeginDeferWindowPos(
     int nNumWindows);

__declspec(dllimport)
HDWP
__stdcall
DeferWindowPos(
     HDWP hWinPosInfo,
     HWND hWnd,
     HWND hWndInsertAfter,
     int x,
     int y,
     int cx,
     int cy,
     UINT uFlags);

__declspec(dllimport)
BOOL
__stdcall
EndDeferWindowPos(
     HDWP hWinPosInfo);

#line 3856 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
IsWindowVisible(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
IsIconic(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
AnyPopup(
    void);

__declspec(dllimport)
BOOL
__stdcall
BringWindowToTop(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
IsZoomed(
     HWND hWnd);






















#line 3909 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"














#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"























#pragma warning(disable:4103)

#pragma pack(push,2)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack2.h"
#line 3924 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct {
    DWORD style;
    DWORD dwExtendedStyle;
    WORD cdit;
    short x;
    short y;
    short cx;
    short cy;
} DLGTEMPLATE;
typedef DLGTEMPLATE *LPDLGTEMPLATEA;
typedef DLGTEMPLATE *LPDLGTEMPLATEW;



typedef LPDLGTEMPLATEA LPDLGTEMPLATE;
#line 3944 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
typedef const DLGTEMPLATE *LPCDLGTEMPLATEA;
typedef const DLGTEMPLATE *LPCDLGTEMPLATEW;



typedef LPCDLGTEMPLATEA LPCDLGTEMPLATE;
#line 3951 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct {
    DWORD style;
    DWORD dwExtendedStyle;
    short x;
    short y;
    short cx;
    short cy;
    WORD id;
} DLGITEMTEMPLATE;
typedef DLGITEMTEMPLATE *PDLGITEMTEMPLATEA;
typedef DLGITEMTEMPLATE *PDLGITEMTEMPLATEW;



typedef PDLGITEMTEMPLATEA PDLGITEMTEMPLATE;
#line 3971 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
typedef DLGITEMTEMPLATE *LPDLGITEMTEMPLATEA;
typedef DLGITEMTEMPLATE *LPDLGITEMTEMPLATEW;



typedef LPDLGITEMTEMPLATEA LPDLGITEMTEMPLATE;
#line 3978 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 3981 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
CreateDialogParamA(
     HINSTANCE hInstance,
     LPCSTR lpTemplateName,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);
__declspec(dllimport)
HWND
__stdcall
CreateDialogParamW(
     HINSTANCE hInstance,
     LPCWSTR lpTemplateName,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);




#line 4005 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
CreateDialogIndirectParamA(
     HINSTANCE hInstance,
     LPCDLGTEMPLATEA lpTemplate,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);
__declspec(dllimport)
HWND
__stdcall
CreateDialogIndirectParamW(
     HINSTANCE hInstance,
     LPCDLGTEMPLATEW lpTemplate,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);




#line 4029 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 4039 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 4049 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
INT_PTR
__stdcall
DialogBoxParamA(
     HINSTANCE hInstance,
     LPCSTR lpTemplateName,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);
__declspec(dllimport)
INT_PTR
__stdcall
DialogBoxParamW(
     HINSTANCE hInstance,
     LPCWSTR lpTemplateName,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);




#line 4073 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
INT_PTR
__stdcall
DialogBoxIndirectParamA(
     HINSTANCE hInstance,
     LPCDLGTEMPLATEA hDialogTemplate,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);
__declspec(dllimport)
INT_PTR
__stdcall
DialogBoxIndirectParamW(
     HINSTANCE hInstance,
     LPCDLGTEMPLATEW hDialogTemplate,
     HWND hWndParent,
     DLGPROC lpDialogFunc,
     LPARAM dwInitParam);




#line 4097 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 4107 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 4117 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
EndDialog(
     HWND hDlg,
     INT_PTR nResult);

__declspec(dllimport)
HWND
__stdcall
GetDlgItem(
     HWND hDlg,
     int nIDDlgItem);

__declspec(dllimport)
BOOL
__stdcall
SetDlgItemInt(
     HWND hDlg,
     int nIDDlgItem,
     UINT uValue,
     BOOL bSigned);

__declspec(dllimport)
UINT
__stdcall
GetDlgItemInt(
     HWND hDlg,
     int nIDDlgItem,
     BOOL *lpTranslated,
     BOOL bSigned);

__declspec(dllimport)
BOOL
__stdcall
SetDlgItemTextA(
     HWND hDlg,
     int nIDDlgItem,
     LPCSTR lpString);
__declspec(dllimport)
BOOL
__stdcall
SetDlgItemTextW(
     HWND hDlg,
     int nIDDlgItem,
     LPCWSTR lpString);




#line 4169 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
UINT
__stdcall
GetDlgItemTextA(
     HWND hDlg,
     int nIDDlgItem,
     LPSTR lpString,
     int nMaxCount);
__declspec(dllimport)
UINT
__stdcall
GetDlgItemTextW(
     HWND hDlg,
     int nIDDlgItem,
     LPWSTR lpString,
     int nMaxCount);




#line 4191 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
CheckDlgButton(
     HWND hDlg,
     int nIDButton,
     UINT uCheck);

__declspec(dllimport)
BOOL
__stdcall
CheckRadioButton(
     HWND hDlg,
     int nIDFirstButton,
     int nIDLastButton,
     int nIDCheckButton);

__declspec(dllimport)
UINT
__stdcall
IsDlgButtonChecked(
     HWND hDlg,
     int nIDButton);

__declspec(dllimport)
LRESULT
__stdcall
SendDlgItemMessageA(
     HWND hDlg,
     int nIDDlgItem,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
LRESULT
__stdcall
SendDlgItemMessageW(
     HWND hDlg,
     int nIDDlgItem,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 4239 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
GetNextDlgGroupItem(
     HWND hDlg,
     HWND hCtl,
     BOOL bPrevious);

__declspec(dllimport)
HWND
__stdcall
GetNextDlgTabItem(
     HWND hDlg,
     HWND hCtl,
     BOOL bPrevious);

__declspec(dllimport)
int
__stdcall
GetDlgCtrlID(
     HWND hWnd);

__declspec(dllimport)
long
__stdcall
GetDialogBaseUnits(void);

__declspec(dllimport)

LRESULT
__stdcall



#line 4275 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefDlgProcA(
     HWND hDlg,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)

LRESULT
__stdcall



#line 4288 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefDlgProcW(
     HWND hDlg,
     UINT Msg,
     WPARAM wParam,
     LPARAM lParam);




#line 4298 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 4307 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 4309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
BOOL
__stdcall
CallMsgFilterA(
     LPMSG lpMsg,
     int nCode);
__declspec(dllimport)
BOOL
__stdcall
CallMsgFilterW(
     LPMSG lpMsg,
     int nCode);




#line 4329 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 4331 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







__declspec(dllimport)
BOOL
__stdcall
OpenClipboard(
     HWND hWndNewOwner);

__declspec(dllimport)
BOOL
__stdcall
CloseClipboard(
    void);




__declspec(dllimport)
DWORD
__stdcall
GetClipboardSequenceNumber(
    void);

#line 4360 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
GetClipboardOwner(
    void);

__declspec(dllimport)
HWND
__stdcall
SetClipboardViewer(
     HWND hWndNewViewer);

__declspec(dllimport)
HWND
__stdcall
GetClipboardViewer(
    void);

__declspec(dllimport)
BOOL
__stdcall
ChangeClipboardChain(
     HWND hWndRemove,
     HWND hWndNewNext);

__declspec(dllimport)
HANDLE
__stdcall
SetClipboardData(
     UINT uFormat,
     HANDLE hMem);

__declspec(dllimport)
HANDLE
__stdcall
GetClipboardData(
     UINT uFormat);

__declspec(dllimport)
UINT
__stdcall
RegisterClipboardFormatA(
     LPCSTR lpszFormat);
__declspec(dllimport)
UINT
__stdcall
RegisterClipboardFormatW(
     LPCWSTR lpszFormat);




#line 4414 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
CountClipboardFormats(
    void);

__declspec(dllimport)
UINT
__stdcall
EnumClipboardFormats(
     UINT format);

__declspec(dllimport)
int
__stdcall
GetClipboardFormatNameA(
     UINT format,
     LPSTR lpszFormatName,
     int cchMaxCount);
__declspec(dllimport)
int
__stdcall
GetClipboardFormatNameW(
     UINT format,
     LPWSTR lpszFormatName,
     int cchMaxCount);




#line 4446 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
EmptyClipboard(
    void);

__declspec(dllimport)
BOOL
__stdcall
IsClipboardFormatAvailable(
     UINT format);

__declspec(dllimport)
int
__stdcall
GetPriorityClipboardFormat(
     UINT *paFormatPriorityList,
     int cFormats);

__declspec(dllimport)
HWND
__stdcall
GetOpenClipboardWindow(
    void);

#line 4473 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





__declspec(dllimport)
BOOL
__stdcall
CharToOemA(
     LPCSTR lpszSrc,
     LPSTR lpszDst);
__declspec(dllimport)
BOOL
__stdcall
CharToOemW(
     LPCWSTR lpszSrc,
     LPSTR lpszDst);




#line 4495 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
OemToCharA(
     LPCSTR lpszSrc,
     LPSTR lpszDst);
__declspec(dllimport)
BOOL
__stdcall
OemToCharW(
     LPCSTR lpszSrc,
     LPWSTR lpszDst);




#line 4513 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
CharToOemBuffA(
     LPCSTR lpszSrc,
     LPSTR lpszDst,
     DWORD cchDstLength);
__declspec(dllimport)
BOOL
__stdcall
CharToOemBuffW(
     LPCWSTR lpszSrc,
     LPSTR lpszDst,
     DWORD cchDstLength);




#line 4533 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
OemToCharBuffA(
     LPCSTR lpszSrc,
     LPSTR lpszDst,
     DWORD cchDstLength);
__declspec(dllimport)
BOOL
__stdcall
OemToCharBuffW(
     LPCSTR lpszSrc,
     LPWSTR lpszDst,
     DWORD cchDstLength);




#line 4553 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LPSTR
__stdcall
CharUpperA(
      LPSTR lpsz);
__declspec(dllimport)
LPWSTR
__stdcall
CharUpperW(
      LPWSTR lpsz);




#line 4569 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
DWORD
__stdcall
CharUpperBuffA(
      LPSTR lpsz,
     DWORD cchLength);
__declspec(dllimport)
DWORD
__stdcall
CharUpperBuffW(
      LPWSTR lpsz,
     DWORD cchLength);




#line 4587 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LPSTR
__stdcall
CharLowerA(
      LPSTR lpsz);
__declspec(dllimport)
LPWSTR
__stdcall
CharLowerW(
      LPWSTR lpsz);




#line 4603 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
DWORD
__stdcall
CharLowerBuffA(
      LPSTR lpsz,
     DWORD cchLength);
__declspec(dllimport)
DWORD
__stdcall
CharLowerBuffW(
      LPWSTR lpsz,
     DWORD cchLength);




#line 4621 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LPSTR
__stdcall
CharNextA(
     LPCSTR lpsz);
__declspec(dllimport)
LPWSTR
__stdcall
CharNextW(
     LPCWSTR lpsz);




#line 4637 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LPSTR
__stdcall
CharPrevA(
     LPCSTR lpszStart,
     LPCSTR lpszCurrent);
__declspec(dllimport)
LPWSTR
__stdcall
CharPrevW(
     LPCWSTR lpszStart,
     LPCWSTR lpszCurrent);




#line 4655 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
LPSTR
__stdcall
CharNextExA(
      WORD CodePage,
      LPCSTR lpCurrentChar,
      DWORD dwFlags);

__declspec(dllimport)
LPSTR
__stdcall
CharPrevExA(
      WORD CodePage,
      LPCSTR lpStart,
      LPCSTR lpCurrentChar,
      DWORD dwFlags);
#line 4674 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















__declspec(dllimport)
BOOL
__stdcall
IsCharAlphaA(
     CHAR ch);
__declspec(dllimport)
BOOL
__stdcall
IsCharAlphaW(
     WCHAR ch);




#line 4709 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
IsCharAlphaNumericA(
     CHAR ch);
__declspec(dllimport)
BOOL
__stdcall
IsCharAlphaNumericW(
     WCHAR ch);




#line 4725 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
IsCharUpperA(
     CHAR ch);
__declspec(dllimport)
BOOL
__stdcall
IsCharUpperW(
     WCHAR ch);




#line 4741 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
IsCharLowerA(
     CHAR ch);
__declspec(dllimport)
BOOL
__stdcall
IsCharLowerW(
     WCHAR ch);




#line 4757 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 4759 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
SetFocus(
     HWND hWnd);

__declspec(dllimport)
HWND
__stdcall
GetActiveWindow(
    void);

__declspec(dllimport)
HWND
__stdcall
GetFocus(
    void);

__declspec(dllimport)
UINT
__stdcall
GetKBCodePage(
    void);

__declspec(dllimport)
SHORT
__stdcall
GetKeyState(
     int nVirtKey);

__declspec(dllimport)
SHORT
__stdcall
GetAsyncKeyState(
     int vKey);

__declspec(dllimport)
BOOL
__stdcall
GetKeyboardState(
     PBYTE lpKeyState);

__declspec(dllimport)
BOOL
__stdcall
SetKeyboardState(
     LPBYTE lpKeyState);

__declspec(dllimport)
int
__stdcall
GetKeyNameTextA(
     LONG lParam,
     LPSTR lpString,
     int nSize
    );
__declspec(dllimport)
int
__stdcall
GetKeyNameTextW(
     LONG lParam,
     LPWSTR lpString,
     int nSize
    );




#line 4829 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
GetKeyboardType(
     int nTypeFlag);

__declspec(dllimport)
int
__stdcall
ToAscii(
     UINT uVirtKey,
     UINT uScanCode,
     const BYTE *lpKeyState,
     LPWORD lpChar,
     UINT uFlags);


__declspec(dllimport)
int
__stdcall
ToAsciiEx(
     UINT uVirtKey,
     UINT uScanCode,
     const BYTE *lpKeyState,
     LPWORD lpChar,
     UINT uFlags,
     HKL dwhkl);
#line 4858 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
ToUnicode(
     UINT wVirtKey,
     UINT wScanCode,
     const BYTE *lpKeyState,
     LPWSTR pwszBuff,
     int cchBuff,
     UINT wFlags);

__declspec(dllimport)
DWORD
__stdcall
OemKeyScan(
     WORD wOemChar);

__declspec(dllimport)
SHORT
__stdcall
VkKeyScanA(
     CHAR ch);
__declspec(dllimport)
SHORT
__stdcall
VkKeyScanW(
     WCHAR ch);




#line 4891 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
SHORT
__stdcall
VkKeyScanExA(
     CHAR  ch,
     HKL   dwhkl);
__declspec(dllimport)
SHORT
__stdcall
VkKeyScanExW(
     WCHAR  ch,
     HKL   dwhkl);




#line 4910 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 4911 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 4917 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
void
__stdcall
keybd_event(
     BYTE bVk,
     BYTE bScan,
     DWORD dwFlags,
     ULONG_PTR dwExtraInfo);
















__declspec(dllimport)
void
__stdcall
mouse_event(
     DWORD dwFlags,
     DWORD dx,
     DWORD dy,
     DWORD dwData,
     ULONG_PTR dwExtraInfo);

















































#line 5001 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"












#line 5014 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
UINT
__stdcall
MapVirtualKeyA(
     UINT uCode,
     UINT uMapType);
__declspec(dllimport)
UINT
__stdcall
MapVirtualKeyW(
     UINT uCode,
     UINT uMapType);




#line 5032 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
UINT
__stdcall
MapVirtualKeyExA(
     UINT uCode,
     UINT uMapType,
     HKL dwhkl);
__declspec(dllimport)
UINT
__stdcall
MapVirtualKeyExW(
     UINT uCode,
     UINT uMapType,
     HKL dwhkl);




#line 5053 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 5054 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetInputState(
    void);

__declspec(dllimport)
DWORD
__stdcall
GetQueueStatus(
     UINT flags);


__declspec(dllimport)
HWND
__stdcall
GetCapture(
    void);

__declspec(dllimport)
HWND
__stdcall
SetCapture(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
ReleaseCapture(
    void);

__declspec(dllimport)
DWORD
__stdcall
MsgWaitForMultipleObjects(
     DWORD nCount,
     const HANDLE *pHandles,
     BOOL fWaitAll,
     DWORD dwMilliseconds,
     DWORD dwWakeMask);

__declspec(dllimport)
DWORD
__stdcall
MsgWaitForMultipleObjectsEx(
     DWORD nCount,
     const HANDLE *pHandles,
     DWORD dwMilliseconds,
     DWORD dwWakeMask,
     DWORD dwFlags);




















#line 5126 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 5135 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 5138 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



















__declspec(dllimport)
UINT_PTR
__stdcall
SetTimer(
     HWND hWnd,
     UINT_PTR nIDEvent,
     UINT uElapse,
     TIMERPROC lpTimerFunc);

__declspec(dllimport)
BOOL
__stdcall
KillTimer(
     HWND hWnd,
     UINT_PTR uIDEvent);

__declspec(dllimport)
BOOL
__stdcall
IsWindowUnicode(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
EnableWindow(
     HWND hWnd,
     BOOL bEnable);

__declspec(dllimport)
BOOL
__stdcall
IsWindowEnabled(
     HWND hWnd);

__declspec(dllimport)
HACCEL
__stdcall
LoadAcceleratorsA(
     HINSTANCE hInstance,
     LPCSTR lpTableName);
__declspec(dllimport)
HACCEL
__stdcall
LoadAcceleratorsW(
     HINSTANCE hInstance,
     LPCWSTR lpTableName);




#line 5209 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HACCEL
__stdcall
CreateAcceleratorTableA(
     LPACCEL,  int);
__declspec(dllimport)
HACCEL
__stdcall
CreateAcceleratorTableW(
     LPACCEL,  int);




#line 5225 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
DestroyAcceleratorTable(
     HACCEL hAccel);

__declspec(dllimport)
int
__stdcall
CopyAcceleratorTableA(
     HACCEL hAccelSrc,
     LPACCEL lpAccelDst,
     int cAccelEntries);
__declspec(dllimport)
int
__stdcall
CopyAcceleratorTableW(
     HACCEL hAccelSrc,
     LPACCEL lpAccelDst,
     int cAccelEntries);




#line 5251 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
int
__stdcall
TranslateAcceleratorA(
     HWND hWnd,
     HACCEL hAccTable,
     LPMSG lpMsg);
__declspec(dllimport)
int
__stdcall
TranslateAcceleratorW(
     HWND hWnd,
     HACCEL hAccTable,
     LPMSG lpMsg);




#line 5273 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 5275 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















































































#line 5357 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 5364 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 5368 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 5376 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 5379 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 5383 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 5387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 5389 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 5397 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 5399 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
int
__stdcall
GetSystemMetrics(
     int nIndex);


#line 5409 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
HMENU
__stdcall
LoadMenuA(
     HINSTANCE hInstance,
     LPCSTR lpMenuName);
__declspec(dllimport)
HMENU
__stdcall
LoadMenuW(
     HINSTANCE hInstance,
     LPCWSTR lpMenuName);




#line 5429 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HMENU
__stdcall
LoadMenuIndirectA(
     const MENUTEMPLATEA *lpMenuTemplate);
__declspec(dllimport)
HMENU
__stdcall
LoadMenuIndirectW(
     const MENUTEMPLATEW *lpMenuTemplate);




#line 5445 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HMENU
__stdcall
GetMenu(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
SetMenu(
     HWND hWnd,
     HMENU hMenu);

__declspec(dllimport)
BOOL
__stdcall
ChangeMenuA(
     HMENU hMenu,
     UINT cmd,
     LPCSTR lpszNewItem,
     UINT cmdInsert,
     UINT flags);
__declspec(dllimport)
BOOL
__stdcall
ChangeMenuW(
     HMENU hMenu,
     UINT cmd,
     LPCWSTR lpszNewItem,
     UINT cmdInsert,
     UINT flags);




#line 5482 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
HiliteMenuItem(
     HWND hWnd,
     HMENU hMenu,
     UINT uIDHiliteItem,
     UINT uHilite);

__declspec(dllimport)
int
__stdcall
GetMenuStringA(
     HMENU hMenu,
     UINT uIDItem,
     LPSTR lpString,
     int nMaxCount,
     UINT uFlag);
__declspec(dllimport)
int
__stdcall
GetMenuStringW(
     HMENU hMenu,
     UINT uIDItem,
     LPWSTR lpString,
     int nMaxCount,
     UINT uFlag);




#line 5515 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
UINT
__stdcall
GetMenuState(
     HMENU hMenu,
     UINT uId,
     UINT uFlags);

__declspec(dllimport)
BOOL
__stdcall
DrawMenuBar(
     HWND hWnd);




#line 5534 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
HMENU
__stdcall
GetSystemMenu(
     HWND hWnd,
     BOOL bRevert);


__declspec(dllimport)
HMENU
__stdcall
CreateMenu(
    void);

__declspec(dllimport)
HMENU
__stdcall
CreatePopupMenu(
    void);

__declspec(dllimport)
BOOL
__stdcall
DestroyMenu(
     HMENU hMenu);

__declspec(dllimport)
DWORD
__stdcall
CheckMenuItem(
     HMENU hMenu,
     UINT uIDCheckItem,
     UINT uCheck);

__declspec(dllimport)
BOOL
__stdcall
EnableMenuItem(
     HMENU hMenu,
     UINT uIDEnableItem,
     UINT uEnable);

__declspec(dllimport)
HMENU
__stdcall
GetSubMenu(
     HMENU hMenu,
     int nPos);

__declspec(dllimport)
UINT
__stdcall
GetMenuItemID(
     HMENU hMenu,
     int nPos);

__declspec(dllimport)
int
__stdcall
GetMenuItemCount(
     HMENU hMenu);

__declspec(dllimport)
BOOL
__stdcall
InsertMenuA(
     HMENU hMenu,
     UINT uPosition,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCSTR lpNewItem
    );
__declspec(dllimport)
BOOL
__stdcall
InsertMenuW(
     HMENU hMenu,
     UINT uPosition,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCWSTR lpNewItem
    );




#line 5623 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
AppendMenuA(
     HMENU hMenu,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCSTR lpNewItem
    );
__declspec(dllimport)
BOOL
__stdcall
AppendMenuW(
     HMENU hMenu,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCWSTR lpNewItem
    );




#line 5647 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
ModifyMenuA(
     HMENU hMnu,
     UINT uPosition,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCSTR lpNewItem
    );
__declspec(dllimport)
BOOL
__stdcall
ModifyMenuW(
     HMENU hMnu,
     UINT uPosition,
     UINT uFlags,
     UINT_PTR uIDNewItem,
     LPCWSTR lpNewItem
    );




#line 5673 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall RemoveMenu(
     HMENU hMenu,
     UINT uPosition,
     UINT uFlags);

__declspec(dllimport)
BOOL
__stdcall
DeleteMenu(
     HMENU hMenu,
     UINT uPosition,
     UINT uFlags);

__declspec(dllimport)
BOOL
__stdcall
SetMenuItemBitmaps(
     HMENU hMenu,
     UINT uPosition,
     UINT uFlags,
     HBITMAP hBitmapUnchecked,
     HBITMAP hBitmapChecked);

__declspec(dllimport)
LONG
__stdcall
GetMenuCheckMarkDimensions(
    void);

__declspec(dllimport)
BOOL
__stdcall
TrackPopupMenu(
     HMENU hMenu,
     UINT uFlags,
     int x,
     int y,
     int nReserved,
     HWND hWnd,
     const RECT *prcRect);








typedef struct tagTPMPARAMS
{
    UINT    cbSize;     
    RECT    rcExclude;  
}   TPMPARAMS;
typedef TPMPARAMS  *LPTPMPARAMS;

__declspec(dllimport)
BOOL
__stdcall
TrackPopupMenuEx(
     HMENU,
     UINT,
     int,
     int,
     HWND,
     LPTPMPARAMS);
#line 5742 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















typedef struct tagMENUINFO
{
    DWORD   cbSize;
    DWORD   fMask;
    DWORD   dwStyle;
    UINT    cyMax;
    HBRUSH  hbrBack;
    DWORD   dwContextHelpID;
    ULONG_PTR dwMenuData;
}   MENUINFO,  *LPMENUINFO;
typedef MENUINFO const  *LPCMENUINFO;

__declspec(dllimport)
BOOL
__stdcall
GetMenuInfo(
     HMENU,
     LPMENUINFO);

__declspec(dllimport)
BOOL
__stdcall
SetMenuInfo(
     HMENU,
     LPCMENUINFO);

__declspec(dllimport)
BOOL
__stdcall
EndMenu(
        void);







typedef struct tagMENUGETOBJECTINFO
{
    DWORD dwFlags;
    UINT uPos;
    HMENU hmenu;
    PVOID riid;
    PVOID pvObj;
} MENUGETOBJECTINFO, * PMENUGETOBJECTINFO;












#line 5818 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 5827 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















#line 5845 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


typedef struct tagMENUITEMINFOA
{
    UINT     cbSize;
    UINT     fMask;
    UINT     fType;         
    UINT     fState;        
    UINT     wID;           
    HMENU    hSubMenu;      
    HBITMAP  hbmpChecked;   
    HBITMAP  hbmpUnchecked; 
    ULONG_PTR dwItemData;   
    LPSTR    dwTypeData;    
    UINT     cch;           

    HBITMAP  hbmpItem;      
#line 5863 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
}   MENUITEMINFOA,  *LPMENUITEMINFOA;
typedef struct tagMENUITEMINFOW
{
    UINT     cbSize;
    UINT     fMask;
    UINT     fType;         
    UINT     fState;        
    UINT     wID;           
    HMENU    hSubMenu;      
    HBITMAP  hbmpChecked;   
    HBITMAP  hbmpUnchecked; 
    ULONG_PTR dwItemData;   
    LPWSTR   dwTypeData;    
    UINT     cch;           

    HBITMAP  hbmpItem;      
#line 5880 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
}   MENUITEMINFOW,  *LPMENUITEMINFOW;




typedef MENUITEMINFOA MENUITEMINFO;
typedef LPMENUITEMINFOA LPMENUITEMINFO;
#line 5888 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
typedef MENUITEMINFOA const  *LPCMENUITEMINFOA;
typedef MENUITEMINFOW const  *LPCMENUITEMINFOW;



typedef LPCMENUITEMINFOA LPCMENUITEMINFO;
#line 5895 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
InsertMenuItemA(
     HMENU,
     UINT,
     BOOL,
     LPCMENUITEMINFOA
    );
__declspec(dllimport)
BOOL
__stdcall
InsertMenuItemW(
     HMENU,
     UINT,
     BOOL,
     LPCMENUITEMINFOW
    );




#line 5920 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetMenuItemInfoA(
     HMENU,
     UINT,
     BOOL,
      LPMENUITEMINFOA
    );
__declspec(dllimport)
BOOL
__stdcall
GetMenuItemInfoW(
     HMENU,
     UINT,
     BOOL,
      LPMENUITEMINFOW
    );




#line 5944 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetMenuItemInfoA(
     HMENU,
     UINT,
     BOOL,
     LPCMENUITEMINFOA
    );
__declspec(dllimport)
BOOL
__stdcall
SetMenuItemInfoW(
     HMENU,
     UINT,
     BOOL,
     LPCMENUITEMINFOW
    );




#line 5968 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





__declspec(dllimport) UINT    __stdcall GetMenuDefaultItem(  HMENU hMenu,  UINT fByPos,  UINT gmdiFlags);
__declspec(dllimport) BOOL    __stdcall SetMenuDefaultItem(  HMENU hMenu,  UINT uItem,   UINT fByPos);

__declspec(dllimport) BOOL    __stdcall GetMenuItemRect(  HWND hWnd,  HMENU hMenu,  UINT uItem,  LPRECT lprcItem);
__declspec(dllimport) int     __stdcall MenuItemFromPoint(  HWND hWnd,  HMENU hMenu,  POINT ptScreen);
#line 5979 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


















#line 5998 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 6007 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 6010 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 6011 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 6014 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







typedef struct tagDROPSTRUCT
{
    HWND    hwndSource;
    HWND    hwndSink;
    DWORD   wFmt;
    ULONG_PTR dwData;
    POINT   ptDrop;
    DWORD   dwControlData;
} DROPSTRUCT, *PDROPSTRUCT, *LPDROPSTRUCT;











__declspec(dllimport)
DWORD
__stdcall
DragObject(
     HWND,
     HWND,
     UINT,
     ULONG_PTR,
     HCURSOR);

__declspec(dllimport)
BOOL
__stdcall
DragDetect(
     HWND,
     POINT);
#line 6058 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
DrawIcon(
     HDC hDC,
     int X,
     int Y,
     HICON hIcon);


































#line 6102 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 6103 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagDRAWTEXTPARAMS
{
    UINT    cbSize;
    int     iTabLength;
    int     iLeftMargin;
    int     iRightMargin;
    UINT    uiLengthDrawn;
} DRAWTEXTPARAMS,  *LPDRAWTEXTPARAMS;
#line 6113 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
int
__stdcall
DrawTextA(
     HDC hDC,
     LPCSTR lpString,
     int nCount,
      LPRECT lpRect,
     UINT uFormat);
__declspec(dllimport)
int
__stdcall
DrawTextW(
     HDC hDC,
     LPCWSTR lpString,
     int nCount,
      LPRECT lpRect,
     UINT uFormat);




#line 6138 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
int
__stdcall
DrawTextExA(
     HDC,
      LPSTR,
     int,
      LPRECT,
     UINT,
     LPDRAWTEXTPARAMS);
__declspec(dllimport)
int
__stdcall
DrawTextExW(
     HDC,
      LPWSTR,
     int,
      LPRECT,
     UINT,
     LPDRAWTEXTPARAMS);




#line 6166 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 6167 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 6169 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GrayStringA(
     HDC hDC,
     HBRUSH hBrush,
     GRAYSTRINGPROC lpOutputFunc,
     LPARAM lpData,
     int nCount,
     int X,
     int Y,
     int nWidth,
     int nHeight);
__declspec(dllimport)
BOOL
__stdcall
GrayStringW(
     HDC hDC,
     HBRUSH hBrush,
     GRAYSTRINGPROC lpOutputFunc,
     LPARAM lpData,
     int nCount,
     int X,
     int Y,
     int nWidth,
     int nHeight);




#line 6201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


















#line 6220 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
DrawStateA(
     HDC,
     HBRUSH,
     DRAWSTATEPROC,
     LPARAM,
     WPARAM,
     int,
     int,
     int,
     int,
     UINT);
__declspec(dllimport)
BOOL
__stdcall
DrawStateW(
     HDC,
     HBRUSH,
     DRAWSTATEPROC,
     LPARAM,
     WPARAM,
     int,
     int,
     int,
     int,
     UINT);




#line 6255 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 6256 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LONG
__stdcall
TabbedTextOutA(
     HDC hDC,
     int X,
     int Y,
     LPCSTR lpString,
     int nCount,
     int nTabPositions,
     const INT *lpnTabStopPositions,
     int nTabOrigin);
__declspec(dllimport)
LONG
__stdcall
TabbedTextOutW(
     HDC hDC,
     int X,
     int Y,
     LPCWSTR lpString,
     int nCount,
     int nTabPositions,
     const INT *lpnTabStopPositions,
     int nTabOrigin);




#line 6286 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
DWORD
__stdcall
GetTabbedTextExtentA(
     HDC hDC,
     LPCSTR lpString,
     int nCount,
     int nTabPositions,
     const INT *lpnTabStopPositions);
__declspec(dllimport)
DWORD
__stdcall
GetTabbedTextExtentW(
     HDC hDC,
     LPCWSTR lpString,
     int nCount,
     int nTabPositions,
     const INT *lpnTabStopPositions);




#line 6310 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UpdateWindow(
     HWND hWnd);

__declspec(dllimport)
HWND
__stdcall
SetActiveWindow(
     HWND hWnd);

__declspec(dllimport)
HWND
__stdcall
GetForegroundWindow(
    void);


__declspec(dllimport)
BOOL
__stdcall
PaintDesktop(
     HDC hdc);

#line 6337 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetForegroundWindow(
     HWND hWnd);



















#line 6363 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
WindowFromDC(
     HDC hDC);

__declspec(dllimport)
HDC
__stdcall
GetDC(
     HWND hWnd);

__declspec(dllimport)
HDC
__stdcall
GetDCEx(
     HWND hWnd,
     HRGN hrgnClip,
     DWORD flags);


















__declspec(dllimport)
HDC
__stdcall
GetWindowDC(
     HWND hWnd);

__declspec(dllimport)
int
__stdcall
ReleaseDC(
     HWND hWnd,
     HDC hDC);

__declspec(dllimport)
HDC
__stdcall
BeginPaint(
     HWND hWnd,
     LPPAINTSTRUCT lpPaint);

__declspec(dllimport)
BOOL
__stdcall
EndPaint(
     HWND hWnd,
     const PAINTSTRUCT *lpPaint);

__declspec(dllimport)
BOOL
__stdcall
GetUpdateRect(
     HWND hWnd,
     LPRECT lpRect,
     BOOL bErase);

__declspec(dllimport)
int
__stdcall
GetUpdateRgn(
     HWND hWnd,
     HRGN hRgn,
     BOOL bErase);

__declspec(dllimport)
int
__stdcall
SetWindowRgn(
     HWND hWnd,
     HRGN hRgn,
     BOOL bRedraw);


__declspec(dllimport)
int
__stdcall
GetWindowRgn(
     HWND hWnd,
     HRGN hRgn);










#line 6470 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
ExcludeUpdateRgn(
     HDC hDC,
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
InvalidateRect(
     HWND hWnd,
     const RECT *lpRect,
     BOOL bErase);

__declspec(dllimport)
BOOL
__stdcall
ValidateRect(
     HWND hWnd,
     const RECT *lpRect);

__declspec(dllimport)
BOOL
__stdcall
InvalidateRgn(
     HWND hWnd,
     HRGN hRgn,
     BOOL bErase);

__declspec(dllimport)
BOOL
__stdcall
ValidateRgn(
     HWND hWnd,
     HRGN hRgn);


__declspec(dllimport)
BOOL
__stdcall
RedrawWindow(
     HWND hWnd,
     const RECT *lprcUpdate,
     HRGN hrgnUpdate,
     UINT flags);


























__declspec(dllimport)
BOOL
__stdcall
LockWindowUpdate(
     HWND hWndLock);

__declspec(dllimport)
BOOL
__stdcall
ScrollWindow(
     HWND hWnd,
     int XAmount,
     int YAmount,
     const RECT *lpRect,
     const RECT *lpClipRect);

__declspec(dllimport)
BOOL
__stdcall
ScrollDC(
     HDC hDC,
     int dx,
     int dy,
     const RECT *lprcScroll,
     const RECT *lprcClip,
     HRGN hrgnUpdate,
     LPRECT lprcUpdate);

__declspec(dllimport)
int
__stdcall
ScrollWindowEx(
     HWND hWnd,
     int dx,
     int dy,
     const RECT *prcScroll,
     const RECT *prcClip,
     HRGN hrgnUpdate,
     LPRECT prcUpdate,
     UINT flags);






#line 6590 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
int
__stdcall
SetScrollPos(
     HWND hWnd,
     int nBar,
     int nPos,
     BOOL bRedraw);

__declspec(dllimport)
int
__stdcall
GetScrollPos(
     HWND hWnd,
     int nBar);

__declspec(dllimport)
BOOL
__stdcall
SetScrollRange(
     HWND hWnd,
     int nBar,
     int nMinPos,
     int nMaxPos,
     BOOL bRedraw);

__declspec(dllimport)
BOOL
__stdcall
GetScrollRange(
     HWND hWnd,
     int nBar,
     LPINT lpMinPos,
     LPINT lpMaxPos);

__declspec(dllimport)
BOOL
__stdcall
ShowScrollBar(
     HWND hWnd,
     int wBar,
     BOOL bShow);

__declspec(dllimport)
BOOL
__stdcall
EnableScrollBar(
     HWND hWnd,
     UINT wSBflags,
     UINT wArrows);


















#line 6662 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetPropA(
     HWND hWnd,
     LPCSTR lpString,
     HANDLE hData);
__declspec(dllimport)
BOOL
__stdcall
SetPropW(
     HWND hWnd,
     LPCWSTR lpString,
     HANDLE hData);




#line 6682 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HANDLE
__stdcall
GetPropA(
     HWND hWnd,
     LPCSTR lpString);
__declspec(dllimport)
HANDLE
__stdcall
GetPropW(
     HWND hWnd,
     LPCWSTR lpString);




#line 6700 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HANDLE
__stdcall
RemovePropA(
     HWND hWnd,
     LPCSTR lpString);
__declspec(dllimport)
HANDLE
__stdcall
RemovePropW(
     HWND hWnd,
     LPCWSTR lpString);




#line 6718 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
EnumPropsExA(
     HWND hWnd,
     PROPENUMPROCEXA lpEnumFunc,
     LPARAM lParam);
__declspec(dllimport)
int
__stdcall
EnumPropsExW(
     HWND hWnd,
     PROPENUMPROCEXW lpEnumFunc,
     LPARAM lParam);




#line 6738 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
EnumPropsA(
     HWND hWnd,
     PROPENUMPROCA lpEnumFunc);
__declspec(dllimport)
int
__stdcall
EnumPropsW(
     HWND hWnd,
     PROPENUMPROCW lpEnumFunc);




#line 6756 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetWindowTextA(
     HWND hWnd,
     LPCSTR lpString);
__declspec(dllimport)
BOOL
__stdcall
SetWindowTextW(
     HWND hWnd,
     LPCWSTR lpString);




#line 6774 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
GetWindowTextA(
     HWND hWnd,
     LPSTR lpString,
     int nMaxCount);
__declspec(dllimport)
int
__stdcall
GetWindowTextW(
     HWND hWnd,
     LPWSTR lpString,
     int nMaxCount);




#line 6794 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
GetWindowTextLengthA(
     HWND hWnd);
__declspec(dllimport)
int
__stdcall
GetWindowTextLengthW(
     HWND hWnd);




#line 6810 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetClientRect(
     HWND hWnd,
     LPRECT lpRect);

__declspec(dllimport)
BOOL
__stdcall
GetWindowRect(
     HWND hWnd,
     LPRECT lpRect);

__declspec(dllimport)
BOOL
__stdcall
AdjustWindowRect(
      LPRECT lpRect,
     DWORD dwStyle,
     BOOL bMenu);

__declspec(dllimport)
BOOL
__stdcall
AdjustWindowRectEx(
      LPRECT lpRect,
     DWORD dwStyle,
     BOOL bMenu,
     DWORD dwExStyle);





typedef struct tagHELPINFO      
{
    UINT    cbSize;             
    int     iContextType;       
    int     iCtrlId;            
    HANDLE  hItemHandle;        
    DWORD_PTR dwContextId;      
    POINT   MousePos;           
}  HELPINFO,  *LPHELPINFO;

__declspec(dllimport)
BOOL
__stdcall
SetWindowContextHelpId(
     HWND,
     DWORD);

__declspec(dllimport)
DWORD
__stdcall
GetWindowContextHelpId(
     HWND);

__declspec(dllimport)
BOOL
__stdcall
SetMenuContextHelpId(
     HMENU,
     DWORD);

__declspec(dllimport)
DWORD
__stdcall
GetMenuContextHelpId(
     HMENU);

#line 6883 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 6899 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 6911 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 6921 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 6928 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 6940 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















__declspec(dllimport)
int
__stdcall
MessageBoxA(
     HWND hWnd,
     LPCSTR lpText,
     LPCSTR lpCaption,
     UINT uType);
__declspec(dllimport)
int
__stdcall
MessageBoxW(
     HWND hWnd,
     LPCWSTR lpText,
     LPCWSTR lpCaption,
     UINT uType);




#line 6977 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
MessageBoxExA(
     HWND hWnd,
     LPCSTR lpText,
     LPCSTR lpCaption,
     UINT uType,
     WORD wLanguageId);
__declspec(dllimport)
int
__stdcall
MessageBoxExW(
     HWND hWnd,
     LPCWSTR lpText,
     LPCWSTR lpCaption,
     UINT uType,
     WORD wLanguageId);




#line 7001 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



typedef void (__stdcall *MSGBOXCALLBACK)(LPHELPINFO lpHelpInfo);

typedef struct tagMSGBOXPARAMSA
{
    UINT        cbSize;
    HWND        hwndOwner;
    HINSTANCE   hInstance;
    LPCSTR      lpszText;
    LPCSTR      lpszCaption;
    DWORD       dwStyle;
    LPCSTR      lpszIcon;
    DWORD_PTR   dwContextHelpId;
    MSGBOXCALLBACK      lpfnMsgBoxCallback;
    DWORD       dwLanguageId;
} MSGBOXPARAMSA, *PMSGBOXPARAMSA, *LPMSGBOXPARAMSA;
typedef struct tagMSGBOXPARAMSW
{
    UINT        cbSize;
    HWND        hwndOwner;
    HINSTANCE   hInstance;
    LPCWSTR     lpszText;
    LPCWSTR     lpszCaption;
    DWORD       dwStyle;
    LPCWSTR     lpszIcon;
    DWORD_PTR   dwContextHelpId;
    MSGBOXCALLBACK      lpfnMsgBoxCallback;
    DWORD       dwLanguageId;
} MSGBOXPARAMSW, *PMSGBOXPARAMSW, *LPMSGBOXPARAMSW;





typedef MSGBOXPARAMSA MSGBOXPARAMS;
typedef PMSGBOXPARAMSA PMSGBOXPARAMS;
typedef LPMSGBOXPARAMSA LPMSGBOXPARAMS;
#line 7041 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
MessageBoxIndirectA(
     const MSGBOXPARAMSA *);
__declspec(dllimport)
int
__stdcall
MessageBoxIndirectW(
     const MSGBOXPARAMSW *);




#line 7057 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 7058 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
MessageBeep(
     UINT uType);

#line 7067 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
ShowCursor(
     BOOL bShow);

__declspec(dllimport)
BOOL
__stdcall
SetCursorPos(
     int X,
     int Y);

__declspec(dllimport)
HCURSOR
__stdcall
SetCursor(
     HCURSOR hCursor);

__declspec(dllimport)
BOOL
__stdcall
GetCursorPos(
     LPPOINT lpPoint);

__declspec(dllimport)
BOOL
__stdcall
ClipCursor(
     const RECT *lpRect);

__declspec(dllimport)
BOOL
__stdcall
GetClipCursor(
     LPRECT lpRect);

__declspec(dllimport)
HCURSOR
__stdcall
GetCursor(
    void);

__declspec(dllimport)
BOOL
__stdcall
CreateCaret(
     HWND hWnd,
     HBITMAP hBitmap,
     int nWidth,
     int nHeight);

__declspec(dllimport)
UINT
__stdcall
GetCaretBlinkTime(
    void);

__declspec(dllimport)
BOOL
__stdcall
SetCaretBlinkTime(
     UINT uMSeconds);

__declspec(dllimport)
BOOL
__stdcall
DestroyCaret(
    void);

__declspec(dllimport)
BOOL
__stdcall
HideCaret(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
ShowCaret(
     HWND hWnd);

__declspec(dllimport)
BOOL
__stdcall
SetCaretPos(
     int X,
     int Y);

__declspec(dllimport)
BOOL
__stdcall
GetCaretPos(
     LPPOINT lpPoint);

__declspec(dllimport)
BOOL
__stdcall
ClientToScreen(
     HWND hWnd,
      LPPOINT lpPoint);

__declspec(dllimport)
BOOL
__stdcall
ScreenToClient(
     HWND hWnd,
      LPPOINT lpPoint);

__declspec(dllimport)
int
__stdcall
MapWindowPoints(
     HWND hWndFrom,
     HWND hWndTo,
      LPPOINT lpPoints,
     UINT cPoints);

__declspec(dllimport)
HWND
__stdcall
WindowFromPoint(
     POINT Point);

__declspec(dllimport)
HWND
__stdcall
ChildWindowFromPoint(
     HWND hWndParent,
     POINT Point);







__declspec(dllimport) HWND    __stdcall ChildWindowFromPointEx(  HWND,  POINT,  UINT);
#line 7207 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










































#line 7250 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 7259 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 7260 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 7269 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
DWORD
__stdcall
GetSysColor(
     int nIndex);


__declspec(dllimport)
HBRUSH
__stdcall
GetSysColorBrush(
     int nIndex);


#line 7286 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetSysColors(
     int cElements,
     const INT * lpaElements,
     const COLORREF * lpaRgbValues);

#line 7296 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
DrawFocusRect(
     HDC hDC,
     const RECT * lprc);

__declspec(dllimport)
int
__stdcall
FillRect(
     HDC hDC,
     const RECT *lprc,
     HBRUSH hbr);

__declspec(dllimport)
int
__stdcall
FrameRect(
     HDC hDC,
     const RECT *lprc,
     HBRUSH hbr);

__declspec(dllimport)
BOOL
__stdcall
InvertRect(
     HDC hDC,
     const RECT *lprc);

__declspec(dllimport)
BOOL
__stdcall
SetRect(
     LPRECT lprc,
     int xLeft,
     int yTop,
     int xRight,
     int yBottom);

__declspec(dllimport)
BOOL
__stdcall
SetRectEmpty(
     LPRECT lprc);

__declspec(dllimport)
BOOL
__stdcall
CopyRect(
     LPRECT lprcDst,
     const RECT *lprcSrc);

__declspec(dllimport)
BOOL
__stdcall
InflateRect(
      LPRECT lprc,
     int dx,
     int dy);

__declspec(dllimport)
BOOL
__stdcall
IntersectRect(
     LPRECT lprcDst,
     const RECT *lprcSrc1,
     const RECT *lprcSrc2);

__declspec(dllimport)
BOOL
__stdcall
UnionRect(
     LPRECT lprcDst,
     const RECT *lprcSrc1,
     const RECT *lprcSrc2);

__declspec(dllimport)
BOOL
__stdcall
SubtractRect(
     LPRECT lprcDst,
     const RECT *lprcSrc1,
     const RECT *lprcSrc2);

__declspec(dllimport)
BOOL
__stdcall
OffsetRect(
      LPRECT lprc,
     int dx,
     int dy);

__declspec(dllimport)
BOOL
__stdcall
IsRectEmpty(
     const RECT *lprc);

__declspec(dllimport)
BOOL
__stdcall
EqualRect(
     const RECT *lprc1,
     const RECT *lprc2);

__declspec(dllimport)
BOOL
__stdcall
PtInRect(
     const RECT *lprc,
     POINT pt);



__declspec(dllimport)
WORD
__stdcall
GetWindowWord(
     HWND hWnd,
     int nIndex);

__declspec(dllimport)
WORD
__stdcall
SetWindowWord(
     HWND hWnd,
     int nIndex,
     WORD wNewWord);

__declspec(dllimport)
LONG
__stdcall
GetWindowLongA(
     HWND hWnd,
     int nIndex);
__declspec(dllimport)
LONG
__stdcall
GetWindowLongW(
     HWND hWnd,
     int nIndex);




#line 7444 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LONG
__stdcall
SetWindowLongA(
     HWND hWnd,
     int nIndex,
     LONG dwNewLong);
__declspec(dllimport)
LONG
__stdcall
SetWindowLongW(
     HWND hWnd,
     int nIndex,
     LONG dwNewLong);




#line 7464 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















































#line 7514 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 7522 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 7524 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
WORD
__stdcall
GetClassWord(
     HWND hWnd,
     int nIndex);

__declspec(dllimport)
WORD
__stdcall
SetClassWord(
     HWND hWnd,
     int nIndex,
     WORD wNewWord);

__declspec(dllimport)
DWORD
__stdcall
GetClassLongA(
     HWND hWnd,
     int nIndex);
__declspec(dllimport)
DWORD
__stdcall
GetClassLongW(
     HWND hWnd,
     int nIndex);




#line 7557 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
DWORD
__stdcall
SetClassLongA(
     HWND hWnd,
     int nIndex,
     LONG dwNewLong);
__declspec(dllimport)
DWORD
__stdcall
SetClassLongW(
     HWND hWnd,
     int nIndex,
     LONG dwNewLong);




#line 7577 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

















































#line 7627 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 7635 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 7637 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 7639 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
GetProcessDefaultLayout(
     DWORD *pdwDefaultLayout);

__declspec(dllimport)
BOOL
__stdcall
SetProcessDefaultLayout(
     DWORD dwDefaultLayout);
#line 7653 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
GetDesktopWindow(
    void);


__declspec(dllimport)
HWND
__stdcall
GetParent(
     HWND hWnd);

__declspec(dllimport)
HWND
__stdcall
SetParent(
     HWND hWndChild,
     HWND hWndNewParent);

__declspec(dllimport)
BOOL
__stdcall
EnumChildWindows(
     HWND hWndParent,
     WNDENUMPROC lpEnumFunc,
     LPARAM lParam);

__declspec(dllimport)
HWND
__stdcall
FindWindowA(
     LPCSTR lpClassName,
     LPCSTR lpWindowName);
__declspec(dllimport)
HWND
__stdcall
FindWindowW(
     LPCWSTR lpClassName,
     LPCWSTR lpWindowName);




#line 7699 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport) HWND    __stdcall FindWindowExA(  HWND,  HWND,  LPCSTR,  LPCSTR);
__declspec(dllimport) HWND    __stdcall FindWindowExW(  HWND,  HWND,  LPCWSTR,  LPCWSTR);




#line 7708 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 7710 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
EnumWindows(
     WNDENUMPROC lpEnumFunc,
     LPARAM lParam);

__declspec(dllimport)
BOOL
__stdcall
EnumThreadWindows(
     DWORD dwThreadId,
     WNDENUMPROC lpfn,
     LPARAM lParam);



__declspec(dllimport)
int
__stdcall
GetClassNameA(
     HWND hWnd,
     LPSTR lpClassName,
     int nMaxCount);
__declspec(dllimport)
int
__stdcall
GetClassNameW(
     HWND hWnd,
     LPWSTR lpClassName,
     int nMaxCount);




#line 7748 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
GetTopWindow(
     HWND hWnd);





__declspec(dllimport)
DWORD
__stdcall
GetWindowThreadProcessId(
     HWND hWnd,
     LPDWORD lpdwProcessId);








#line 7774 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
HWND
__stdcall
GetLastActivePopup(
     HWND hWnd);












#line 7796 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 7799 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HWND
__stdcall
GetWindow(
     HWND hWnd,
     UINT uCmd);







__declspec(dllimport)
HHOOK
__stdcall
SetWindowsHookA(
     int nFilterType,
     HOOKPROC pfnFilterProc);
__declspec(dllimport)
HHOOK
__stdcall
SetWindowsHookW(
     int nFilterType,
     HOOKPROC pfnFilterProc);




#line 7830 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





















#line 7852 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UnhookWindowsHook(
     int nCode,
     HOOKPROC pfnFilterProc);

__declspec(dllimport)
HHOOK
__stdcall
SetWindowsHookExA(
     int idHook,
     HOOKPROC lpfn,
     HINSTANCE hmod,
     DWORD dwThreadId);
__declspec(dllimport)
HHOOK
__stdcall
SetWindowsHookExW(
     int idHook,
     HOOKPROC lpfn,
     HINSTANCE hmod,
     DWORD dwThreadId);




#line 7881 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
UnhookWindowsHookEx(
     HHOOK hhk);

__declspec(dllimport)
LRESULT
__stdcall
CallNextHookEx(
     HHOOK hhk,
     int nCode,
     WPARAM wParam,
     LPARAM lParam);










#line 7907 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 7908 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








































#line 7949 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 7954 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 7959 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






















#line 7982 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
BOOL
__stdcall
CheckMenuRadioItem(
     HMENU,
     UINT,
     UINT,
     UINT,
     UINT);
#line 7996 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct {
    WORD versionNumber;
    WORD offset;
} MENUITEMTEMPLATEHEADER, *PMENUITEMTEMPLATEHEADER;

typedef struct {        
    WORD mtOption;
    WORD mtID;
    WCHAR mtString[1];
} MENUITEMTEMPLATE, *PMENUITEMTEMPLATE;


#line 8013 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



























#line 8041 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 8049 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





__declspec(dllimport)
HBITMAP
__stdcall
LoadBitmapA(
     HINSTANCE hInstance,
     LPCSTR lpBitmapName);
__declspec(dllimport)
HBITMAP
__stdcall
LoadBitmapW(
     HINSTANCE hInstance,
     LPCWSTR lpBitmapName);




#line 8071 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HCURSOR
__stdcall
LoadCursorA(
     HINSTANCE hInstance,
     LPCSTR lpCursorName);
__declspec(dllimport)
HCURSOR
__stdcall
LoadCursorW(
     HINSTANCE hInstance,
     LPCWSTR lpCursorName);




#line 8089 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HCURSOR
__stdcall
LoadCursorFromFileA(
     LPCSTR lpFileName);
__declspec(dllimport)
HCURSOR
__stdcall
LoadCursorFromFileW(
     LPCWSTR lpFileName);




#line 8105 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HCURSOR
__stdcall
CreateCursor(
     HINSTANCE hInst,
     int xHotSpot,
     int yHotSpot,
     int nWidth,
     int nHeight,
     const void *pvANDPlane,
     const void *pvXORPlane);

__declspec(dllimport)
BOOL
__stdcall
DestroyCursor(
     HCURSOR hCursor);









#line 8133 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



















#line 8153 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 8157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
SetSystemCursor(
     HCURSOR hcur,
     DWORD   id);

typedef struct _ICONINFO {
    BOOL    fIcon;
    DWORD   xHotspot;
    DWORD   yHotspot;
    HBITMAP hbmMask;
    HBITMAP hbmColor;
} ICONINFO;
typedef ICONINFO *PICONINFO;

__declspec(dllimport)
HICON
__stdcall
LoadIconA(
     HINSTANCE hInstance,
     LPCSTR lpIconName);
__declspec(dllimport)
HICON
__stdcall
LoadIconW(
     HINSTANCE hInstance,
     LPCWSTR lpIconName);




#line 8191 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
HICON
__stdcall
CreateIcon(
     HINSTANCE hInstance,
     int nWidth,
     int nHeight,
     BYTE cPlanes,
     BYTE cBitsPixel,
     const BYTE *lpbANDbits,
     const BYTE *lpbXORbits);

__declspec(dllimport)
BOOL
__stdcall
DestroyIcon(
     HICON hIcon);

__declspec(dllimport)
int
__stdcall
LookupIconIdFromDirectory(
     PBYTE presbits,
     BOOL fIcon);


__declspec(dllimport)
int
__stdcall
LookupIconIdFromDirectoryEx(
     PBYTE presbits,
     BOOL  fIcon,
     int   cxDesired,
     int   cyDesired,
     UINT  Flags);
#line 8229 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HICON
__stdcall
CreateIconFromResource(
     PBYTE presbits,
     DWORD dwResSize,
     BOOL fIcon,
     DWORD dwVer);


__declspec(dllimport)
HICON
__stdcall
CreateIconFromResourceEx(
     PBYTE presbits,
     DWORD dwResSize,
     BOOL  fIcon,
     DWORD dwVer,
     int   cxDesired,
     int   cyDesired,
     UINT  Flags);


typedef struct tagCURSORSHAPE
{
    int     xHotSpot;
    int     yHotSpot;
    int     cx;
    int     cy;
    int     cbWidth;
    BYTE    Planes;
    BYTE    BitsPixel;
} CURSORSHAPE,  *LPCURSORSHAPE;
#line 8264 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





















__declspec(dllimport)
HANDLE
__stdcall
LoadImageA(
     HINSTANCE,
     LPCSTR,
     UINT,
     int,
     int,
     UINT);
__declspec(dllimport)
HANDLE
__stdcall
LoadImageW(
     HINSTANCE,
     LPCWSTR,
     UINT,
     int,
     int,
     UINT);




#line 8310 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HANDLE
__stdcall
CopyImage(
     HANDLE,
     UINT,
     int,
     int,
     UINT);








#line 8329 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport) BOOL __stdcall DrawIconEx(  HDC hdc,  int xLeft,  int yTop,
               HICON hIcon,  int cxWidth,  int cyWidth,
               UINT istepIfAniCur,  HBRUSH hbrFlickerFreeDraw,  UINT diFlags);
#line 8334 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
HICON
__stdcall
CreateIconIndirect(
     PICONINFO piconinfo);

__declspec(dllimport)
HICON
__stdcall
CopyIcon(
     HICON hIcon);

__declspec(dllimport)
BOOL
__stdcall
GetIconInfo(
     HICON hIcon,
     PICONINFO piconinfo);




#line 8358 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"












































































































#line 8467 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 8468 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 8474 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 8477 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
LoadStringA(
     HINSTANCE hInstance,
     UINT uID,
     LPSTR lpBuffer,
     int nBufferMax);
__declspec(dllimport)
int
__stdcall
LoadStringW(
     HINSTANCE hInstance,
     UINT uID,
     LPWSTR lpBuffer,
     int nBufferMax);




#line 8499 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 8515 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 8520 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 8525 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 8526 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





























#line 8556 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 8559 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















#line 8576 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






#line 8583 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









#line 8593 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"













































#line 8639 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 8644 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 8647 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







































#line 8687 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















#line 8704 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



















#line 8724 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

























#line 8750 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 8753 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 8765 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















#line 8782 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 8784 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"































__declspec(dllimport)
BOOL
__stdcall
IsDialogMessageA(
     HWND hDlg,
     LPMSG lpMsg);
__declspec(dllimport)
BOOL
__stdcall
IsDialogMessageW(
     HWND hDlg,
     LPMSG lpMsg);




#line 8832 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 8834 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
MapDialogRect(
     HWND hDlg,
      LPRECT lpRect);

__declspec(dllimport)
int
__stdcall
DlgDirListA(
     HWND hDlg,
      LPSTR lpPathSpec,
     int nIDListBox,
     int nIDStaticPath,
     UINT uFileType);
__declspec(dllimport)
int
__stdcall
DlgDirListW(
     HWND hDlg,
      LPWSTR lpPathSpec,
     int nIDListBox,
     int nIDStaticPath,
     UINT uFileType);




#line 8865 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















__declspec(dllimport)
BOOL
__stdcall
DlgDirSelectExA(
     HWND hDlg,
     LPSTR lpString,
     int nCount,
     int nIDListBox);
__declspec(dllimport)
BOOL
__stdcall
DlgDirSelectExW(
     HWND hDlg,
     LPWSTR lpString,
     int nCount,
     int nIDListBox);




#line 8901 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
int
__stdcall
DlgDirListComboBoxA(
     HWND hDlg,
      LPSTR lpPathSpec,
     int nIDComboBox,
     int nIDStaticPath,
     UINT uFiletype);
__declspec(dllimport)
int
__stdcall
DlgDirListComboBoxW(
     HWND hDlg,
      LPWSTR lpPathSpec,
     int nIDComboBox,
     int nIDStaticPath,
     UINT uFiletype);




#line 8925 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
DlgDirSelectComboBoxExA(
     HWND hDlg,
     LPSTR lpString,
     int nCount,
     int nIDComboBox);
__declspec(dllimport)
BOOL
__stdcall
DlgDirSelectComboBoxExW(
     HWND hDlg,
     LPWSTR lpString,
     int nCount,
     int nIDComboBox);




#line 8947 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

























#line 8973 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 8981 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


































                                  




























































#line 9077 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 9080 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




#line 9085 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9089 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9091 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9095 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9097 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"























#line 9121 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9125 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"












































#line 9170 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9172 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











































#line 9216 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9217 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9221 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9225 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9227 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9231 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9232 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 9253 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 9256 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"














#line 9271 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



#line 9275 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









typedef struct tagSCROLLINFO
{
    UINT    cbSize;
    UINT    fMask;
    int     nMin;
    int     nMax;
    UINT    nPage;
    int     nPos;
    int     nTrackPos;
}   SCROLLINFO,  *LPSCROLLINFO;
typedef SCROLLINFO const  *LPCSCROLLINFO;

__declspec(dllimport) int     __stdcall SetScrollInfo( HWND,  int,  LPCSCROLLINFO,  BOOL);
__declspec(dllimport) BOOL    __stdcall GetScrollInfo( HWND,  int,   LPSCROLLINFO);

#line 9300 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9301 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9302 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
















#line 9319 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagMDICREATESTRUCTA {
    LPCSTR   szClass;
    LPCSTR   szTitle;
    HANDLE hOwner;
    int x;
    int y;
    int cx;
    int cy;
    DWORD style;
    LPARAM lParam;        
} MDICREATESTRUCTA, *LPMDICREATESTRUCTA;
typedef struct tagMDICREATESTRUCTW {
    LPCWSTR  szClass;
    LPCWSTR  szTitle;
    HANDLE hOwner;
    int x;
    int y;
    int cx;
    int cy;
    DWORD style;
    LPARAM lParam;        
} MDICREATESTRUCTW, *LPMDICREATESTRUCTW;




typedef MDICREATESTRUCTA MDICREATESTRUCT;
typedef LPMDICREATESTRUCTA LPMDICREATESTRUCT;
#line 9349 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagCLIENTCREATESTRUCT {
    HANDLE hWindowMenu;
    UINT idFirstChild;
} CLIENTCREATESTRUCT, *LPCLIENTCREATESTRUCT;

__declspec(dllimport)
LRESULT
__stdcall
DefFrameProcA(
     HWND hWnd,
     HWND hWndMDIClient,
     UINT uMsg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)
LRESULT
__stdcall
DefFrameProcW(
     HWND hWnd,
     HWND hWndMDIClient,
     UINT uMsg,
     WPARAM wParam,
     LPARAM lParam);




#line 9378 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)

LRESULT
__stdcall



#line 9387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefMDIChildProcA(
     HWND hWnd,
     UINT uMsg,
     WPARAM wParam,
     LPARAM lParam);
__declspec(dllimport)

LRESULT
__stdcall



#line 9400 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
DefMDIChildProcW(
     HWND hWnd,
     UINT uMsg,
     WPARAM wParam,
     LPARAM lParam);




#line 9410 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
BOOL
__stdcall
TranslateMDISysAccel(
     HWND hWndClient,
     LPMSG lpMsg);

#line 9421 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
UINT
__stdcall
ArrangeIconicWindows(
     HWND hWnd);

__declspec(dllimport)
HWND
__stdcall
CreateMDIWindowA(
     LPCSTR lpClassName,
     LPCSTR lpWindowName,
     DWORD dwStyle,
     int X,
     int Y,
     int nWidth,
     int nHeight,
     HWND hWndParent,
     HINSTANCE hInstance,
     LPARAM lParam
    );
__declspec(dllimport)
HWND
__stdcall
CreateMDIWindowW(
     LPCWSTR lpClassName,
     LPCWSTR lpWindowName,
     DWORD dwStyle,
     int X,
     int Y,
     int nWidth,
     int nHeight,
     HWND hWndParent,
     HINSTANCE hInstance,
     LPARAM lParam
    );




#line 9463 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport) WORD    __stdcall TileWindows(  HWND hwndParent,  UINT wHow,  const RECT * lpRect,  UINT cKids,  const HWND  * lpKids);
__declspec(dllimport) WORD    __stdcall CascadeWindows(  HWND hwndParent,  UINT wHow,  const RECT * lpRect,  UINT cKids,   const HWND  * lpKids);
#line 9468 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9469 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9471 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





typedef DWORD HELPPOLY;
typedef struct tagMULTIKEYHELPA {

    DWORD  mkSize;


#line 9483 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
    CHAR   mkKeylist;
    CHAR   szKeyphrase[1];
} MULTIKEYHELPA, *PMULTIKEYHELPA, *LPMULTIKEYHELPA;
typedef struct tagMULTIKEYHELPW {

    DWORD  mkSize;


#line 9492 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
    WCHAR  mkKeylist;
    WCHAR  szKeyphrase[1];
} MULTIKEYHELPW, *PMULTIKEYHELPW, *LPMULTIKEYHELPW;





typedef MULTIKEYHELPA MULTIKEYHELP;
typedef PMULTIKEYHELPA PMULTIKEYHELP;
typedef LPMULTIKEYHELPA LPMULTIKEYHELP;
#line 9504 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagHELPWININFOA {
    int  wStructSize;
    int  x;
    int  y;
    int  dx;
    int  dy;
    int  wMax;
    CHAR   rgchMember[2];
} HELPWININFOA, *PHELPWININFOA, *LPHELPWININFOA;
typedef struct tagHELPWININFOW {
    int  wStructSize;
    int  x;
    int  y;
    int  dx;
    int  dy;
    int  wMax;
    WCHAR  rgchMember[2];
} HELPWININFOW, *PHELPWININFOW, *LPHELPWININFOW;





typedef HELPWININFOA HELPWININFO;
typedef PHELPWININFOA PHELPWININFO;
typedef LPHELPWININFOA LPHELPWININFO;
#line 9532 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





































#line 9570 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
BOOL
__stdcall
WinHelpA(
     HWND hWndMain,
     LPCSTR lpszHelp,
     UINT uCommand,
     ULONG_PTR dwData
    );
__declspec(dllimport)
BOOL
__stdcall
WinHelpW(
     HWND hWndMain,
     LPCWSTR lpszHelp,
     UINT uCommand,
     ULONG_PTR dwData
    );




#line 9596 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9598 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"






__declspec(dllimport)
DWORD
__stdcall
GetGuiResources(
     HANDLE hProcess,
     DWORD uiFlags);

#line 9612 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





















































































#line 9698 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 9714 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 9720 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















#line 9736 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 9744 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"










































#line 9787 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"































#line 9819 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 9821 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"












typedef struct tagNONCLIENTMETRICSA
{
    UINT    cbSize;
    int     iBorderWidth;
    int     iScrollWidth;
    int     iScrollHeight;
    int     iCaptionWidth;
    int     iCaptionHeight;
    LOGFONTA lfCaptionFont;
    int     iSmCaptionWidth;
    int     iSmCaptionHeight;
    LOGFONTA lfSmCaptionFont;
    int     iMenuWidth;
    int     iMenuHeight;
    LOGFONTA lfMenuFont;
    LOGFONTA lfStatusFont;
    LOGFONTA lfMessageFont;
}   NONCLIENTMETRICSA, *PNONCLIENTMETRICSA, * LPNONCLIENTMETRICSA;
typedef struct tagNONCLIENTMETRICSW
{
    UINT    cbSize;
    int     iBorderWidth;
    int     iScrollWidth;
    int     iScrollHeight;
    int     iCaptionWidth;
    int     iCaptionHeight;
    LOGFONTW lfCaptionFont;
    int     iSmCaptionWidth;
    int     iSmCaptionHeight;
    LOGFONTW lfSmCaptionFont;
    int     iMenuWidth;
    int     iMenuHeight;
    LOGFONTW lfMenuFont;
    LOGFONTW lfStatusFont;
    LOGFONTW lfMessageFont;
}   NONCLIENTMETRICSW, *PNONCLIENTMETRICSW, * LPNONCLIENTMETRICSW;





typedef NONCLIENTMETRICSA NONCLIENTMETRICS;
typedef PNONCLIENTMETRICSA PNONCLIENTMETRICS;
typedef LPNONCLIENTMETRICSA LPNONCLIENTMETRICS;
#line 9878 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9879 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9880 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"















typedef struct tagMINIMIZEDMETRICS
{
    UINT    cbSize;
    int     iWidth;
    int     iHorzGap;
    int     iVertGap;
    int     iArrange;
}   MINIMIZEDMETRICS, *PMINIMIZEDMETRICS, *LPMINIMIZEDMETRICS;



typedef struct tagICONMETRICSA
{
    UINT    cbSize;
    int     iHorzSpacing;
    int     iVertSpacing;
    int     iTitleWrap;
    LOGFONTA lfFont;
}   ICONMETRICSA, *PICONMETRICSA, *LPICONMETRICSA;
typedef struct tagICONMETRICSW
{
    UINT    cbSize;
    int     iHorzSpacing;
    int     iVertSpacing;
    int     iTitleWrap;
    LOGFONTW lfFont;
}   ICONMETRICSW, *PICONMETRICSW, *LPICONMETRICSW;





typedef ICONMETRICSA ICONMETRICS;
typedef PICONMETRICSA PICONMETRICS;
typedef LPICONMETRICSA LPICONMETRICS;
#line 9931 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9932 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 9933 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagANIMATIONINFO
{
    UINT    cbSize;
    int     iMinAnimate;
}   ANIMATIONINFO, *LPANIMATIONINFO;

typedef struct tagSERIALKEYSA
{
    UINT    cbSize;
    DWORD   dwFlags;
    LPSTR     lpszActivePort;
    LPSTR     lpszPort;
    UINT    iBaudRate;
    UINT    iPortState;
    UINT    iActive;
}   SERIALKEYSA, *LPSERIALKEYSA;
typedef struct tagSERIALKEYSW
{
    UINT    cbSize;
    DWORD   dwFlags;
    LPWSTR    lpszActivePort;
    LPWSTR    lpszPort;
    UINT    iBaudRate;
    UINT    iPortState;
    UINT    iActive;
}   SERIALKEYSW, *LPSERIALKEYSW;




typedef SERIALKEYSA SERIALKEYS;
typedef LPSERIALKEYSA LPSERIALKEYS;
#line 9967 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







typedef struct tagHIGHCONTRASTA
{
    UINT    cbSize;
    DWORD   dwFlags;
    LPSTR   lpszDefaultScheme;
}   HIGHCONTRASTA, *LPHIGHCONTRASTA;
typedef struct tagHIGHCONTRASTW
{
    UINT    cbSize;
    DWORD   dwFlags;
    LPWSTR  lpszDefaultScheme;
}   HIGHCONTRASTW, *LPHIGHCONTRASTW;




typedef HIGHCONTRASTA HIGHCONTRAST;
typedef LPHIGHCONTRASTA LPHIGHCONTRAST;
#line 9993 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\tvout.h"










#pragma once
#line 13 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\tvout.h"





typedef struct _VIDEOPARAMETERS {
    GUID  Guid;                         
    ULONG dwOffset;                     
    ULONG dwCommand;                    
    ULONG dwFlags;                      
    ULONG dwMode;                       
    ULONG dwTVStandard;                 
    ULONG dwAvailableModes;             
    ULONG dwAvailableTVStandard;        
    ULONG dwFlickerFilter;              
    ULONG dwOverScanX;                  
    ULONG dwOverScanY;                  
    ULONG dwMaxUnscaledX;               
    ULONG dwMaxUnscaledY;               
    ULONG dwPositionX;                  
    ULONG dwPositionY;                  
    ULONG dwBrightness;                 
    ULONG dwContrast;                   
    ULONG dwCPType;                     
    ULONG dwCPCommand;                  
    ULONG dwCPStandard;                 
    ULONG dwCPKey;
    ULONG bCP_APSTriggerBits;           
    UCHAR bOEMCopyProtection[256];      
} VIDEOPARAMETERS, *PVIDEOPARAMETERS, *LPVIDEOPARAMETERS;


                                        












































#line 91 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\tvout.h"
#line 10014 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 10026 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
LONG
__stdcall
ChangeDisplaySettingsA(
     LPDEVMODEA  lpDevMode,
     DWORD       dwFlags);
__declspec(dllimport)
LONG
__stdcall
ChangeDisplaySettingsW(
     LPDEVMODEW  lpDevMode,
     DWORD       dwFlags);




#line 10047 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
LONG
__stdcall
ChangeDisplaySettingsExA(
     LPCSTR    lpszDeviceName,
     LPDEVMODEA  lpDevMode,
     HWND        hwnd,
     DWORD       dwflags,
     LPVOID      lParam);
__declspec(dllimport)
LONG
__stdcall
ChangeDisplaySettingsExW(
     LPCWSTR    lpszDeviceName,
     LPDEVMODEW  lpDevMode,
     HWND        hwnd,
     DWORD       dwflags,
     LPVOID      lParam);




#line 10071 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
BOOL
__stdcall
EnumDisplaySettingsA(
     LPCSTR lpszDeviceName,
     DWORD iModeNum,
     LPDEVMODEA lpDevMode);
__declspec(dllimport)
BOOL
__stdcall
EnumDisplaySettingsW(
     LPCWSTR lpszDeviceName,
     DWORD iModeNum,
     LPDEVMODEW lpDevMode);




#line 10094 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"



__declspec(dllimport)
BOOL
__stdcall
EnumDisplaySettingsExA(
     LPCSTR lpszDeviceName,
     DWORD iModeNum,
     LPDEVMODEA lpDevMode,
     DWORD dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumDisplaySettingsExW(
     LPCWSTR lpszDeviceName,
     DWORD iModeNum,
     LPDEVMODEW lpDevMode,
     DWORD dwFlags);




#line 10118 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




__declspec(dllimport)
BOOL
__stdcall
EnumDisplayDevicesA(
     LPCSTR lpDevice,
     DWORD iDevNum,
     PDISPLAY_DEVICEA lpDisplayDevice,
     DWORD dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumDisplayDevicesW(
     LPCWSTR lpDevice,
     DWORD iDevNum,
     PDISPLAY_DEVICEW lpDisplayDevice,
     DWORD dwFlags);




#line 10143 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 10144 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 10146 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 10147 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


__declspec(dllimport)
BOOL
__stdcall
SystemParametersInfoA(
     UINT uiAction,
     UINT uiParam,
      PVOID pvParam,
     UINT fWinIni);
__declspec(dllimport)
BOOL
__stdcall
SystemParametersInfoW(
     UINT uiAction,
     UINT uiParam,
      PVOID pvParam,
     UINT fWinIni);




#line 10170 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


#line 10173 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct tagFILTERKEYS
{
    UINT  cbSize;
    DWORD dwFlags;
    DWORD iWaitMSec;            
    DWORD iDelayMSec;           
    DWORD iRepeatMSec;          
    DWORD iBounceMSec;          
} FILTERKEYS, *LPFILTERKEYS;












typedef struct tagSTICKYKEYS
{
    UINT  cbSize;
    DWORD dwFlags;
} STICKYKEYS, *LPSTICKYKEYS;






























#line 10234 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagMOUSEKEYS
{
    UINT cbSize;
    DWORD dwFlags;
    DWORD iMaxSpeed;
    DWORD iTimeToMaxSpeed;
    DWORD iCtrlSpeed;
    DWORD dwReserved1;
    DWORD dwReserved2;
} MOUSEKEYS, *LPMOUSEKEYS;


















#line 10264 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef struct tagACCESSTIMEOUT
{
    UINT  cbSize;
    DWORD dwFlags;
    DWORD iTimeOutMSec;
} ACCESSTIMEOUT, *LPACCESSTIMEOUT;
























typedef struct tagSOUNDSENTRYA
{
    UINT cbSize;
    DWORD dwFlags;
    DWORD iFSTextEffect;
    DWORD iFSTextEffectMSec;
    DWORD iFSTextEffectColorBits;
    DWORD iFSGrafEffect;
    DWORD iFSGrafEffectMSec;
    DWORD iFSGrafEffectColor;
    DWORD iWindowsEffect;
    DWORD iWindowsEffectMSec;
    LPSTR   lpszWindowsEffectDLL;
    DWORD iWindowsEffectOrdinal;
} SOUNDSENTRYA, *LPSOUNDSENTRYA;
typedef struct tagSOUNDSENTRYW
{
    UINT cbSize;
    DWORD dwFlags;
    DWORD iFSTextEffect;
    DWORD iFSTextEffectMSec;
    DWORD iFSTextEffectColorBits;
    DWORD iFSGrafEffect;
    DWORD iFSGrafEffectMSec;
    DWORD iFSGrafEffectColor;
    DWORD iWindowsEffect;
    DWORD iWindowsEffectMSec;
    LPWSTR  lpszWindowsEffectDLL;
    DWORD iWindowsEffectOrdinal;
} SOUNDSENTRYW, *LPSOUNDSENTRYW;




typedef SOUNDSENTRYA SOUNDSENTRY;
typedef LPSOUNDSENTRYA LPSOUNDSENTRY;
#line 10332 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








typedef struct tagTOGGLEKEYS
{
    UINT cbSize;
    DWORD dwFlags;
} TOGGLEKEYS, *LPTOGGLEKEYS;















__declspec(dllimport)
void
__stdcall
SetDebugErrorLevel(
     DWORD dwLevel
    );









__declspec(dllimport)
void
__stdcall
SetLastErrorEx(
     DWORD dwErrCode,
     DWORD dwType
    );












__declspec(dllimport)
HMONITOR
__stdcall
MonitorFromPoint(
     POINT pt,
     DWORD dwFlags);

__declspec(dllimport)
HMONITOR
__stdcall
MonitorFromRect(
     LPCRECT lprc,
     DWORD dwFlags);

__declspec(dllimport)
HMONITOR
__stdcall
MonitorFromWindow(  HWND hwnd,  DWORD dwFlags);







typedef struct tagMONITORINFO
{
    DWORD   cbSize;
    RECT    rcMonitor;
    RECT    rcWork;
    DWORD   dwFlags;
} MONITORINFO, *LPMONITORINFO;


typedef struct tagMONITORINFOEXA : public tagMONITORINFO
{
    CHAR        szDevice[32];
} MONITORINFOEXA, *LPMONITORINFOEXA;
typedef struct tagMONITORINFOEXW : public tagMONITORINFO
{
    WCHAR       szDevice[32];
} MONITORINFOEXW, *LPMONITORINFOEXW;




typedef MONITORINFOEXA MONITORINFOEX;
typedef LPMONITORINFOEXA LPMONITORINFOEX;
#line 10443 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


















#line 10462 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport) BOOL __stdcall GetMonitorInfoA(  HMONITOR hMonitor,  LPMONITORINFO lpmi);
__declspec(dllimport) BOOL __stdcall GetMonitorInfoW(  HMONITOR hMonitor,  LPMONITORINFO lpmi);




#line 10470 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

typedef BOOL (__stdcall* MONITORENUMPROC)(HMONITOR, HDC, LPRECT, LPARAM);

__declspec(dllimport)
BOOL
__stdcall
EnumDisplayMonitors(
     HDC             hdc,
     LPCRECT         lprcClip,
     MONITORENUMPROC lpfnEnum,
     LPARAM          dwData);








__declspec(dllimport)
void
__stdcall
NotifyWinEvent(
     DWORD event,
     HWND  hwnd,
     LONG  idObject,
     LONG  idChild);

typedef void (__stdcall* WINEVENTPROC)(
    HWINEVENTHOOK hWinEventHook,
    DWORD         event,
    HWND          hwnd,
    LONG          idObject,
    LONG          idChild,
    DWORD         idEventThread,
    DWORD         dwmsEventTime);

__declspec(dllimport)
HWINEVENTHOOK
__stdcall
SetWinEventHook(
     DWORD        eventMin,
     DWORD        eventMax,
     HMODULE      hmodWinEventProc,
     WINEVENTPROC pfnWinEventProc,
     DWORD        idProcess,
     DWORD        idThread,
     DWORD        dwFlags);







#line 10526 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"









__declspec(dllimport)
BOOL
__stdcall
UnhookWinEvent(
     HWINEVENTHOOK hWinEventHook);

































































































































































































































#line 10766 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




















































































































































































































typedef struct tagGUITHREADINFO
{
    DWORD   cbSize;
    DWORD   flags;
    HWND    hwndActive;
    HWND    hwndFocus;
    HWND    hwndCapture;
    HWND    hwndMenuOwner;
    HWND    hwndMoveSize;
    HWND    hwndCaret;
    RECT    rcCaret;
} GUITHREADINFO, *PGUITHREADINFO,  * LPGUITHREADINFO;








#line 10999 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

__declspec(dllimport)
BOOL
__stdcall
GetGUIThreadInfo(
     DWORD idThread,
     PGUITHREADINFO pgui);

__declspec(dllimport)
UINT
__stdcall
GetWindowModuleFileNameA(
     HWND     hwnd,
     LPSTR pszFileName,
     UINT     cchFileNameMax);
__declspec(dllimport)
UINT
__stdcall
GetWindowModuleFileNameW(
     HWND     hwnd,
     LPWSTR pszFileName,
     UINT     cchFileNameMax);




#line 11026 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


































#line 11061 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







typedef struct tagCURSORINFO
{
    DWORD   cbSize;
    DWORD   flags;
    HCURSOR hCursor;
    POINT   ptScreenPos;
} CURSORINFO, *PCURSORINFO, *LPCURSORINFO;



__declspec(dllimport)
BOOL
__stdcall
GetCursorInfo(
     PCURSORINFO pci
);




typedef struct tagWINDOWINFO
{
    DWORD cbSize;
    RECT  rcWindow;
    RECT  rcClient;
    DWORD dwStyle;
    DWORD dwExStyle;
    DWORD dwWindowStatus;
    UINT  cxWindowBorders;
    UINT  cyWindowBorders;
    ATOM  atomWindowType;
    WORD  wCreatorVersion;
} WINDOWINFO, *PWINDOWINFO, *LPWINDOWINFO;



__declspec(dllimport)
BOOL
__stdcall
GetWindowInfo(
     HWND hwnd,
     PWINDOWINFO pwi
);




typedef struct tagTITLEBARINFO
{
    DWORD cbSize;
    RECT  rcTitleBar;
    DWORD rgstate[5+1];
} TITLEBARINFO, *PTITLEBARINFO, *LPTITLEBARINFO;

__declspec(dllimport)
BOOL
__stdcall
GetTitleBarInfo(
     HWND hwnd,
     PTITLEBARINFO pti
);




typedef struct tagMENUBARINFO
{
    DWORD cbSize;
    RECT  rcBar;          
    HMENU hMenu;          
    HWND  hwndMenu;       
    BOOL  fBarFocused:1;  
    BOOL  fFocused:1;     
} MENUBARINFO, *PMENUBARINFO, *LPMENUBARINFO;

__declspec(dllimport)
BOOL
__stdcall
GetMenuBarInfo(
     HWND hwnd,
     LONG idObject,
     LONG idItem,
     PMENUBARINFO pmbi
);




typedef struct tagSCROLLBARINFO
{
    DWORD cbSize;
    RECT  rcScrollBar;
    int   dxyLineButton;
    int   xyThumbTop;
    int   xyThumbBottom;
    int   reserved;
    DWORD rgstate[5+1];
} SCROLLBARINFO, *PSCROLLBARINFO, *LPSCROLLBARINFO;

__declspec(dllimport)
BOOL
__stdcall
GetScrollBarInfo(
     HWND hwnd,
     LONG idObject,
     PSCROLLBARINFO psbi
);




typedef struct tagCOMBOBOXINFO
{
    DWORD cbSize;
    RECT  rcItem;
    RECT  rcButton;
    DWORD stateButton;
    HWND  hwndCombo;
    HWND  hwndItem;
    HWND  hwndList;
} COMBOBOXINFO, *PCOMBOBOXINFO, *LPCOMBOBOXINFO;

__declspec(dllimport)
BOOL
__stdcall
GetComboBoxInfo(
     HWND hwndCombo,
     PCOMBOBOXINFO pcbi
);








__declspec(dllimport)
HWND
__stdcall
GetAncestor(
     HWND hwnd,
     UINT gaFlags
);








__declspec(dllimport)
HWND
__stdcall
RealChildWindowFromPoint(
     HWND hwndParent,
     POINT ptParentClientCoords
);






__declspec(dllimport)
UINT
__stdcall
RealGetWindowClassA(
     HWND  hwnd,
     LPSTR pszType,
     UINT  cchType
);




__declspec(dllimport)
UINT
__stdcall
RealGetWindowClassW(
     HWND  hwnd,
     LPWSTR pszType,
     UINT  cchType
);




#line 11258 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"




typedef struct tagALTTABINFO
{
    DWORD cbSize;
    int   cItems;
    int   cColumns;
    int   cRows;
    int   iColFocus;
    int   iRowFocus;
    int   cxItem;
    int   cyItem;
    POINT ptStart;
} ALTTABINFO, *PALTTABINFO, *LPALTTABINFO;

__declspec(dllimport)
BOOL
__stdcall
GetAltTabInfoA(
     HWND hwnd,
     int iItem,
     PALTTABINFO pati,
     LPSTR pszItemText,
     UINT cchItemText
);
__declspec(dllimport)
BOOL
__stdcall
GetAltTabInfoW(
     HWND hwnd,
     int iItem,
     PALTTABINFO pati,
     LPWSTR pszItemText,
     UINT cchItemText
);




#line 11300 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





__declspec(dllimport)
DWORD
__stdcall
GetListBoxInfo(
     HWND hwnd
);

#line 11313 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 11314 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"








#line 11323 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"











#line 11335 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"













































































































































































































































































































































































#line 11701 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"







#line 11709 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"
#line 11710 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"


}
#line 11714 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"

#line 11716 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winuser.h"





#line 165 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"





















extern "C" {
#line 24 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"








































#line 65 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"




















































































#line 150 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"















































































































































































































































#line 390 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"























































































































#line 510 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"










#line 521 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"





















#line 543 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


























#line 570 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"























































#line 626 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"



























































typedef DWORD LGRPID;





typedef DWORD LCTYPE;





typedef DWORD CALTYPE;





typedef DWORD CALID;






typedef struct _cpinfo {
    UINT    MaxCharSize;                    
    BYTE    DefaultChar[2];   
    BYTE    LeadByte[12];        
} CPINFO, *LPCPINFO;

typedef struct _cpinfoexA {
    UINT    MaxCharSize;                    
    BYTE    DefaultChar[2];   
    BYTE    LeadByte[12];        
    WCHAR   UnicodeDefaultChar;             
    UINT    CodePage;                       
    CHAR    CodePageName[260];         
} CPINFOEXA, *LPCPINFOEXA;
typedef struct _cpinfoexW {
    UINT    MaxCharSize;                    
    BYTE    DefaultChar[2];   
    BYTE    LeadByte[12];        
    WCHAR   UnicodeDefaultChar;             
    UINT    CodePage;                       
    WCHAR   CodePageName[260];         
} CPINFOEXW, *LPCPINFOEXW;




typedef CPINFOEXA CPINFOEX;
typedef LPCPINFOEXA LPCPINFOEX;
#line 739 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"






typedef struct _numberfmtA {
    UINT    NumDigits;                 
    UINT    LeadingZero;               
    UINT    Grouping;                  
    LPSTR   lpDecimalSep;              
    LPSTR   lpThousandSep;             
    UINT    NegativeOrder;             
} NUMBERFMTA, *LPNUMBERFMTA;
typedef struct _numberfmtW {
    UINT    NumDigits;                 
    UINT    LeadingZero;               
    UINT    Grouping;                  
    LPWSTR  lpDecimalSep;              
    LPWSTR  lpThousandSep;             
    UINT    NegativeOrder;             
} NUMBERFMTW, *LPNUMBERFMTW;




typedef NUMBERFMTA NUMBERFMT;
typedef LPNUMBERFMTA LPNUMBERFMT;
#line 768 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"






typedef struct _currencyfmtA {
    UINT    NumDigits;                 
    UINT    LeadingZero;               
    UINT    Grouping;                  
    LPSTR   lpDecimalSep;              
    LPSTR   lpThousandSep;             
    UINT    NegativeOrder;             
    UINT    PositiveOrder;             
    LPSTR   lpCurrencySymbol;          
} CURRENCYFMTA, *LPCURRENCYFMTA;
typedef struct _currencyfmtW {
    UINT    NumDigits;                 
    UINT    LeadingZero;               
    UINT    Grouping;                  
    LPWSTR  lpDecimalSep;              
    LPWSTR  lpThousandSep;             
    UINT    NegativeOrder;             
    UINT    PositiveOrder;             
    LPWSTR  lpCurrencySymbol;          
} CURRENCYFMTW, *LPCURRENCYFMTW;




typedef CURRENCYFMTA CURRENCYFMT;
typedef LPCURRENCYFMTA LPCURRENCYFMT;
#line 801 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"






typedef LONG    GEOID;
typedef DWORD   GEOTYPE;
typedef DWORD   GEOCLASS;







enum SYSGEOTYPE {
    GEO_NATION      =       0x0001,
    GEO_LATITUDE    =       0x0002,
    GEO_LONGITUDE   =       0x0003,
    GEO_ISO2        =       0x0004,
    GEO_ISO3        =       0x0005,
    GEO_RFC1766     =       0x0006,
    GEO_LCID        =       0x0007,
    GEO_FRIENDLYNAME=       0x0008,
    GEO_OFFICIALNAME=       0x0009,
    GEO_TIMEZONES   =       0x000A,
    GEO_OFFICIALLANGUAGES = 0x000B,
};





enum SYSGEOCLASS {
    GEOCLASS_NATION  = 16,
    GEOCLASS_REGION  = 14,
};








typedef BOOL (__stdcall* LANGUAGEGROUP_ENUMPROCA)(LGRPID, LPSTR, LPSTR, DWORD, LONG_PTR);
typedef BOOL (__stdcall* LANGGROUPLOCALE_ENUMPROCA)(LGRPID, LCID, LPSTR, LONG_PTR);
typedef BOOL (__stdcall* UILANGUAGE_ENUMPROCA)(LPSTR, LONG_PTR);
typedef BOOL (__stdcall* LOCALE_ENUMPROCA)(LPSTR);
typedef BOOL (__stdcall* CODEPAGE_ENUMPROCA)(LPSTR);
typedef BOOL (__stdcall* DATEFMT_ENUMPROCA)(LPSTR);
typedef BOOL (__stdcall* DATEFMT_ENUMPROCEXA)(LPSTR, CALID);
typedef BOOL (__stdcall* TIMEFMT_ENUMPROCA)(LPSTR);
typedef BOOL (__stdcall* CALINFO_ENUMPROCA)(LPSTR);
typedef BOOL (__stdcall* CALINFO_ENUMPROCEXA)(LPSTR, CALID);

typedef BOOL (__stdcall* LANGUAGEGROUP_ENUMPROCW)(LGRPID, LPWSTR, LPWSTR, DWORD, LONG_PTR);
typedef BOOL (__stdcall* LANGGROUPLOCALE_ENUMPROCW)(LGRPID, LCID, LPWSTR, LONG_PTR);
typedef BOOL (__stdcall* UILANGUAGE_ENUMPROCW)(LPWSTR, LONG_PTR);
typedef BOOL (__stdcall* LOCALE_ENUMPROCW)(LPWSTR);
typedef BOOL (__stdcall* CODEPAGE_ENUMPROCW)(LPWSTR);
typedef BOOL (__stdcall* DATEFMT_ENUMPROCW)(LPWSTR);
typedef BOOL (__stdcall* DATEFMT_ENUMPROCEXW)(LPWSTR, CALID);
typedef BOOL (__stdcall* TIMEFMT_ENUMPROCW)(LPWSTR);
typedef BOOL (__stdcall* CALINFO_ENUMPROCW)(LPWSTR);
typedef BOOL (__stdcall* CALINFO_ENUMPROCEXW)(LPWSTR, CALID);
typedef BOOL (__stdcall* GEO_ENUMPROC)(GEOID);


























#line 896 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"



























#line 924 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"



























__declspec(dllimport)
BOOL
__stdcall
IsValidCodePage(
     UINT  CodePage);

__declspec(dllimport)
UINT
__stdcall
GetACP(void);

__declspec(dllimport)
UINT
__stdcall
GetOEMCP(void);

__declspec(dllimport)
BOOL
__stdcall
GetCPInfo(
     UINT       CodePage,
     LPCPINFO  lpCPInfo);

__declspec(dllimport)
BOOL
__stdcall
GetCPInfoExA(
     UINT          CodePage,
     DWORD         dwFlags,
     LPCPINFOEXA  lpCPInfoEx);
__declspec(dllimport)
BOOL
__stdcall
GetCPInfoExW(
     UINT          CodePage,
     DWORD         dwFlags,
     LPCPINFOEXW  lpCPInfoEx);




#line 993 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
IsDBCSLeadByte(
     BYTE  TestChar);

__declspec(dllimport)
BOOL
__stdcall
IsDBCSLeadByteEx(
     UINT  CodePage,
     BYTE  TestChar);

__declspec(dllimport)
int
__stdcall
MultiByteToWideChar(
     UINT     CodePage,
     DWORD    dwFlags,
     LPCSTR   lpMultiByteStr,
     int      cbMultiByte,
     LPWSTR  lpWideCharStr,
     int      cchWideChar);

__declspec(dllimport)
int
__stdcall
WideCharToMultiByte(
     UINT     CodePage,
     DWORD    dwFlags,
     LPCWSTR  lpWideCharStr,
     int      cchWideChar,
     LPSTR   lpMultiByteStr,
     int      cbMultiByte,
     LPCSTR   lpDefaultChar,
     LPBOOL  lpUsedDefaultChar);






__declspec(dllimport)
int
__stdcall
CompareStringA(
     LCID     Locale,
     DWORD    dwCmpFlags,
     LPCSTR  lpString1,
     int      cchCount1,
     LPCSTR  lpString2,
     int      cchCount2);
__declspec(dllimport)
int
__stdcall
CompareStringW(
     LCID     Locale,
     DWORD    dwCmpFlags,
     LPCWSTR  lpString1,
     int      cchCount1,
     LPCWSTR  lpString2,
     int      cchCount2);




#line 1061 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
LCMapStringA(
     LCID     Locale,
     DWORD    dwMapFlags,
     LPCSTR  lpSrcStr,
     int      cchSrc,
     LPSTR  lpDestStr,
     int      cchDest);
__declspec(dllimport)
int
__stdcall
LCMapStringW(
     LCID     Locale,
     DWORD    dwMapFlags,
     LPCWSTR  lpSrcStr,
     int      cchSrc,
     LPWSTR  lpDestStr,
     int      cchDest);




#line 1087 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
GetLocaleInfoA(
     LCID     Locale,
     LCTYPE   LCType,
     LPSTR  lpLCData,
     int      cchData);
__declspec(dllimport)
int
__stdcall
GetLocaleInfoW(
     LCID     Locale,
     LCTYPE   LCType,
     LPWSTR  lpLCData,
     int      cchData);




#line 1109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
SetLocaleInfoA(
     LCID     Locale,
     LCTYPE   LCType,
     LPCSTR  lpLCData);
__declspec(dllimport)
BOOL
__stdcall
SetLocaleInfoW(
     LCID     Locale,
     LCTYPE   LCType,
     LPCWSTR  lpLCData);




#line 1129 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


__declspec(dllimport)
int
__stdcall
GetCalendarInfoA(
    LCID     Locale,
    CALID    Calendar,
    CALTYPE  CalType,
    LPSTR   lpCalData,
    int      cchData,
    LPDWORD  lpValue);
__declspec(dllimport)
int
__stdcall
GetCalendarInfoW(
    LCID     Locale,
    CALID    Calendar,
    CALTYPE  CalType,
    LPWSTR   lpCalData,
    int      cchData,
    LPDWORD  lpValue);




#line 1156 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
SetCalendarInfoA(
    LCID     Locale,
    CALID    Calendar,
    CALTYPE  CalType,
    LPCSTR  lpCalData);
__declspec(dllimport)
BOOL
__stdcall
SetCalendarInfoW(
    LCID     Locale,
    CALID    Calendar,
    CALTYPE  CalType,
    LPCWSTR  lpCalData);




#line 1178 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"
#line 1179 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
GetTimeFormatA(
     LCID             Locale,
     DWORD            dwFlags,
     const SYSTEMTIME *lpTime,
     LPCSTR          lpFormat,
     LPSTR          lpTimeStr,
     int              cchTime);
__declspec(dllimport)
int
__stdcall
GetTimeFormatW(
     LCID             Locale,
     DWORD            dwFlags,
     const SYSTEMTIME *lpTime,
     LPCWSTR          lpFormat,
     LPWSTR          lpTimeStr,
     int              cchTime);




#line 1205 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
GetDateFormatA(
     LCID             Locale,
     DWORD            dwFlags,
     const SYSTEMTIME *lpDate,
     LPCSTR          lpFormat,
     LPSTR          lpDateStr,
     int              cchDate);
__declspec(dllimport)
int
__stdcall
GetDateFormatW(
     LCID             Locale,
     DWORD            dwFlags,
     const SYSTEMTIME *lpDate,
     LPCWSTR          lpFormat,
     LPWSTR          lpDateStr,
     int              cchDate);




#line 1231 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
GetNumberFormatA(
     LCID             Locale,
     DWORD            dwFlags,
     LPCSTR          lpValue,
     const NUMBERFMTA *lpFormat,
     LPSTR          lpNumberStr,
     int              cchNumber);
__declspec(dllimport)
int
__stdcall
GetNumberFormatW(
     LCID             Locale,
     DWORD            dwFlags,
     LPCWSTR          lpValue,
     const NUMBERFMTW *lpFormat,
     LPWSTR          lpNumberStr,
     int              cchNumber);




#line 1257 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
int
__stdcall
GetCurrencyFormatA(
     LCID               Locale,
     DWORD              dwFlags,
     LPCSTR            lpValue,
     const CURRENCYFMTA *lpFormat,
     LPSTR            lpCurrencyStr,
     int                cchCurrency);
__declspec(dllimport)
int
__stdcall
GetCurrencyFormatW(
     LCID               Locale,
     DWORD              dwFlags,
     LPCWSTR            lpValue,
     const CURRENCYFMTW *lpFormat,
     LPWSTR            lpCurrencyStr,
     int                cchCurrency);




#line 1283 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumCalendarInfoA(
     CALINFO_ENUMPROCA lpCalInfoEnumProc,
     LCID              Locale,
     CALID             Calendar,
     CALTYPE           CalType);
__declspec(dllimport)
BOOL
__stdcall
EnumCalendarInfoW(
     CALINFO_ENUMPROCW lpCalInfoEnumProc,
     LCID              Locale,
     CALID             Calendar,
     CALTYPE           CalType);




#line 1305 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


__declspec(dllimport)
BOOL
__stdcall
EnumCalendarInfoExA(
     CALINFO_ENUMPROCEXA lpCalInfoEnumProcEx,
     LCID                Locale,
     CALID               Calendar,
     CALTYPE             CalType);
__declspec(dllimport)
BOOL
__stdcall
EnumCalendarInfoExW(
     CALINFO_ENUMPROCEXW lpCalInfoEnumProcEx,
     LCID                Locale,
     CALID               Calendar,
     CALTYPE             CalType);




#line 1328 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"
#line 1329 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumTimeFormatsA(
     TIMEFMT_ENUMPROCA lpTimeFmtEnumProc,
     LCID              Locale,
     DWORD             dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumTimeFormatsW(
     TIMEFMT_ENUMPROCW lpTimeFmtEnumProc,
     LCID              Locale,
     DWORD             dwFlags);




#line 1349 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumDateFormatsA(
     DATEFMT_ENUMPROCA lpDateFmtEnumProc,
     LCID              Locale,
     DWORD             dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumDateFormatsW(
     DATEFMT_ENUMPROCW lpDateFmtEnumProc,
     LCID              Locale,
     DWORD             dwFlags);




#line 1369 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


__declspec(dllimport)
BOOL
__stdcall
EnumDateFormatsExA(
     DATEFMT_ENUMPROCEXA lpDateFmtEnumProcEx,
     LCID                Locale,
     DWORD               dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumDateFormatsExW(
     DATEFMT_ENUMPROCEXW lpDateFmtEnumProcEx,
     LCID                Locale,
     DWORD               dwFlags);




#line 1390 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"
#line 1391 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


__declspec(dllimport)
BOOL
__stdcall
IsValidLanguageGroup(
     LGRPID  LanguageGroup,
     DWORD   dwFlags);
#line 1400 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
IsValidLocale(
     LCID   Locale,
     DWORD  dwFlags);

__declspec(dllimport)
int
__stdcall
GetGeoInfoA(
    GEOID       Location,
    GEOTYPE     GeoType,
    LPSTR     lpGeoData,
    int         cchData,
    LANGID      LangId);
__declspec(dllimport)
int
__stdcall
GetGeoInfoW(
    GEOID       Location,
    GEOTYPE     GeoType,
    LPWSTR     lpGeoData,
    int         cchData,
    LANGID      LangId);




#line 1431 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumSystemGeoID(
    GEOCLASS        GeoClass,
    GEOID           ParentGeoId,
    GEO_ENUMPROC    lpGeoEnumProc);

__declspec(dllimport)
GEOID
__stdcall
GetUserGeoID(
    GEOCLASS    GeoClass);

__declspec(dllimport)
BOOL
__stdcall
SetUserGeoID(
    GEOID       GeoId);

__declspec(dllimport)
LCID
__stdcall
ConvertDefaultLocale(
      LCID   Locale);

__declspec(dllimport)
LCID
__stdcall
GetThreadLocale(void);

__declspec(dllimport)
BOOL
__stdcall
SetThreadLocale(
     LCID  Locale
    );


__declspec(dllimport)
LANGID
__stdcall
GetSystemDefaultUILanguage(void);

__declspec(dllimport)
LANGID
__stdcall
GetUserDefaultUILanguage(void);
#line 1481 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
LANGID
__stdcall
GetSystemDefaultLangID(void);

__declspec(dllimport)
LANGID
__stdcall
GetUserDefaultLangID(void);

__declspec(dllimport)
LCID
__stdcall
GetSystemDefaultLCID(void);

__declspec(dllimport)
LCID
__stdcall
GetUserDefaultLCID(void);







__declspec(dllimport)
BOOL
__stdcall
GetStringTypeExA(
     LCID     Locale,
     DWORD    dwInfoType,
     LPCSTR  lpSrcStr,
     int      cchSrc,
     LPWORD  lpCharType);
__declspec(dllimport)
BOOL
__stdcall
GetStringTypeExW(
     LCID     Locale,
     DWORD    dwInfoType,
     LPCWSTR  lpSrcStr,
     int      cchSrc,
     LPWORD  lpCharType);




#line 1531 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"












__declspec(dllimport)
BOOL
__stdcall
GetStringTypeA(
     LCID     Locale,
     DWORD    dwInfoType,
     LPCSTR   lpSrcStr,
     int      cchSrc,
     LPWORD  lpCharType);

__declspec(dllimport)
BOOL
__stdcall
GetStringTypeW(
     DWORD    dwInfoType,
     LPCWSTR  lpSrcStr,
     int      cchSrc,
     LPWORD  lpCharType);


__declspec(dllimport)
int
__stdcall
FoldStringA(
     DWORD    dwMapFlags,
     LPCSTR  lpSrcStr,
     int      cchSrc,
     LPSTR  lpDestStr,
     int      cchDest);
__declspec(dllimport)
int
__stdcall
FoldStringW(
     DWORD    dwMapFlags,
     LPCWSTR  lpSrcStr,
     int      cchSrc,
     LPWSTR  lpDestStr,
     int      cchDest);




#line 1586 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


__declspec(dllimport)
BOOL
__stdcall
EnumSystemLanguageGroupsA(
     LANGUAGEGROUP_ENUMPROCA lpLanguageGroupEnumProc,
     DWORD                   dwFlags,
     LONG_PTR                lParam);
__declspec(dllimport)
BOOL
__stdcall
EnumSystemLanguageGroupsW(
     LANGUAGEGROUP_ENUMPROCW lpLanguageGroupEnumProc,
     DWORD                   dwFlags,
     LONG_PTR                lParam);




#line 1607 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumLanguageGroupLocalesA(
     LANGGROUPLOCALE_ENUMPROCA lpLangGroupLocaleEnumProc,
     LGRPID                    LanguageGroup,
     DWORD                     dwFlags,
     LONG_PTR                  lParam);
__declspec(dllimport)
BOOL
__stdcall
EnumLanguageGroupLocalesW(
     LANGGROUPLOCALE_ENUMPROCW lpLangGroupLocaleEnumProc,
     LGRPID                    LanguageGroup,
     DWORD                     dwFlags,
     LONG_PTR                  lParam);




#line 1629 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumUILanguagesA(
     UILANGUAGE_ENUMPROCA lpUILanguageEnumProc,
     DWORD                dwFlags,
     LONG_PTR             lParam);
__declspec(dllimport)
BOOL
__stdcall
EnumUILanguagesW(
     UILANGUAGE_ENUMPROCW lpUILanguageEnumProc,
     DWORD                dwFlags,
     LONG_PTR             lParam);




#line 1649 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"
#line 1650 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumSystemLocalesA(
     LOCALE_ENUMPROCA lpLocaleEnumProc,
     DWORD            dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumSystemLocalesW(
     LOCALE_ENUMPROCW lpLocaleEnumProc,
     DWORD            dwFlags);




#line 1668 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

__declspec(dllimport)
BOOL
__stdcall
EnumSystemCodePagesA(
     CODEPAGE_ENUMPROCA lpCodePageEnumProc,
     DWORD              dwFlags);
__declspec(dllimport)
BOOL
__stdcall
EnumSystemCodePagesW(
     CODEPAGE_ENUMPROCW lpCodePageEnumProc,
     DWORD              dwFlags);




#line 1686 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"


#line 1689 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"



}
#line 1694 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"

#line 1696 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnls.h"
#line 167 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 168 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

























extern "C" {
#line 28 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

typedef struct _COORD {
    SHORT X;
    SHORT Y;
} COORD, *PCOORD;

typedef struct _SMALL_RECT {
    SHORT Left;
    SHORT Top;
    SHORT Right;
    SHORT Bottom;
} SMALL_RECT, *PSMALL_RECT;

typedef struct _KEY_EVENT_RECORD {
    BOOL bKeyDown;
    WORD wRepeatCount;
    WORD wVirtualKeyCode;
    WORD wVirtualScanCode;
    union {
        WCHAR UnicodeChar;
        CHAR   AsciiChar;
    } uChar;
    DWORD dwControlKeyState;
} KEY_EVENT_RECORD, *PKEY_EVENT_RECORD;






















typedef struct _MOUSE_EVENT_RECORD {
    COORD dwMousePosition;
    DWORD dwButtonState;
    DWORD dwControlKeyState;
    DWORD dwEventFlags;
} MOUSE_EVENT_RECORD, *PMOUSE_EVENT_RECORD;



















typedef struct _WINDOW_BUFFER_SIZE_RECORD {
    COORD dwSize;
} WINDOW_BUFFER_SIZE_RECORD, *PWINDOW_BUFFER_SIZE_RECORD;

typedef struct _MENU_EVENT_RECORD {
    UINT dwCommandId;
} MENU_EVENT_RECORD, *PMENU_EVENT_RECORD;

typedef struct _FOCUS_EVENT_RECORD {
    BOOL bSetFocus;
} FOCUS_EVENT_RECORD, *PFOCUS_EVENT_RECORD;

typedef struct _INPUT_RECORD {
    WORD EventType;
    union {
        KEY_EVENT_RECORD KeyEvent;
        MOUSE_EVENT_RECORD MouseEvent;
        WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
        MENU_EVENT_RECORD MenuEvent;
        FOCUS_EVENT_RECORD FocusEvent;
    } Event;
} INPUT_RECORD, *PINPUT_RECORD;











typedef struct _CHAR_INFO {
    union {
        WCHAR UnicodeChar;
        CHAR   AsciiChar;
    } Char;
    WORD Attributes;
} CHAR_INFO, *PCHAR_INFO;
























typedef struct _CONSOLE_SCREEN_BUFFER_INFO {
    COORD dwSize;
    COORD dwCursorPosition;
    WORD  wAttributes;
    SMALL_RECT srWindow;
    COORD dwMaximumWindowSize;
} CONSOLE_SCREEN_BUFFER_INFO, *PCONSOLE_SCREEN_BUFFER_INFO;

typedef struct _CONSOLE_CURSOR_INFO {
    DWORD  dwSize;
    BOOL   bVisible;
} CONSOLE_CURSOR_INFO, *PCONSOLE_CURSOR_INFO;

typedef struct _CONSOLE_FONT_INFO {
    DWORD  nFont;
    COORD  dwFontSize;
} CONSOLE_FONT_INFO, *PCONSOLE_FONT_INFO;

















#line 198 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"





typedef
BOOL
(__stdcall *PHANDLER_ROUTINE)(
    DWORD CtrlType
    );






























__declspec(dllimport)
BOOL
__stdcall
PeekConsoleInputA(
     HANDLE hConsoleInput,
     PINPUT_RECORD lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsRead
    );
__declspec(dllimport)
BOOL
__stdcall
PeekConsoleInputW(
     HANDLE hConsoleInput,
     PINPUT_RECORD lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsRead
    );




#line 261 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
ReadConsoleInputA(
     HANDLE hConsoleInput,
     PINPUT_RECORD lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsRead
    );
__declspec(dllimport)
BOOL
__stdcall
ReadConsoleInputW(
     HANDLE hConsoleInput,
     PINPUT_RECORD lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsRead
    );




#line 285 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
WriteConsoleInputA(
     HANDLE hConsoleInput,
     const INPUT_RECORD *lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsWritten
    );
__declspec(dllimport)
BOOL
__stdcall
WriteConsoleInputW(
     HANDLE hConsoleInput,
     const INPUT_RECORD *lpBuffer,
     DWORD nLength,
     LPDWORD lpNumberOfEventsWritten
    );




#line 309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
ReadConsoleOutputA(
     HANDLE hConsoleOutput,
     PCHAR_INFO lpBuffer,
     COORD dwBufferSize,
     COORD dwBufferCoord,
      PSMALL_RECT lpReadRegion
    );
__declspec(dllimport)
BOOL
__stdcall
ReadConsoleOutputW(
     HANDLE hConsoleOutput,
     PCHAR_INFO lpBuffer,
     COORD dwBufferSize,
     COORD dwBufferCoord,
      PSMALL_RECT lpReadRegion
    );




#line 335 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
WriteConsoleOutputA(
     HANDLE hConsoleOutput,
     const CHAR_INFO *lpBuffer,
     COORD dwBufferSize,
     COORD dwBufferCoord,
      PSMALL_RECT lpWriteRegion
    );
__declspec(dllimport)
BOOL
__stdcall
WriteConsoleOutputW(
     HANDLE hConsoleOutput,
     const CHAR_INFO *lpBuffer,
     COORD dwBufferSize,
     COORD dwBufferCoord,
      PSMALL_RECT lpWriteRegion
    );




#line 361 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
ReadConsoleOutputCharacterA(
     HANDLE hConsoleOutput,
     LPSTR lpCharacter,
      DWORD nLength,
     COORD dwReadCoord,
     LPDWORD lpNumberOfCharsRead
    );
__declspec(dllimport)
BOOL
__stdcall
ReadConsoleOutputCharacterW(
     HANDLE hConsoleOutput,
     LPWSTR lpCharacter,
      DWORD nLength,
     COORD dwReadCoord,
     LPDWORD lpNumberOfCharsRead
    );




#line 387 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
ReadConsoleOutputAttribute(
     HANDLE hConsoleOutput,
     LPWORD lpAttribute,
     DWORD nLength,
     COORD dwReadCoord,
     LPDWORD lpNumberOfAttrsRead
    );

__declspec(dllimport)
BOOL
__stdcall
WriteConsoleOutputCharacterA(
     HANDLE hConsoleOutput,
     LPCSTR lpCharacter,
     DWORD nLength,
     COORD dwWriteCoord,
     LPDWORD lpNumberOfCharsWritten
    );
__declspec(dllimport)
BOOL
__stdcall
WriteConsoleOutputCharacterW(
     HANDLE hConsoleOutput,
     LPCWSTR lpCharacter,
     DWORD nLength,
     COORD dwWriteCoord,
     LPDWORD lpNumberOfCharsWritten
    );




#line 424 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
WriteConsoleOutputAttribute(
     HANDLE hConsoleOutput,
     const WORD *lpAttribute,
     DWORD nLength,
     COORD dwWriteCoord,
     LPDWORD lpNumberOfAttrsWritten
    );

__declspec(dllimport)
BOOL
__stdcall
FillConsoleOutputCharacterA(
     HANDLE hConsoleOutput,
     CHAR  cCharacter,
     DWORD  nLength,
     COORD  dwWriteCoord,
     LPDWORD lpNumberOfCharsWritten
    );
__declspec(dllimport)
BOOL
__stdcall
FillConsoleOutputCharacterW(
     HANDLE hConsoleOutput,
     WCHAR  cCharacter,
     DWORD  nLength,
     COORD  dwWriteCoord,
     LPDWORD lpNumberOfCharsWritten
    );




#line 461 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
FillConsoleOutputAttribute(
     HANDLE hConsoleOutput,
     WORD   wAttribute,
     DWORD  nLength,
     COORD  dwWriteCoord,
     LPDWORD lpNumberOfAttrsWritten
    );

__declspec(dllimport)
BOOL
__stdcall
GetConsoleMode(
     HANDLE hConsoleHandle,
     LPDWORD lpMode
    );

__declspec(dllimport)
BOOL
__stdcall
GetNumberOfConsoleInputEvents(
     HANDLE hConsoleInput,
     LPDWORD lpNumberOfEvents
    );

__declspec(dllimport)
BOOL
__stdcall
GetConsoleScreenBufferInfo(
     HANDLE hConsoleOutput,
     PCONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo
    );

__declspec(dllimport)
COORD
__stdcall
GetLargestConsoleWindowSize(
     HANDLE hConsoleOutput
    );

__declspec(dllimport)
BOOL
__stdcall
GetConsoleCursorInfo(
     HANDLE hConsoleOutput,
     PCONSOLE_CURSOR_INFO lpConsoleCursorInfo
    );



























#line 539 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
GetNumberOfConsoleMouseButtons(
     LPDWORD lpNumberOfMouseButtons
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleMode(
     HANDLE hConsoleHandle,
     DWORD dwMode
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleActiveScreenBuffer(
     HANDLE hConsoleOutput
    );

__declspec(dllimport)
BOOL
__stdcall
FlushConsoleInputBuffer(
     HANDLE hConsoleInput
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleScreenBufferSize(
     HANDLE hConsoleOutput,
     COORD dwSize
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleCursorPosition(
     HANDLE hConsoleOutput,
     COORD dwCursorPosition
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleCursorInfo(
     HANDLE hConsoleOutput,
     const CONSOLE_CURSOR_INFO *lpConsoleCursorInfo
    );

__declspec(dllimport)
BOOL
__stdcall
ScrollConsoleScreenBufferA(
     HANDLE hConsoleOutput,
     const SMALL_RECT *lpScrollRectangle,
     const SMALL_RECT *lpClipRectangle,
     COORD dwDestinationOrigin,
     const CHAR_INFO *lpFill
    );
__declspec(dllimport)
BOOL
__stdcall
ScrollConsoleScreenBufferW(
     HANDLE hConsoleOutput,
     const SMALL_RECT *lpScrollRectangle,
     const SMALL_RECT *lpClipRectangle,
     COORD dwDestinationOrigin,
     const CHAR_INFO *lpFill
    );




#line 618 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
SetConsoleWindowInfo(
     HANDLE hConsoleOutput,
     BOOL bAbsolute,
     const SMALL_RECT *lpConsoleWindow
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleTextAttribute(
     HANDLE hConsoleOutput,
     WORD wAttributes
    );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleCtrlHandler(
     PHANDLER_ROUTINE HandlerRoutine,
     BOOL Add
    );

__declspec(dllimport)
BOOL
__stdcall
GenerateConsoleCtrlEvent(
     DWORD dwCtrlEvent,
     DWORD dwProcessGroupId
    );

__declspec(dllimport)
BOOL
__stdcall
AllocConsole( void );

__declspec(dllimport)
BOOL
__stdcall
FreeConsole( void );








#line 670 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
DWORD
__stdcall
GetConsoleTitleA(
     LPSTR lpConsoleTitle,
     DWORD nSize
    );
__declspec(dllimport)
DWORD
__stdcall
GetConsoleTitleW(
     LPWSTR lpConsoleTitle,
     DWORD nSize
    );




#line 690 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
SetConsoleTitleA(
     LPCSTR lpConsoleTitle
    );
__declspec(dllimport)
BOOL
__stdcall
SetConsoleTitleW(
     LPCWSTR lpConsoleTitle
    );




#line 708 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
ReadConsoleA(
     HANDLE hConsoleInput,
     LPVOID lpBuffer,
     DWORD nNumberOfCharsToRead,
     LPDWORD lpNumberOfCharsRead,
     LPVOID lpReserved
    );
__declspec(dllimport)
BOOL
__stdcall
ReadConsoleW(
     HANDLE hConsoleInput,
     LPVOID lpBuffer,
     DWORD nNumberOfCharsToRead,
     LPDWORD lpNumberOfCharsRead,
     LPVOID lpReserved
    );




#line 734 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

__declspec(dllimport)
BOOL
__stdcall
WriteConsoleA(
     HANDLE hConsoleOutput,
     const void *lpBuffer,
     DWORD nNumberOfCharsToWrite,
     LPDWORD lpNumberOfCharsWritten,
     LPVOID lpReserved
    );
__declspec(dllimport)
BOOL
__stdcall
WriteConsoleW(
     HANDLE hConsoleOutput,
     const void *lpBuffer,
     DWORD nNumberOfCharsToWrite,
     LPDWORD lpNumberOfCharsWritten,
     LPVOID lpReserved
    );




#line 760 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"



__declspec(dllimport)
HANDLE
__stdcall
CreateConsoleScreenBuffer(
     DWORD dwDesiredAccess,
     DWORD dwShareMode,
     const SECURITY_ATTRIBUTES *lpSecurityAttributes,
     DWORD dwFlags,
     LPVOID lpScreenBufferData
    );

__declspec(dllimport)
UINT
__stdcall
GetConsoleCP( void );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleCP(
     UINT wCodePageID
    );

__declspec(dllimport)
UINT
__stdcall
GetConsoleOutputCP( void );

__declspec(dllimport)
BOOL
__stdcall
SetConsoleOutputCP(
     UINT wCodePageID
    );




















#line 818 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"









#line 828 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"


}
#line 832 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

#line 834 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\wincon.h"

#line 170 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"
















extern "C" {
#line 19 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"











#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"




































































































typedef struct tagVS_FIXEDFILEINFO
{
    DWORD   dwSignature;            
    DWORD   dwStrucVersion;         
    DWORD   dwFileVersionMS;        
    DWORD   dwFileVersionLS;        
    DWORD   dwProductVersionMS;     
    DWORD   dwProductVersionLS;     
    DWORD   dwFileFlagsMask;        
    DWORD   dwFileFlags;            
    DWORD   dwFileOS;               
    DWORD   dwFileType;             
    DWORD   dwFileSubtype;          
    DWORD   dwFileDateMS;           
    DWORD   dwFileDateLS;           
} VS_FIXEDFILEINFO;



DWORD
__stdcall
VerFindFileA(
        DWORD uFlags,
        LPSTR szFileName,
        LPSTR szWinDir,
        LPSTR szAppDir,
        LPSTR szCurDir,
        PUINT lpuCurDirLen,
        LPSTR szDestDir,
        PUINT lpuDestDirLen
        );
DWORD
__stdcall
VerFindFileW(
        DWORD uFlags,
        LPWSTR szFileName,
        LPWSTR szWinDir,
        LPWSTR szAppDir,
        LPWSTR szCurDir,
        PUINT lpuCurDirLen,
        LPWSTR szDestDir,
        PUINT lpuDestDirLen
        );




#line 179 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

DWORD
__stdcall
VerInstallFileA(
        DWORD uFlags,
        LPSTR szSrcFileName,
        LPSTR szDestFileName,
        LPSTR szSrcDir,
        LPSTR szDestDir,
        LPSTR szCurDir,
        LPSTR szTmpFile,
        PUINT lpuTmpFileLen
        );
DWORD
__stdcall
VerInstallFileW(
        DWORD uFlags,
        LPWSTR szSrcFileName,
        LPWSTR szDestFileName,
        LPWSTR szSrcDir,
        LPWSTR szDestDir,
        LPWSTR szCurDir,
        LPWSTR szTmpFile,
        PUINT lpuTmpFileLen
        );




#line 209 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"


DWORD
__stdcall
GetFileVersionInfoSizeA(
        LPSTR lptstrFilename, 
        LPDWORD lpdwHandle
        );                      

DWORD
__stdcall
GetFileVersionInfoSizeW(
        LPWSTR lptstrFilename, 
        LPDWORD lpdwHandle
        );                      




#line 229 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"


BOOL
__stdcall
GetFileVersionInfoA(
        LPSTR lptstrFilename, 
        DWORD dwHandle,         
        DWORD dwLen,            
        LPVOID lpData
        );                      

BOOL
__stdcall
GetFileVersionInfoW(
        LPWSTR lptstrFilename, 
        DWORD dwHandle,         
        DWORD dwLen,            
        LPVOID lpData
        );                      




#line 253 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

DWORD
__stdcall
VerLanguageNameA(
        DWORD wLang,
        LPSTR szLang,
        DWORD nSize
        );
DWORD
__stdcall
VerLanguageNameW(
        DWORD wLang,
        LPWSTR szLang,
        DWORD nSize
        );




#line 273 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

BOOL
__stdcall
VerQueryValueA(
        const LPVOID pBlock,
        LPSTR lpSubBlock,
        LPVOID * lplpBuffer,
        PUINT puLen
        );
BOOL
__stdcall
VerQueryValueW(
        const LPVOID pBlock,
        LPWSTR lpSubBlock,
        LPVOID * lplpBuffer,
        PUINT puLen
        );




#line 295 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

#line 297 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"


}
#line 301 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

#line 303 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winver.h"

#line 171 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 172 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"
























extern "C" {
#line 27 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"









typedef ACCESS_MASK REGSAM;





















struct val_context {
    int valuelen;       
    LPVOID value_context;   
    LPVOID val_buff_ptr;    
};

typedef struct val_context  *PVALCONTEXT;

typedef struct pvalueA {           
    LPSTR   pv_valuename;          
    int pv_valuelen;
    LPVOID pv_value_context;
    DWORD pv_type;
}PVALUEA,  *PPVALUEA;
typedef struct pvalueW {           
    LPWSTR  pv_valuename;          
    int pv_valuelen;
    LPVOID pv_value_context;
    DWORD pv_type;
}PVALUEW,  *PPVALUEW;




typedef PVALUEA PVALUE;
typedef PPVALUEA PPVALUE;
#line 85 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

typedef
DWORD _cdecl
QUERYHANDLER (LPVOID keycontext, PVALCONTEXT val_list, DWORD num_vals,
          LPVOID outputbuffer, DWORD  *total_outlen, DWORD input_blen);

typedef QUERYHANDLER  *PQUERYHANDLER;

typedef struct provider_info {
    PQUERYHANDLER pi_R0_1val;
    PQUERYHANDLER pi_R0_allvals;
    PQUERYHANDLER pi_R3_1val;
    PQUERYHANDLER pi_R3_allvals;
    DWORD pi_flags;    
    LPVOID pi_key_context;
}REG_PROVIDER;

typedef struct provider_info  *PPROVIDER;

typedef struct value_entA {
    LPSTR   ve_valuename;
    DWORD ve_valuelen;
    DWORD_PTR ve_valueptr;
    DWORD ve_type;
}VALENTA,  *PVALENTA;
typedef struct value_entW {
    LPWSTR  ve_valuename;
    DWORD ve_valuelen;
    DWORD_PTR ve_valueptr;
    DWORD ve_type;
}VALENTW,  *PVALENTW;




typedef VALENTA VALENT;
typedef PVALENTA PVALENT;
#line 123 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

#line 125 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


#line 128 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"













__declspec(dllimport)
LONG
__stdcall
RegCloseKey (
     HKEY hKey
    );

__declspec(dllimport)
LONG
__stdcall
RegOverridePredefKey (
     HKEY hKey,
     HKEY hNewHKey
    );

__declspec(dllimport)
LONG
__stdcall
RegOpenUserClassesRoot(
    HANDLE hToken,
    DWORD  dwOptions,
    REGSAM samDesired,
    PHKEY  phkResult
    );

__declspec(dllimport)
LONG
__stdcall
RegOpenCurrentUser(
    REGSAM samDesired,
    PHKEY phkResult
    );

__declspec(dllimport)
LONG
__stdcall
RegDisablePredefinedCache(
    );

__declspec(dllimport)
LONG
__stdcall
RegConnectRegistryA (
     LPCSTR lpMachineName,
     HKEY hKey,
     PHKEY phkResult
    );
__declspec(dllimport)
LONG
__stdcall
RegConnectRegistryW (
     LPCWSTR lpMachineName,
     HKEY hKey,
     PHKEY phkResult
    );




#line 201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegCreateKeyA (
     HKEY hKey,
     LPCSTR lpSubKey,
     PHKEY phkResult
    );
__declspec(dllimport)
LONG
__stdcall
RegCreateKeyW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     PHKEY phkResult
    );




#line 223 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegCreateKeyExA (
     HKEY hKey,
     LPCSTR lpSubKey,
     DWORD Reserved,
     LPSTR lpClass,
     DWORD dwOptions,
     REGSAM samDesired,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     PHKEY phkResult,
     LPDWORD lpdwDisposition
    );
__declspec(dllimport)
LONG
__stdcall
RegCreateKeyExW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     DWORD Reserved,
     LPWSTR lpClass,
     DWORD dwOptions,
     REGSAM samDesired,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     PHKEY phkResult,
     LPDWORD lpdwDisposition
    );




#line 257 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegDeleteKeyA (
     HKEY hKey,
     LPCSTR lpSubKey
    );
__declspec(dllimport)
LONG
__stdcall
RegDeleteKeyW (
     HKEY hKey,
     LPCWSTR lpSubKey
    );




#line 277 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegDeleteValueA (
     HKEY hKey,
     LPCSTR lpValueName
    );
__declspec(dllimport)
LONG
__stdcall
RegDeleteValueW (
     HKEY hKey,
     LPCWSTR lpValueName
    );




#line 297 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegEnumKeyA (
     HKEY hKey,
     DWORD dwIndex,
     LPSTR lpName,
     DWORD cbName
    );
__declspec(dllimport)
LONG
__stdcall
RegEnumKeyW (
     HKEY hKey,
     DWORD dwIndex,
     LPWSTR lpName,
     DWORD cbName
    );




#line 321 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegEnumKeyExA (
     HKEY hKey,
     DWORD dwIndex,
     LPSTR lpName,
      LPDWORD lpcbName,
     LPDWORD lpReserved,
      LPSTR lpClass,
      LPDWORD lpcbClass,
     PFILETIME lpftLastWriteTime
    );
__declspec(dllimport)
LONG
__stdcall
RegEnumKeyExW (
     HKEY hKey,
     DWORD dwIndex,
     LPWSTR lpName,
      LPDWORD lpcbName,
     LPDWORD lpReserved,
      LPWSTR lpClass,
      LPDWORD lpcbClass,
     PFILETIME lpftLastWriteTime
    );




#line 353 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegEnumValueA (
     HKEY hKey,
     DWORD dwIndex,
     LPSTR lpValueName,
      LPDWORD lpcbValueName,
     LPDWORD lpReserved,
     LPDWORD lpType,
     LPBYTE lpData,
      LPDWORD lpcbData
    );
__declspec(dllimport)
LONG
__stdcall
RegEnumValueW (
     HKEY hKey,
     DWORD dwIndex,
     LPWSTR lpValueName,
      LPDWORD lpcbValueName,
     LPDWORD lpReserved,
     LPDWORD lpType,
     LPBYTE lpData,
      LPDWORD lpcbData
    );




#line 385 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegFlushKey (
     HKEY hKey
    );

__declspec(dllimport)
LONG
__stdcall
RegGetKeySecurity (
     HKEY hKey,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor,
      LPDWORD lpcbSecurityDescriptor
    );

__declspec(dllimport)
LONG
__stdcall
RegLoadKeyA (
     HKEY    hKey,
     LPCSTR  lpSubKey,
     LPCSTR  lpFile
    );
__declspec(dllimport)
LONG
__stdcall
RegLoadKeyW (
     HKEY    hKey,
     LPCWSTR  lpSubKey,
     LPCWSTR  lpFile
    );




#line 424 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegNotifyChangeKeyValue (
     HKEY hKey,
     BOOL bWatchSubtree,
     DWORD dwNotifyFilter,
     HANDLE hEvent,
     BOOL fAsynchronus
    );

__declspec(dllimport)
LONG
__stdcall
RegOpenKeyA (
     HKEY hKey,
     LPCSTR lpSubKey,
     PHKEY phkResult
    );
__declspec(dllimport)
LONG
__stdcall
RegOpenKeyW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     PHKEY phkResult
    );




#line 457 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegOpenKeyExA (
     HKEY hKey,
     LPCSTR lpSubKey,
     DWORD ulOptions,
     REGSAM samDesired,
     PHKEY phkResult
    );
__declspec(dllimport)
LONG
__stdcall
RegOpenKeyExW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     DWORD ulOptions,
     REGSAM samDesired,
     PHKEY phkResult
    );




#line 483 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegQueryInfoKeyA (
     HKEY hKey,
     LPSTR lpClass,
      LPDWORD lpcbClass,
     LPDWORD lpReserved,
     LPDWORD lpcSubKeys,
     LPDWORD lpcbMaxSubKeyLen,
     LPDWORD lpcbMaxClassLen,
     LPDWORD lpcValues,
     LPDWORD lpcbMaxValueNameLen,
     LPDWORD lpcbMaxValueLen,
     LPDWORD lpcbSecurityDescriptor,
     PFILETIME lpftLastWriteTime
    );
__declspec(dllimport)
LONG
__stdcall
RegQueryInfoKeyW (
     HKEY hKey,
     LPWSTR lpClass,
      LPDWORD lpcbClass,
     LPDWORD lpReserved,
     LPDWORD lpcSubKeys,
     LPDWORD lpcbMaxSubKeyLen,
     LPDWORD lpcbMaxClassLen,
     LPDWORD lpcValues,
     LPDWORD lpcbMaxValueNameLen,
     LPDWORD lpcbMaxValueLen,
     LPDWORD lpcbSecurityDescriptor,
     PFILETIME lpftLastWriteTime
    );




#line 523 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegQueryValueA (
     HKEY hKey,
     LPCSTR lpSubKey,
     LPSTR lpValue,
      PLONG   lpcbValue
    );
__declspec(dllimport)
LONG
__stdcall
RegQueryValueW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     LPWSTR lpValue,
      PLONG   lpcbValue
    );




#line 547 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


__declspec(dllimport)
LONG
__stdcall
RegQueryMultipleValuesA (
     HKEY hKey,
     PVALENTA val_list,
     DWORD num_vals,
     LPSTR lpValueBuf,
      LPDWORD ldwTotsize
    );
__declspec(dllimport)
LONG
__stdcall
RegQueryMultipleValuesW (
     HKEY hKey,
     PVALENTW val_list,
     DWORD num_vals,
     LPWSTR lpValueBuf,
      LPDWORD ldwTotsize
    );




#line 574 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"
#line 575 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegQueryValueExA (
     HKEY hKey,
     LPCSTR lpValueName,
     LPDWORD lpReserved,
     LPDWORD lpType,
      LPBYTE lpData,
      LPDWORD lpcbData
    );
__declspec(dllimport)
LONG
__stdcall
RegQueryValueExW (
     HKEY hKey,
     LPCWSTR lpValueName,
     LPDWORD lpReserved,
     LPDWORD lpType,
      LPBYTE lpData,
      LPDWORD lpcbData
    );




#line 603 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegReplaceKeyA (
     HKEY     hKey,
     LPCSTR  lpSubKey,
     LPCSTR  lpNewFile,
     LPCSTR  lpOldFile
    );
__declspec(dllimport)
LONG
__stdcall
RegReplaceKeyW (
     HKEY     hKey,
     LPCWSTR  lpSubKey,
     LPCWSTR  lpNewFile,
     LPCWSTR  lpOldFile
    );




#line 627 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegRestoreKeyA (
     HKEY hKey,
     LPCSTR lpFile,
     DWORD   dwFlags
    );
__declspec(dllimport)
LONG
__stdcall
RegRestoreKeyW (
     HKEY hKey,
     LPCWSTR lpFile,
     DWORD   dwFlags
    );




#line 649 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegSaveKeyA (
     HKEY hKey,
     LPCSTR lpFile,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );
__declspec(dllimport)
LONG
__stdcall
RegSaveKeyW (
     HKEY hKey,
     LPCWSTR lpFile,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes
    );




#line 671 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegSetKeySecurity (
     HKEY hKey,
     SECURITY_INFORMATION SecurityInformation,
     PSECURITY_DESCRIPTOR pSecurityDescriptor
    );

__declspec(dllimport)
LONG
__stdcall
RegSetValueA (
     HKEY hKey,
     LPCSTR lpSubKey,
     DWORD dwType,
     LPCSTR lpData,
     DWORD cbData
    );
__declspec(dllimport)
LONG
__stdcall
RegSetValueW (
     HKEY hKey,
     LPCWSTR lpSubKey,
     DWORD dwType,
     LPCWSTR lpData,
     DWORD cbData
    );




#line 706 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


__declspec(dllimport)
LONG
__stdcall
RegSetValueExA (
     HKEY hKey,
     LPCSTR lpValueName,
     DWORD Reserved,
     DWORD dwType,
     const BYTE* lpData,
     DWORD cbData
    );
__declspec(dllimport)
LONG
__stdcall
RegSetValueExW (
     HKEY hKey,
     LPCWSTR lpValueName,
     DWORD Reserved,
     DWORD dwType,
     const BYTE* lpData,
     DWORD cbData
    );




#line 735 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
RegUnLoadKeyA (
     HKEY    hKey,
     LPCSTR lpSubKey
    );
__declspec(dllimport)
LONG
__stdcall
RegUnLoadKeyW (
     HKEY    hKey,
     LPCWSTR lpSubKey
    );




#line 755 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"





__declspec(dllimport)
BOOL
__stdcall
InitiateSystemShutdownA(
     LPSTR lpMachineName,
     LPSTR lpMessage,
     DWORD dwTimeout,
     BOOL bForceAppsClosed,
     BOOL bRebootAfterShutdown
    );
__declspec(dllimport)
BOOL
__stdcall
InitiateSystemShutdownW(
     LPWSTR lpMachineName,
     LPWSTR lpMessage,
     DWORD dwTimeout,
     BOOL bForceAppsClosed,
     BOOL bRebootAfterShutdown
    );




#line 785 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


__declspec(dllimport)
BOOL
__stdcall
AbortSystemShutdownA(
     LPSTR lpMachineName
    );
__declspec(dllimport)
BOOL
__stdcall
AbortSystemShutdownW(
     LPWSTR lpMachineName
    );




#line 804 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"





#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\reason.h"

































































    










#line 78 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\reason.h"
#line 810 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"












__declspec(dllimport)
BOOL
__stdcall
InitiateSystemShutdownExA(
     LPSTR lpMachineName,
     LPSTR lpMessage,
     DWORD dwTimeout,
     BOOL bForceAppsClosed,
     BOOL bRebootAfterShutdown,
     DWORD dwReason
    );
__declspec(dllimport)
BOOL
__stdcall
InitiateSystemShutdownExW(
     LPWSTR lpMachineName,
     LPWSTR lpMessage,
     DWORD dwTimeout,
     BOOL bForceAppsClosed,
     BOOL bRebootAfterShutdown,
     DWORD dwReason
    );




#line 849 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


__declspec(dllimport)
LONG
__stdcall
RegSaveKeyExA (
     HKEY hKey,
     LPCSTR lpFile,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     DWORD Flags
    );
__declspec(dllimport)
LONG
__stdcall
RegSaveKeyExW (
     HKEY hKey,
     LPCWSTR lpFile,
     LPSECURITY_ATTRIBUTES lpSecurityAttributes,
     DWORD Flags
    );




#line 874 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

__declspec(dllimport)
LONG
__stdcall
Wow64Win32ApiEntry (
    DWORD dwFuncNumber,
    DWORD dwFlag,
    DWORD dwRes
    );


}
#line 887 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"


#line 890 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winreg.h"

#line 174 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 175 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"



























extern "C" {
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"








































































#line 103 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"






#line 110 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"









#line 120 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"













#line 134 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"



#line 138 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

typedef struct  _NETRESOURCEA {
    DWORD    dwScope;
    DWORD    dwType;
    DWORD    dwDisplayType;
    DWORD    dwUsage;
    LPSTR    lpLocalName;
    LPSTR    lpRemoteName;
    LPSTR    lpComment ;
    LPSTR    lpProvider;
}NETRESOURCEA, *LPNETRESOURCEA;
typedef struct  _NETRESOURCEW {
    DWORD    dwScope;
    DWORD    dwType;
    DWORD    dwDisplayType;
    DWORD    dwUsage;
    LPWSTR   lpLocalName;
    LPWSTR   lpRemoteName;
    LPWSTR   lpComment ;
    LPWSTR   lpProvider;
}NETRESOURCEW, *LPNETRESOURCEW;




typedef NETRESOURCEA NETRESOURCE;
typedef LPNETRESOURCEA LPNETRESOURCE;
#line 166 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





















#line 188 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"



#line 192 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetAddConnectionA(
      LPCSTR   lpRemoteName,
      LPCSTR   lpPassword,
      LPCSTR   lpLocalName
    );
DWORD __stdcall
WNetAddConnectionW(
      LPCWSTR   lpRemoteName,
      LPCWSTR   lpPassword,
      LPCWSTR   lpLocalName
    );




#line 210 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetAddConnection2A(
      LPNETRESOURCEA lpNetResource,
      LPCSTR       lpPassword,
      LPCSTR       lpUserName,
      DWORD          dwFlags
    );
DWORD __stdcall
WNetAddConnection2W(
      LPNETRESOURCEW lpNetResource,
      LPCWSTR       lpPassword,
      LPCWSTR       lpUserName,
      DWORD          dwFlags
    );




#line 230 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetAddConnection3A(
      HWND           hwndOwner,
      LPNETRESOURCEA lpNetResource,
      LPCSTR       lpPassword,
      LPCSTR       lpUserName,
      DWORD          dwFlags
    );
DWORD __stdcall
WNetAddConnection3W(
      HWND           hwndOwner,
      LPNETRESOURCEW lpNetResource,
      LPCWSTR       lpPassword,
      LPCWSTR       lpUserName,
      DWORD          dwFlags
    );




#line 252 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetCancelConnectionA(
      LPCSTR lpName,
      BOOL     fForce
    );
DWORD __stdcall
WNetCancelConnectionW(
      LPCWSTR lpName,
      BOOL     fForce
    );




#line 268 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetCancelConnection2A(
      LPCSTR lpName,
      DWORD    dwFlags,
      BOOL     fForce
    );
DWORD __stdcall
WNetCancelConnection2W(
      LPCWSTR lpName,
      DWORD    dwFlags,
      BOOL     fForce
    );




#line 286 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetGetConnectionA(
      LPCSTR lpLocalName,
      LPSTR  lpRemoteName,
       LPDWORD  lpnLength
    );
DWORD __stdcall
WNetGetConnectionW(
      LPCWSTR lpLocalName,
      LPWSTR  lpRemoteName,
       LPDWORD  lpnLength
    );




#line 304 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"



DWORD __stdcall
WNetUseConnectionA(
     HWND            hwndOwner,
     LPNETRESOURCEA  lpNetResource,
     LPCSTR        lpPassword,
     LPCSTR        lpUserID,
     DWORD           dwFlags,
     LPSTR        lpAccessName,
      LPDWORD     lpBufferSize,
     LPDWORD        lpResult
    );
DWORD __stdcall
WNetUseConnectionW(
     HWND            hwndOwner,
     LPNETRESOURCEW  lpNetResource,
     LPCWSTR        lpPassword,
     LPCWSTR        lpUserID,
     DWORD           dwFlags,
     LPWSTR        lpAccessName,
      LPDWORD     lpBufferSize,
     LPDWORD        lpResult
    );




#line 334 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"
#line 335 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"






DWORD __stdcall
WNetConnectionDialog(
     HWND  hwnd,
     DWORD dwType
    );

DWORD __stdcall
WNetDisconnectDialog(
     HWND  hwnd,
     DWORD dwType
    );


typedef struct _CONNECTDLGSTRUCTA{
    DWORD cbStructure;       
    HWND hwndOwner;          
    LPNETRESOURCEA lpConnRes;
    DWORD dwFlags;           
    DWORD dwDevNum;          
} CONNECTDLGSTRUCTA,  *LPCONNECTDLGSTRUCTA;
typedef struct _CONNECTDLGSTRUCTW{
    DWORD cbStructure;       
    HWND hwndOwner;          
    LPNETRESOURCEW lpConnRes;
    DWORD dwFlags;           
    DWORD dwDevNum;          
} CONNECTDLGSTRUCTW,  *LPCONNECTDLGSTRUCTW;




typedef CONNECTDLGSTRUCTA CONNECTDLGSTRUCT;
typedef LPCONNECTDLGSTRUCTA LPCONNECTDLGSTRUCT;
#line 375 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"














DWORD __stdcall
WNetConnectionDialog1A(
      LPCONNECTDLGSTRUCTA lpConnDlgStruct
    );
DWORD __stdcall
WNetConnectionDialog1W(
      LPCONNECTDLGSTRUCTW lpConnDlgStruct
    );




#line 402 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

typedef struct _DISCDLGSTRUCTA{
    DWORD           cbStructure;      
    HWND            hwndOwner;        
    LPSTR           lpLocalName;      
    LPSTR           lpRemoteName;     
    DWORD           dwFlags;          
} DISCDLGSTRUCTA,  *LPDISCDLGSTRUCTA;
typedef struct _DISCDLGSTRUCTW{
    DWORD           cbStructure;      
    HWND            hwndOwner;        
    LPWSTR          lpLocalName;      
    LPWSTR          lpRemoteName;     
    DWORD           dwFlags;          
} DISCDLGSTRUCTW,  *LPDISCDLGSTRUCTW;




typedef DISCDLGSTRUCTA DISCDLGSTRUCT;
typedef LPDISCDLGSTRUCTA LPDISCDLGSTRUCT;
#line 424 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"




DWORD __stdcall
WNetDisconnectDialog1A(
     LPDISCDLGSTRUCTA lpConnDlgStruct
    );
DWORD __stdcall
WNetDisconnectDialog1W(
     LPDISCDLGSTRUCTW lpConnDlgStruct
    );




#line 441 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"
#line 442 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





DWORD __stdcall
WNetOpenEnumA(
      DWORD          dwScope,
      DWORD          dwType,
      DWORD          dwUsage,
      LPNETRESOURCEA lpNetResource,
      LPHANDLE       lphEnum
    );
DWORD __stdcall
WNetOpenEnumW(
      DWORD          dwScope,
      DWORD          dwType,
      DWORD          dwUsage,
      LPNETRESOURCEW lpNetResource,
      LPHANDLE       lphEnum
    );




#line 468 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetEnumResourceA(
      HANDLE  hEnum,
       LPDWORD lpcCount,
      LPVOID  lpBuffer,
       LPDWORD lpBufferSize
    );
DWORD __stdcall
WNetEnumResourceW(
      HANDLE  hEnum,
       LPDWORD lpcCount,
      LPVOID  lpBuffer,
       LPDWORD lpBufferSize
    );




#line 488 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetCloseEnum(
     HANDLE   hEnum
    );


DWORD __stdcall
WNetGetResourceParentA(
     LPNETRESOURCEA lpNetResource,
     LPVOID lpBuffer,
      LPDWORD lpcbBuffer
    );
DWORD __stdcall
WNetGetResourceParentW(
     LPNETRESOURCEW lpNetResource,
     LPVOID lpBuffer,
      LPDWORD lpcbBuffer
    );




#line 512 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetGetResourceInformationA(
     LPNETRESOURCEA  lpNetResource,
     LPVOID          lpBuffer,
      LPDWORD         lpcbBuffer,
     LPSTR         *lplpSystem
    );
DWORD __stdcall
WNetGetResourceInformationW(
     LPNETRESOURCEW  lpNetResource,
     LPVOID          lpBuffer,
      LPDWORD         lpcbBuffer,
     LPWSTR         *lplpSystem
    );




#line 532 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"
#line 533 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"








typedef struct  _UNIVERSAL_NAME_INFOA {
    LPSTR    lpUniversalName;
}UNIVERSAL_NAME_INFOA, *LPUNIVERSAL_NAME_INFOA;
typedef struct  _UNIVERSAL_NAME_INFOW {
    LPWSTR   lpUniversalName;
}UNIVERSAL_NAME_INFOW, *LPUNIVERSAL_NAME_INFOW;




typedef UNIVERSAL_NAME_INFOA UNIVERSAL_NAME_INFO;
typedef LPUNIVERSAL_NAME_INFOA LPUNIVERSAL_NAME_INFO;
#line 554 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

typedef struct  _REMOTE_NAME_INFOA {
    LPSTR    lpUniversalName;
    LPSTR    lpConnectionName;
    LPSTR    lpRemainingPath;
}REMOTE_NAME_INFOA, *LPREMOTE_NAME_INFOA;
typedef struct  _REMOTE_NAME_INFOW {
    LPWSTR   lpUniversalName;
    LPWSTR   lpConnectionName;
    LPWSTR   lpRemainingPath;
}REMOTE_NAME_INFOW, *LPREMOTE_NAME_INFOW;




typedef REMOTE_NAME_INFOA REMOTE_NAME_INFO;
typedef LPREMOTE_NAME_INFOA LPREMOTE_NAME_INFO;
#line 572 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

DWORD __stdcall
WNetGetUniversalNameA(
      LPCSTR lpLocalPath,
      DWORD    dwInfoLevel,
      LPVOID   lpBuffer,
       LPDWORD  lpBufferSize
     );
DWORD __stdcall
WNetGetUniversalNameW(
      LPCWSTR lpLocalPath,
      DWORD    dwInfoLevel,
      LPVOID   lpBuffer,
       LPDWORD  lpBufferSize
     );




#line 592 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





DWORD __stdcall
WNetGetUserA(
      LPCSTR  lpName,
      LPSTR   lpUserName,
       LPDWORD   lpnLength
    );
DWORD __stdcall
WNetGetUserW(
      LPCWSTR  lpName,
      LPWSTR   lpUserName,
       LPDWORD   lpnLength
    );




#line 614 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"











#line 626 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"



DWORD __stdcall
WNetGetProviderNameA(
     DWORD   dwNetType,
     LPSTR lpProviderName,
      LPDWORD lpBufferSize
    );
DWORD __stdcall
WNetGetProviderNameW(
     DWORD   dwNetType,
     LPWSTR lpProviderName,
      LPDWORD lpBufferSize
    );




#line 646 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

typedef struct _NETINFOSTRUCT{
    DWORD cbStructure;
    DWORD dwProviderVersion;
    DWORD dwStatus;
    DWORD dwCharacteristics;
    ULONG_PTR dwHandle;
    WORD  wNetType;
    DWORD dwPrinters;
    DWORD dwDrives;
} NETINFOSTRUCT,  *LPNETINFOSTRUCT;





DWORD __stdcall
WNetGetNetworkInformationA(
     LPCSTR          lpProvider,
     LPNETINFOSTRUCT   lpNetInfoStruct
    );
DWORD __stdcall
WNetGetNetworkInformationW(
     LPCWSTR          lpProvider,
     LPNETINFOSTRUCT   lpNetInfoStruct
    );




#line 677 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





typedef UINT ( __stdcall *PFNGETPROFILEPATHA) (
    LPCSTR    pszUsername,
    LPSTR     pszBuffer,
    UINT        cbBuffer
    );
typedef UINT ( __stdcall *PFNGETPROFILEPATHW) (
    LPCWSTR    pszUsername,
    LPWSTR     pszBuffer,
    UINT        cbBuffer
    );




#line 697 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

typedef UINT ( __stdcall *PFNRECONCILEPROFILEA) (
    LPCSTR    pszCentralFile,
    LPCSTR    pszLocalFile,
    DWORD       dwFlags
    );
typedef UINT ( __stdcall *PFNRECONCILEPROFILEW) (
    LPCWSTR    pszCentralFile,
    LPCWSTR    pszLocalFile,
    DWORD       dwFlags
    );




#line 713 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"









typedef BOOL ( __stdcall *PFNPROCESSPOLICIESA) (
    HWND        hwnd,
    LPCSTR    pszPath,
    LPCSTR    pszUsername,
    LPCSTR    pszComputerName,
    DWORD       dwFlags
    );
typedef BOOL ( __stdcall *PFNPROCESSPOLICIESW) (
    HWND        hwnd,
    LPCWSTR    pszPath,
    LPCWSTR    pszUsername,
    LPCWSTR    pszComputerName,
    DWORD       dwFlags
    );




#line 741 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"


#line 744 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





DWORD __stdcall
WNetGetLastErrorA(
      LPDWORD    lpError,
      LPSTR    lpErrorBuf,
      DWORD      nErrorBufSize,
      LPSTR    lpNameBuf,
      DWORD      nNameBufSize
    );
DWORD __stdcall
WNetGetLastErrorW(
      LPDWORD    lpError,
      LPWSTR    lpErrorBuf,
      DWORD      nErrorBufSize,
      LPWSTR    lpNameBuf,
      DWORD      nNameBufSize
    );




#line 770 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"





























#line 800 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"




















#line 821 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"












#line 834 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"






typedef struct _NETCONNECTINFOSTRUCT{
    DWORD cbStructure;
    DWORD dwFlags;
    DWORD dwSpeed;
    DWORD dwDelay;
    DWORD dwOptDataSize;
} NETCONNECTINFOSTRUCT,  *LPNETCONNECTINFOSTRUCT;






DWORD __stdcall
MultinetGetConnectionPerformanceA(
         LPNETRESOURCEA lpNetResource,
         LPNETCONNECTINFOSTRUCT lpNetConnectInfoStruct
        );
DWORD __stdcall
MultinetGetConnectionPerformanceW(
         LPNETRESOURCEW lpNetResource,
         LPNETCONNECTINFOSTRUCT lpNetConnectInfoStruct
        );




#line 868 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"
#line 869 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"


}
#line 873 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

#line 875 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winnetwk.h"

#line 177 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 178 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"




































#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"














































extern "C" {
#line 49 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"














































































































































































































































































































#line 352 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"






































































#line 423 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"




































#line 460 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"











































#line 504 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"



#line 508 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"











#line 520 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"









#line 530 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"


}
#line 534 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"


#line 537 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\stralign.h"

    

                                         



                                                      
#line 215 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"












#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"






























#line 32 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"


extern "C" {
#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"




































#line 73 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"


















































































































typedef struct _SERVICE_DESCRIPTIONA {
    LPSTR       lpDescription;
} SERVICE_DESCRIPTIONA, *LPSERVICE_DESCRIPTIONA;



typedef struct _SERVICE_DESCRIPTIONW {
    LPWSTR      lpDescription;
} SERVICE_DESCRIPTIONW, *LPSERVICE_DESCRIPTIONW;




typedef SERVICE_DESCRIPTIONA SERVICE_DESCRIPTION;
typedef LPSERVICE_DESCRIPTIONA LPSERVICE_DESCRIPTION;
#line 203 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"




typedef enum _SC_ACTION_TYPE {
        SC_ACTION_NONE          = 0,
        SC_ACTION_RESTART       = 1,
        SC_ACTION_REBOOT        = 2,
        SC_ACTION_RUN_COMMAND   = 3
} SC_ACTION_TYPE;

typedef struct _SC_ACTION {
    SC_ACTION_TYPE  Type;
    DWORD           Delay;
} SC_ACTION, *LPSC_ACTION;

typedef struct _SERVICE_FAILURE_ACTIONSA {
    DWORD       dwResetPeriod;
    LPSTR       lpRebootMsg;
    LPSTR       lpCommand;
    DWORD       cActions;



    SC_ACTION * lpsaActions;
} SERVICE_FAILURE_ACTIONSA, *LPSERVICE_FAILURE_ACTIONSA;
typedef struct _SERVICE_FAILURE_ACTIONSW {
    DWORD       dwResetPeriod;
    LPWSTR      lpRebootMsg;
    LPWSTR      lpCommand;
    DWORD       cActions;



    SC_ACTION * lpsaActions;
} SERVICE_FAILURE_ACTIONSW, *LPSERVICE_FAILURE_ACTIONSW;




typedef SERVICE_FAILURE_ACTIONSA SERVICE_FAILURE_ACTIONS;
typedef LPSERVICE_FAILURE_ACTIONSA LPSERVICE_FAILURE_ACTIONS;
#line 246 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"






struct SC_HANDLE__ { int unused; }; typedef struct SC_HANDLE__ *SC_HANDLE;
typedef SC_HANDLE   *LPSC_HANDLE;

struct SERVICE_STATUS_HANDLE__ { int unused; }; typedef struct SERVICE_STATUS_HANDLE__ *SERVICE_STATUS_HANDLE;





typedef enum _SC_STATUS_TYPE {
        SC_STATUS_PROCESS_INFO      = 0
} SC_STATUS_TYPE;




typedef enum _SC_ENUM_TYPE {
        SC_ENUM_PROCESS_INFO        = 0
} SC_ENUM_TYPE;






typedef struct _SERVICE_STATUS {
    DWORD   dwServiceType;
    DWORD   dwCurrentState;
    DWORD   dwControlsAccepted;
    DWORD   dwWin32ExitCode;
    DWORD   dwServiceSpecificExitCode;
    DWORD   dwCheckPoint;
    DWORD   dwWaitHint;
} SERVICE_STATUS, *LPSERVICE_STATUS;

typedef struct _SERVICE_STATUS_PROCESS {
    DWORD   dwServiceType;
    DWORD   dwCurrentState;
    DWORD   dwControlsAccepted;
    DWORD   dwWin32ExitCode;
    DWORD   dwServiceSpecificExitCode;
    DWORD   dwCheckPoint;
    DWORD   dwWaitHint;
    DWORD   dwProcessId;
    DWORD   dwServiceFlags;
} SERVICE_STATUS_PROCESS, *LPSERVICE_STATUS_PROCESS;






typedef struct _ENUM_SERVICE_STATUSA {
    LPSTR             lpServiceName;
    LPSTR             lpDisplayName;
    SERVICE_STATUS    ServiceStatus;
} ENUM_SERVICE_STATUSA, *LPENUM_SERVICE_STATUSA;
typedef struct _ENUM_SERVICE_STATUSW {
    LPWSTR            lpServiceName;
    LPWSTR            lpDisplayName;
    SERVICE_STATUS    ServiceStatus;
} ENUM_SERVICE_STATUSW, *LPENUM_SERVICE_STATUSW;




typedef ENUM_SERVICE_STATUSA ENUM_SERVICE_STATUS;
typedef LPENUM_SERVICE_STATUSA LPENUM_SERVICE_STATUS;
#line 321 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

typedef struct _ENUM_SERVICE_STATUS_PROCESSA {
    LPSTR                     lpServiceName;
    LPSTR                     lpDisplayName;
    SERVICE_STATUS_PROCESS    ServiceStatusProcess;
} ENUM_SERVICE_STATUS_PROCESSA, *LPENUM_SERVICE_STATUS_PROCESSA;
typedef struct _ENUM_SERVICE_STATUS_PROCESSW {
    LPWSTR                    lpServiceName;
    LPWSTR                    lpDisplayName;
    SERVICE_STATUS_PROCESS    ServiceStatusProcess;
} ENUM_SERVICE_STATUS_PROCESSW, *LPENUM_SERVICE_STATUS_PROCESSW;




typedef ENUM_SERVICE_STATUS_PROCESSA ENUM_SERVICE_STATUS_PROCESS;
typedef LPENUM_SERVICE_STATUS_PROCESSA LPENUM_SERVICE_STATUS_PROCESS;
#line 339 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"





typedef LPVOID  SC_LOCK;

typedef struct _QUERY_SERVICE_LOCK_STATUSA {
    DWORD   fIsLocked;
    LPSTR   lpLockOwner;
    DWORD   dwLockDuration;
} QUERY_SERVICE_LOCK_STATUSA, *LPQUERY_SERVICE_LOCK_STATUSA;
typedef struct _QUERY_SERVICE_LOCK_STATUSW {
    DWORD   fIsLocked;
    LPWSTR  lpLockOwner;
    DWORD   dwLockDuration;
} QUERY_SERVICE_LOCK_STATUSW, *LPQUERY_SERVICE_LOCK_STATUSW;




typedef QUERY_SERVICE_LOCK_STATUSA QUERY_SERVICE_LOCK_STATUS;
typedef LPQUERY_SERVICE_LOCK_STATUSA LPQUERY_SERVICE_LOCK_STATUS;
#line 363 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"







typedef struct _QUERY_SERVICE_CONFIGA {
    DWORD   dwServiceType;
    DWORD   dwStartType;
    DWORD   dwErrorControl;
    LPSTR   lpBinaryPathName;
    LPSTR   lpLoadOrderGroup;
    DWORD   dwTagId;
    LPSTR   lpDependencies;
    LPSTR   lpServiceStartName;
    LPSTR   lpDisplayName;
} QUERY_SERVICE_CONFIGA, *LPQUERY_SERVICE_CONFIGA;
typedef struct _QUERY_SERVICE_CONFIGW {
    DWORD   dwServiceType;
    DWORD   dwStartType;
    DWORD   dwErrorControl;
    LPWSTR  lpBinaryPathName;
    LPWSTR  lpLoadOrderGroup;
    DWORD   dwTagId;
    LPWSTR  lpDependencies;
    LPWSTR  lpServiceStartName;
    LPWSTR  lpDisplayName;
} QUERY_SERVICE_CONFIGW, *LPQUERY_SERVICE_CONFIGW;




typedef QUERY_SERVICE_CONFIGA QUERY_SERVICE_CONFIG;
typedef LPQUERY_SERVICE_CONFIGA LPQUERY_SERVICE_CONFIG;
#line 399 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"







typedef void (__stdcall *LPSERVICE_MAIN_FUNCTIONW)(
    DWORD   dwNumServicesArgs,
    LPWSTR  *lpServiceArgVectors
    );

typedef void (__stdcall *LPSERVICE_MAIN_FUNCTIONA)(
    DWORD   dwNumServicesArgs,
    LPSTR   *lpServiceArgVectors
    );





#line 421 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"






typedef struct _SERVICE_TABLE_ENTRYA {
    LPSTR                       lpServiceName;
    LPSERVICE_MAIN_FUNCTIONA    lpServiceProc;
}SERVICE_TABLE_ENTRYA, *LPSERVICE_TABLE_ENTRYA;
typedef struct _SERVICE_TABLE_ENTRYW {
    LPWSTR                      lpServiceName;
    LPSERVICE_MAIN_FUNCTIONW    lpServiceProc;
}SERVICE_TABLE_ENTRYW, *LPSERVICE_TABLE_ENTRYW;




typedef SERVICE_TABLE_ENTRYA SERVICE_TABLE_ENTRY;
typedef LPSERVICE_TABLE_ENTRYA LPSERVICE_TABLE_ENTRY;
#line 442 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"





typedef void (__stdcall *LPHANDLER_FUNCTION)(
    DWORD    dwControl
    );

typedef DWORD (__stdcall *LPHANDLER_FUNCTION_EX)(
    DWORD    dwControl,
    DWORD    dwEventType,
    LPVOID   lpEventData,
    LPVOID   lpContext
    );






__declspec(dllimport)
BOOL
__stdcall
ChangeServiceConfigA(
    SC_HANDLE    hService,
    DWORD        dwServiceType,
    DWORD        dwStartType,
    DWORD        dwErrorControl,
    LPCSTR     lpBinaryPathName,
    LPCSTR     lpLoadOrderGroup,
    LPDWORD      lpdwTagId,
    LPCSTR     lpDependencies,
    LPCSTR     lpServiceStartName,
    LPCSTR     lpPassword,
    LPCSTR     lpDisplayName
    );
__declspec(dllimport)
BOOL
__stdcall
ChangeServiceConfigW(
    SC_HANDLE    hService,
    DWORD        dwServiceType,
    DWORD        dwStartType,
    DWORD        dwErrorControl,
    LPCWSTR     lpBinaryPathName,
    LPCWSTR     lpLoadOrderGroup,
    LPDWORD      lpdwTagId,
    LPCWSTR     lpDependencies,
    LPCWSTR     lpServiceStartName,
    LPCWSTR     lpPassword,
    LPCWSTR     lpDisplayName
    );




#line 500 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
ChangeServiceConfig2A(
    SC_HANDLE    hService,
    DWORD        dwInfoLevel,
    LPVOID       lpInfo
    );
__declspec(dllimport)
BOOL
__stdcall
ChangeServiceConfig2W(
    SC_HANDLE    hService,
    DWORD        dwInfoLevel,
    LPVOID       lpInfo
    );




#line 522 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
CloseServiceHandle(
    SC_HANDLE   hSCObject
    );

__declspec(dllimport)
BOOL
__stdcall
ControlService(
    SC_HANDLE           hService,
    DWORD               dwControl,
    LPSERVICE_STATUS    lpServiceStatus
    );

__declspec(dllimport)
SC_HANDLE
__stdcall
CreateServiceA(
    SC_HANDLE    hSCManager,
    LPCSTR     lpServiceName,
    LPCSTR     lpDisplayName,
    DWORD        dwDesiredAccess,
    DWORD        dwServiceType,
    DWORD        dwStartType,
    DWORD        dwErrorControl,
    LPCSTR     lpBinaryPathName,
    LPCSTR     lpLoadOrderGroup,
    LPDWORD      lpdwTagId,
    LPCSTR     lpDependencies,
    LPCSTR     lpServiceStartName,
    LPCSTR     lpPassword
    );
__declspec(dllimport)
SC_HANDLE
__stdcall
CreateServiceW(
    SC_HANDLE    hSCManager,
    LPCWSTR     lpServiceName,
    LPCWSTR     lpDisplayName,
    DWORD        dwDesiredAccess,
    DWORD        dwServiceType,
    DWORD        dwStartType,
    DWORD        dwErrorControl,
    LPCWSTR     lpBinaryPathName,
    LPCWSTR     lpLoadOrderGroup,
    LPDWORD      lpdwTagId,
    LPCWSTR     lpDependencies,
    LPCWSTR     lpServiceStartName,
    LPCWSTR     lpPassword
    );




#line 580 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
DeleteService(
    SC_HANDLE   hService
    );

__declspec(dllimport)
BOOL
__stdcall
EnumDependentServicesA(
    SC_HANDLE               hService,
    DWORD                   dwServiceState,
    LPENUM_SERVICE_STATUSA  lpServices,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded,
    LPDWORD                 lpServicesReturned
    );
__declspec(dllimport)
BOOL
__stdcall
EnumDependentServicesW(
    SC_HANDLE               hService,
    DWORD                   dwServiceState,
    LPENUM_SERVICE_STATUSW  lpServices,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded,
    LPDWORD                 lpServicesReturned
    );




#line 615 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
EnumServicesStatusA(
    SC_HANDLE               hSCManager,
    DWORD                   dwServiceType,
    DWORD                   dwServiceState,
    LPENUM_SERVICE_STATUSA  lpServices,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded,
    LPDWORD                 lpServicesReturned,
    LPDWORD                 lpResumeHandle
    );
__declspec(dllimport)
BOOL
__stdcall
EnumServicesStatusW(
    SC_HANDLE               hSCManager,
    DWORD                   dwServiceType,
    DWORD                   dwServiceState,
    LPENUM_SERVICE_STATUSW  lpServices,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded,
    LPDWORD                 lpServicesReturned,
    LPDWORD                 lpResumeHandle
    );




#line 647 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
EnumServicesStatusExA(
    SC_HANDLE                  hSCManager,
    SC_ENUM_TYPE               InfoLevel,
    DWORD                      dwServiceType,
    DWORD                      dwServiceState,
    LPBYTE                     lpServices,
    DWORD                      cbBufSize,
    LPDWORD                    pcbBytesNeeded,
    LPDWORD                    lpServicesReturned,
    LPDWORD                    lpResumeHandle,
    LPCSTR                   pszGroupName
    );
__declspec(dllimport)
BOOL
__stdcall
EnumServicesStatusExW(
    SC_HANDLE                  hSCManager,
    SC_ENUM_TYPE               InfoLevel,
    DWORD                      dwServiceType,
    DWORD                      dwServiceState,
    LPBYTE                     lpServices,
    DWORD                      cbBufSize,
    LPDWORD                    pcbBytesNeeded,
    LPDWORD                    lpServicesReturned,
    LPDWORD                    lpResumeHandle,
    LPCWSTR                   pszGroupName
    );




#line 683 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
GetServiceKeyNameA(
    SC_HANDLE               hSCManager,
    LPCSTR                lpDisplayName,
    LPSTR                 lpServiceName,
    LPDWORD                 lpcchBuffer
    );
__declspec(dllimport)
BOOL
__stdcall
GetServiceKeyNameW(
    SC_HANDLE               hSCManager,
    LPCWSTR                lpDisplayName,
    LPWSTR                 lpServiceName,
    LPDWORD                 lpcchBuffer
    );




#line 707 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
GetServiceDisplayNameA(
    SC_HANDLE               hSCManager,
    LPCSTR                lpServiceName,
    LPSTR                 lpDisplayName,
    LPDWORD                 lpcchBuffer
    );
__declspec(dllimport)
BOOL
__stdcall
GetServiceDisplayNameW(
    SC_HANDLE               hSCManager,
    LPCWSTR                lpServiceName,
    LPWSTR                 lpDisplayName,
    LPDWORD                 lpcchBuffer
    );




#line 731 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
SC_LOCK
__stdcall
LockServiceDatabase(
    SC_HANDLE   hSCManager
    );

__declspec(dllimport)
BOOL
__stdcall
NotifyBootConfigStatus(
    BOOL     BootAcceptable
    );

__declspec(dllimport)
SC_HANDLE
__stdcall
OpenSCManagerA(
    LPCSTR lpMachineName,
    LPCSTR lpDatabaseName,
    DWORD   dwDesiredAccess
    );
__declspec(dllimport)
SC_HANDLE
__stdcall
OpenSCManagerW(
    LPCWSTR lpMachineName,
    LPCWSTR lpDatabaseName,
    DWORD   dwDesiredAccess
    );




#line 767 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
SC_HANDLE
__stdcall
OpenServiceA(
    SC_HANDLE   hSCManager,
    LPCSTR    lpServiceName,
    DWORD       dwDesiredAccess
    );
__declspec(dllimport)
SC_HANDLE
__stdcall
OpenServiceW(
    SC_HANDLE   hSCManager,
    LPCWSTR    lpServiceName,
    DWORD       dwDesiredAccess
    );




#line 789 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
QueryServiceConfigA(
    SC_HANDLE               hService,
    LPQUERY_SERVICE_CONFIGA lpServiceConfig,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded
    );
__declspec(dllimport)
BOOL
__stdcall
QueryServiceConfigW(
    SC_HANDLE               hService,
    LPQUERY_SERVICE_CONFIGW lpServiceConfig,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded
    );




#line 813 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
QueryServiceConfig2A(
    SC_HANDLE   hService,
    DWORD       dwInfoLevel,
    LPBYTE      lpBuffer,
    DWORD       cbBufSize,
    LPDWORD     pcbBytesNeeded
    );
__declspec(dllimport)
BOOL
__stdcall
QueryServiceConfig2W(
    SC_HANDLE   hService,
    DWORD       dwInfoLevel,
    LPBYTE      lpBuffer,
    DWORD       cbBufSize,
    LPDWORD     pcbBytesNeeded
    );




#line 839 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
QueryServiceLockStatusA(
    SC_HANDLE                       hSCManager,
    LPQUERY_SERVICE_LOCK_STATUSA    lpLockStatus,
    DWORD                           cbBufSize,
    LPDWORD                         pcbBytesNeeded
    );
__declspec(dllimport)
BOOL
__stdcall
QueryServiceLockStatusW(
    SC_HANDLE                       hSCManager,
    LPQUERY_SERVICE_LOCK_STATUSW    lpLockStatus,
    DWORD                           cbBufSize,
    LPDWORD                         pcbBytesNeeded
    );




#line 863 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
QueryServiceObjectSecurity(
    SC_HANDLE               hService,
    SECURITY_INFORMATION    dwSecurityInformation,
    PSECURITY_DESCRIPTOR    lpSecurityDescriptor,
    DWORD                   cbBufSize,
    LPDWORD                 pcbBytesNeeded
    );

__declspec(dllimport)
BOOL
__stdcall
QueryServiceStatus(
    SC_HANDLE           hService,
    LPSERVICE_STATUS    lpServiceStatus
    );

__declspec(dllimport)
BOOL
__stdcall
QueryServiceStatusEx(
    SC_HANDLE           hService,
    SC_STATUS_TYPE      InfoLevel,
    LPBYTE              lpBuffer,
    DWORD               cbBufSize,
    LPDWORD             pcbBytesNeeded
    );

__declspec(dllimport)
SERVICE_STATUS_HANDLE
__stdcall
RegisterServiceCtrlHandlerA(
    LPCSTR             lpServiceName,
    LPHANDLER_FUNCTION   lpHandlerProc
    );
__declspec(dllimport)
SERVICE_STATUS_HANDLE
__stdcall
RegisterServiceCtrlHandlerW(
    LPCWSTR             lpServiceName,
    LPHANDLER_FUNCTION   lpHandlerProc
    );




#line 913 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
SERVICE_STATUS_HANDLE
__stdcall
RegisterServiceCtrlHandlerExA(
    LPCSTR                lpServiceName,
    LPHANDLER_FUNCTION_EX   lpHandlerProc,
    LPVOID                  lpContext
    );
__declspec(dllimport)
SERVICE_STATUS_HANDLE
__stdcall
RegisterServiceCtrlHandlerExW(
    LPCWSTR                lpServiceName,
    LPHANDLER_FUNCTION_EX   lpHandlerProc,
    LPVOID                  lpContext
    );




#line 935 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
SetServiceObjectSecurity(
    SC_HANDLE               hService,
    SECURITY_INFORMATION    dwSecurityInformation,
    PSECURITY_DESCRIPTOR    lpSecurityDescriptor
    );

__declspec(dllimport)
BOOL
__stdcall
SetServiceStatus(
    SERVICE_STATUS_HANDLE   hServiceStatus,
    LPSERVICE_STATUS        lpServiceStatus
    );

__declspec(dllimport)
BOOL
__stdcall
StartServiceCtrlDispatcherA(
    const SERVICE_TABLE_ENTRYA *lpServiceStartTable
    );
__declspec(dllimport)
BOOL
__stdcall
StartServiceCtrlDispatcherW(
    const SERVICE_TABLE_ENTRYW *lpServiceStartTable
    );




#line 970 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"


__declspec(dllimport)
BOOL
__stdcall
StartServiceA(
    SC_HANDLE            hService,
    DWORD                dwNumServiceArgs,
    LPCSTR             *lpServiceArgVectors
    );
__declspec(dllimport)
BOOL
__stdcall
StartServiceW(
    SC_HANDLE            hService,
    DWORD                dwNumServiceArgs,
    LPCWSTR             *lpServiceArgVectors
    );




#line 993 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

__declspec(dllimport)
BOOL
__stdcall
UnlockServiceDatabase(
    SC_LOCK     ScLock
    );



}
#line 1005 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"

#line 1007 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsvc.h"
#line 228 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 229 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\mcx.h"












#pragma once
#line 15 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\mcx.h"

typedef struct _MODEMDEVCAPS {
    DWORD   dwActualSize;
    DWORD   dwRequiredSize;
    DWORD   dwDevSpecificOffset;
    DWORD   dwDevSpecificSize;

    
    DWORD   dwModemProviderVersion;
    DWORD   dwModemManufacturerOffset;
    DWORD   dwModemManufacturerSize;
    DWORD   dwModemModelOffset;
    DWORD   dwModemModelSize;
    DWORD   dwModemVersionOffset;
    DWORD   dwModemVersionSize;

    
    DWORD   dwDialOptions;          
    DWORD   dwCallSetupFailTimer;   
    DWORD   dwInactivityTimeout;    
    DWORD   dwSpeakerVolume;        
    DWORD   dwSpeakerMode;          
    DWORD   dwModemOptions;         
    DWORD   dwMaxDTERate;           
    DWORD   dwMaxDCERate;           

    
    BYTE    abVariablePortion [1];
} MODEMDEVCAPS, *PMODEMDEVCAPS, *LPMODEMDEVCAPS;

typedef struct _MODEMSETTINGS {
    DWORD   dwActualSize;
    DWORD   dwRequiredSize;
    DWORD   dwDevSpecificOffset;
    DWORD   dwDevSpecificSize;

    
    DWORD   dwCallSetupFailTimer;       
    DWORD   dwInactivityTimeout;        
    DWORD   dwSpeakerVolume;            
    DWORD   dwSpeakerMode;              
    DWORD   dwPreferredModemOptions;    

    
    DWORD   dwNegotiatedModemOptions;   
    DWORD   dwNegotiatedDCERate;        

    
    BYTE    abVariablePortion [1];
} MODEMSETTINGS, *PMODEMSETTINGS, *LPMODEMSETTINGS;

















































































































































































































































































































































































































































































































































































































































































#line 723 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\mcx.h"
#line 233 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 234 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"











extern "C" {
#line 14 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"






struct HIMC__ { int unused; }; typedef struct HIMC__ *HIMC;
struct HIMCC__ { int unused; }; typedef struct HIMCC__ *HIMCC;



#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

typedef HKL   *LPHKL;
typedef UINT  *LPUINT;

typedef struct tagCOMPOSITIONFORM {
    DWORD dwStyle;
    POINT ptCurrentPos;
    RECT  rcArea;
} COMPOSITIONFORM, *PCOMPOSITIONFORM,  *NPCOMPOSITIONFORM,  *LPCOMPOSITIONFORM;


typedef struct tagCANDIDATEFORM {
    DWORD dwIndex;
    DWORD dwStyle;
    POINT ptCurrentPos;
    RECT  rcArea;
} CANDIDATEFORM, *PCANDIDATEFORM,  *NPCANDIDATEFORM,  *LPCANDIDATEFORM;


typedef struct tagCANDIDATELIST {
    DWORD dwSize;
    DWORD dwStyle;
    DWORD dwCount;
    DWORD dwSelection;
    DWORD dwPageStart;
    DWORD dwPageSize;
    DWORD dwOffset[1];
} CANDIDATELIST, *PCANDIDATELIST,  *NPCANDIDATELIST,  *LPCANDIDATELIST;

typedef struct tagREGISTERWORDA {
    LPSTR   lpReading;
    LPSTR   lpWord;
} REGISTERWORDA, *PREGISTERWORDA,  *NPREGISTERWORDA,  *LPREGISTERWORDA;
typedef struct tagREGISTERWORDW {
    LPWSTR  lpReading;
    LPWSTR  lpWord;
} REGISTERWORDW, *PREGISTERWORDW,  *NPREGISTERWORDW,  *LPREGISTERWORDW;






typedef REGISTERWORDA REGISTERWORD;
typedef PREGISTERWORDA PREGISTERWORD;
typedef NPREGISTERWORDA NPREGISTERWORD;
typedef LPREGISTERWORDA LPREGISTERWORD;
#line 74 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"



typedef struct tagRECONVERTSTRING {
    DWORD dwSize;
    DWORD dwVersion;
    DWORD dwStrLen;
    DWORD dwStrOffset;
    DWORD dwCompStrLen;
    DWORD dwCompStrOffset;
    DWORD dwTargetStrLen;
    DWORD dwTargetStrOffset;
} RECONVERTSTRING, *PRECONVERTSTRING,  *NPRECONVERTSTRING,  *LPRECONVERTSTRING;

#line 89 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"



typedef struct tagSTYLEBUFA {
    DWORD       dwStyle;
    CHAR        szDescription[32];
} STYLEBUFA, *PSTYLEBUFA,  *NPSTYLEBUFA,  *LPSTYLEBUFA;
typedef struct tagSTYLEBUFW {
    DWORD       dwStyle;
    WCHAR       szDescription[32];
} STYLEBUFW, *PSTYLEBUFW,  *NPSTYLEBUFW,  *LPSTYLEBUFW;






typedef STYLEBUFA STYLEBUF;
typedef PSTYLEBUFA PSTYLEBUF;
typedef NPSTYLEBUFA NPSTYLEBUF;
typedef LPSTYLEBUFA LPSTYLEBUF;
#line 111 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"






typedef struct tagIMEMENUITEMINFOA {
    UINT        cbSize;
    UINT        fType;
    UINT        fState;
    UINT        wID;
    HBITMAP     hbmpChecked;
    HBITMAP     hbmpUnchecked;
    DWORD       dwItemData;
    CHAR        szString[80];
    HBITMAP     hbmpItem;
} IMEMENUITEMINFOA, *PIMEMENUITEMINFOA,  *NPIMEMENUITEMINFOA,  *LPIMEMENUITEMINFOA;
typedef struct tagIMEMENUITEMINFOW {
    UINT        cbSize;
    UINT        fType;
    UINT        fState;
    UINT        wID;
    HBITMAP     hbmpChecked;
    HBITMAP     hbmpUnchecked;
    DWORD       dwItemData;
    WCHAR       szString[80];
    HBITMAP     hbmpItem;
} IMEMENUITEMINFOW, *PIMEMENUITEMINFOW,  *NPIMEMENUITEMINFOW,  *LPIMEMENUITEMINFOW;






typedef IMEMENUITEMINFOA IMEMENUITEMINFO;
typedef PIMEMENUITEMINFOA PIMEMENUITEMINFO;
typedef NPIMEMENUITEMINFOA NPIMEMENUITEMINFO;
typedef LPIMEMENUITEMINFOA LPIMEMENUITEMINFO;
#line 150 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

typedef struct tagIMECHARPOSITION {
    DWORD       dwSize;
    DWORD       dwCharPos;
    POINT       pt;
    UINT        cLineHeight;
    RECT        rcDocument;
} IMECHARPOSITION, *PIMECHARPOSITION,  *NPIMECHARPOSITION,  *LPIMECHARPOSITION;

typedef BOOL    (__stdcall* IMCENUMPROC)(HIMC, LPARAM);

#line 162 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"



HKL  __stdcall ImmInstallIMEA( LPCSTR lpszIMEFileName,  LPCSTR lpszLayoutText);
HKL  __stdcall ImmInstallIMEW( LPCWSTR lpszIMEFileName,  LPCWSTR lpszLayoutText);




#line 172 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

HWND __stdcall ImmGetDefaultIMEWnd( HWND);

UINT __stdcall ImmGetDescriptionA( HKL,  LPSTR,  UINT uBufLen);
UINT __stdcall ImmGetDescriptionW( HKL,  LPWSTR,  UINT uBufLen);




#line 182 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

UINT __stdcall ImmGetIMEFileNameA( HKL,  LPSTR,  UINT uBufLen);
UINT __stdcall ImmGetIMEFileNameW( HKL,  LPWSTR,  UINT uBufLen);




#line 190 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

DWORD __stdcall ImmGetProperty( HKL,  DWORD);

BOOL __stdcall ImmIsIME( HKL);

BOOL __stdcall ImmSimulateHotKey( HWND,  DWORD);

HIMC __stdcall ImmCreateContext(void);
BOOL __stdcall ImmDestroyContext( HIMC);
HIMC __stdcall ImmGetContext( HWND);
BOOL __stdcall ImmReleaseContext( HWND,  HIMC);
HIMC __stdcall ImmAssociateContext( HWND,  HIMC);

BOOL __stdcall ImmAssociateContextEx( HWND,  HIMC,  DWORD);
#line 205 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

LONG  __stdcall ImmGetCompositionStringA( HIMC,  DWORD,  LPVOID,  DWORD);
LONG  __stdcall ImmGetCompositionStringW( HIMC,  DWORD,  LPVOID,  DWORD);




#line 213 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL  __stdcall ImmSetCompositionStringA( HIMC,  DWORD dwIndex,  LPVOID lpComp,  DWORD,  LPVOID lpRead,  DWORD);
BOOL  __stdcall ImmSetCompositionStringW( HIMC,  DWORD dwIndex,  LPVOID lpComp,  DWORD,  LPVOID lpRead,  DWORD);




#line 221 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

DWORD __stdcall ImmGetCandidateListCountA( HIMC,  LPDWORD lpdwListCount);
DWORD __stdcall ImmGetCandidateListCountW( HIMC,  LPDWORD lpdwListCount);




#line 229 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

DWORD __stdcall ImmGetCandidateListA( HIMC,  DWORD deIndex,  LPCANDIDATELIST,  DWORD dwBufLen);
DWORD __stdcall ImmGetCandidateListW( HIMC,  DWORD deIndex,  LPCANDIDATELIST,  DWORD dwBufLen);




#line 237 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

DWORD __stdcall ImmGetGuideLineA( HIMC,  DWORD dwIndex,  LPSTR,  DWORD dwBufLen);
DWORD __stdcall ImmGetGuideLineW( HIMC,  DWORD dwIndex,  LPWSTR,  DWORD dwBufLen);




#line 245 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL __stdcall ImmGetConversionStatus( HIMC,  LPDWORD,  LPDWORD);
BOOL __stdcall ImmSetConversionStatus( HIMC,  DWORD,  DWORD);
BOOL __stdcall ImmGetOpenStatus( HIMC);
BOOL __stdcall ImmSetOpenStatus( HIMC,  BOOL);


BOOL __stdcall ImmGetCompositionFontA( HIMC,  LPLOGFONTA);
BOOL __stdcall ImmGetCompositionFontW( HIMC,  LPLOGFONTW);




#line 259 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL __stdcall ImmSetCompositionFontA( HIMC,  LPLOGFONTA);
BOOL __stdcall ImmSetCompositionFontW( HIMC,  LPLOGFONTW);




#line 267 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"
#line 268 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL    __stdcall ImmConfigureIMEA( HKL,  HWND,  DWORD,  LPVOID);
BOOL    __stdcall ImmConfigureIMEW( HKL,  HWND,  DWORD,  LPVOID);




#line 276 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

LRESULT __stdcall ImmEscapeA( HKL,  HIMC,  UINT,  LPVOID);
LRESULT __stdcall ImmEscapeW( HKL,  HIMC,  UINT,  LPVOID);




#line 284 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

DWORD   __stdcall ImmGetConversionListA( HKL,  HIMC,  LPCSTR,  LPCANDIDATELIST,  DWORD dwBufLen,  UINT uFlag);
DWORD   __stdcall ImmGetConversionListW( HKL,  HIMC,  LPCWSTR,  LPCANDIDATELIST,  DWORD dwBufLen,  UINT uFlag);




#line 292 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL    __stdcall ImmNotifyIME( HIMC,  DWORD dwAction,  DWORD dwIndex,  DWORD dwValue);

BOOL __stdcall ImmGetStatusWindowPos( HIMC,  LPPOINT);
BOOL __stdcall ImmSetStatusWindowPos( HIMC,  LPPOINT);
BOOL __stdcall ImmGetCompositionWindow( HIMC,  LPCOMPOSITIONFORM);
BOOL __stdcall ImmSetCompositionWindow( HIMC,  LPCOMPOSITIONFORM);
BOOL __stdcall ImmGetCandidateWindow( HIMC,  DWORD,  LPCANDIDATEFORM);
BOOL __stdcall ImmSetCandidateWindow( HIMC,  LPCANDIDATEFORM);

BOOL __stdcall ImmIsUIMessageA( HWND,  UINT,  WPARAM,  LPARAM);
BOOL __stdcall ImmIsUIMessageW( HWND,  UINT,  WPARAM,  LPARAM);




#line 309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"


UINT __stdcall ImmGetVirtualKey( HWND);

typedef int (__stdcall *REGISTERWORDENUMPROCA)(LPCSTR, DWORD, LPCSTR, LPVOID);
typedef int (__stdcall *REGISTERWORDENUMPROCW)(LPCWSTR, DWORD, LPCWSTR, LPVOID);




#line 320 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL __stdcall ImmRegisterWordA( HKL,  LPCSTR lpszReading,  DWORD,  LPCSTR lpszRegister);
BOOL __stdcall ImmRegisterWordW( HKL,  LPCWSTR lpszReading,  DWORD,  LPCWSTR lpszRegister);




#line 328 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

BOOL __stdcall ImmUnregisterWordA( HKL,  LPCSTR lpszReading,  DWORD,  LPCSTR lpszUnregister);
BOOL __stdcall ImmUnregisterWordW( HKL,  LPCWSTR lpszReading,  DWORD,  LPCWSTR lpszUnregister);




#line 336 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

UINT __stdcall ImmGetRegisterWordStyleA( HKL,  UINT nItem,  LPSTYLEBUFA);
UINT __stdcall ImmGetRegisterWordStyleW( HKL,  UINT nItem,  LPSTYLEBUFW);




#line 344 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

UINT __stdcall ImmEnumRegisterWordA( HKL,  REGISTERWORDENUMPROCA,  LPCSTR lpszReading,  DWORD,  LPCSTR lpszRegister,  LPVOID);
UINT __stdcall ImmEnumRegisterWordW( HKL,  REGISTERWORDENUMPROCW,  LPCWSTR lpszReading,  DWORD,  LPCWSTR lpszRegister,  LPVOID);




#line 352 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"


BOOL __stdcall ImmDisableIME( DWORD);
BOOL __stdcall ImmEnumInputContext(DWORD idThread, IMCENUMPROC lpfn, LPARAM lParam);
DWORD __stdcall ImmGetImeMenuItemsA( HIMC,  DWORD,  DWORD,  LPIMEMENUITEMINFOA,  LPIMEMENUITEMINFOA,  DWORD);
DWORD __stdcall ImmGetImeMenuItemsW( HIMC,  DWORD,  DWORD,  LPIMEMENUITEMINFOW,  LPIMEMENUITEMINFOW,  DWORD);




#line 363 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"
#line 364 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"




































































































































































































































































#line 625 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"





































































#line 695 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"








#line 704 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"


}
#line 708 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"

#line 710 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\imm.h"
#line 237 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 238 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 239 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 240 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"




#pragma warning(pop)





#line 251 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 252 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 253 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 255 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 257 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"
#line 258 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\windows.h"

#line 9 "d:\\liuxiong\\bombman\\gamemanager\\stdafx.h"

#using <mscorlib.dll>

#line 4 "t.cpp"

#line 1 "d:\\liuxiong\\bombman\\gamemanager\\GameManager.h"

#line 1 "d:\\liuxiong\\bombman\\gamemanager\\Global.h"
#pragma once




















enum Cell {
		EMPTY		= 0x001,
		BUNNY1		= 0x002,
		BUNNY2		= 0x004,
		BUNNY3		= 0x008,
		BUNNY4		= 0x010,
		BOMB		= 0x020,
		SOFTWALL	= 0x040,
		EXPLOSION	= 0x080,
		HARDWALL	= 0x100,
		TREASURE	= 0x200,
		EXPLODED	= 0x400,
};

enum DIRECTION {
	LEFT = 0,
	UP,
	RIGHT,
	DOWN
};

enum STATUS {
	DEAD = 0,
	ALIVE,
	INVINCIBLE
};

typedef struct {
	int r;
	int c;
	int range;
	int counter;
	int owner;
	int nGameID;
} Bomb;

typedef struct {
	int nUserID;	
	int nGameID;
	int r;	
	int c;	
	int nBombs;	
	int nBombsLeft;	
	int range;	
	TCHAR* strUserName;	
	int status;
	Bomb bomb[4];
} Bunny;

typedef struct {
	int nHumans; 
	int nRobots; 
	Bunny bunny[4];
	WORD  arBoard[11][13];
	int   nHighScore;
	int nPlayers;	
	int nAlives;	
} Game;

typedef struct {
	Game game[5];	
} Server;










#line 95 "d:\\liuxiong\\bombman\\gamemanager\\Global.h"
#line 3 "d:\\liuxiong\\bombman\\gamemanager\\GameManager.h"
#line 1 "d:\\liuxiong\\bombman\\gamemanager\\UDPServer.h"
#pragma once











#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"



























#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"























#pragma warning(disable:4103)

#pragma pack(push,4)


#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\pshpack4.h"
#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"



#line 42 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
















#line 59 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"



#line 63 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 75 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 76 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


extern "C" {
#line 80 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




typedef unsigned char   u_char;
typedef unsigned short  u_short;
typedef unsigned int    u_int;
typedef unsigned long   u_long;
typedef unsigned __int64 u_int64;






typedef UINT_PTR        SOCKET;











#line 108 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

typedef struct fd_set {
        u_int fd_count;               
        SOCKET  fd_array[64];   
} fd_set;

extern int __stdcall  __WSAFDIsSet(SOCKET, fd_set  *);






































struct timeval {
        long    tv_sec;         
        long    tv_usec;        
};



























                                        
























struct  hostent {
        char     * h_name;           
        char     *  * h_aliases;  
        short   h_addrtype;             
        short   h_length;               
        char     *  * h_addr_list; 

};





struct  netent {
        char     * n_name;           
        char     *  * n_aliases;  
        short   n_addrtype;             
        u_long  n_net;                  
};

struct  servent {
        char     * s_name;           
        char     *  * s_aliases;  




        short   s_port;                 
        char     * s_proto;          
#line 239 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
};

struct  protoent {
        char     * p_name;           
        char     *  * p_aliases;  
        short   p_proto;                
};































































                                        

















struct in_addr {
        union {
                struct { u_char s_b1,s_b2,s_b3,s_b4; } S_un_b;
                struct { u_short s_w1,s_w2; } S_un_w;
                u_long S_addr;
        } S_un;

                                

                                

                                

                                

                                

                                
};







































struct sockaddr_in {
        short   sin_family;
        u_short sin_port;
        struct  in_addr sin_addr;
        char    sin_zero[8];
};




typedef struct WSAData {
        WORD                    wVersion;
        WORD                    wHighVersion;







        char                    szDescription[256+1];
        char                    szSystemStatus[128+1];
        unsigned short          iMaxSockets;
        unsigned short          iMaxUdpDg;
        char  *              lpVendorInfo;
#line 411 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
} WSADATA,  * LPWSADATA;






































































#line 483 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


                                       
                                       
                                       


























































struct sockaddr {
        u_short sa_family;              
        char    sa_data[14];            
};



















struct sockaddr_storage {
    short ss_family;               
    char __ss_pad1[((sizeof(__int64)) - sizeof (short))];  
                                   
                                   
                                   
    __int64 __ss_align;            
    char __ss_pad2[(128 - (sizeof (short) + ((sizeof(__int64)) - sizeof (short)) + (sizeof(__int64))))];  
                                   
                                   
                                   
};





struct sockproto {
        u_short sp_family;              
        u_short sp_protocol;            
};



































struct  linger {
        u_short l_onoff;                
        u_short l_linger;               
};










































































































































































































































































































#line 928 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"































typedef DWORD                   WSAEVENT,  * LPWSAEVENT;

typedef struct _WSAOVERLAPPED {
    DWORD    Internal;
    DWORD    InternalHigh;
    DWORD    Offset;
    DWORD    OffsetHigh;
    WSAEVENT hEvent;
} WSAOVERLAPPED,  * LPWSAOVERLAPPED;















#line 984 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"






typedef struct _WSABUF {
    u_long      len;     
    char  *  buf;     
} WSABUF,  * LPWSABUF;

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\qos.h"

























typedef ULONG   SERVICETYPE;





























































typedef struct _flowspec
{
    ULONG       TokenRate;              
    ULONG       TokenBucketSize;        
    ULONG       PeakBandwidth;          
    ULONG       Latency;                
    ULONG       DelayVariation;         
    SERVICETYPE ServiceType;
    ULONG       MaxSduSize;             
    ULONG       MinimumPolicedSize;     

} FLOWSPEC, *PFLOWSPEC, * LPFLOWSPEC;































typedef struct  {

    ULONG   ObjectType;
    ULONG   ObjectLength;  


} QOS_OBJECT_HDR, *LPQOS_OBJECT_HDR;









          

          

          

          




















typedef struct _QOS_SD_MODE {

    QOS_OBJECT_HDR   ObjectHdr;
    ULONG            ShapeDiscardMode;

} QOS_SD_MODE, *LPQOS_SD_MODE;















typedef struct _QOS_SHAPING_RATE {

    QOS_OBJECT_HDR   ObjectHdr;
    ULONG            ShapingRate;

} QOS_SHAPING_RATE, *LPQOS_SHAPING_RATE;


#line 204 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\qos.h"
#line 996 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

typedef struct _QualityOfService
{
    FLOWSPEC      SendingFlowspec;       
    FLOWSPEC      ReceivingFlowspec;     
    WSABUF        ProviderSpecific;      
} QOS,  * LPQOS;


















typedef unsigned int             GROUP;







typedef struct _WSANETWORKEVENTS {
       long lNetworkEvents;
       int iErrorCode[10];
} WSANETWORKEVENTS,  * LPWSANETWORKEVENTS;















typedef struct _WSAPROTOCOLCHAIN {
    int ChainLen;                                 
                                                  
                                                  
                                                  
    DWORD ChainEntries[7];       
} WSAPROTOCOLCHAIN,  * LPWSAPROTOCOLCHAIN;



typedef struct _WSAPROTOCOL_INFOA {
    DWORD dwServiceFlags1;
    DWORD dwServiceFlags2;
    DWORD dwServiceFlags3;
    DWORD dwServiceFlags4;
    DWORD dwProviderFlags;
    GUID ProviderId;
    DWORD dwCatalogEntryId;
    WSAPROTOCOLCHAIN ProtocolChain;
    int iVersion;
    int iAddressFamily;
    int iMaxSockAddr;
    int iMinSockAddr;
    int iSocketType;
    int iProtocol;
    int iProtocolMaxOffset;
    int iNetworkByteOrder;
    int iSecurityScheme;
    DWORD dwMessageSize;
    DWORD dwProviderReserved;
    CHAR   szProtocol[255+1];
} WSAPROTOCOL_INFOA,  * LPWSAPROTOCOL_INFOA;
typedef struct _WSAPROTOCOL_INFOW {
    DWORD dwServiceFlags1;
    DWORD dwServiceFlags2;
    DWORD dwServiceFlags3;
    DWORD dwServiceFlags4;
    DWORD dwProviderFlags;
    GUID ProviderId;
    DWORD dwCatalogEntryId;
    WSAPROTOCOLCHAIN ProtocolChain;
    int iVersion;
    int iAddressFamily;
    int iMaxSockAddr;
    int iMinSockAddr;
    int iSocketType;
    int iProtocol;
    int iProtocolMaxOffset;
    int iNetworkByteOrder;
    int iSecurityScheme;
    DWORD dwMessageSize;
    DWORD dwProviderReserved;
    WCHAR  szProtocol[255+1];
} WSAPROTOCOL_INFOW,  * LPWSAPROTOCOL_INFOW;




typedef WSAPROTOCOL_INFOA WSAPROTOCOL_INFO;
typedef LPWSAPROTOCOL_INFOA LPWSAPROTOCOL_INFO;
#line 1109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"























































































typedef
int
(__stdcall * LPCONDITIONPROC)(
     LPWSABUF lpCallerId,
     LPWSABUF lpCallerData,
      LPQOS lpSQOS,
      LPQOS lpGQOS,
     LPWSABUF lpCalleeId,
     LPWSABUF lpCalleeData,
     GROUP  * g,
     DWORD_PTR dwCallbackData
    );

typedef
void
(__stdcall * LPWSAOVERLAPPED_COMPLETION_ROUTINE)(
     DWORD dwError,
     DWORD cbTransferred,
     LPWSAOVERLAPPED lpOverlapped,
     DWORD dwFlags
    );







typedef enum _WSACOMPLETIONTYPE {
    NSP_NOTIFY_IMMEDIATELY = 0,
    NSP_NOTIFY_HWND,
    NSP_NOTIFY_EVENT,
    NSP_NOTIFY_PORT,
    NSP_NOTIFY_APC,
} WSACOMPLETIONTYPE, *PWSACOMPLETIONTYPE,  * LPWSACOMPLETIONTYPE;

typedef struct _WSACOMPLETION {
    WSACOMPLETIONTYPE Type;
    union {
        struct {
            HWND hWnd;
            UINT uMsg;
            WPARAM context;
        } WindowMessage;
        struct {
            LPWSAOVERLAPPED lpOverlapped;
        } Event;
        struct {
            LPWSAOVERLAPPED lpOverlapped;
            LPWSAOVERLAPPED_COMPLETION_ROUTINE lpfnCompletionProc;
        } Apc;
        struct {
            LPWSAOVERLAPPED lpOverlapped;
            HANDLE hPort;
            ULONG_PTR Key;
        } Port;
    } Parameters;
} WSACOMPLETION, *PWSACOMPLETION,  *LPWSACOMPLETION;













typedef struct sockaddr SOCKADDR;
typedef struct sockaddr *PSOCKADDR;
typedef struct sockaddr  *LPSOCKADDR;

typedef struct sockaddr_storage SOCKADDR_STORAGE;
typedef struct sockaddr_storage *PSOCKADDR_STORAGE;
typedef struct sockaddr_storage  *LPSOCKADDR_STORAGE;










typedef struct _BLOB {
    ULONG cbSize ;



    BYTE *pBlobData ;
#line 1291 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
} BLOB, *LPBLOB ;
#line 1293 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

















































#line 1343 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

































#line 1377 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








typedef struct _SOCKET_ADDRESS {
    LPSOCKADDR lpSockaddr ;
    INT iSockaddrLength ;
} SOCKET_ADDRESS, *PSOCKET_ADDRESS,  * LPSOCKET_ADDRESS ;




typedef struct _CSADDR_INFO {
    SOCKET_ADDRESS LocalAddr ;
    SOCKET_ADDRESS RemoteAddr ;
    INT iSocketType ;
    INT iProtocol ;
} CSADDR_INFO, *PCSADDR_INFO,  * LPCSADDR_INFO ;
#line 1400 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




typedef struct _SOCKET_ADDRESS_LIST {
    INT             iAddressCount;
    SOCKET_ADDRESS  Address[1];
} SOCKET_ADDRESS_LIST,  * LPSOCKET_ADDRESS_LIST;




typedef struct _AFPROTOCOLS {
    INT iAddressFamily;
    INT iProtocol;
} AFPROTOCOLS, *PAFPROTOCOLS, *LPAFPROTOCOLS;








typedef enum _WSAEcomparator
{
    COMP_EQUAL = 0,
    COMP_NOTLESS
} WSAECOMPARATOR, *PWSAECOMPARATOR, *LPWSAECOMPARATOR;

typedef struct _WSAVersion
{
    DWORD           dwVersion;
    WSAECOMPARATOR  ecHow;
}WSAVERSION, *PWSAVERSION, *LPWSAVERSION;

typedef struct _WSAQuerySetA
{
    DWORD           dwSize;
    LPSTR           lpszServiceInstanceName;
    LPGUID          lpServiceClassId;
    LPWSAVERSION    lpVersion;
    LPSTR           lpszComment;
    DWORD           dwNameSpace;
    LPGUID          lpNSProviderId;
    LPSTR           lpszContext;
    DWORD           dwNumberOfProtocols;
    LPAFPROTOCOLS   lpafpProtocols;
    LPSTR           lpszQueryString;
    DWORD           dwNumberOfCsAddrs;
    LPCSADDR_INFO   lpcsaBuffer;
    DWORD           dwOutputFlags;
    LPBLOB          lpBlob;
} WSAQUERYSETA, *PWSAQUERYSETA, *LPWSAQUERYSETA;
typedef struct _WSAQuerySetW
{
    DWORD           dwSize;
    LPWSTR          lpszServiceInstanceName;
    LPGUID          lpServiceClassId;
    LPWSAVERSION    lpVersion;
    LPWSTR          lpszComment;
    DWORD           dwNameSpace;
    LPGUID          lpNSProviderId;
    LPWSTR          lpszContext;
    DWORD           dwNumberOfProtocols;
    LPAFPROTOCOLS   lpafpProtocols;
    LPWSTR          lpszQueryString;
    DWORD           dwNumberOfCsAddrs;
    LPCSADDR_INFO   lpcsaBuffer;
    DWORD           dwOutputFlags;
    LPBLOB          lpBlob;
} WSAQUERYSETW, *PWSAQUERYSETW, *LPWSAQUERYSETW;





typedef WSAQUERYSETA WSAQUERYSET;
typedef PWSAQUERYSETA PWSAQUERYSET;
typedef LPWSAQUERYSETA LPWSAQUERYSET;
#line 1481 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


































typedef enum _WSAESETSERVICEOP
{
    RNRSERVICE_REGISTER=0,
    RNRSERVICE_DEREGISTER,
    RNRSERVICE_DELETE
} WSAESETSERVICEOP, *PWSAESETSERVICEOP, *LPWSAESETSERVICEOP;





typedef struct _WSANSClassInfoA
{
    LPSTR   lpszName;
    DWORD   dwNameSpace;
    DWORD   dwValueType;
    DWORD   dwValueSize;
    LPVOID  lpValue;
}WSANSCLASSINFOA, *PWSANSCLASSINFOA, *LPWSANSCLASSINFOA;
typedef struct _WSANSClassInfoW
{
    LPWSTR  lpszName;
    DWORD   dwNameSpace;
    DWORD   dwValueType;
    DWORD   dwValueSize;
    LPVOID  lpValue;
}WSANSCLASSINFOW, *PWSANSCLASSINFOW, *LPWSANSCLASSINFOW;





typedef WSANSCLASSINFOA WSANSCLASSINFO;
typedef PWSANSCLASSINFOA PWSANSCLASSINFO;
typedef LPWSANSCLASSINFOA LPWSANSCLASSINFO;
#line 1551 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

typedef struct _WSAServiceClassInfoA
{
    LPGUID              lpServiceClassId;
    LPSTR               lpszServiceClassName;
    DWORD               dwCount;
    LPWSANSCLASSINFOA   lpClassInfos;
}WSASERVICECLASSINFOA, *PWSASERVICECLASSINFOA, *LPWSASERVICECLASSINFOA;
typedef struct _WSAServiceClassInfoW
{
    LPGUID              lpServiceClassId;
    LPWSTR              lpszServiceClassName;
    DWORD               dwCount;
    LPWSANSCLASSINFOW   lpClassInfos;
}WSASERVICECLASSINFOW, *PWSASERVICECLASSINFOW, *LPWSASERVICECLASSINFOW;





typedef WSASERVICECLASSINFOA WSASERVICECLASSINFO;
typedef PWSASERVICECLASSINFOA PWSASERVICECLASSINFO;
typedef LPWSASERVICECLASSINFOA LPWSASERVICECLASSINFO;
#line 1575 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

typedef struct _WSANAMESPACE_INFOA {
    GUID                NSProviderId;
    DWORD               dwNameSpace;
    BOOL                fActive;
    DWORD               dwVersion;
    LPSTR               lpszIdentifier;
} WSANAMESPACE_INFOA, *PWSANAMESPACE_INFOA, *LPWSANAMESPACE_INFOA;
typedef struct _WSANAMESPACE_INFOW {
    GUID                NSProviderId;
    DWORD               dwNameSpace;
    BOOL                fActive;
    DWORD               dwVersion;
    LPWSTR              lpszIdentifier;
} WSANAMESPACE_INFOW, *PWSANAMESPACE_INFOW, *LPWSANAMESPACE_INFOW;





typedef WSANAMESPACE_INFOA WSANAMESPACE_INFO;
typedef PWSANAMESPACE_INFOA PWSANAMESPACE_INFO;
typedef LPWSANAMESPACE_INFOA LPWSANAMESPACE_INFO;
#line 1599 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




__declspec(dllimport)
SOCKET
 __stdcall
accept(
     SOCKET s,
     struct sockaddr  * addr,
      int  * addrlen
    );
#line 1612 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1622 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
bind(
     SOCKET s,
     const struct sockaddr  * name,
     int namelen
    );
#line 1633 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1643 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
closesocket(
     SOCKET s
    );
#line 1652 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1660 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
connect(
     SOCKET s,
     const struct sockaddr  * name,
     int namelen
    );
#line 1671 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1681 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
ioctlsocket(
     SOCKET s,
     long cmd,
      u_long  * argp
    );
#line 1692 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1702 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
getpeername(
     SOCKET s,
     struct sockaddr  * name,
      int  * namelen
    );
#line 1713 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1723 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
getsockname(
     SOCKET s,
     struct sockaddr  * name,
      int  * namelen
    );
#line 1734 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 1744 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
getsockopt(
     SOCKET s,
     int level,
     int optname,
     char  * optval,
      int  * optlen
    );
#line 1757 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 1769 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
u_long
 __stdcall
htonl(
     u_long hostlong
    );
#line 1778 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1786 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
u_short
 __stdcall
htons(
     u_short hostshort
    );
#line 1795 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1803 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
unsigned long
 __stdcall
inet_addr(
     const char  * cp
    );
#line 1812 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1820 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
char  *
 __stdcall
inet_ntoa(
     struct in_addr in
    );
#line 1829 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1837 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
listen(
     SOCKET s,
     int backlog
    );
#line 1847 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 1856 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
u_long
 __stdcall
ntohl(
     u_long netlong
    );
#line 1865 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1873 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
u_short
 __stdcall
ntohs(
     u_short netshort
    );
#line 1882 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 1890 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
recv(
     SOCKET s,
     char  * buf,
     int len,
     int flags
    );
#line 1902 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"










#line 1913 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
recvfrom(
     SOCKET s,
     char  * buf,
     int len,
     int flags,
     struct sockaddr  * from,
      int  * fromlen
    );
#line 1927 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"












#line 1940 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
select(
     int nfds,
      fd_set  * readfds,
      fd_set  * writefds,
      fd_set  *exceptfds,
     const struct timeval  * timeout
    );
#line 1953 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 1965 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
send(
     SOCKET s,
     const char  * buf,
     int len,
     int flags
    );
#line 1977 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"










#line 1988 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
sendto(
     SOCKET s,
     const char  * buf,
     int len,
     int flags,
     const struct sockaddr  * to,
     int tolen
    );
#line 2002 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"












#line 2015 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
setsockopt(
     SOCKET s,
     int level,
     int optname,
     const char  * optval,
     int optlen
    );
#line 2028 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2040 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
shutdown(
     SOCKET s,
     int how
    );
#line 2050 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 2059 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
SOCKET
 __stdcall
socket(
     int af,
     int type,
     int protocol
    );
#line 2070 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2080 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




__declspec(dllimport)
struct hostent  *
 __stdcall
gethostbyaddr(
     const char  * addr,
     int len,
     int type
    );
#line 2093 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2103 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
struct hostent  *
 __stdcall
gethostbyname(
     const char  * name
    );
#line 2112 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2120 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
gethostname(
     char  * name,
     int namelen
    );
#line 2130 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 2139 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
struct servent  *
 __stdcall
getservbyport(
     int port,
     const char  * proto
    );
#line 2149 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 2158 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
struct servent  *
 __stdcall
getservbyname(
     const char  * name,
     const char  * proto
    );
#line 2168 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 2177 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
struct protoent  *
 __stdcall
getprotobynumber(
     int number
    );
#line 2186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2194 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
struct protoent  *
 __stdcall
getprotobyname(
     const char  * name
    );
#line 2203 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2211 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




__declspec(dllimport)
int
 __stdcall
WSAStartup(
     WORD wVersionRequested,
     LPWSADATA lpWSAData
    );
#line 2223 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 2232 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSACleanup(
    void
    );
#line 2241 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2249 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
void
 __stdcall
WSASetLastError(
     int iError
    );
#line 2258 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2266 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAGetLastError(
    void
    );
#line 2275 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2283 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSAIsBlocking(
    void
    );
#line 2292 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2300 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAUnhookBlockingHook(
    void
    );
#line 2309 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2317 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
FARPROC
 __stdcall
WSASetBlockingHook(
     FARPROC lpBlockFunc
    );
#line 2326 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2334 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSACancelBlockingCall(
    void
    );
#line 2343 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2351 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetServByName(
     HWND hWnd,
     u_int wMsg,
     const char  * name,
     const char  * proto,
     char  * buf,
     int buflen
    );
#line 2365 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"












#line 2378 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetServByPort(
     HWND hWnd,
     u_int wMsg,
     int port,
     const char  * proto,
     char  * buf,
     int buflen
    );
#line 2392 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"












#line 2405 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetProtoByName(
     HWND hWnd,
     u_int wMsg,
     const char  * name,
     char  * buf,
     int buflen
    );
#line 2418 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2430 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetProtoByNumber(
     HWND hWnd,
     u_int wMsg,
     int number,
     char  * buf,
     int buflen
    );
#line 2443 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2455 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetHostByName(
     HWND hWnd,
     u_int wMsg,
     const char  * name,
     char  * buf,
     int buflen
    );
#line 2468 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2480 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
HANDLE
 __stdcall
WSAAsyncGetHostByAddr(
     HWND hWnd,
     u_int wMsg,
     const char  * addr,
     int len,
     int type,
     char  * buf,
     int buflen
    );
#line 2495 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"













#line 2509 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSACancelAsyncRequest(
     HANDLE hAsyncTaskHandle
    );
#line 2518 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2526 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAAsyncSelect(
     SOCKET s,
     HWND hWnd,
     u_int wMsg,
     long lEvent
    );
#line 2538 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"










#line 2549 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"




__declspec(dllimport)
SOCKET
 __stdcall
WSAAccept(
     SOCKET s,
     struct sockaddr  * addr,
      LPINT addrlen,
     LPCONDITIONPROC lpfnCondition,
     DWORD_PTR dwCallbackData
    );
#line 2564 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2576 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSACloseEvent(
     WSAEVENT hEvent
    );
#line 2585 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2593 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAConnect(
     SOCKET s,
     const struct sockaddr  * name,
     int namelen,
     LPWSABUF lpCallerData,
     LPWSABUF lpCalleeData,
     LPQOS lpSQOS,
     LPQOS lpGQOS
    );
#line 2608 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"













#line 2622 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
WSAEVENT
 __stdcall
WSACreateEvent(
    void
    );
#line 2631 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 2639 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSADuplicateSocketA(
     SOCKET s,
     DWORD dwProcessId,
     LPWSAPROTOCOL_INFOA lpProtocolInfo
    );
__declspec(dllimport)
int
 __stdcall
WSADuplicateSocketW(
     SOCKET s,
     DWORD dwProcessId,
     LPWSAPROTOCOL_INFOW lpProtocolInfo
    );




#line 2662 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 2663 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





















#line 2685 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAEnumNetworkEvents(
     SOCKET s,
     WSAEVENT hEventObject,
     LPWSANETWORKEVENTS lpNetworkEvents
    );
#line 2696 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2706 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAEnumProtocolsA(
     LPINT lpiProtocols,
     LPWSAPROTOCOL_INFOA lpProtocolBuffer,
      LPDWORD lpdwBufferLength
    );
__declspec(dllimport)
int
 __stdcall
WSAEnumProtocolsW(
     LPINT lpiProtocols,
     LPWSAPROTOCOL_INFOW lpProtocolBuffer,
      LPDWORD lpdwBufferLength
    );




#line 2729 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 2730 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





















#line 2752 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAEventSelect(
     SOCKET s,
     WSAEVENT hEventObject,
     long lNetworkEvents
    );
#line 2763 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2773 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSAGetOverlappedResult(
     SOCKET s,
     LPWSAOVERLAPPED lpOverlapped,
     LPDWORD lpcbTransfer,
     BOOL fWait,
     LPDWORD lpdwFlags
    );
#line 2786 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 2798 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSAGetQOSByName(
     SOCKET s,
     LPWSABUF lpQOSName,
     LPQOS lpQOS
    );
#line 2809 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2819 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAHtonl(
     SOCKET s,
     u_long hostlong,
     u_long  * lpnetlong
    );
#line 2830 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2840 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAHtons(
     SOCKET s,
     u_short hostshort,
     u_short  * lpnetshort
    );
#line 2851 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2861 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSAIoctl(
     SOCKET s,
     DWORD dwIoControlCode,
     LPVOID lpvInBuffer,
     DWORD cbInBuffer,
     LPVOID lpvOutBuffer,
     DWORD cbOutBuffer,
     LPDWORD lpcbBytesReturned,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 2878 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"















#line 2894 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
SOCKET
 __stdcall
WSAJoinLeaf(
     SOCKET s,
     const struct sockaddr  * name,
     int namelen,
     LPWSABUF lpCallerData,
     LPWSABUF lpCalleeData,
     LPQOS lpSQOS,
     LPQOS lpGQOS,
     DWORD dwFlags
    );
#line 2910 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"














#line 2925 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSANtohl(
     SOCKET s,
     u_long netlong,
     u_long  * lphostlong
    );
#line 2936 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2946 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSANtohs(
     SOCKET s,
     u_short netshort,
     u_short  * lphostshort
    );
#line 2957 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 2967 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSARecv(
     SOCKET s,
      LPWSABUF lpBuffers,
     DWORD dwBufferCount,
     LPDWORD lpNumberOfBytesRecvd,
      LPDWORD lpFlags,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 2982 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"













#line 2996 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSARecvDisconnect(
     SOCKET s,
     LPWSABUF lpInboundDisconnectData
    );
#line 3006 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 3015 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSARecvFrom(
     SOCKET s,
      LPWSABUF lpBuffers,
     DWORD dwBufferCount,
     LPDWORD lpNumberOfBytesRecvd,
      LPDWORD lpFlags,
     struct sockaddr  * lpFrom,
      LPINT lpFromlen,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 3032 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"















#line 3048 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSAResetEvent(
     WSAEVENT hEvent
    );
#line 3057 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 3065 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSASend(
     SOCKET s,
     LPWSABUF lpBuffers,
     DWORD dwBufferCount,
     LPDWORD lpNumberOfBytesSent,
     DWORD dwFlags,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 3080 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"













#line 3094 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSASendDisconnect(
     SOCKET s,
     LPWSABUF lpOutboundDisconnectData
    );
#line 3104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"








#line 3113 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
int
 __stdcall
WSASendTo(
     SOCKET s,
     LPWSABUF lpBuffers,
     DWORD dwBufferCount,
     LPDWORD lpNumberOfBytesSent,
     DWORD dwFlags,
     const struct sockaddr  * lpTo,
     int iTolen,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 3130 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"















#line 3146 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
BOOL
 __stdcall
WSASetEvent(
     WSAEVENT hEvent
    );
#line 3155 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 3163 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
SOCKET
 __stdcall
WSASocketA(
     int af,
     int type,
     int protocol,
     LPWSAPROTOCOL_INFOA lpProtocolInfo,
     GROUP g,
     DWORD dwFlags
    );
__declspec(dllimport)
SOCKET
 __stdcall
WSASocketW(
     int af,
     int type,
     int protocol,
     LPWSAPROTOCOL_INFOW lpProtocolInfo,
     GROUP g,
     DWORD dwFlags
    );




#line 3192 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3193 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"



























#line 3221 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
DWORD
 __stdcall
WSAWaitForMultipleEvents(
     DWORD cEvents,
     const WSAEVENT  * lphEvents,
     BOOL fWaitAll,
     DWORD dwTimeout,
     BOOL fAlertable
    );
#line 3234 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"











#line 3246 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAAddressToStringA(
         LPSOCKADDR          lpsaAddress,
         DWORD               dwAddressLength,
         LPWSAPROTOCOL_INFOA lpProtocolInfo,
      LPSTR             lpszAddressString,
      LPDWORD             lpdwAddressStringLength
    );
__declspec(dllimport)
INT
 __stdcall
WSAAddressToStringW(
         LPSOCKADDR          lpsaAddress,
         DWORD               dwAddressLength,
         LPWSAPROTOCOL_INFOW lpProtocolInfo,
      LPWSTR             lpszAddressString,
      LPDWORD             lpdwAddressStringLength
    );




#line 3273 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3274 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

























#line 3300 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAStringToAddressA(
         LPSTR               AddressString,
         INT                 AddressFamily,
         LPWSAPROTOCOL_INFOA lpProtocolInfo,
        LPSOCKADDR          lpAddress,
      LPINT               lpAddressLength
    );
__declspec(dllimport)
INT
 __stdcall
WSAStringToAddressW(
         LPWSTR              AddressString,
         INT                 AddressFamily,
         LPWSAPROTOCOL_INFOW lpProtocolInfo,
        LPSOCKADDR          lpAddress,
      LPINT               lpAddressLength
    );




#line 3327 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3328 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

























#line 3354 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





__declspec(dllimport)
INT
 __stdcall
WSALookupServiceBeginA(
      LPWSAQUERYSETA lpqsRestrictions,
      DWORD          dwControlFlags,
     LPHANDLE       lphLookup
    );
__declspec(dllimport)
INT
 __stdcall
WSALookupServiceBeginW(
      LPWSAQUERYSETW lpqsRestrictions,
      DWORD          dwControlFlags,
     LPHANDLE       lphLookup
    );




#line 3380 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3381 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





















#line 3403 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSALookupServiceNextA(
         HANDLE           hLookup,
         DWORD            dwControlFlags,
      LPDWORD          lpdwBufferLength,
        LPWSAQUERYSETA   lpqsResults
    );
__declspec(dllimport)
INT
 __stdcall
WSALookupServiceNextW(
         HANDLE           hLookup,
         DWORD            dwControlFlags,
      LPDWORD          lpdwBufferLength,
        LPWSAQUERYSETW   lpqsResults
    );




#line 3428 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3429 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"























#line 3453 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSANSPIoctl(
      HANDLE           hLookup,
      DWORD            dwControlCode,
      LPVOID           lpvInBuffer,
      DWORD            cbInBuffer,
     LPVOID           lpvOutBuffer,
      DWORD            cbOutBuffer,
     LPDWORD          lpcbBytesReturned,
      LPWSACOMPLETION  lpCompletion
    );
#line 3469 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"














#line 3484 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSALookupServiceEnd(
     HANDLE  hLookup
    );
#line 3493 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 3501 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAInstallServiceClassA(
      LPWSASERVICECLASSINFOA   lpServiceClassInfo
    );
__declspec(dllimport)
INT
 __stdcall
WSAInstallServiceClassW(
      LPWSASERVICECLASSINFOW   lpServiceClassInfo
    );




#line 3520 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3521 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"

















#line 3539 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSARemoveServiceClass(
      LPGUID  lpServiceClassId
    );
#line 3548 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"







#line 3556 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAGetServiceClassInfoA(
      LPGUID  lpProviderId,
      LPGUID  lpServiceClassId,
      LPDWORD  lpdwBufSize,
     LPWSASERVICECLASSINFOA lpServiceClassInfo
    );
__declspec(dllimport)
INT
 __stdcall
WSAGetServiceClassInfoW(
      LPGUID  lpProviderId,
      LPGUID  lpServiceClassId,
      LPDWORD  lpdwBufSize,
     LPWSASERVICECLASSINFOW lpServiceClassInfo
    );




#line 3581 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3582 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"























#line 3606 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAEnumNameSpaceProvidersA(
      LPDWORD              lpdwBufferLength,
        LPWSANAMESPACE_INFOA lpnspBuffer
    );
__declspec(dllimport)
INT
 __stdcall
WSAEnumNameSpaceProvidersW(
      LPDWORD              lpdwBufferLength,
        LPWSANAMESPACE_INFOW lpnspBuffer
    );




#line 3627 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3628 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"



















#line 3648 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAGetServiceClassNameByClassIdA(
          LPGUID  lpServiceClassId,
         LPSTR lpszServiceClassName,
       LPDWORD lpdwBufferLength
    );
__declspec(dllimport)
INT
 __stdcall
WSAGetServiceClassNameByClassIdW(
          LPGUID  lpServiceClassId,
         LPWSTR lpszServiceClassName,
       LPDWORD lpdwBufferLength
    );




#line 3671 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3672 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





















#line 3694 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSASetServiceA(
     LPWSAQUERYSETA lpqsRegInfo,
     WSAESETSERVICEOP essoperation,
     DWORD dwControlFlags
    );
__declspec(dllimport)
INT
 __stdcall
WSASetServiceW(
     LPWSAQUERYSETW lpqsRegInfo,
     WSAESETSERVICEOP essoperation,
     DWORD dwControlFlags
    );




#line 3717 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3718 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





















#line 3740 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


__declspec(dllimport)
INT
 __stdcall
WSAProviderConfigChange(
      LPHANDLE lpNotificationHandle,
     LPWSAOVERLAPPED lpOverlapped,
     LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
    );
#line 3751 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"









#line 3761 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


typedef struct sockaddr_in SOCKADDR_IN;
typedef struct sockaddr_in *PSOCKADDR_IN;
typedef struct sockaddr_in  *LPSOCKADDR_IN;

typedef struct linger LINGER;
typedef struct linger *PLINGER;
typedef struct linger  *LPLINGER;

typedef struct in_addr IN_ADDR;
typedef struct in_addr *PIN_ADDR;
typedef struct in_addr  *LPIN_ADDR;

typedef struct fd_set FD_SET;
typedef struct fd_set *PFD_SET;
typedef struct fd_set  *LPFD_SET;

typedef struct hostent HOSTENT;
typedef struct hostent *PHOSTENT;
typedef struct hostent  *LPHOSTENT;

typedef struct servent SERVENT;
typedef struct servent *PSERVENT;
typedef struct servent  *LPSERVENT;

typedef struct protoent PROTOENT;
typedef struct protoent *PPROTOENT;
typedef struct protoent  *LPPROTOENT;

typedef struct timeval TIMEVAL;
typedef struct timeval *PTIMEVAL;
typedef struct timeval  *LPTIMEVAL;








































}
#line 3836 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


























#pragma warning(disable:4103)

#pragma pack(pop)


#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\poppack.h"
#line 3839 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 3840 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"





#line 3846 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\PlatformSDK\\include\\winsock2.h"
#line 14 "d:\\liuxiong\\bombman\\gamemanager\\UDPServer.h"
#line 1 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"
#pragma once











#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\strstream"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\istream"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ios"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cerrno"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

#pragma once





		


		



		

 
  
 

#line 22 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

 
  
 #line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

 

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"












#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"

#pragma comment(lib,"libcpmtd")


#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"







#line 45 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"

#line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\use_ansi.h"
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"


 
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"


 
   

#line 40 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"
    
   #line 42 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"
 #line 43 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

 

#line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"


 
  
 

#line 54 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

		
 
  
  
  

  
   
   

  
  
  
  

 












#line 84 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

 

 
namespace std {
typedef bool _Bool;
}
 #line 92 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"

		





		






typedef __int64 _Longlong;
typedef unsigned __int64 _ULonglong;

		


 







		
		





 
namespace std {
		
class  _Lockit
	{	
public:
  
	explicit _Lockit();	
	explicit _Lockit(int);	
	~_Lockit();	

private:
	_Lockit(const _Lockit&);				
	_Lockit& operator=(const _Lockit&);	

	int _Locktype;
  












#line 157 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"
	};

class  _Mutex
	{	
public:
  
	_Mutex();
	~_Mutex();
	void _Lock();
	void _Unlock();

private:
	_Mutex(const _Mutex&);				
	_Mutex& operator=(const _Mutex&);	
	void *_Mtx;
  







#line 181 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"
	};

class _Init_locks
	{	
public:
 
	_Init_locks();
	~_Init_locks();
 







#line 198 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"
	};
}
 #line 201 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"


		

extern "C" {
 void __cdecl _Atexit(void (__cdecl *)(void));
}

typedef int _Mbstatet;





#line 216 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\yvals.h"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cerrno"






 #line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"
















#pragma once
#line 19 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"






#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"



extern "C" {
#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"


















#line 50 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"




 extern int * __cdecl _errno(void);



#line 59 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"
















































}
#line 109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"

#line 111 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\errno.h"
#line 13 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cerrno"

namespace std {
  


}
#line 20 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cerrno"
#line 21 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cerrno"




#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\climits"

#pragma once




 #pragma warning(disable: 4514)

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"













#line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"
















#line 56 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"





#line 62 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"





#line 68 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"








#line 77 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"








#line 86 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"
































#line 119 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\limits.h"
#line 10 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\climits"
#line 11 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\climits"





#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdio"

#pragma once









 

namespace std {
using ::size_t; using ::fpos_t; using ::FILE;
using ::clearerr; using ::fclose; using ::feof;
using ::ferror; using ::fflush; using ::fgetc;
using ::fgetpos; using ::fgets; using ::fopen;
using ::fprintf; using ::fputc; using ::fputs;
using ::fread; using ::freopen; using ::fscanf;
using ::fseek; using ::fsetpos; using ::ftell;
using ::fwrite; using ::getc; using ::getchar;
using ::gets; using ::perror;
using ::putc; using ::putchar;
using ::printf; using ::puts; using ::remove;
using ::rename; using ::rewind; using ::scanf;
using ::setbuf; using ::setvbuf; using ::sprintf;
using ::sscanf; using ::tmpfile; using ::tmpnam;
using ::ungetc; using ::vfprintf; using ::vprintf;
using ::vsprintf;
}
#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdio"
#line 34 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdio"





#line 8 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdlib"

#pragma once









 #line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
















#pragma once
#line 19 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"






#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"







#pragma pack(push,8)
#line 35 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


extern "C" {
#line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"








#line 48 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
















#line 65 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"




































typedef int (__cdecl * _onexit_t)(void);



#line 106 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

#line 108 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"






typedef struct _div_t {
        int quot;
        int rem;
} div_t;

typedef struct _ldiv_t {
        long quot;
        long rem;
} ldiv_t;


#line 126 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"














































typedef void (__cdecl * _secerr_handler_func)(int, void *);
#line 174 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"




 int * __cdecl _errno(void);
 unsigned long * __cdecl __doserrno(void);





#line 186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


 extern char * _sys_errlist[];   
 extern int _sys_nerr;           

























#line 216 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

 extern int __argc;          
 extern char ** __argv;      
 extern wchar_t ** __wargv;  




 extern char ** _environ;    
 extern wchar_t ** _wenviron;    
#line 227 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

 extern char * _pgmptr;      
 extern wchar_t * _wpgmptr;  

#line 232 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


 extern int _fmode;          
 extern int _fileinfo;       




 extern unsigned int _osplatform;
 extern unsigned int _osver;
 extern unsigned int _winver;
 extern unsigned int _winmajor;
 extern unsigned int _winminor;





 __declspec(noreturn) void   __cdecl abort(void);
 __declspec(noreturn) void   __cdecl exit(int);



#line 256 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"



#line 260 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
        int    __cdecl abs(int);
#line 262 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
        __int64    __cdecl _abs64(__int64);
        int    __cdecl atexit(void (__cdecl *)(void));
 double __cdecl atof(const char *);
 int    __cdecl atoi(const char *);
 long   __cdecl atol(const char *);
 void * __cdecl bsearch(const void *, const void *, size_t, size_t,
        int (__cdecl *)(const void *, const void *));
        unsigned short __cdecl _byteswap_ushort(unsigned short);
        unsigned long  __cdecl _byteswap_ulong (unsigned long);
        unsigned __int64 __cdecl _byteswap_uint64(unsigned __int64);
 void * __cdecl calloc(size_t, size_t);
 div_t  __cdecl div(int, int);
 void   __cdecl free(void *);
 char * __cdecl getenv(const char *);
 char * __cdecl _itoa(int, char *, int);

 char * __cdecl _i64toa(__int64, char *, int);
 char * __cdecl _ui64toa(unsigned __int64, char *, int);
 __int64 __cdecl _atoi64(const char *);
 __int64 __cdecl _strtoi64(const char *, char **, int);
 unsigned __int64 __cdecl _strtoui64(const char *, char **, int);
#line 284 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


#line 287 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
        long __cdecl labs(long);
#line 289 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
 ldiv_t __cdecl ldiv(long, long);
 char * __cdecl _ltoa(long, char *, int);
 void * __cdecl malloc(size_t);
 int    __cdecl mblen(const char *, size_t);
 size_t __cdecl _mbstrlen(const char *s);
 int    __cdecl mbtowc(wchar_t *, const char *, size_t);
 size_t __cdecl mbstowcs(wchar_t *, const char *, size_t);
 void   __cdecl qsort(void *, size_t, size_t, int (__cdecl *)
        (const void *, const void *));
 int    __cdecl rand(void);
 void * __cdecl realloc(void *, size_t);
 int    __cdecl _set_error_mode(int);

 _secerr_handler_func
               __cdecl _set_security_error_handler(_secerr_handler_func);
#line 305 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
 void   __cdecl srand(unsigned int);
 double __cdecl strtod(const char *, char **);
 long   __cdecl strtol(const char *, char **, int);
 unsigned long __cdecl strtoul(const char *, char **, int);
 int    __cdecl system(const char *);
 char * __cdecl _ultoa(unsigned long, char *, int);
 int    __cdecl wctomb(char *, wchar_t);
 size_t __cdecl wcstombs(char *, const wchar_t *, size_t);






 wchar_t * __cdecl _itow (int, wchar_t *, int);
 wchar_t * __cdecl _ltow (long, wchar_t *, int);
 wchar_t * __cdecl _ultow (unsigned long, wchar_t *, int);
 double __cdecl wcstod(const wchar_t *, wchar_t **);
 long   __cdecl wcstol(const wchar_t *, wchar_t **, int);
 unsigned long __cdecl wcstoul(const wchar_t *, wchar_t **, int);
 wchar_t * __cdecl _wgetenv(const wchar_t *);
 int    __cdecl _wsystem(const wchar_t *);
 double __cdecl _wtof(const wchar_t *);
 int __cdecl _wtoi(const wchar_t *);
 long __cdecl _wtol(const wchar_t *);

 wchar_t * __cdecl _i64tow(__int64, wchar_t *, int);
 wchar_t * __cdecl _ui64tow(unsigned __int64, wchar_t *, int);
 __int64   __cdecl _wtoi64(const wchar_t *);
 __int64   __cdecl _wcstoi64(const wchar_t *, wchar_t **, int);
 unsigned __int64  __cdecl _wcstoui64(const wchar_t *, wchar_t **, int);
#line 337 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


#line 340 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"




 char * __cdecl _ecvt(double, int, int *, int *);

 __declspec(noreturn) void   __cdecl _exit(int);


#line 350 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
 char * __cdecl _fcvt(double, int, int *, int *);
 char * __cdecl _fullpath(char *, const char *, size_t);
 char * __cdecl _gcvt(double, int, char *);
        unsigned long __cdecl _lrotl(unsigned long, int);
        unsigned long __cdecl _lrotr(unsigned long, int);
 void   __cdecl _makepath(char *, const char *, const char *, const char *,
        const char *);
        _onexit_t __cdecl _onexit(_onexit_t);
 void   __cdecl perror(const char *);
 int    __cdecl _putenv(const char *);
        unsigned int __cdecl _rotl(unsigned int, int);
        unsigned __int64 __cdecl _rotl64(unsigned __int64, int);
        unsigned int __cdecl _rotr(unsigned int, int);
        unsigned __int64 __cdecl _rotr64(unsigned __int64, int);
 void   __cdecl _searchenv(const char *, const char *, char *);
 void   __cdecl _splitpath(const char *, char *, char *, char *, char *);
 void   __cdecl _swab(char *, char *, int);





 wchar_t * __cdecl _wfullpath(wchar_t *, const wchar_t *, size_t);
 void   __cdecl _wmakepath(wchar_t *, const wchar_t *, const wchar_t *, const wchar_t *,
        const wchar_t *);
 void   __cdecl _wperror(const wchar_t *);
 int    __cdecl _wputenv(const wchar_t *);
 void   __cdecl _wsearchenv(const wchar_t *, const wchar_t *, wchar_t *);
 void   __cdecl _wsplitpath(const wchar_t *, wchar_t *, wchar_t *, wchar_t *, wchar_t *);


#line 382 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"



 void __cdecl _seterrormode(int);
 void __cdecl _beep(unsigned, unsigned);
 void __cdecl _sleep(unsigned long);


#line 391 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"







 int __cdecl tolower(int);
#line 400 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

 int __cdecl toupper(int);
#line 403 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

#line 405 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

















 char * __cdecl ecvt(double, int, int *, int *);
 char * __cdecl fcvt(double, int, int *, int *);
 char * __cdecl gcvt(double, int, char *);
 char * __cdecl itoa(int, char *, int);
 char * __cdecl ltoa(long, char *, int);
        _onexit_t __cdecl onexit(_onexit_t);
 int    __cdecl putenv(const char *);
 void   __cdecl swab(char *, char *, int);
 char * __cdecl ultoa(unsigned long, char *, int);

#line 433 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

#line 435 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


}

#line 440 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"


#pragma pack(pop)
#line 444 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"

#line 446 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdlib.h"
#line 13 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdlib"

namespace std {
using ::size_t; using ::div_t; using ::ldiv_t;

using ::abort; using ::abs; using ::atexit;
using ::atof; using ::atoi; using ::atol;
using ::bsearch; using ::calloc; using ::div;
using ::exit; using ::free; using ::getenv;
using ::labs; using ::ldiv; using ::malloc;
using ::mblen; using ::mbstowcs; using ::mbtowc;
using ::qsort; using ::rand; using ::realloc;
using ::srand; using ::strtod; using ::strtol;
using ::strtoul; using ::system;
using ::wcstombs; using ::wctomb;
}
#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdlib"
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstdlib"





#line 9 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\streambuf"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xiosbase"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"

#pragma once



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstring"

#pragma once









 

namespace std {
using ::size_t; using ::memchr; using ::memcmp;
using ::memcpy; using ::memmove; using ::memset;
using ::strcat; using ::strchr; using ::strcmp;
using ::strcoll; using ::strcpy; using ::strcspn;
using ::strerror; using ::strlen; using ::strncat;
using ::strncmp; using ::strncpy; using ::strpbrk;
using ::strrchr; using ::strspn; using ::strstr;
using ::strtok; using ::strxfrm;
}
#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstring"
#line 26 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstring"





#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"

#pragma once





#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstddef"

#pragma once









 #line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"






#line 25 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"



extern "C" {
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"








#line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"















#line 55 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"
















 extern int * __cdecl _errno(void);



#line 76 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"








typedef __w64 int            intptr_t;
#line 86 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"

#line 88 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"














typedef __w64 int            ptrdiff_t;
#line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"

#line 106 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"























#line 130 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"



 extern unsigned long  __cdecl __threadid(void);

 extern uintptr_t __cdecl __threadhandle(void);
#line 137 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"



}
#line 142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"

#line 144 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stddef.h"
#line 13 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstddef"

namespace std {
using ::ptrdiff_t; using ::size_t;
}
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstddef"
#line 19 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cstddef"





#line 9 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
 
 
 
 
 

 
 

 
 
 
 











#line 40 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"

		
 

 
  
 #line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"

 
  
 #line 51 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"

		
 

 

		




 
 

 

		
enum _Uninitialized
	{	
	_Noinit};

		
 void __cdecl _Nomemory();
}
#pragma warning(pop)
#pragma pack(pop)

#line 79 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstddef"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"

#pragma pack(push,8)
#pragma warning(push,3)

#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"













#pragma once
#line 16 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"






#line 23 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"





#pragma pack(push,8)
#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"















typedef void (__cdecl *terminate_function)();
typedef void (__cdecl *unexpected_function)();
typedef void (__cdecl *terminate_handler)();
typedef void (__cdecl *unexpected_handler)();

struct _EXCEPTION_POINTERS;
typedef void (__cdecl *_se_translator_function)(unsigned int, struct _EXCEPTION_POINTERS*);


 __declspec(noreturn) void __cdecl terminate(void);
 __declspec(noreturn) void __cdecl unexpected(void);



#line 60 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"

 terminate_function __cdecl set_terminate(terminate_function);
 unexpected_function __cdecl set_unexpected(unexpected_function);
 _se_translator_function __cdecl _set_se_translator(_se_translator_function);
 bool __uncaught_exception();


#pragma pack(pop)
#line 69 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"

#line 71 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\eh.h"
#line 11 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"



#line 15 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"









typedef const char *__exString;

class  exception
	{	
public:
	exception();
	exception(const char *const&);
	exception(const exception&);
	exception& operator=(const exception&);
	virtual ~exception();
	virtual const char *what() const;

private:
	const char *_m_what;
	int _m_doFree;
	};

 namespace std {

 

using ::exception;
typedef void (*_Prhand)(const exception&);
extern  _Prhand _Raise_handler;
 bool __cdecl uncaught_exception();

using ::unexpected_handler; using ::set_unexpected; using ::unexpected;
using ::terminate_handler; using ::set_terminate; using ::terminate;

 























































































#line 142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"

		
class bad_exception : public exception
	{	
public:
	bad_exception(const char *_Message = "bad exception")
		throw ()
		: exception(_Message)
		{	
		}

	virtual ~bad_exception() throw ()
		{	
		}

 





#line 164 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"
	};
}
#pragma warning(pop)
#pragma pack(pop)

#line 170 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\exception"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstring"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xmemory"

#pragma once



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

#pragma once




#pragma pack(push,8)
#pragma warning(push,3)


namespace std {
		
class bad_alloc
	: public exception
	{	
public:
	bad_alloc(const char *_Message = "bad allocation") throw ()
		: exception(_Message)
		{	
		}

	virtual ~bad_alloc() throw ()
		{	
		}

 





#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"
	};

		
 
typedef void (__cdecl *new_handler)();	
 #line 39 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

 
struct nothrow_t
	{	
	};

extern const nothrow_t nothrow;	
 #line 47 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

		
 new_handler __cdecl set_new_handler(new_handler)
	throw ();	
}

		
void __cdecl operator delete(void *) throw ();
void *__cdecl operator new(size_t) throw (...);

 
  
inline void *__cdecl operator new(size_t, void *_Where) throw ()
	{	
	return (_Where);
	}

inline void __cdecl operator delete(void *, void *) throw ()
	{	
	}
 #line 68 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

 
  
inline void *__cdecl operator new[](size_t, void *_Where) throw ()
	{	
	return (_Where);
	}

inline void __cdecl operator delete[](void *, void *) throw ()
	{	
	}
 #line 80 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

void __cdecl operator delete[](void *) throw ();	

void *__cdecl operator new[](size_t)
	throw (...);	

 
  
void *__cdecl operator new(size_t, const std::nothrow_t&)
	throw ();	

void *__cdecl operator new[](size_t, const std::nothrow_t&)
	throw ();	

void __cdecl operator delete(void *, const std::nothrow_t&)
	throw ();	

void __cdecl operator delete[](void *, const std::nothrow_t&)
	throw ();	
 #line 100 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

 
using std::new_handler;
 #line 104 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"

#pragma warning(pop)
#pragma pack(pop)

#line 109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\new"





#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xmemory"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

#pragma once



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\utility"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iosfwd"

#pragma once




#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cwchar"

#pragma once









 #line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


















#pragma once
#line 21 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"









#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



#pragma pack(push,8)
#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


extern "C" {
#line 40 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"








#line 49 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"
























#line 74 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"















typedef __w64 long time_t;       
#line 91 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 93 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



typedef __int64 __time64_t;     
#line 98 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 100 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"































































typedef unsigned long _fsize_t; 

#line 166 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



struct _wfinddata_t {
        unsigned attrib;
        time_t   time_create;   
        time_t   time_access;   
        time_t   time_write;
        _fsize_t size;
        wchar_t  name[260];
};



struct _wfinddatai64_t {
        unsigned attrib;
        time_t   time_create;   
        time_t   time_access;   
        time_t   time_write;
        __int64  size;
        wchar_t  name[260];
};

struct __wfinddata64_t {
        unsigned attrib;
        __time64_t  time_create;    
        __time64_t  time_access;    
        __time64_t  time_write;
        __int64     size;
        wchar_t     name[260];
};

#line 199 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#line 202 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"













 extern const unsigned short _ctype[];
 extern const unsigned short _wctype[];
 extern const unsigned short *_pctype;
 extern const wctype_t *_pwctype;
#line 220 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"








                                














































 int __cdecl _wchdir(const wchar_t *);
 wchar_t * __cdecl _wgetcwd(wchar_t *, int);
 wchar_t * __cdecl _wgetdcwd(int, wchar_t *, int);
 int __cdecl _wmkdir(const wchar_t *);
 int __cdecl _wrmdir(const wchar_t *);


#line 283 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"





 int __cdecl _waccess(const wchar_t *, int);
 int __cdecl _wchmod(const wchar_t *, int);
 int __cdecl _wcreat(const wchar_t *, int);
 intptr_t __cdecl _wfindfirst(wchar_t *, struct _wfinddata_t *);
 int __cdecl _wfindnext(intptr_t, struct _wfinddata_t *);
 int __cdecl _wunlink(const wchar_t *);
 int __cdecl _wrename(const wchar_t *, const wchar_t *);
 int __cdecl _wopen(const wchar_t *, int, ...);
 int __cdecl _wsopen(const wchar_t *, int, int, ...);
 wchar_t * __cdecl _wmktemp(wchar_t *);


 intptr_t __cdecl _wfindfirsti64(wchar_t *, struct _wfinddatai64_t *);
 intptr_t __cdecl _wfindfirst64(wchar_t *, struct __wfinddata64_t *);
 int __cdecl _wfindnexti64(intptr_t, struct _wfinddatai64_t *);
 int __cdecl _wfindnext64(intptr_t, struct __wfinddata64_t *);
#line 305 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#line 308 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"





 wchar_t * __cdecl _wsetlocale(int, const wchar_t *);


#line 317 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"





 intptr_t __cdecl _wexecl(const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wexecle(const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wexeclp(const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wexeclpe(const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wexecv(const wchar_t *, const wchar_t * const *);
 intptr_t __cdecl _wexecve(const wchar_t *, const wchar_t * const *, const wchar_t * const *);
 intptr_t __cdecl _wexecvp(const wchar_t *, const wchar_t * const *);
 intptr_t __cdecl _wexecvpe(const wchar_t *, const wchar_t * const *, const wchar_t * const *);
 intptr_t __cdecl _wspawnl(int, const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wspawnle(int, const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wspawnlp(int, const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wspawnlpe(int, const wchar_t *, const wchar_t *, ...);
 intptr_t __cdecl _wspawnv(int, const wchar_t *, const wchar_t * const *);
 intptr_t __cdecl _wspawnve(int, const wchar_t *, const wchar_t * const *,
        const wchar_t * const *);
 intptr_t __cdecl _wspawnvp(int, const wchar_t *, const wchar_t * const *);
 intptr_t __cdecl _wspawnvpe(int, const wchar_t *, const wchar_t * const *,
        const wchar_t * const *);
 int __cdecl _wsystem(const wchar_t *);


#line 344 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


















































typedef unsigned short _ino_t;      


typedef unsigned short ino_t;
#line 399 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 401 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


typedef unsigned int _dev_t;        


typedef unsigned int dev_t;
#line 408 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 410 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


typedef long _off_t;                


typedef long off_t;
#line 417 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 419 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



struct _stat {
        _dev_t st_dev;
        _ino_t st_ino;
        unsigned short st_mode;
        short st_nlink;
        short st_uid;
        short st_gid;
        _dev_t st_rdev;
        _off_t st_size;
        time_t st_atime;
        time_t st_mtime;
        time_t st_ctime;
        };



struct stat {
        _dev_t st_dev;
        _ino_t st_ino;
        unsigned short st_mode;
        short st_nlink;
        short st_uid;
        short st_gid;
        _dev_t st_rdev;
        _off_t st_size;
        time_t st_atime;
        time_t st_mtime;
        time_t st_ctime;
        };
#line 452 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



struct _stati64 {
        _dev_t st_dev;
        _ino_t st_ino;
        unsigned short st_mode;
        short st_nlink;
        short st_uid;
        short st_gid;
        _dev_t st_rdev;
        __int64 st_size;
        time_t st_atime;
        time_t st_mtime;
        time_t st_ctime;
        };

struct __stat64 {
        _dev_t st_dev;
        _ino_t st_ino;
        unsigned short st_mode;
        short st_nlink;
        short st_uid;
        short st_gid;
        _dev_t st_rdev;
        __int64 st_size;
        __time64_t st_atime;
        __time64_t st_mtime;
        __time64_t st_ctime;
        };

#line 484 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#line 487 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"






 int __cdecl _wstat(const wchar_t *, struct _stat *);


 int __cdecl _wstati64(const wchar_t *, struct _stati64 *);
 int __cdecl _wstat64(const wchar_t *, struct __stat64 *);
#line 499 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#line 502 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 504 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"




 wchar_t * __cdecl _cgetws(wchar_t *);
 wint_t __cdecl _getwch(void);
 wint_t __cdecl _getwche(void);
 wint_t __cdecl _putwch(wchar_t);
 wint_t __cdecl _ungetwch(wint_t);
 int __cdecl _cputws(const wchar_t *);
 int __cdecl _cwprintf(const wchar_t *, ...);
 int __cdecl _cwscanf(const wchar_t *, ...);



#line 520 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"














































































































#line 631 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

















































































struct tm {
        int tm_sec;     
        int tm_min;     
        int tm_hour;    
        int tm_mday;    
        int tm_mon;     
        int tm_year;    
        int tm_wday;    
        int tm_yday;    
        int tm_isdst;   
        };

#line 725 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"





 wchar_t * __cdecl _wasctime(const struct tm *);
 wchar_t * __cdecl _wctime(const time_t *);
 size_t __cdecl wcsftime(wchar_t *, size_t, const wchar_t *,
        const struct tm *);
 wchar_t * __cdecl _wstrdate(wchar_t *);
 wchar_t * __cdecl _wstrtime(wchar_t *);


 wchar_t * __cdecl _wctime64(const __time64_t *);
#line 740 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#line 743 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"



typedef int mbstate_t;
typedef wchar_t _Wint_t;

 wint_t __cdecl btowc(int);
 size_t __cdecl mbrlen(const char *, size_t, mbstate_t *);
 size_t __cdecl mbrtowc(wchar_t *, const char *, size_t, mbstate_t *);
 size_t __cdecl mbsrtowcs(wchar_t *, const char **, size_t, mbstate_t *);

 size_t __cdecl wcrtomb(char *, wchar_t, mbstate_t *);
 size_t __cdecl wcsrtombs(char *, const wchar_t **, size_t, mbstate_t *);
 int __cdecl wctob(wint_t);






#line 764 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"
 void *  __cdecl memmove(void *, const void *, size_t);
#line 766 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"
void *  __cdecl memcpy(void *, const void *, size_t);

inline int fwide(FILE *, int _M)
        {return (_M); }
inline int mbsinit(const mbstate_t *_P)
        {return (_P == 0 || *_P == 0); }
inline const wchar_t *wmemchr(const wchar_t *_S, wchar_t _C, size_t _N)
        {for (; 0 < _N; ++_S, --_N)
                if (*_S == _C)
                        return (_S);
        return (0); }
inline int wmemcmp(const wchar_t *_S1, const wchar_t *_S2, size_t _N)
        {for (; 0 < _N; ++_S1, ++_S2, --_N)
                if (*_S1 != *_S2)
                        return (*_S1 < *_S2 ? -1 : +1);
        return (0); }
inline wchar_t *wmemcpy(wchar_t *_S1, const wchar_t *_S2, size_t _N)
        {
            return (wchar_t *)memcpy(_S1, _S2, _N*sizeof(wchar_t));
        }
inline wchar_t *wmemmove(wchar_t *_S1, const wchar_t *_S2, size_t _N)
        {
            return (wchar_t *)memmove(_S1, _S2, _N*sizeof(wchar_t));
        }
inline wchar_t *wmemset(wchar_t *_S, wchar_t _C, size_t _N)
        {wchar_t *_Su = _S;
        for (; 0 < _N; ++_Su, --_N)
                *_Su = _C;
        return (_S); }
}       

extern "C++" {
inline wchar_t *wmemchr(wchar_t *_S, wchar_t _C, size_t _N)
        {return ((wchar_t *)wmemchr((const wchar_t *)_S, _C, _N)); }
}

#line 803 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"


#pragma pack(pop)
#line 807 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"

#line 809 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\wchar.h"
#line 13 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cwchar"

namespace std {
using ::mbstate_t; using ::size_t; using ::tm; using ::wint_t;

using ::btowc; using ::fgetwc; using ::fgetws; using ::fputwc;
using ::fputws; using ::fwide; using ::fwprintf;
using ::fwscanf; using ::getwc; using ::getwchar;
using ::mbrlen; using ::mbrtowc; using ::mbsrtowcs;
using ::mbsinit; using ::putwc; using ::putwchar;
using ::swprintf; using ::swscanf; using ::ungetwc;
using ::vfwprintf; using ::vswprintf; using ::vwprintf;
using ::wcrtomb; using ::wprintf; using ::wscanf;
using ::wcsrtombs; using ::wcstol; using ::wcscat;
using ::wcschr; using ::wcscmp; using ::wcscoll;
using ::wcscpy; using ::wcscspn; using ::wcslen;
using ::wcsncat; using ::wcsncmp; using ::wcsncpy;
using ::wcspbrk; using ::wcsrchr; using ::wcsspn;
using ::wcstod; using ::wcstoul; using ::wcsstr;
using ::wcstok; using ::wcsxfrm; using ::wctob;
using ::wmemchr; using ::wmemcmp; using ::wmemcpy;
using ::wmemmove; using ::wmemset; using ::wcsftime;
}
#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cwchar"
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\cwchar"





#line 8 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iosfwd"


#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
 



typedef long streamoff;
typedef int streamsize;
 #line 22 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iosfwd"

extern  fpos_t _Fpz;
extern  const streamoff _BADOFF;

		
template<class _Statetype>
	class fpos
	{	
	typedef fpos<_Statetype> _Myt;

public:
	fpos(streamoff _Off = 0)
		: _Myoff(_Off), _Fpos(_Fpz), _Mystate(_Stz)
		{	
		}

	fpos(_Statetype _State, fpos_t _Fileposition)
		: _Myoff(0), _Fpos(_Fileposition), _Mystate(_State)
		{	
		}

	_Statetype state() const
		{	
		return (_Mystate);
		}

	void state(_Statetype _State)
		{	
		_Mystate = _State;
		}

	fpos_t seekpos() const
		{	
		return (_Fpos);
		}

	operator streamoff() const
		{	
		return (_Myoff + ((long)(_Fpos)));
		}

	streamoff operator-(const _Myt& _Right) const
		{	
		return ((streamoff)*this - (streamoff)_Right);
		}

	_Myt& operator+=(streamoff _Off)
		{	
		_Myoff += _Off;
		return (*this);
		}

	_Myt& operator-=(streamoff _Off)
		{	
		_Myoff -= _Off;
		return (*this);
		}

	_Myt operator+(streamoff _Off) const
		{	
		_Myt _Tmp = *this;
		return (_Tmp += _Off);
		}

	_Myt operator-(streamoff _Off) const
		{	
		_Myt _Tmp = *this;
		return (_Tmp -= _Off);
		}

	bool operator==(const _Myt& _Right) const
		{	
		return ((streamoff)*this == (streamoff)_Right);
		}

	bool operator!=(const _Myt& _Right) const
		{	
		return (!(*this == _Right));
		}

private:
	static _Statetype _Stz;	
	streamoff _Myoff;	
	fpos_t _Fpos;	
	_Statetype _Mystate;	
	};

	
template<class _Statetype>
	_Statetype fpos<_Statetype>::_Stz;

typedef fpos<mbstate_t> streampos;
typedef streampos wstreampos;

		
template<class _Elem>
	struct char_traits
	{	
	typedef _Elem char_type;
	typedef _Elem int_type;
	typedef streampos pos_type;
	typedef streamoff off_type;
	typedef mbstate_t state_type;

	static void __cdecl assign(_Elem& _Left, const _Elem& _Right)
		{	
		_Left = _Right;
		}

	static bool __cdecl eq(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left == _Right);
		}

	static bool __cdecl lt(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left < _Right);
		}

	static int __cdecl compare(const _Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		for (; 0 < _Count; --_Count, ++_First1, ++_First2)
			if (!eq(*_First1, *_First2))
				return (lt(*_First1, *_First2) ? -1 : +1);
		return (0);
		}

	static size_t __cdecl length(const _Elem *_First)
		{	
		size_t _Count;
		for (_Count = 0; !eq(*_First, _Elem()); ++_First)
			++_Count;
		return (_Count);
		}

	static _Elem *__cdecl copy(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		_Elem *_Next = _First1;
		for (; 0 < _Count; --_Count, ++_Next, ++_First2)
			assign(*_Next, *_First2);
		return (_First1);
		}

	static const _Elem *__cdecl find(const _Elem *_First, size_t _Count,
		const _Elem& _Ch)
		{	
		for (; 0 < _Count; --_Count, ++_First)
			if (eq(*_First, _Ch))
				return (_First);
		return (0);
		}

	static _Elem *__cdecl move(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		_Elem *_Next = _First1;
		if (_First2 < _Next && _Next < _First2 + _Count)
			for (_Next += _Count, _First2 += _Count; 0 < _Count; --_Count)
				assign(*--_Next, *--_First2);
		else
			for (; 0 < _Count; --_Count, ++_Next, ++_First2)
				assign(*_Next, *_First2);
		return (_First1);
		}

	static _Elem *__cdecl assign(_Elem *_First, size_t _Count, _Elem _Ch)
		{	
		_Elem *_Next = _First;
		for (; 0 < _Count; --_Count, ++_Next)
			assign(*_Next, _Ch);
		return (_First);
		}

	static _Elem __cdecl to_char_type(const int_type& _Meta)
		{	
		return (_Meta);
		}

	static int_type __cdecl to_int_type(const _Elem& _Ch)
		{	
		return (_Ch);
		}

	static bool __cdecl eq_int_type(const int_type& _Left,
		const int_type& _Right)
		{	
		return (_Left == _Right);
		}

	static int_type __cdecl eof()
		{	
		return ((int_type)(-1));
		}

	static int_type __cdecl not_eof(const int_type& _Meta)
		{	
		return (_Meta != eof() ? _Meta : !eof());
		}
	};

		
template<> struct  char_traits<wchar_t>
	{	
	typedef wchar_t _Elem;
	typedef _Elem char_type;	
	typedef wint_t int_type;
	typedef streampos pos_type;
	typedef streamoff off_type;
	typedef mbstate_t state_type;

	static void __cdecl assign(_Elem& _Left, const _Elem& _Right)
		{	
		_Left = _Right;
		}

	static bool __cdecl eq(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left == _Right);
		}

	static bool __cdecl lt(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left < _Right);
		}

	static int __cdecl compare(const _Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return (::wmemcmp(_First1, _First2, _Count));
		}

	static size_t __cdecl length(const _Elem *_First)
		{	
		return (::wcslen(_First));
		}

	static _Elem *__cdecl copy(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return (::wmemcpy(_First1, _First2, _Count));
		}

	static const _Elem *__cdecl find(const _Elem *_First, size_t _Count,
		const _Elem& _Ch)
		{	
		return ((const _Elem *)::wmemchr(_First, _Ch, _Count));
		}

	static _Elem *__cdecl move(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return (::wmemmove(_First1, _First2, _Count));
		}

	static _Elem *__cdecl assign(_Elem *_First, size_t _Count, _Elem _Ch)
		{	
		return (::wmemset(_First, _Ch, _Count));
		}

	static _Elem __cdecl to_char_type(const int_type& _Meta)
		{	
		return (_Meta);
		}

	static int_type __cdecl to_int_type(const _Elem& _Ch)
		{	
		return (_Ch);
		}

	static bool __cdecl eq_int_type(const int_type& _Left,
		const int_type& _Right)
		{	
		return (_Left == _Right);
		}

	static int_type __cdecl eof()
		{	
		return ((wint_t)(0xFFFF));
		}

	static int_type __cdecl not_eof(const int_type& _Meta)
		{	
		return (_Meta != eof() ? _Meta : !eof());
		}
	};

		
template<> struct  char_traits<char>
	{	
	typedef char _Elem;
	typedef _Elem char_type;
	typedef int int_type;
	typedef streampos pos_type;
	typedef streamoff off_type;
	typedef mbstate_t state_type;

	static void __cdecl assign(_Elem& _Left, const _Elem& _Right)
		{	
		_Left = _Right;
		}

	static bool __cdecl eq(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left == _Right);
		}

	static bool __cdecl lt(const _Elem& _Left, const _Elem& _Right)
		{	
		return (_Left < _Right);
		}

	static int __cdecl compare(const _Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return (::memcmp(_First1, _First2, _Count));
		}

	static size_t __cdecl length(const _Elem *_First)
		{	
		return (::strlen(_First));
		}

	static _Elem *__cdecl copy(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return ((_Elem *)::memcpy(_First1, _First2, _Count));
		}

	static const _Elem *__cdecl find(const _Elem *_First, size_t _Count,
		const _Elem& _Ch)
		{	
		return ((const _Elem *)::memchr(_First, _Ch, _Count));
		}

	static _Elem *__cdecl move(_Elem *_First1, const _Elem *_First2,
		size_t _Count)
		{	
		return ((_Elem *)::memmove(_First1, _First2, _Count));
		}

	static _Elem *__cdecl assign(_Elem *_First, size_t _Count, _Elem _Ch)
		{	
		return ((_Elem *)::memset(_First, _Ch, _Count));
		}

	static _Elem __cdecl to_char_type(const int_type& _Meta)
		{	
		return ((_Elem)_Meta);
		}

	static int_type __cdecl to_int_type(const _Elem& _Ch)
		{	
		return ((unsigned char)_Ch);
		}

	static bool __cdecl eq_int_type(const int_type& _Left,
		const int_type& _Right)
		{	
		return (_Left == _Right);
		}

	static int_type __cdecl eof()
		{	
		return ((-1));
		}

	static int_type __cdecl not_eof(const int_type& _Meta)
		{	
		return (_Meta != eof() ? _Meta : !eof());
		}
	};

		
template<class _Ty>
	class allocator;
class ios_base;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_ios;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class istreambuf_iterator;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class ostreambuf_iterator;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_streambuf;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_istream;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_ostream;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_iostream;
template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Alloc = allocator<_Elem> >
	class basic_stringbuf;
template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Alloc = allocator<_Elem> >
	class basic_istringstream;
template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Alloc = allocator<_Elem> >
	class basic_ostringstream;
template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Alloc = allocator<_Elem> >
	class basic_stringstream;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_filebuf;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_ifstream;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_ofstream;
template<class _Elem,
	class _Traits = char_traits<_Elem> >
	class basic_fstream;

 










		
typedef basic_ios<char, char_traits<char> > ios;
typedef basic_streambuf<char, char_traits<char> > streambuf;
typedef basic_istream<char, char_traits<char> > istream;
typedef basic_ostream<char, char_traits<char> > ostream;
typedef basic_iostream<char, char_traits<char> > iostream;
typedef basic_stringbuf<char, char_traits<char>,
	allocator<char> > stringbuf;
typedef basic_istringstream<char, char_traits<char>,
	allocator<char> > istringstream;
typedef basic_ostringstream<char, char_traits<char>,
	allocator<char> > ostringstream;
typedef basic_stringstream<char, char_traits<char>,
	allocator<char> > stringstream;
typedef basic_filebuf<char, char_traits<char> > filebuf;
typedef basic_ifstream<char, char_traits<char> > ifstream;
typedef basic_ofstream<char, char_traits<char> > ofstream;
typedef basic_fstream<char, char_traits<char> > fstream;

		
typedef basic_ios<wchar_t, char_traits<wchar_t> > wios;
typedef basic_streambuf<wchar_t, char_traits<wchar_t> >
	wstreambuf;
typedef basic_istream<wchar_t, char_traits<wchar_t> > wistream;
typedef basic_ostream<wchar_t, char_traits<wchar_t> > wostream;
typedef basic_iostream<wchar_t, char_traits<wchar_t> > wiostream;
typedef basic_stringbuf<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wstringbuf;
typedef basic_istringstream<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wistringstream;
typedef basic_ostringstream<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wostringstream;
typedef basic_stringstream<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wstringstream;
typedef basic_filebuf<wchar_t, char_traits<wchar_t> > wfilebuf;
typedef basic_ifstream<wchar_t, char_traits<wchar_t> > wifstream;
typedef basic_ofstream<wchar_t, char_traits<wchar_t> > wofstream;
typedef basic_fstream<wchar_t, char_traits<wchar_t> > wfstream;


 











}
#pragma warning(pop)
#pragma pack(pop)

#line 518 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iosfwd"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\utility"

#pragma pack(push,8)
#pragma warning(push,3)

namespace std {
		
template<class _Ty> inline
	void swap(_Ty& _Left, _Ty& _Right)
	{	
	_Ty _Tmp = _Left;
	_Left = _Right, _Right = _Tmp;
	}

		
template<class _Ty1,
	class _Ty2> struct pair
	{	
	typedef pair<_Ty1, _Ty2> _Myt;
	typedef _Ty1 first_type;
	typedef _Ty2 second_type;

	pair()
		: first(_Ty1()), second(_Ty2())
		{	
		}

	pair(const _Ty1& _Val1, const _Ty2& _Val2)
		: first(_Val1), second(_Val2)
		{	
		}

	template<class _Other1,
		class _Other2>
		pair(const pair<_Other1, _Other2>& _Right)
		: first(_Right.first), second(_Right.second)
		{	
		}

	void swap(_Myt& _Right)
		{	
		std::swap(first, _Right.first);
		std::swap(second, _Right.second);
		}

	friend void swap(_Myt& _Left, _Myt& _Right)
		{	
		_Left.swap(_Right);
		}

	_Ty1 first;	
	_Ty2 second;	
	};

		
template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator==(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (_Left.first == _Right.first && _Left.second == _Right.second);
	}

template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator!=(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (!(_Left == _Right));
	}

template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator<(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (_Left.first < _Right.first ||
		!(_Right.first < _Left.first) && _Left.second < _Right.second);
	}

template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator>(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (_Right < _Left);
	}

template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator<=(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (!(_Right < _Left));
	}

template<class _Ty1,
	class _Ty2> inline
	bool __cdecl operator>=(const pair<_Ty1, _Ty2>& _Left,
		const pair<_Ty1, _Ty2>& _Right)
	{	
	return (!(_Left < _Right));
	}

template<class _Ty1,
	class _Ty2> inline
	pair<_Ty1, _Ty2> __cdecl make_pair(_Ty1 _Val1, _Ty2 _Val2)
	{	
	return (pair<_Ty1, _Ty2>(_Val1, _Val2));
	}

		
	namespace rel_ops
		{	
template<class _Ty> inline
	bool __cdecl operator!=(const _Ty& _Left, const _Ty& _Right)
	{	
	return (!(_Left == _Right));
	}

template<class _Ty> inline
	bool __cdecl operator>(const _Ty& _Left, const _Ty& _Right)
	{	
	return (_Right < _Left);
	}

template<class _Ty> inline
	bool __cdecl operator<=(const _Ty& _Left, const _Ty& _Right)
	{	
	return (!(_Right < _Left));
	}

template<class _Ty> inline
	bool __cdecl operator>=(const _Ty& _Left, const _Ty& _Right)
	{	
	return (!(_Left < _Right));
	}
		}
}
#pragma warning(pop)
#pragma pack(pop)

#line 148 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\utility"






















#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

#pragma pack(push,8)
#pragma warning(push,3)

 #pragma warning(disable:4786)
namespace std {



		
struct input_iterator_tag
	{	
	};

struct output_iterator_tag
	{	
	};

struct forward_iterator_tag
	: public input_iterator_tag
	{	
	};

struct bidirectional_iterator_tag
	: public forward_iterator_tag
	{	
	};

struct random_access_iterator_tag
	: public bidirectional_iterator_tag
	{	
	};

struct _Int_iterator_tag
	{	
	};

		
struct _Nonscalar_ptr_iterator_tag
	{	
	};
struct _Scalar_ptr_iterator_tag
	{	
	};

		
template<class _Category,
	class _Ty,
	class _Diff = ptrdiff_t,
	class _Pointer = _Ty *,
	class _Reference = _Ty&>
		struct iterator
	{	
	typedef _Category iterator_category;
	typedef _Ty value_type;
	typedef _Diff difference_type;
	typedef _Diff distance_type;	
	typedef _Pointer pointer;
	typedef _Reference reference;
	};

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference>
	struct _Bidit
		: public iterator<bidirectional_iterator_tag, _Ty, _Diff,
			_Pointer, _Reference>
	{	
	};

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference>
	struct _Ranit
		: public iterator<random_access_iterator_tag, _Ty, _Diff,
			_Pointer, _Reference>
	{	
	};

struct _Outit
	: public iterator<output_iterator_tag, void, void,
		void, void>
	{	
	};

		
template<class _Iter>
	struct iterator_traits
	{	
	typedef typename _Iter::iterator_category iterator_category;
	typedef typename _Iter::value_type value_type;
	typedef typename _Iter::difference_type difference_type;
	typedef difference_type distance_type;	
	typedef typename _Iter::pointer pointer;
	typedef typename _Iter::reference reference;
	};

		
template<class _Category,
	class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference> inline
		_Category _Iter_cat(const iterator<_Category, _Ty, _Diff,
			_Pointer, _Reference>&)
	{	
	_Category _Cat;
	return (_Cat);
	}

template<class _Ty> inline
	random_access_iterator_tag _Iter_cat(const _Ty *)
	{	
	random_access_iterator_tag _Cat;
	return (_Cat);
	}

		
inline _Int_iterator_tag _Iter_cat(_Bool)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(char)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(signed char)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(unsigned char)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(short)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(unsigned short)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(int)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(unsigned int)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(long)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(unsigned long)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}
 

inline _Int_iterator_tag _Iter_cat(__int64)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}

inline _Int_iterator_tag _Iter_cat(unsigned __int64)
	{	
	_Int_iterator_tag _Cat;
	return (_Cat);
	}
 #line 200 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

		
template<class _T1,
	class _T2> inline
	_Nonscalar_ptr_iterator_tag _Ptr_cat(const _T1&, _T2&)
	{	
	_Nonscalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}


		
inline _Scalar_ptr_iterator_tag _Ptr_cat(const _Bool *, _Bool *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const char *, char *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const signed char *, signed char *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const unsigned char *,
	unsigned char *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const short *, short *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const unsigned short *,
	unsigned short *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const int *, int *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const unsigned int *, unsigned int *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const long *, long *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const unsigned long *,
	unsigned long *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const float *, float *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const double *, double *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const long double *, long double *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}
 

inline _Scalar_ptr_iterator_tag _Ptr_cat(const __int64 *, __int64 *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}

inline _Scalar_ptr_iterator_tag _Ptr_cat(const unsigned __int64 *, unsigned __int64 *)
	{	
	_Scalar_ptr_iterator_tag _Cat;
	return (_Cat);
	}
 #line 306 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

		
template<class _InIt> inline
	ptrdiff_t distance(_InIt _First, _InIt _Last)
	{	
	ptrdiff_t _Off = 0;
	_Distance2(_First, _Last, _Off, _Iter_cat(_First));
	return (_Off);
	}

template<class _InIt,
	class _Diff> inline
		void _Distance(_InIt _First, _InIt _Last, _Diff& _Off)
	{	
	_Distance2(_First, _Last, _Off, _Iter_cat(_First));
	}

template<class _InIt,
	class _Diff> inline
		void _Distance2(_InIt _First, _InIt _Last, _Diff& _Off,
			input_iterator_tag)
	{	
	for (; _First != _Last; ++_First)
		++_Off;
	}

template<class _FwdIt,
	class _Diff> inline
		void _Distance2(_FwdIt _First, _FwdIt _Last, _Diff& _Off,
			forward_iterator_tag)
	{	
	for (; _First != _Last; ++_First)
		++_Off;
	}

template<class _BidIt,
	class _Diff> inline
		void _Distance2(_BidIt _First, _BidIt _Last, _Diff& _Off,
			bidirectional_iterator_tag)
	{	
	for (; _First != _Last; ++_First)
		++_Off;
	}

template<class _RanIt,
	class _Diff> inline
		void _Distance2(_RanIt _First, _RanIt _Last, _Diff& _Off,
			random_access_iterator_tag)
	{	
	_Off += _Last - _First;
	}

		
template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2>
	class _Ptrit
		: public _Ranit<_Ty, _Diff, _Pointer, _Reference>
	{	
public:
	typedef _Ptrit<_Ty, _Diff, _Pointer, _Reference,
		_Pointer2, _Reference2> _Myt;
	_Ptrit()
		{	
		}

	_Ptrit(_Pointer _Ptr)
		: current(_Ptr)
		{	
		}

	_Ptrit(const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
		_Pointer2, _Reference2>& _Iter)
		: current(_Iter.base())
		{	
		}

	_Pointer base() const
		{	
		return (current);
		}

	_Reference operator*() const
		{	
		return (*current);
		}

	_Pointer operator->() const
		{	
		return (&**this);
		}

	_Myt& operator++()
		{	
		++current;
		return (*this);
		}

	_Myt operator++(int)
		{	
		_Myt _Tmp = *this;
		++current;
		return (_Tmp);
		}

	_Myt& operator--()
		{	
		--current;
		return (*this);
		}

	_Myt operator--(int)
		{	
		_Myt _Tmp = *this;
		--current;
		return (_Tmp);
		}

	bool operator==(int _Right) const
		{	
		return (current == (_Pointer)_Right);
		}

	bool operator==(const _Myt& _Right) const
		{	
		return (current == _Right.current);
		}

	bool operator!=(const _Myt& _Right) const
		{	
		return (!(*this == _Right));
		}

	_Myt& operator+=(_Diff _Off)
		{	
		current += _Off;
		return (*this);
		}

	_Myt operator+(_Diff _Off) const
		{	
		return (_Myt(current + _Off));
		}

	_Myt& operator-=(_Diff _Off)
		{	
		current -= _Off;
		return (*this);
		}

	_Myt operator-(_Diff _Off) const
		{	
		return (_Myt(current - _Off));
		}

	_Reference operator[](_Diff _Off) const
		{	
		return (*(*this + _Off));
		}

	bool operator<(const _Myt& _Right) const
		{	
		return (current < _Right.current);
		}

	bool operator>(const _Myt& _Right) const
		{	
		return (_Right < *this);
		}

	bool operator<=(const _Myt& _Right) const
		{	
		return (!(_Right < *this));
		}

	bool operator>=(const _Myt& _Right) const
		{	
		return (!(*this < _Right));
		}

	_Diff operator-(const _Myt& _Right) const
		{	
		return (current - _Right.current);
		}

protected:
	_Pointer current;	
	};

		
template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
		_Ptrit<_Ty, _Diff, _Pointer, _Reference, _Pointer2, _Reference2>
			__cdecl operator+(_Diff _Off,
				const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
					_Pointer2, _Reference2>& _Right)
	{	
	return (_Right + _Off);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator==(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right == _Left);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator!=(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right != _Left);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator<(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right > _Left);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator>(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right < _Left);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator<=(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right >= _Left);
	}

template<class _Ty,
	class _Diff,
	class _Pointer,
	class _Reference,
	class _Pointer2,
	class _Reference2> inline
	bool __cdecl operator>=(
		const _Ptrit<_Ty, _Diff, _Pointer2, _Reference2,
			_Pointer2, _Reference2>& _Left,
		const _Ptrit<_Ty, _Diff, _Pointer, _Reference,
			_Pointer2, _Reference2>& _Right)
	{	
	return (_Right <= _Left);
	}

		
template<class _RanIt>
	class reverse_iterator
		: public iterator<
			typename iterator_traits<_RanIt>::iterator_category,
			typename iterator_traits<_RanIt>::value_type,
			typename iterator_traits<_RanIt>::difference_type,
			typename iterator_traits<_RanIt>::pointer,
			typename iterator_traits<_RanIt>::reference>
	{	
public:
	typedef reverse_iterator<_RanIt> _Myt;
 	typedef typename iterator_traits<_RanIt>::difference_type difference_type;
	typedef typename iterator_traits<_RanIt>::pointer pointer;
	typedef typename iterator_traits<_RanIt>::reference reference;
	typedef _RanIt iterator_type;

	reverse_iterator()
		{	
		}

	explicit reverse_iterator(_RanIt _Right)
		: current(_Right)
		{	
		}

	template<class _Other>
		reverse_iterator(const reverse_iterator<_Other>& _Right)
		: current(_Right.base())
		{	
		}

	_RanIt base() const
		{	
		return (current);
		}

	reference operator*() const
		{	
		_RanIt _Tmp = current;
		return (*--_Tmp);
		}

	pointer operator->() const
		{	
		return (&**this);
		}

	_Myt& operator++()
		{	
		--current;
		return (*this);
		}

	_Myt operator++(int)
		{	
		_Myt _Tmp = *this;
		--current;
		return (_Tmp);
		}

	_Myt& operator--()
		{	
		++current;
		return (*this);
		}

	_Myt operator--(int)
		{	
		_Myt _Tmp = *this;
		++current;
		return (_Tmp);
		}

	bool _Equal(const _Myt& _Right) const
		{	
		return (current == _Right.current);
		}



	_Myt& operator+=(difference_type _Off)
		{	
		current -= _Off;
		return (*this);
		}

	_Myt operator+(difference_type _Off) const
		{	
		return (_Myt(current - _Off));
		}

	_Myt& operator-=(difference_type _Off)
		{	
		current += _Off;
		return (*this);
		}

	_Myt operator-(difference_type _Off) const
		{	
		return (_Myt(current + _Off));
		}

	reference operator[](difference_type _Off) const
		{	
		return (*(*this + _Off));
		}

	bool _Less(const _Myt& _Right) const
		{	
		return (_Right.current < current);
		}

	difference_type _Minus(const _Myt& _Right) const
		{	
		return (_Right.current - current);
		}

protected:
	_RanIt current;	
	};

		
template<class _RanIt,
	class _Diff> inline
	reverse_iterator<_RanIt> __cdecl operator+(_Diff _Off,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (_Right + _Off);
	}

template<class _RanIt> inline
	ptrdiff_t __cdecl operator-(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (_Left._Minus(_Right));
	}

template<class _RanIt> inline
	bool __cdecl operator==(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (_Left._Equal(_Right));
	}

template<class _RanIt> inline
	bool __cdecl operator!=(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (!(_Left == _Right));
	}

template<class _RanIt> inline
	bool __cdecl operator<(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (_Left._Less(_Right));
	}

template<class _RanIt> inline
	bool __cdecl operator>(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (_Right < _Left);
	}

template<class _RanIt> inline
	bool __cdecl operator<=(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (!(_Right < _Left));
	}

template<class _RanIt> inline
	bool __cdecl operator>=(const reverse_iterator<_RanIt>& _Left,
		const reverse_iterator<_RanIt>& _Right)
	{	
	return (!(_Left < _Right));
	}

		
template<class _BidIt,
	class _Ty,
	class _Reference = _Ty&,
	class _Pointer = _Ty *,
	class _Diff = ptrdiff_t>
	class reverse_bidirectional_iterator
		: public _Bidit<_Ty, _Diff, _Pointer, _Reference>
	{	
public:
	typedef reverse_bidirectional_iterator<_BidIt, _Ty, _Reference,
		_Pointer, _Diff> _Myt;
	typedef _BidIt iterator_type;

	reverse_bidirectional_iterator()
		{	
		}

	explicit reverse_bidirectional_iterator(_BidIt _Right)
		: current(_Right)
		{	
		}

	_BidIt base() const
		{	
		return (current);
		}

	_Reference operator*() const
		{	
		_BidIt _Tmp = current;
		return (*--_Tmp);
		}

	_Pointer operator->() const
		{	
		_Reference _Tmp = **this;
		return (&_Tmp);
		}

	_Myt& operator++()
		{	
		--current;
		return (*this);
		}

	_Myt operator++(int)
		{	
		_Myt _Tmp = *this;
		--current;
		return (_Tmp);
		}

	_Myt& operator--()
		{	
		++current;
		return (*this);
		}

	_Myt operator--(int)
		{	
		_Myt _Tmp = *this;
		++current;
		return (_Tmp);
		}

	bool operator==(const _Myt& _Right) const
		{	
		return (current == _Right.current);
		}

	bool operator!=(const _Myt& _Right) const
		{	
		return (!(*this == _Right));
		}

protected:
	_BidIt current;	
	};

		
template<class _BidIt,
	class _BidIt2 = _BidIt>
	class _Revbidit
		: public iterator<
			typename iterator_traits<_BidIt>::iterator_category,
			typename iterator_traits<_BidIt>::value_type,
			typename iterator_traits<_BidIt>::difference_type,
			typename iterator_traits<_BidIt>::pointer,
			typename iterator_traits<_BidIt>::reference>
	{	
public:
	typedef _Revbidit<_BidIt, _BidIt2> _Myt;
	typedef typename iterator_traits<_BidIt>::difference_type _Diff;
	typedef typename iterator_traits<_BidIt>::pointer _Pointer;
	typedef typename iterator_traits<_BidIt>::reference _Reference;
	typedef _BidIt iterator_type;

	_Revbidit()
		{	
		}

	explicit _Revbidit(_BidIt _Right)
		: current(_Right)
		{	
		}

	_Revbidit(const _Revbidit<_BidIt2>& _Other)
		: current (_Other.base())
		{	
		}

	_BidIt base() const
		{	
		return (current);
		}

	_Reference operator*() const
		{	
		_BidIt _Tmp = current;
		return (*--_Tmp);
		}

	_Pointer operator->() const
		{	
		_Reference _Tmp = **this;
		return (&_Tmp);
		}

	_Myt& operator++()
		{	
		--current;
		return (*this);
		}

	_Myt operator++(int)
		{	
		_Myt _Tmp = *this;
		--current;
		return (_Tmp);
		}

	_Myt& operator--()
		{	
		++current;
		return (*this);
		}

	_Myt operator--(int)
		{	
		_Myt _Tmp = *this;
		++current;
		return (_Tmp);
		}

	bool operator==(const _Myt& _Right) const
		{	
		return (current == _Right.current);
		}

	bool operator!=(const _Myt& _Right) const
		{	
		return (!(*this == _Right));
		}

protected:
	_BidIt current;
	};

		
template<class _Elem,
	class _Traits>
	class istreambuf_iterator
		: public iterator<input_iterator_tag,
			_Elem, typename _Traits::off_type, _Elem *, _Elem&>
	{	
public:
	typedef istreambuf_iterator<_Elem, _Traits> _Myt;
	typedef _Elem char_type;
	typedef _Traits traits_type;
	typedef basic_streambuf<_Elem, _Traits> streambuf_type;
	typedef basic_istream<_Elem, _Traits> istream_type;
	typedef typename traits_type::int_type int_type;

	istreambuf_iterator(streambuf_type *_Sb = 0) throw ()
		: _Strbuf(_Sb), _Got(_Sb == 0)
		{	
		}

	istreambuf_iterator(istream_type& _Istr) throw ()
		: _Strbuf(_Istr.rdbuf()), _Got(_Istr.rdbuf() == 0)
		{	
		}

	_Elem operator*() const
		{	
		if (!_Got)
			((_Myt *)this)->_Peek();
		return (_Val);
		}

	_Myt& operator++()
		{	
		_Inc();
		return (*this);
		}

	_Myt operator++(int)
		{	
		if (!_Got)
			_Peek();
		_Myt _Tmp = *this;
		_Inc();
		return (_Tmp);
		}

	bool equal(const _Myt& _Right) const
		{	
		if (!_Got)
			((_Myt *)this)->_Peek();
		if (!_Right._Got)
			((_Myt *)&_Right)->_Peek();
		return (_Strbuf == 0 && _Right._Strbuf == 0
			|| _Strbuf != 0 && _Right._Strbuf != 0);
		}

private:
	void _Inc()
		{	
		if (_Strbuf == 0
			|| traits_type::eq_int_type(traits_type::eof(),
				_Strbuf->sbumpc()))
			_Strbuf = 0, _Got = true;
		else
			_Got = false;
		}

	_Elem _Peek()
		{	
		int_type _Meta;
		if (_Strbuf == 0
			|| traits_type::eq_int_type(traits_type::eof(),
				_Meta = _Strbuf->sgetc()))
			_Strbuf = 0;
		else
			_Val = traits_type::to_char_type(_Meta);
		_Got = true;
		return (_Val);
		}

	streambuf_type *_Strbuf;	
	bool _Got;	
	_Elem _Val;	
	};

		
template<class _Elem,
	class _Traits> inline
	bool __cdecl operator==(
		const istreambuf_iterator<_Elem, _Traits>& _Left,
		const istreambuf_iterator<_Elem, _Traits>& _Right)
	{	
	return (_Left.equal(_Right));
	}

template<class _Elem,
	class _Traits> inline
	bool __cdecl operator!=(
		const istreambuf_iterator<_Elem, _Traits>& _Left,
		const istreambuf_iterator<_Elem, _Traits>& _Right)
	{	
	return (!(_Left == _Right));
	}

		
template<class _Elem,
	class _Traits>
	class ostreambuf_iterator
		: public _Outit
	{	
	typedef ostreambuf_iterator<_Elem, _Traits> _Myt;
public:
	typedef _Elem char_type;
	typedef _Traits traits_type;
	typedef basic_streambuf<_Elem, _Traits> streambuf_type;
	typedef basic_ostream<_Elem, _Traits> ostream_type;

	ostreambuf_iterator(streambuf_type *_Sb) throw ()
		: _Failed(false), _Strbuf(_Sb)
		{	
		}

	ostreambuf_iterator(ostream_type& _Ostr) throw ()
		: _Failed(false), _Strbuf(_Ostr.rdbuf())
		{	
		}

	_Myt& operator=(_Elem _Right)
		{	
		if (_Strbuf == 0
			|| traits_type::eq_int_type(_Traits::eof(),
				_Strbuf->sputc(_Right)))
			_Failed = true;
		return (*this);
		}

	_Myt& operator*()
		{	
		return (*this);
		}

	_Myt& operator++()
		{	
		return (*this);
		}

	_Myt& operator++(int)
		{	
		return (*this);
		}

	bool failed() const throw ()
		{	
		return (_Failed);
		}

private:
	bool _Failed;	
	streambuf_type *_Strbuf;	
	};



		
template<class _InIt,
	class _OutIt> inline
	_OutIt copy(_InIt _First, _InIt _Last, _OutIt _Dest)
	{	
	return (_Copy_opt(_First, _Last, _Dest, _Ptr_cat(_First, _Dest)));
	}

template<class _InIt,
	class _OutIt> inline
	_OutIt _Copy_opt(_InIt _First, _InIt _Last, _OutIt _Dest,
		_Nonscalar_ptr_iterator_tag)
	{	
	for (; _First != _Last; ++_Dest, ++_First)
		*_Dest = *_First;
	return (_Dest);
	}

template<class _InIt,
	class _OutIt> inline
	_OutIt _Copy_opt(_InIt _First, _InIt _Last, _OutIt _Dest,
		_Scalar_ptr_iterator_tag)
	{	
	ptrdiff_t _Off = _Last - _First;	
	return ((_OutIt)::memmove(&*_Dest, &*_First,
		_Off * sizeof (*_First)) + _Off);
	}

		
template<class _BidIt1,
	class _BidIt2> inline
	_BidIt2 copy_backward(_BidIt1 _First, _BidIt1 _Last, _BidIt2 _Dest)
	{	
	return (_Copy_backward_opt(_First, _Last, _Dest,
		_Ptr_cat(_First, _Dest)));
	}

template<class _BidIt1,
	class _BidIt2> inline
	_BidIt2 _Copy_backward_opt(_BidIt1 _First, _BidIt1 _Last, _BidIt2 _Dest,
		_Nonscalar_ptr_iterator_tag)
	{	
	while (_First != _Last)
		*--_Dest = *--_Last;
	return (_Dest);
	}

template<class _InIt,
	class _OutIt> inline
	_OutIt _Copy_backward_opt(_InIt _First, _InIt _Last, _OutIt _Dest,
		_Scalar_ptr_iterator_tag)
	{	
	ptrdiff_t _Off = _Last - _First;	
	return ((_OutIt)memmove(&*_Dest - _Off, &*_First,
		_Off * sizeof (*_First)));
	}

		
template<class _InIt1,
	class _InIt2> inline
	pair<_InIt1, _InIt2>
		mismatch(_InIt1 _First1, _InIt1 _Last1, _InIt2 _First2)
	{	
	for (; _First1 != _Last1 && *_First1 == *_First2; )
		++_First1, ++_First2;
	return (pair<_InIt1, _InIt2>(_First1, _First2));
	}

		
template<class _InIt1,
	class _InIt2,
	class _Pr> inline
	pair<_InIt1, _InIt2>
		mismatch(_InIt1 _First1, _InIt1 _Last1, _InIt2 _First2, _Pr _Pred)
	{	
	for (; _First1 != _Last1 && _Pred(*_First1, *_First2); )
		++_First1, ++_First2;
	return (pair<_InIt1, _InIt2>(_First1, _First2));
	}

		
template<class _InIt1,
	class _InIt2> inline
	bool equal(_InIt1 _First1, _InIt1 _Last1, _InIt2 _First2)
	{	
	return (mismatch(_First1, _Last1, _First2).first == _Last1);
	}

inline bool equal(const char *_First1,
	const char *_Last1, const char *_First2)
	{	
	return (::memcmp(_First1, _First2, _Last1 - _First1) == 0);
	}

inline bool equal(const signed char *_First1,
	const signed char *_Last1, const signed char *_First2)
	{	
	return (::memcmp(_First1, _First2, _Last1 - _First1) == 0);
	}

inline bool equal(const unsigned char *_First1,
	const unsigned char *_Last1, const unsigned char *_First2)
	{	
	return (::memcmp(_First1, _First2, _Last1 - _First1) == 0);
	}

		
template<class _InIt1,
	class _InIt2,
	class _Pr> inline
	bool equal(_InIt1 _First1, _InIt1 _Last1, _InIt2 _First2, _Pr _Pred)
	{	
	return (mismatch(_First1, _Last1, _First2, _Pred).first == _Last1);
	}

		
template<class _FwdIt,
	class _Ty> inline
	void fill(_FwdIt _First, _FwdIt _Last, const _Ty& _Val)
	{	
	for (; _First != _Last; ++_First)
		*_First = _Val;
	}

inline void fill(char *_First, char *_Last, int _Val)
	{	
	::memset(_First, _Val, _Last - _First);
	}

inline void fill(signed char *_First, signed char *_Last, int _Val)
	{	
	::memset(_First, _Val, _Last - _First);
	}

inline void fill(unsigned char *_First, unsigned char *_Last, int _Val)
	{	
	::memset(_First, _Val, _Last - _First);
	}

		
template<class _OutIt,
	class _Diff,
	class _Ty> inline
	void fill_n(_OutIt _First, _Diff _Count, const _Ty& _Val)
	{	
	for (; 0 < _Count; --_Count, ++_First)
		*_First = _Val;
	}

inline void fill_n(char *_First, size_t _Count, int _Val)
	{	
	::memset(_First, _Val, _Count);
	}

inline void fill_n(signed char *_First, size_t _Count, int _Val)
	{	
	::memset(_First, _Val, _Count);
	}

inline void fill_n(unsigned char *_First, size_t _Count, int _Val)
	{	
	::memset(_First, _Val, _Count);
	}

		
template<class _InIt1,
	class _InIt2> inline
	bool lexicographical_compare(_InIt1 _First1, _InIt1 _Last1,
		_InIt2 _First2, _InIt2 _Last2)
	{	
	for (; _First1 != _Last1 && _First2 != _Last2; ++_First1, ++_First2)
		if (*_First1 < *_First2)
			return (true);
		else if (*_First2 < *_First1)
			return (false);
	return (_First1 == _Last1 && _First2 != _Last2);
	}

inline bool lexicographical_compare(
	const unsigned char *_First1, const unsigned char *_Last1,
	const unsigned char *_First2, const unsigned char *_Last2)
	{	
	ptrdiff_t _Num1 = _Last1 - _First1;
	ptrdiff_t _Num2 = _Last2 - _First2;
	int _Ans = ::memcmp(_First1, _First2, _Num1 < _Num2 ? _Num1 : _Num2);
	return (_Ans < 0 || _Ans == 0 && _Num1 < _Num2);
	}

 









#line 1315 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

		
template<class _InIt1,
	class _InIt2,
	class _Pr> inline
	bool lexicographical_compare(_InIt1 _First1, _InIt1 _Last1,
		_InIt2 _First2, _InIt2 _Last2, _Pr _Pred)
	{	
	for (; _First1 != _Last1 && _First2 != _Last2; ++_First1, ++_First2)
		if (_Pred(*_First1, *_First2))
			return (true);
		else if (_Pred(*_First2, *_First1))
			return (false);
	return (_First1 == _Last1 && _First2 != _Last2);
	}

 
  
  
 #line 1335 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

		
template<class _Ty> inline
	const _Ty& (max)(const _Ty& _Left, const _Ty& _Right)
	{	
	return (_Left < _Right ? _Right : _Left);
	}

		
template<class _Ty,
	class _Pr> inline
	const _Ty& (max)(const _Ty& _Left, const _Ty& _Right, _Pr _Pred)
	{	
	return (_Pred(_Left, _Right) ? _Right : _Left);
	}

		
template<class _Ty> inline
	const _Ty& (min)(const _Ty& _Left, const _Ty& _Right)
	{	
	return (_Right < _Left ? _Right : _Left);
	}

		
template<class _Ty,
	class _Pr> inline
	const _Ty& (min)(const _Ty& _Left, const _Ty& _Right, _Pr _Pred)
	{	
	return (_Pred(_Right, _Left) ? _Right : _Left);
	}

 
  
  
 #line 1370 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"

  #pragma warning(default:4786)
}
#pragma warning(pop)
#pragma pack(pop)

#line 1377 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xutility"






















#line 8 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xmemory"

#pragma pack(push,8)
#pragma warning(push,3)

 #pragma warning(disable: 4100)


 
 
 
#line 19 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xmemory"

 

 

 

 


namespace std {
		
template<class _Ty> inline
	_Ty  *_Allocate(size_t _Count, _Ty  *)
	{	
	return ((_Ty  *)operator new(_Count * sizeof (_Ty)));
	}

		
template<class _T1,
	class _T2> inline
	void _Construct(_T1  *_Ptr, const _T2& _Val)
	{	
	new ((void  *)_Ptr) _T1(_Val);
	}

		
template<class _Ty> inline
	void _Destroy(_Ty  *_Ptr)
	{	
	(_Ptr)->~_Ty();
	}

template<> inline
	void _Destroy(char  *)
	{	
	}

template<> inline
	void _Destroy(wchar_t  *)
	{	
	}

		
template<class _Ty>
	class allocator
	{	
public:
	typedef size_t size_type;
	typedef ptrdiff_t difference_type;
	typedef _Ty  *pointer;
	typedef const _Ty  *const_pointer;
	typedef _Ty & reference;
	typedef const _Ty & const_reference;
	typedef _Ty value_type;

	template<class _Other>
		struct rebind
		{	
		typedef allocator<_Other> other;
		};

	pointer address(reference _Val) const
		{	
		return (&_Val);
		}

	const_pointer address(const_reference _Val) const
		{	
		return (&_Val);
		}

	allocator()
		{	
		}

	allocator(const allocator<_Ty>&)
		{	
		}

	template<class _Other>
		allocator(const allocator<_Other>&)
		{	
		}

	template<class _Other>
		allocator<_Ty>& operator=(const allocator<_Other>&)
		{	
		return (*this);
		}

	pointer allocate(size_type _Count, const void *)
		{	
		return (_Allocate(_Count, (pointer)0));
		}

	pointer allocate(size_type _Count)
		{	
		return (_Allocate(_Count, (pointer)0));
		}

	void deallocate(pointer _Ptr, size_type)
		{	
		operator delete(_Ptr);
		}

	void construct(pointer _Ptr, const _Ty& _Val)
		{	
		_Construct(_Ptr, _Val);
		}

	void destroy(pointer _Ptr)
		{	
		_Destroy(_Ptr);
		}

	size_t max_size() const
		{	
		size_t _Count = (size_t)(-1) / sizeof (_Ty);
		return (0 < _Count ? _Count : 1);
		}
	};

		
template<class _Ty,
	class _Other> inline
	bool operator==(const allocator<_Ty>&, const allocator<_Other>&)
	{	
	return (true);
	}

template<class _Ty,
	class _Other> inline
	bool operator!=(const allocator<_Ty>&, const allocator<_Other>&)
	{	
	return (false);
	}

		
template<> class  allocator<void>
	{	
public:
	typedef void _Ty;
	typedef _Ty  *pointer;
	typedef const _Ty  *const_pointer;
	typedef _Ty value_type;

	template<class _Other>
		struct rebind
		{	
		typedef allocator<_Other> other;
		};

	allocator()
		{	
		}

	allocator(const allocator<_Ty>&)
		{	
		}

	template<class _Other>
		allocator(const allocator<_Other>&)
		{	
		}

	template<class _Other>
		allocator<_Ty>& operator=(const allocator<_Other>&)
		{	
		return (*this);
		}
	};

		
template<class _Ty,
	class _Alloc> inline
	void _Destroy_range(_Ty *_First, _Ty *_Last, _Alloc& _Al)
	{	
	_Destroy_range(_First, _Last, _Al, _Ptr_cat(_First, _Last));
	}

template<class _Ty,
	class _Alloc> inline
	void _Destroy_range(_Ty *_First, _Ty *_Last, _Alloc& _Al,
		_Nonscalar_ptr_iterator_tag)
	{	
	for (; _First != _Last; ++_First)
		_Al.destroy(_First);
	}

template<class _Ty,
	class _Alloc> inline
	void _Destroy_range(_Ty *_First, _Ty *_Last, _Alloc& _Al,
		_Scalar_ptr_iterator_tag)
	{	
	}
}

  #pragma warning(default: 4100)
#pragma warning(pop)
#pragma pack(pop)

#line 222 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xmemory"






















#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstring"

#pragma pack(push,8)
#pragma warning(push,3)
 #pragma warning(disable: 4251)
namespace std {

		
class  _String_base
	{	
public:
	void _Xlen() const;	

	void _Xran() const;	
	};

		
template<class _Ty,
	class _Alloc>
	class _String_val
		: public _String_base
	{	
protected:
	typedef typename _Alloc::template
		rebind<_Ty>::other _Alty;

	_String_val(_Alty _Al = _Alty())
		: _Alval(_Al)
		{	
		}

	_Alty _Alval;	
	};

		
template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Ax = allocator<_Elem> >
	class basic_string
		: public _String_val<_Elem, _Ax>
	{	
public:
	typedef basic_string<_Elem, _Traits, _Ax> _Myt;
	typedef _String_val<_Elem, _Ax> _Mybase;
	typedef typename _Mybase::_Alty _Alloc;
	typedef typename _Alloc::size_type size_type;
	typedef typename _Alloc::difference_type difference_type;
	typedef typename _Alloc::pointer _Tptr;
	typedef typename _Alloc::const_pointer _Ctptr;
	typedef _Tptr pointer;
	typedef _Ctptr const_pointer;
	typedef typename _Alloc::reference reference;
	typedef typename _Alloc::const_reference const_reference;
	typedef typename _Alloc::value_type value_type;
	typedef _Ptrit<value_type, difference_type, _Tptr,
		reference, _Tptr, reference> iterator;
	typedef _Ptrit<value_type, difference_type, _Ctptr,
		const_reference, _Tptr, reference> const_iterator;
	typedef std::reverse_iterator<iterator>
		reverse_iterator;
	typedef std::reverse_iterator<const_iterator>
		const_reverse_iterator;

	basic_string()
		: _Mybase()
		{	
		_Tidy();
		}

	explicit basic_string(const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		}

	basic_string(const _Myt& _Right)
		: _Mybase(_Right._Alval)
		{	
		_Tidy();
		assign(_Right, 0, npos);
		}

	basic_string(const _Myt& _Right, size_type _Roff,
		size_type _Count = npos)
		: _Mybase()
		{	
		_Tidy();
		assign(_Right, _Roff, _Count);
		}

	basic_string(const _Myt& _Right, size_type _Roff, size_type _Count,
		const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		assign(_Right, _Roff, _Count);
		}

	basic_string(const _Elem *_Ptr, size_type _Count)
		: _Mybase()
		{	
		_Tidy();
		assign(_Ptr, _Count);
		}

	basic_string(const _Elem *_Ptr, size_type _Count, const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		assign(_Ptr, _Count);
		}

	basic_string(const _Elem *_Ptr)
		: _Mybase()
		{	
		_Tidy();
		assign(_Ptr);
		}

	basic_string(const _Elem *_Ptr, const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		assign(_Ptr);
		}

	basic_string(size_type _Count, _Elem _Ch)
		: _Mybase()
		{	
		_Tidy();
		assign(_Count, _Ch);
		}

	basic_string(size_type _Count, _Elem _Ch, const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		assign(_Count, _Ch);
		}

	template<class _It>
		basic_string(_It _First, _It _Last)
		: _Mybase()
		{	
		_Tidy();
		_Construct(_First, _Last, _Iter_cat(_First));
		}

	template<class _It>
		basic_string(_It _First, _It _Last, const _Alloc& _Al)
		: _Mybase(_Al)
		{	
		_Tidy();
		_Construct(_First, _Last, _Iter_cat(_First));
		}

	template<class _It>
		void _Construct(_It _Count, _It _Ch, _Int_iterator_tag)
		{	
		assign((size_type)_Count, (_Elem)_Ch);
		}

	template<class _It>
		void _Construct(_It _First, _It _Last, input_iterator_tag)
		{	
		try {
		for (; _First != _Last; ++_First)
			append((size_type)1, (_Elem)*_First);
		} catch (...) {
		_Tidy(true);
		throw;
		}
		}

	template<class _It>
		void _Construct(_It _First, _It _Last, forward_iterator_tag)
		{	
		size_type _Count = 0;
		_Distance(_First, _Last, _Count);
		reserve(_Count);

		try {
		for (; _First != _Last; ++_First)
			append((size_type)1, (_Elem)*_First);
		} catch (...) {
		_Tidy(true);
		throw;
		}
		}

	basic_string(const_pointer _First, const_pointer _Last)
		: _Mybase()
		{	
		_Tidy();
		if (_First != _Last)
			assign(&*_First, _Last - _First);
		}

	basic_string(const_iterator _First, const_iterator _Last)
		: _Mybase()
		{	
		_Tidy();
		if (_First != _Last)
			assign(&*_First, _Last - _First);
		}

	~basic_string()
		{	
		_Tidy(true);
		}

	typedef _Traits traits_type;
	typedef _Alloc allocator_type;

	static const size_type npos;	

	_Myt& operator=(const _Myt& _Right)
		{	
		return (assign(_Right));
		}

	_Myt& operator=(const _Elem *_Ptr)
		{	
		return (assign(_Ptr));
		}

	_Myt& operator=(_Elem _Ch)
		{	
		return (assign(1, _Ch));
		}

	_Myt& operator+=(const _Myt& _Right)
		{	
		return (append(_Right));
		}

	_Myt& operator+=(const _Elem *_Ptr)
		{	
		return (append(_Ptr));
		}

	_Myt& operator+=(_Elem _Ch)
		{	
		return (append((size_type)1, _Ch));
		}

	_Myt& append(const _Myt& _Right)
		{	
		return (append(_Right, 0, npos));
		}

	_Myt& append(const _Myt& _Right, size_type _Roff, size_type _Count)
		{	
		if (_Right.size() < _Roff)
			_String_base::_Xran();	
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	

		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::copy(_Myptr() + _Mysize,
				_Right._Myptr() + _Roff, _Count);
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& append(const _Elem *_Ptr, size_type _Count)
		{	
		if (_Inside(_Ptr))
			return (append(*this, _Ptr - _Myptr(), _Count));	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	

		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::copy(_Myptr() + _Mysize, _Ptr, _Count);
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& append(const _Elem *_Ptr)
		{	
		return (append(_Ptr, _Traits::length(_Ptr)));
		}

	_Myt& append(size_type _Count, _Elem _Ch)
		{	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	

		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::assign(_Myptr() + _Mysize, _Count, _Ch);
			_Eos(_Num);
			}
		return (*this);
		}

	template<class _It>
		_Myt& append(_It _First, _It _Last)
		{	
		return (_Append(_First, _Last, _Iter_cat(_First)));
		}

	template<class _It>
		_Myt& _Append(_It _Count, _It _Ch, _Int_iterator_tag)
		{	
		return (append((size_type)_Count, (_Elem)_Ch));
		}

	template<class _It>
		_Myt& _Append(_It _First, _It _Last, input_iterator_tag)
		{	
		return (replace(end(), end(), _First, _Last));
		}

	_Myt& append(const_pointer _First, const_pointer _Last)
		{	
		return (replace(end(), end(), _First, _Last));
		}

	_Myt& append(const_iterator _First, const_iterator _Last)
		{	
		return (replace(end(), end(), _First, _Last));
		}

	_Myt& assign(const _Myt& _Right)
		{	
		return (assign(_Right, 0, npos));
		}

	_Myt& assign(const _Myt& _Right, size_type _Roff, size_type _Count)
		{	
		if (_Right.size() < _Roff)
			_String_base::_Xran();	
		size_type _Num = _Right.size() - _Roff;
		if (_Count < _Num)
			_Num = _Count;	

		if (this == &_Right)
			erase((size_type)(_Roff + _Num)), erase(0, _Roff);	
		else if (_Grow(_Num, true))
			{	
			_Traits::copy(_Myptr(), _Right._Myptr() + _Roff, _Num);
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& assign(const _Elem *_Ptr, size_type _Num)
		{	
		if (_Inside(_Ptr))
			return (assign(*this, _Ptr - _Myptr(), _Num));	

		if (_Grow(_Num, true))
			{	
			_Traits::copy(_Myptr(), _Ptr, _Num);
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& assign(const _Elem *_Ptr)
		{	
		return (assign(_Ptr, _Traits::length(_Ptr)));
		}

	_Myt& assign(size_type _Count, _Elem _Ch)
		{	
		if (_Count == npos)
			_String_base::_Xlen();	

		if (_Grow(_Count, true))
			{	
			_Traits::assign(_Myptr(), _Count, _Ch);
			_Eos(_Count);
			}
		return (*this);
		}

	template<class _It>
		_Myt& assign(_It _First, _It _Last)
		{	
		return (_Assign(_First, _Last, _Iter_cat(_First)));
		}

	template<class _It>
		_Myt& _Assign(_It _Count, _It _Ch, _Int_iterator_tag)
		{	
		return (assign((size_type)_Count, (_Elem)_Ch));
		}

	template<class _It>
		_Myt& _Assign(_It _First, _It _Last, input_iterator_tag)
		{	
		return (replace(begin(), end(), _First, _Last));
		}

	_Myt& assign(const_pointer _First, const_pointer _Last)
		{	
		return (replace(begin(), end(), _First, _Last));
		}

	_Myt& assign(const_iterator _First, const_iterator _Last)
		{	
		return (replace(begin(), end(), _First, _Last));
		}

	_Myt& insert(size_type _Off, const _Myt& _Right)
		{	
		return (insert(_Off, _Right, 0, npos));
		}

	_Myt& insert(size_type _Off, const _Myt& _Right, size_type _Roff,
		size_type _Count)
		{	
		if (_Mysize < _Off || _Right.size() < _Roff)
			_String_base::_Xran();	
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	

		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	
			if (this == &_Right)
				_Traits::move(_Myptr() + _Off,
					_Myptr() + (_Off < _Roff ? _Roff + _Count : _Roff),
						_Count);	
			else
				_Traits::copy(_Myptr() + _Off,
					_Right._Myptr() + _Roff, _Count);	
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& insert(size_type _Off, const _Elem *_Ptr, size_type _Count)
		{	
		if (_Inside(_Ptr))
			return (insert(_Off, *this,
				_Ptr - _Myptr(), _Count));	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	
		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	
			_Traits::copy(_Myptr() + _Off, _Ptr, _Count);	
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& insert(size_type _Off, const _Elem *_Ptr)
		{	
		return (insert(_Off, _Ptr, _Traits::length(_Ptr)));
		}

	_Myt& insert(size_type _Off, size_type _Count, _Elem _Ch)
		{	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	
		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	
			_Traits::assign(_Myptr() + _Off, _Count, _Ch);	
			_Eos(_Num);
			}
		return (*this);
		}

	iterator insert(iterator _Where)
		{	
		return (insert(_Where, _Elem()));
		}

	iterator insert(iterator _Where, _Elem _Ch)
		{	
		size_type _Off = _Pdif(_Where, begin());
		insert(_Off, 1, _Ch);
		return (begin() + _Off);
		}

	void insert(iterator _Where, size_type _Count, _Elem _Ch)
		{	
		size_type _Off = _Pdif(_Where, begin());
		insert(_Off, _Count, _Ch);
		}

	template<class _It>
		void insert(iterator _Where, _It _First, _It _Last)
		{	
		_Insert(_Where, _First, _Last, _Iter_cat(_First));
		}

	template<class _It>
		void _Insert(iterator _Where, _It _Count, _It _Ch,
			_Int_iterator_tag)
		{	
		insert(_Where, (size_type)_Count, (_Elem)_Ch);
		}

	template<class _It>
		void _Insert(iterator _Where, _It _First, _It _Last,
			input_iterator_tag)
		{	
		replace(_Where, _Where, _First, _Last);
		}

	void insert(iterator _Where, const_pointer _First, const_pointer _Last)
		{	
		replace(_Where, _Where, _First, _Last);
		}

	void insert(iterator _Where, const_iterator _First, const_iterator _Last)
		{	
		replace(_Where, _Where, _First, _Last);
		}

	_Myt& erase(size_type _Off = 0, size_type _Count = npos)
		{	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (_Mysize - _Off < _Count)
			_Count = _Mysize - _Off;	
		if (0 < _Count)
			{	
			_Traits::move(_Myptr() + _Off, _Myptr() + _Off + _Count,
				_Mysize - _Off - _Count);
			size_type _Newsize = _Mysize - _Count;
			if (_Grow(_Newsize))
				_Eos(_Newsize);
			}
		return (*this);
		}

	iterator erase(iterator _Where)
		{	
		size_type _Count = _Pdif(_Where, begin());
		erase(_Count, 1);
		return (iterator(_Myptr() + _Count));
		}

	iterator erase(iterator _First, iterator _Last)
		{	
		size_type _Count = _Pdif(_First, begin());
		erase(_Count, _Pdif(_Last, _First));
		return (iterator(_Myptr() + _Count));
		}

	void clear()
		{	
		erase(begin(), end());
		}

	_Myt& replace(size_type _Off, size_type _N0, const _Myt& _Right)
		{	
		return (replace(_Off, _N0, _Right, 0, npos));
		}

	_Myt& replace(size_type _Off, size_type _N0, const _Myt& _Right,
		size_type _Roff, size_type _Count)
		{	
		if (_Mysize < _Off || _Right.size() < _Roff)
			_String_base::_Xran();	
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	

		size_type _Nm = _Mysize - _N0 - _Off;	
		size_type _Newsize = _Mysize + _Count - _N0;
		if (_Mysize < _Newsize)
			_Grow(_Newsize);

		if (this != &_Right)
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
			_Traits::copy(_Myptr() + _Off,
				_Right._Myptr() + _Roff, _Count);	
			}
		else if (_Count <= _N0)
			{	
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _Count);	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
			}
		else if (_Roff <= _Off)
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _Count);	
			}
		else if (_Off + _N0 <= _Roff)
			{	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
			_Traits::move(_Myptr() + _Off,
				_Myptr() + (_Roff + _Count - _N0), _Count);	
			}
		else
			{	
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _N0);	
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
			_Traits::move(_Myptr() + _Off + _N0, _Myptr() + _Roff + _Count,
				_Count - _N0);	
			}

		if (_Mysize < _Newsize || _Grow(_Newsize))
			_Eos(_Newsize);	
		return (*this);
		}

	_Myt& replace(size_type _Off, size_type _N0, const _Elem *_Ptr,
		size_type _Count)
		{	
		if (_Inside(_Ptr))
			return (replace(_Off, _N0, *this,
				_Ptr - _Myptr(), _Count));	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	
		size_type _Nm = _Mysize - _N0 - _Off;

		if (_Count < _N0)
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
		size_type _Num;
		if ((0 < _Count || 0 < _N0) && _Grow(_Num = _Mysize + _Count - _N0))
			{	
			if (_N0 < _Count)
				_Traits::move(_Myptr() + _Off + _Count,
					_Myptr() + _Off + _N0, _Nm);	
			_Traits::copy(_Myptr() + _Off, _Ptr, _Count);	
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& replace(size_type _Off, size_type _N0, const _Elem *_Ptr)
		{	
		return (replace(_Off, _N0, _Ptr, _Traits::length(_Ptr)));
		}

	_Myt& replace(size_type _Off, size_type _N0,
		size_type _Count, _Elem _Ch)
		{	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	
		size_type _Nm = _Mysize - _N0 - _Off;

		if (_Count < _N0)
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	
		size_type _Num;
		if ((0 < _Count || 0 < _N0) && _Grow(_Num = _Mysize + _Count - _N0))
			{	
			if (_N0 < _Count)
				_Traits::move(_Myptr() + _Off + _Count,
					_Myptr() + _Off + _N0, _Nm);	
			_Traits::assign(_Myptr() + _Off, _Count, _Ch);	
			_Eos(_Num);
			}
		return (*this);
		}

	_Myt& replace(iterator _First, iterator _Last, const _Myt& _Right)
		{	
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Right));
		}

	_Myt& replace(iterator _First, iterator _Last, const _Elem *_Ptr,
		size_type _Count)
		{	
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Ptr, _Count));
		}

	_Myt& replace(iterator _First, iterator _Last, const _Elem *_Ptr)
		{	
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Ptr));
		}

	_Myt& replace(iterator _First, iterator _Last,
		size_type _Count, _Elem _Ch)
		{	
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Count, _Ch));
		}

	template<class _It>
		_Myt& replace(iterator _First, iterator _Last,
			_It _First2, _It _Last2)
		{	
		return (_Replace(_First, _Last,
			_First2, _Last2, _Iter_cat(_First2)));
		}

	template<class _It>
		_Myt& _Replace(iterator _First, iterator _Last,
			_It _Count, _It _Ch, _Int_iterator_tag)
		{	
		return (replace(_First, _Last, (size_type)_Count, (_Elem)_Ch));
		}

	template<class _It>
		_Myt& _Replace(iterator _First, iterator _Last,
			_It _First2, _It _Last2, input_iterator_tag)
		{	
		_Myt _Right(_First2, _Last2);
		replace(_First, _Last, _Right);
		return (*this);
		}

	_Myt& replace(iterator _First, iterator _Last,
		const_pointer _First2, const_pointer _Last2)
		{	
		if (_First2 == _Last2)
			erase(_Pdif(_First, begin()), _Pdif(_Last, _First));
		else
			replace(_Pdif(_First, begin()), _Pdif(_Last, _First),
				&*_First2, _Last2 - _First2);
		return (*this);
		}

	_Myt& replace(iterator _First, iterator _Last,
		const_iterator _First2, const_iterator _Last2)
		{	
		if (_First2 == _Last2)
			erase(_Pdif(_First, begin()), _Pdif(_Last, _First));
		else
			replace(_Pdif(_First, begin()), _Pdif(_Last, _First),
				&*_First2, _Last2 - _First2);
		return (*this);
		}

	iterator begin()
		{	
		return (iterator(_Myptr()));
		}

	const_iterator begin() const
		{	
		return (const_iterator(_Myptr()));
		}

	iterator end()
		{	
		return (iterator(_Myptr() + _Mysize));
		}

	const_iterator end() const
		{	
		return (const_iterator(_Myptr() + _Mysize));
		}

	reverse_iterator rbegin()
		{	
		return (reverse_iterator(end()));
		}

	const_reverse_iterator rbegin() const
		{	
		return (const_reverse_iterator(end()));
		}

	reverse_iterator rend()
		{	
		return (reverse_iterator(begin()));
		}

	const_reverse_iterator rend() const
		{	
		return (const_reverse_iterator(begin()));
		}

	reference at(size_type _Off)
		{	
		if (_Mysize <= _Off)
			_String_base::_Xran();	
		return (_Myptr()[_Off]);
		}

	const_reference at(size_type _Off) const
		{	
		if (_Mysize <= _Off)
			_String_base::_Xran();	
		return (_Myptr()[_Off]);
		}

	reference operator[](size_type _Off)
		{	
		return (_Myptr()[_Off]);
		}

	const_reference operator[](size_type _Off) const
		{	
		return (_Myptr()[_Off]);
		}

	void push_back(_Elem _Ch)
		{	
		insert(end(), _Ch);
		}

	const _Elem *c_str() const
		{	
		return (_Myptr());
		}

	const _Elem *data() const
		{	
		return (c_str());
		}

	size_type length() const
		{	
		return (_Mysize);
		}

	size_type size() const
		{	
		return (_Mysize);
		}

	size_type max_size() const
		{	
		size_type _Num = _Mybase::_Alval.max_size();
		return (_Num <= 1 ? 1 : _Num - 1);
		}

	void resize(size_type _Newsize)
		{	
		resize(_Newsize, _Elem());
		}

	void resize(size_type _Newsize, _Elem _Ch)
		{	
		if (_Newsize <= _Mysize)
			erase(_Newsize);
		else
			append(_Newsize - _Mysize, _Ch);
		}

	size_type capacity() const
		{	
		return (_Myres);
		}

	void reserve(size_type _Newcap = 0)
		{	
		if (_Myres < _Newcap)
			_Grow(_Newcap);
		}

	bool empty() const
		{	
		return (_Mysize == 0);
		}

	size_type copy(_Elem *_Ptr, size_type _Count, size_type _Off = 0) const
		{	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (_Mysize - _Off < _Count)
			_Count = _Mysize - _Off;
		_Traits::copy(_Ptr, _Myptr() + _Off, _Count);
		return (_Count);
		}

	void swap(_Myt& _Right)
		{	
		if (_Mybase::_Alval == _Right._Alval)
			{	
			_Bxty _Tbx = _Bx;
			_Bx = _Right._Bx, _Right._Bx = _Tbx;

			size_type _Tlen = _Mysize;
			_Mysize = _Right._Mysize, _Right._Mysize = _Tlen;

			size_type _Tres = _Myres;
			_Myres = _Right._Myres, _Right._Myres = _Tres;
			}
		else
			{	
			_Myt _Tmp = *this; *this = _Right, _Right = _Tmp;
			}
		}

	friend void swap(_Myt& _Left, _Myt& _Right)
		{	
		_Left.swap(_Right);
		}

	size_type find(const _Myt& _Right, size_type _Off = 0) const
		{	
		return (find(_Right._Myptr(), _Off, _Right.size()));
		}

	size_type find(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (_Count == 0 && _Off <= _Mysize)
			return (_Off);	

		size_type _Nm;
		if (_Off < _Mysize && _Count <= (_Nm = _Mysize - _Off))
			{	
			const _Elem *_Uptr, *_Vptr;
			for (_Nm -= _Count - 1, _Vptr = _Myptr() + _Off;
				(_Uptr = _Traits::find(_Vptr, _Nm, *_Ptr)) != 0;
				_Nm -= _Uptr - _Vptr + 1, _Vptr = _Uptr + 1)
				if (_Traits::compare(_Uptr, _Ptr, _Count) == 0)
					return (_Uptr - _Myptr());	
			}

		return (npos);	
		}

	size_type find(const _Elem *_Ptr, size_type _Off = 0) const
		{	
		return (find(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type find(_Elem _Ch, size_type _Off = 0) const
		{	
		return (find((const _Elem *)&_Ch, _Off, 1));
		}

	size_type rfind(const _Myt& _Right, size_type _Off = npos) const
		{	
		return (rfind(_Right._Myptr(), _Off, _Right.size()));
		}

	size_type rfind(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (_Count == 0)
			return (_Off < _Mysize ? _Off : _Mysize);	
		if (_Count <= _Mysize)
			{	
			const _Elem *_Uptr = _Myptr() +
				(_Off < _Mysize - _Count ? _Off : _Mysize - _Count);
			for (; ; --_Uptr)
				if (_Traits::eq(*_Uptr, *_Ptr)
					&& _Traits::compare(_Uptr, _Ptr, _Count) == 0)
					return (_Uptr - _Myptr());	
				else if (_Uptr == _Myptr())
					break;	
			}

		return (npos);	
		}

	size_type rfind(const _Elem *_Ptr, size_type _Off = npos) const
		{	
		return (rfind(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type rfind(_Elem _Ch, size_type _Off = npos) const
		{	
		return (rfind((const _Elem *)&_Ch, _Off, 1));
		}

	size_type find_first_of(const _Myt& _Right,
		size_type _Off = 0) const
		{	
		return (find_first_of(_Right._Myptr(), _Off, _Right.size()));
		}

	size_type find_first_of(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (0 < _Count && _Off < _Mysize)
			{	
			const _Elem *const _Vptr = _Myptr() + _Mysize;
			for (const _Elem *_Uptr = _Myptr() + _Off; _Uptr < _Vptr; ++_Uptr)
				if (_Traits::find(_Ptr, _Count, *_Uptr) != 0)
					return (_Uptr - _Myptr());	
			}

		return (npos);	
		}

	size_type find_first_of(const _Elem *_Ptr, size_type _Off = 0) const
		{	
		return (find_first_of(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type find_first_of(_Elem _Ch, size_type _Off = 0) const
		{	
		return (find((const _Elem *)&_Ch, _Off, 1));
		}

	size_type find_last_of(const _Myt& _Right,
		size_type _Off = npos) const
		{	
		return (find_last_of(_Right._Myptr(), _Off, _Right.size()));
		}

	size_type find_last_of(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (0 < _Count && 0 < _Mysize)
			for (const _Elem *_Uptr = _Myptr()
				+ (_Off < _Mysize ? _Off : _Mysize - 1); ; --_Uptr)
				if (_Traits::find(_Ptr, _Count, *_Uptr) != 0)
					return (_Uptr - _Myptr());	
				else if (_Uptr == _Myptr())
					break;	

		return (npos);	
		}

	size_type find_last_of(const _Elem *_Ptr,
		size_type _Off = npos) const
		{	
		return (find_last_of(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type find_last_of(_Elem _Ch, size_type _Off = npos) const
		{	
		return (rfind((const _Elem *)&_Ch, _Off, 1));
		}

	size_type find_first_not_of(const _Myt& _Right,
		size_type _Off = 0) const
		{	
		return (find_first_not_of(_Right._Myptr(), _Off,
			_Right.size()));
		}

	size_type find_first_not_of(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (_Off < _Mysize)
			{	
			const _Elem *const _Vptr = _Myptr() + _Mysize;
			for (const _Elem *_Uptr = _Myptr() + _Off; _Uptr < _Vptr; ++_Uptr)
				if (_Traits::find(_Ptr, _Count, *_Uptr) == 0)
					return (_Uptr - _Myptr());
			}
		return (npos);
		}

	size_type find_first_not_of(const _Elem *_Ptr,
		size_type _Off = 0) const
		{	
		return (find_first_not_of(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type find_first_not_of(_Elem _Ch, size_type _Off = 0) const
		{	
		return (find_first_not_of((const _Elem *)&_Ch, _Off, 1));
		}

	size_type find_last_not_of(const _Myt& _Right,
		size_type _Off = npos) const
		{	
		return (find_last_not_of(_Right._Myptr(), _Off, _Right.size()));
		}

	size_type find_last_not_of(const _Elem *_Ptr, size_type _Off,
		size_type _Count) const
		{	
		if (0 < _Mysize)
			for (const _Elem *_Uptr = _Myptr()
				+ (_Off < _Mysize ? _Off : _Mysize - 1); ; --_Uptr)
				if (_Traits::find(_Ptr, _Count, *_Uptr) == 0)
					return (_Uptr - _Myptr());
				else if (_Uptr == _Myptr())
					break;
		return (npos);
		}

	size_type find_last_not_of(const _Elem *_Ptr,
		size_type _Off = npos) const
		{	
		return (find_last_not_of(_Ptr, _Off, _Traits::length(_Ptr)));
		}

	size_type find_last_not_of(_Elem _Ch, size_type _Off = npos) const
		{	
		return (find_last_not_of((const _Elem *)&_Ch, _Off, 1));
		}

	_Myt substr(size_type _Off = 0, size_type _Count = npos) const
		{	
		return (_Myt(*this, _Off, _Count));
		}

	int compare(const _Myt& _Right) const
		{	
		return (compare(0, _Mysize, _Right._Myptr(), _Right.size()));
		}

	int compare(size_type _Off, size_type _N0,
		const _Myt& _Right) const
		{	
		return (compare(_Off, _N0, _Right, 0, npos));
		}

	int compare(size_type _Off, size_type _N0, const _Myt& _Right,
		size_type _Roff, size_type _Count) const
		{	
		if (_Right.size() < _Roff)
			_String_base::_Xran();	
		if (_Right._Mysize - _Roff < _Count)
			_Count = _Right._Mysize - _Roff;	
		return (compare(_Off, _N0, _Right._Myptr() + _Roff, _Count));
		}

	int compare(const _Elem *_Ptr) const
		{	
		return (compare(0, _Mysize, _Ptr, _Traits::length(_Ptr)));
		}

	int compare(size_type _Off, size_type _N0, const _Elem *_Ptr) const
		{	
		return (compare(_Off, _N0, _Ptr, _Traits::length(_Ptr)));
		}

	int compare(size_type _Off, size_type _N0, const _Elem *_Ptr,
		size_type _Count) const
		{	
		if (_Mysize < _Off)
			_String_base::_Xran();	
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	

		size_type _Ans = _N0 == 0 ? 0
			: _Traits::compare(_Myptr() + _Off, _Ptr,
				_N0 < _Count ? _N0 : _Count);
		return (_Ans != 0 ? (int)_Ans : _N0 < _Count ? -1
			: _N0 == _Count ? 0 : +1);
		}

	allocator_type get_allocator() const
		{	
		return (_Mybase::_Alval);
		}

	enum
		{	
		_BUF_SIZE = 16 / sizeof (_Elem) < 1 ? 1
			: 16 / sizeof(_Elem)};
private:
	enum
		{	
		_ALLOC_MASK = sizeof (_Elem) <= 1 ? 15
			: sizeof (_Elem) <= 2 ? 7
			: sizeof (_Elem) <= 4 ? 3
			: sizeof (_Elem) <= 8 ? 1 : 0};

	void _Copy(size_type _Newsize, size_type _Oldlen)
		{	
		size_type _Newres = _Newsize | _ALLOC_MASK;
		if (max_size() < _Newres)
			_Newres = _Newsize;	
		_Elem *_Ptr;

		try {
			_Ptr = _Mybase::_Alval.allocate(_Newres + 1, (void *)0);
		} catch (...) {
			_Newres = _Newsize;	
			try {
				_Ptr = _Mybase::_Alval.allocate(_Newres + 1, (void *)0);
			} catch (...) {
			_Tidy(true);	
			throw;
			}
		}

		if (0 < _Oldlen)
			_Traits::copy(_Ptr, _Myptr(), _Oldlen);	
		_Tidy(true);
		_Bx._Ptr = _Ptr;
		_Myres = _Newres;
		_Eos(_Oldlen);
		}

	void _Eos(size_type _Newsize)
		{	
		_Traits::assign(_Myptr()[_Mysize = _Newsize], _Elem());
		}

	bool _Grow(size_type _Newsize, bool _Trim = false)
		{	
		if (max_size() < _Newsize)
			_String_base::_Xlen();	
		if (_Myres < _Newsize)
			_Copy(_Newsize, _Trim ? 0 : _Mysize);	
		else if (_Trim && _Newsize < _BUF_SIZE)
			_Tidy(true);	
		else if (_Newsize == 0)
			_Eos(0);	
		return (0 < _Newsize);	
		}

	bool _Inside(const _Elem *_Ptr)
		{	
		return (_Myptr() <= _Ptr && _Ptr < _Myptr() + _Mysize);
		}

	static size_type __cdecl _Pdif(const_iterator _P2,
		const_iterator _P1)
		{	
		return (_P2.base() == 0 ? 0 : _P2 - _P1);
		}

	_Elem *_Myptr()
		{	
		return (_BUF_SIZE <= _Myres ? _Bx._Ptr : _Bx._Buf);
		}

	const _Elem *_Myptr() const
		{	
		return (_BUF_SIZE <= _Myres ? _Bx._Ptr : _Bx._Buf);
		}

	void _Tidy(bool _Built = false)
		{	
		if (!_Built)
			;
		else if (_BUF_SIZE <= _Myres)
			_Mybase::_Alval.deallocate(_Myptr(), _Myres + 1);
		_Myres = _BUF_SIZE - 1;
		_Eos(0);
		}

	union _Bxty
		{	
		_Elem _Buf[_BUF_SIZE];
		_Elem *_Ptr;
		} _Bx;

	size_type _Mysize;	
	size_type _Myres;	
	};

		
template<class _Elem,
	class _Traits,
	class _Alloc>
	const  basic_string<_Elem, _Traits, _Alloc>::size_type
		basic_string<_Elem, _Traits, _Alloc>::npos =
			(basic_string<_Elem, _Traits, _Alloc>::size_type)(-1);

typedef basic_string<char, char_traits<char>, allocator<char> >
	string;
typedef basic_string<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wstring;

 





}
 #pragma warning(default: 4251)
#pragma warning(pop)
#pragma pack(pop)

#line 1305 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xstring"





#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
class logic_error
	: public exception
	{	
public:
	explicit logic_error(const string& _Message)
		: _Str(_Message)
		{	
		}

	virtual ~logic_error()
		{	
		}

	virtual const char *what() const throw ()
		{	
		return (_Str.c_str());
		}

 





#line 38 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"

private:
	string _Str;	
	};

		
class domain_error
	: public logic_error
	{	
public:
	explicit domain_error(const string& _Message)
		: logic_error(_Message)
		{	
		}

	virtual ~domain_error()
		{	
		}

 





#line 64 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class invalid_argument
	: public logic_error
	{	
public:
	explicit invalid_argument(const string& _Message)
		: logic_error(_Message)
		{	
		}

	virtual ~invalid_argument()
		{	
		}

 





#line 87 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class length_error
	: public logic_error
	{	
public:
	explicit length_error(const string& _Message)
		: logic_error(_Message)
		{	
		}

	virtual ~length_error()
		{	
		}

 





#line 110 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class out_of_range
	: public logic_error
	{	
public:
	explicit out_of_range(const string& _Message)
		: logic_error(_Message)
		{	
		}

	virtual ~out_of_range()
		{	
		}

 





#line 133 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class runtime_error
	: public exception
	{	
public:
	explicit runtime_error(const string& _Message)
		: _Str(_Message)
		{	
		}

	virtual ~runtime_error()
		{	
		}

	virtual const char *what() const throw ()
		{	
		return (_Str.c_str());
		}

 





#line 161 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
private:
	string _Str;	
	};

		
class overflow_error
	: public runtime_error
	{	
public:
	explicit overflow_error(const string& _Message)
		: runtime_error(_Message)
		{	
		}

	virtual ~overflow_error()
		{	
		}

 





#line 186 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class underflow_error
	: public runtime_error
	{	
public:
	explicit underflow_error(const string& _Message)
		: runtime_error(_Message)
		{	
		}

	virtual ~underflow_error()
		{	
		}

 





#line 209 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};

		
class range_error
	: public runtime_error
	{	
public:
	explicit range_error(const string& _Message)
		: runtime_error(_Message)
		{	
		}

	virtual ~range_error()
		{	
		}

 





#line 232 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"
	};
}
#pragma warning(pop)
#pragma pack(pop)

#line 238 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcept"





#line 8 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"















#pragma once
#line 18 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"





 



 

#line 30 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"

 #line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo.h"














#pragma once
#line 17 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo.h"










#line 28 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo.h"












class type_info {
public:
     virtual ~type_info();
     int operator==(const type_info& rhs) const;
     int operator!=(const type_info& rhs) const;
     int before(const type_info& rhs) const;
     const char* name() const;
     const char* raw_name() const;
private:
    void *_m_data;
    char _m_d_name[1];
    type_info(const type_info& rhs);
    type_info& operator=(const type_info& rhs);
};



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcpt.h"














#pragma once
#line 17 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcpt.h"






#line 24 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcpt.h"






#line 31 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcpt.h"
#line 32 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\stdexcpt.h"
#line 58 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo.h"

class  bad_cast : public exception {
public:
    bad_cast(const char * _Message = "bad cast");
    bad_cast(const bad_cast &);
    virtual ~bad_cast();
};

class  bad_typeid : public exception {
public:
    bad_typeid(const char * _Message = "bad typeid");
    bad_typeid(const bad_typeid &);
    virtual ~bad_typeid();
};

class  __non_rtti_object : public bad_typeid {
public:
    __non_rtti_object(const char * _Message);
    __non_rtti_object(const __non_rtti_object &);
    virtual ~__non_rtti_object();
};









#line 89 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo.h"
#line 32 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"

 namespace std {
 
using ::type_info;
using ::bad_cast;
using ::bad_typeid;
using ::__non_rtti_object;
 



















































#line 92 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"

 }

#line 96 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\typeinfo"







#line 9 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo"

#pragma once


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo.h"

#pragma once



#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"














#pragma once
#line 17 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"






#line 24 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"







#pragma pack(push,8)
#line 33 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"


extern "C" {
#line 37 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"


















#line 56 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"































struct lconv {
        char *decimal_point;
        char *thousands_sep;
        char *grouping;
        char *int_curr_symbol;
        char *currency_symbol;
        char *mon_decimal_point;
        char *mon_thousands_sep;
        char *mon_grouping;
        char *positive_sign;
        char *negative_sign;
        char int_frac_digits;
        char frac_digits;
        char p_cs_precedes;
        char p_sep_by_space;
        char n_cs_precedes;
        char n_sep_by_space;
        char p_sign_posn;
        char n_sign_posn;
        };

#line 109 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"












 char * __cdecl setlocale(int, const char *);
 struct lconv * __cdecl localeconv(void);











}
#line 136 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"


#pragma pack(pop)
#line 140 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"

#line 142 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\locale.h"
#line 7 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo.h"





		











		



















typedef struct _Collvec
	{	
	unsigned long _Hand;	
	unsigned int _Page;		
	} _Collvec;

typedef struct _Ctypevec
	{	
	unsigned long _Hand;	
	unsigned int _Page;		
	const short *_Table;
	int _Delfl;
	} _Ctypevec;

typedef struct _Cvtvec
	{	
	unsigned long _Hand;	
	unsigned int _Page;		
	} _Cvtvec;

		
extern "C" {
 _Collvec __cdecl _Getcoll();
 _Ctypevec __cdecl _Getctype();
 _Cvtvec __cdecl _Getcvt();

 int __cdecl _Getdateorder();
 char *__cdecl _Getdays();
 char *__cdecl _Getmonths();
 void *__cdecl _Gettnames();

 int __cdecl _Mbrtowc(wchar_t *, const char *, size_t,
	mbstate_t *, const _Cvtvec *);
 float __cdecl _Stof(const char *, char **, long);
 double __cdecl _Stod(const char *, char **, long);
 long double __cdecl _Stold(const char *, char **, long);
 int __cdecl _Strcoll(const char *, const char *,
	const char *, const char *, const _Collvec *);
 size_t __cdecl _Strftime(char *, size_t, const char *,
	const struct tm *, void *);
 size_t __cdecl _Strxfrm(char *, char *,
	const char *, const char *, const _Collvec *);
 int __cdecl _Tolower(int, const _Ctypevec *);
 int __cdecl _Toupper(int, const _Ctypevec *);
 int __cdecl _Wcrtomb(char *, wchar_t, mbstate_t *,
	const _Cvtvec *);
 int __cdecl _Wcscoll(const wchar_t *, const wchar_t *,
	const wchar_t *, const wchar_t *, const _Collvec *);
 size_t __cdecl _Wcsxfrm(wchar_t *, wchar_t *,
	const wchar_t *, const wchar_t *, const _Collvec *);

 short __cdecl _Getwctype(wchar_t, const _Ctypevec *);
 const wchar_t * __cdecl _Getwctypes(const wchar_t *, const wchar_t *,
	short*, const _Ctypevec*);
 wchar_t __cdecl _Towlower(wchar_t, const _Ctypevec *);
 wchar_t __cdecl _Towupper(wchar_t, const _Ctypevec *);
}
#line 102 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo.h"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo"



#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
class  _Timevec
	{	
public:
	_Timevec(void *_Ptr = 0)
		: _Timeptr(_Ptr)
		{	
		}

	_Timevec(const _Timevec& _Right)
		{	
		*this = _Right;
		}

	~_Timevec()
		{	
		free(_Timeptr);
		}

	_Timevec& operator=(const _Timevec& _Right)
		{	
		_Timeptr = _Right._Timeptr;
		((_Timevec *)&_Right)->_Timeptr = 0;
		return (*this);
		}

	void *_Getptr() const
		{	
		return (_Timeptr);
		}

private:
	void *_Timeptr;	
	};

		
class  _Locinfo
	{	
public:
	typedef ::_Collvec _Collvec;
	typedef ::_Ctypevec _Ctypevec;
	typedef ::_Cvtvec _Cvtvec;
	typedef std::_Timevec _Timevec;

	_Locinfo(const char * = "C");	

	_Locinfo(int, const char *);	

	~_Locinfo();	

	_Locinfo& _Addcats(int, const char *);	

	string _Getname() const
		{	
		return (_Newlocname);
		}

	_Collvec _Getcoll() const
		{	
		return (::_Getcoll());
		}

	_Ctypevec _Getctype() const
		{	
		return (::_Getctype());
		}

	_Cvtvec _Getcvt() const
		{	
		return (::_Getcvt());
		}

	const lconv *_Getlconv() const
		{	
		return (localeconv());
		}

	_Timevec _Gettnames() const
		{	
		return (_Timevec(::_Gettnames()));
		}

	const char *_Getdays() const
		{	
		const char *_Ptr = ::_Getdays();
		if (_Ptr != 0)
			{	
			((_Locinfo *)this)->_Days = _Ptr;
			free((void *)_Ptr);
			}
		return (_Days.size() != 0 ? _Days.c_str()
			: ":Sun:Sunday:Mon:Monday:Tue:Tuesday:Wed:Wednesday"
				":Thu:Thursday:Fri:Friday:Sat:Saturday");
		}

	const char *_Getmonths() const
		{	
		const char *_Ptr = ::_Getmonths();
		if (_Ptr != 0)
			{	
			((_Locinfo *)this)->_Months = _Ptr;
			free((void *)_Ptr);
			}
		return (_Months.size() != 0 ? _Months.c_str()
			: ":Jan:January:Feb:February:Mar:March"
				":Apr:April:May:May:Jun:June"
				":Jul:July:Aug:August:Sep:September"
				":Oct:October:Nov:November:Dec:December");
		}

	const char *_Getfalse() const
		{	
		return ("false");
		}

	const char *_Gettrue() const
		{	
		return ("true");
		}

	int _Getdateorder() const
		{	
		return ::_Getdateorder();
		}

private:
	_Lockit _Lock;	
	string _Days;	
	string _Months;	
	string _Oldlocname;	
	string _Newlocname;	
	};

		
template<class _Elem> inline
	int __cdecl _LStrcoll(const _Elem *_First1, const _Elem *_Last1,
		const _Elem *_First2, const _Elem *_Last2,
			const _Locinfo::_Collvec *)
	{	
	for (; _First1 != _Last1 && _First2 != _Last2; ++_First1, ++_First2)
		if (*_First1 < *_First2)
			return (-1);	
		else if (*_First2 < *_First1)
			return (+1);	
	return (_First2 != _Last2 ? -1 : _First1 != _Last1 ? +1 : 0);
	}

template<> inline
	int __cdecl _LStrcoll(const char *_First1, const char *_Last1,
		const char *_First2, const char *_Last2,
			const _Locinfo::_Collvec *_Vector)
	{	
	return (_Strcoll(_First1, _Last1, _First2, _Last2, _Vector));
	}

template<> inline
	int __cdecl _LStrcoll(const wchar_t *_First1, const wchar_t *_Last1,
		const wchar_t *_First2, const wchar_t *_Last2,
			const _Locinfo::_Collvec *_Vector)
	{	
	return (_Wcscoll(_First1, _Last1, _First2, _Last2, _Vector));
	}

		
template<class _Elem> inline
	size_t __cdecl _LStrxfrm(_Elem *_First1, _Elem *_Last1,
		const _Elem *_First2, const _Elem *_Last2,
			const _Locinfo::_Collvec *)
	{	
	size_t _Count = _Last2 - _First2;
	if (_Count <= (size_t)(_Last1 - _First1))
		memcpy(_First1, _First2, _Count * sizeof (_Elem));
	return (_Count);
	}

template<> inline
	size_t __cdecl _LStrxfrm(char *_First1, char *_Last1,
		const char *_First2, const char *_Last2,
			const _Locinfo::_Collvec *_Vector)
	{	
	return (_Strxfrm(_First1, _Last1, _First2, _Last2, _Vector));
	}

template<> inline
	size_t __cdecl _LStrxfrm(wchar_t *_First1, wchar_t *_Last1,
		const wchar_t *_First2, const wchar_t *_Last2,
			const _Locinfo::_Collvec *_Vector)
	{	
	return (_Wcsxfrm(_First1, _Last1, _First2, _Last2, _Vector));
	}
}
#pragma warning(pop)
#pragma pack(pop)

#line 208 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocinfo"





#line 10 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"
#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug"

#pragma once



#pragma pack(push,8)
#pragma warning(push,3)

		
 




#line 16 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug"
  
  

namespace std {
struct _DebugHeapTag_t
	{	
	int _Type;
	};

extern  const _DebugHeapTag_t _DebugHeapTag;
}

 void * __cdecl
	operator new(size_t, const std::_DebugHeapTag_t&, char *, int)
	throw (...);	

 void * __cdecl
	operator new[](size_t, const std::_DebugHeapTag_t&, char *, int)
	throw (...);	

 void __cdecl
	operator delete(void *, const std::_DebugHeapTag_t&, char *, int)
	throw ();	

 void __cdecl
	operator delete[](void *, const std::_DebugHeapTag_t&, char *, int)
	throw ();	

  
  
  
  

namespace std {
		
template<class _Ty>
	void _DebugHeapDelete(_Ty *_Ptr)
	{	
	if (_Ptr != 0)
		{
		_Ptr->~_Ty();
		
		
		free(_Ptr);
		}
	}

		
template<class _Ty>
	class _DebugHeapAllocator
	: public allocator<_Ty>
	{	
public:

	template<class _Other>
		struct rebind
		{	
		typedef _DebugHeapAllocator<_Other> other;
		};

	pointer allocate(size_type _Count, const void *)
		{	
		return (_Ty *)new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug", 78) char[_Count * sizeof(_Ty)];
		}

	pointer allocate(size_type _Count)
		{	
		return (_Ty *)new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug", 83) char[_Count * sizeof(_Ty)];
		}

	void deallocate(pointer _Ptr, size_type)
		{	
		std::_DebugHeapDelete((void *)_Ptr);
		}
	};

		
class _DebugHeapString
	: public basic_string<char, char_traits<char>, _DebugHeapAllocator<char> >
	{	
public:
	typedef _DebugHeapString _Myt;
	typedef basic_string<char, char_traits<char>, _DebugHeapAllocator<char> >
		_Mybase;
	typedef char _Elem;

	_DebugHeapString()
		: _Mybase()
		{	
		}

	_DebugHeapString(const _Myt& _Right)
		: _Mybase(_Right)
		{	
		}

	_DebugHeapString(const _Elem *_Ptr)
		: _Mybase(_Ptr)
		{	
		}

	_DebugHeapString(const string &_Str)
		: _Mybase(_Str.c_str())
		{	
		}

	operator string() const
		{
		return string(c_str());
		}
	};

}


 #line 132 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug"

#pragma warning(pop)
#pragma pack(pop)

#line 137 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xdebug"





#line 11 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"

#pragma pack(push,8)
#pragma warning(push,3)

namespace std {

		
template<class _Dummy>
	class _Locbase
	{	
public:
	static const int collate = ((1 << (1)) >> 1);
	static const int ctype = ((1 << (2)) >> 1);
	static const int monetary = ((1 << (3)) >> 1);
	static const int numeric = ((1 << (4)) >> 1);
	static const int time = ((1 << (5)) >> 1);
	static const int messages = ((1 << (6)) >> 1);
	static const int all = (((1 << (7)) >> 1) - 1);
	static const int none = 0;
	};

template<class _Dummy>
	const int _Locbase<_Dummy>::collate;
template<class _Dummy>
	const int _Locbase<_Dummy>::ctype;
template<class _Dummy>
	const int _Locbase<_Dummy>::monetary;
template<class _Dummy>
	const int _Locbase<_Dummy>::numeric;
template<class _Dummy>
	const int _Locbase<_Dummy>::time;
template<class _Dummy>
	const int _Locbase<_Dummy>::messages;
template<class _Dummy>
	const int _Locbase<_Dummy>::all;
template<class _Dummy>
	const int _Locbase<_Dummy>::none;

		
class  locale
	: public _Locbase<int>
	{	
public:
	typedef int category;

			
	class  id
		{	
	public:
		id(size_t _Val = 0)
			: _Id(_Val)
			{	
			}

		operator size_t()
			{	
			if (_Id == 0)
				{	
				_Lockit _Lock(0);
				if (_Id == 0)
					_Id = ++_Id_cnt;
				}
			return (_Id);
			}

	private:
		id(const id&);	
		id& operator=(const id&);	

		size_t _Id;	
		static int _Id_cnt;	
		};

	class _Locimp;

			
	class  facet
		{	
		friend class locale;
		friend class _Locimp;

	public:
		static size_t __cdecl _Getcat(const facet ** = 0)
			{	
			return ((size_t)(-1));
			}

		void _Incref()
			{	
			_Lockit _Lock(0);

			if (_Refs < (size_t)(-1))
				++_Refs;
			}

		facet *_Decref()
			{	
			_Lockit _Lock(0);

			if (0 < _Refs && _Refs < (size_t)(-1))
				--_Refs;
			return (_Refs == 0 ? this : 0);
			}

		void _Register();	


		virtual ~facet()
			{	
			}

	protected:
		explicit facet(size_t _Initrefs = 0)
			: _Refs(_Initrefs)
			{	
			}

	private:
		facet(const facet&);	
		facet& operator=(const facet&);	

		size_t _Refs;	
		};

			
	class _Locimp
		: public facet
		{	
	protected:
		~_Locimp();	

	private:
		friend class locale;

		_Locimp(bool _Transparent = false);	

		 _Locimp(const _Locimp&);	

		 void _Addfac(facet *, size_t);	

		static _Locimp *__cdecl _Makeloc(const _Locinfo&,
			category, _Locimp *, const locale *);	

		static void __cdecl _Makewloc(const _Locinfo&,
			category, _Locimp *, const locale *);	

		static void __cdecl _Makexloc(const _Locinfo&,
			category, _Locimp *, const locale *);	

		facet **_Facetvec;	
		size_t _Facetcount;	
		category _Catmask;	
		bool _Xparent;	
		_DebugHeapString _Name;	
		static  _Locimp *_Clocptr;	
		};

	__declspec(deprecated) locale& _Addfac(facet *, size_t,
		size_t);	

	template<class _Elem,
		class _Traits,
		class _Alloc>
		bool operator()(const basic_string<_Elem, _Traits, _Alloc>& _Left,
			const basic_string<_Elem, _Traits, _Alloc>& _Right) const
		{	
		const std::collate<_Elem>& _Fac =
			std::use_facet<std::collate<_Elem> >(*this);

		return (_Fac.compare(_Left.c_str(), _Left.c_str() + _Left.size(),
			_Right.c_str(), _Right.c_str() + _Right.size()) < 0);
		}

	template<class _Facet>
		locale combine(const locale& _Loc) const
		{	
		_Facet *_Facptr;

		try {
			_Facptr = (_Facet *)&std::use_facet<_Facet>(_Loc);
		} catch (...) {
			throw runtime_error("locale::combine facet missing");
		}

		_Locimp *_Newimp = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 195) _Locimp(*_Ptr);
		_Newimp->_Addfac(_Facptr, _Facet::id);
		if (_Facet::_Getcat() != (size_t)(-1))
			{	
			_Newimp->_Catmask = 0;
			_Newimp->_Name = "*";
			}
		return (locale(_Newimp));
		}

	template<class _Facet>
		locale(const locale& _Loc, _Facet *_Facptr)
			: _Ptr(new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 207) _Locimp(*_Loc._Ptr))
		{	
		if (_Facptr != 0)
			{	
			_Ptr->_Addfac(_Facptr, _Facet::id);
			if (_Facet::_Getcat() != (size_t)(-1))
				_Ptr->_Catmask = 0, _Ptr->_Name = "*";	
			}
		}


	locale() throw ();	

	locale(_Uninitialized)
		{	
		}

	locale(const locale& _Right) throw ()
		: _Ptr(_Right._Ptr)
		{	
		_Ptr->_Incref();
		}

	locale(const locale&, const locale&,
		category);	

	explicit locale(const char *,
		category = all);	

	locale(const locale&, const char *,
		category);	

	~locale() throw ()
		{	
		if (_Ptr != 0)
			std::_DebugHeapDelete(_Ptr->_Decref());
		}

	locale& operator=(const locale& _Right) throw ()
		{	
		if (_Ptr != _Right._Ptr)
			{	
			std::_DebugHeapDelete(_Ptr->_Decref());
			_Ptr = _Right._Ptr;
			_Ptr->_Incref();
			}
		return (*this);
		}

	string name() const
		{	
		return (_Ptr->_Name);
		}

	const facet *_Getfacet(size_t) const;	

	bool operator==(const locale&) const;	

	bool operator!=(const locale& _Right) const
		{	
		return (!(*this == _Right));
		}

	static const locale& __cdecl classic();	

	static locale __cdecl global(const locale&);	

	static locale __cdecl empty();	

private:
	locale(_Locimp *_Ptrimp)
		: _Ptr(_Ptrimp)
		{	
		}

	static _Locimp *__cdecl _Init();	

	_Locimp *_Ptr;	
	};

		
template<class _Facet> inline __declspec(deprecated)
	locale _Addfac(locale _Loc, _Facet *_Fac)
		{	
		return (_Loc._Addfac(_Fac, _Facet::id, _Facet::_Getcat()));
		}

  

  


template<class _Facet> inline
	const _Facet& __cdecl use_facet(const locale& _Loc)
	{	
	_Lockit _Lock(0);	
	static const locale::facet *_Psave;	

	size_t _Id = _Facet::id;
	const locale::facet *_Pf = _Loc._Getfacet(_Id);

	if (_Pf != 0)
		;	
	else if (_Psave != 0)
		_Pf = _Psave;	
	else if (_Facet::_Getcat(&_Psave) == (size_t)(-1))
 
		throw bad_cast();	
 

#line 318 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"
	else
		{	
		_Pf = _Psave;

		locale::facet *_Pfmod = (_Facet *)_Psave;
		_Pfmod->_Incref();
		_Pfmod->_Register();
		}

	return ((const _Facet&)(*_Pf));	
	}

template<class _Facet> inline __declspec(deprecated)
	const _Facet& __cdecl use_facet(const locale& _Loc, const _Facet *,
		bool = false)
	{	
	return use_facet<_Facet>(_Loc);
	}

		


template<class _Elem> inline
	char _Narrow(_Elem _Ch)
	{	
	return ((char)_Ch);	
	}

template<> inline
	char _Narrow(wchar_t _Ch)
	{	
	return ((char)wctob(_Ch));
	}

		


template<class _Elem> inline
	_Elem _Widen(char _Ch, _Elem *)
	{	
	return ((_Elem)(unsigned char)_Ch);	
	}

template<> inline
	wchar_t _Widen(char _Ch, wchar_t *)
	{	
	return (btowc(_Ch));
	}

		
template<class _Elem,
	class _InIt> inline
	int __cdecl _Getloctxt(_InIt& _First, _InIt& _Last, size_t _Numfields,
		const _Elem *_Ptr)
	{	
	for (size_t _Off = 0; _Ptr[_Off] != (_Elem)0; ++_Off)
		if (_Ptr[_Off] == _Ptr[0])
			++_Numfields;	
	string _Str(_Numfields, '\0');	

	int _Ans = -2;	
	for (size_t _Column = 1; ; ++_Column, ++_First, _Ans = -1)
		{	
		bool  _Prefix = false;	
		size_t _Off = 0;	
		size_t _Field = 0;	

		for (; _Field < _Numfields; ++_Field)
			{	
			for (; _Ptr[_Off] != (_Elem)0 && _Ptr[_Off] != _Ptr[0]; ++_Off)
				;	

			if (_Str[_Field] != '\0')
				_Off += _Str[_Field];	
			else if (_Ptr[_Off += _Column] == _Ptr[0]
				|| _Ptr[_Off] == (_Elem)0)
				{	
				_Str[_Field] = (char)(_Column < 127
					? _Column : 127);	
				_Ans = (int)_Field;	
				}
			else if (_First == _Last || _Ptr[_Off] != *_First)
				_Str[_Field] = (char)(_Column < 127
					? _Column : 127);	
			else
				_Prefix = true;	
			}

		if (!_Prefix || _First == _Last)
			break;	
		}
	return (_Ans);	
	}

		



template<class _Elem> inline
	_Elem *__cdecl _Maklocstr(const char *_Ptr, _Elem *,
		const _Locinfo::_Cvtvec &)
	{	
	size_t _Count = ::strlen(_Ptr) + 1;
	_Elem *_Ptrdest = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 421) _Elem[_Count];

	for (_Elem *_Ptrnext = _Ptrdest; 0 < _Count; --_Count, ++_Ptrnext, ++_Ptr)
		*_Ptrnext = _Widen(*_Ptr, (_Elem *)0);
	return (_Ptrdest);
	}

template<> inline
	wchar_t *__cdecl _Maklocstr(const char *_Ptr, wchar_t *,
		const _Locinfo::_Cvtvec &_Cvt)
	{	
	size_t _Count, _Count1;
	size_t _Wchars;
	const char *_Ptr1;
	wchar_t *_Ptrdest, *_Ptrnext;

	mbstate_t _Mbst1 = {0};
	_Count = _Count1 = ::strlen(_Ptr) + 1;
	for (_Wchars = 0, _Ptr1 = _Ptr; 0 < _Count; ++_Wchars)
		{	
		int _Bytes;
		if ((_Bytes = _Mbrtowc(0, _Ptr1, _Count, &_Mbst1, &_Cvt)) <= 0)
			break;
		_Ptr1 += _Bytes;
		_Count -= _Bytes;
		}
	++_Wchars;

	_Ptrdest = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 449) wchar_t[_Wchars];
	mbstate_t _Mbst2 = {0};
	for (_Ptrnext = _Ptrdest; 0 < _Wchars; --_Wchars, ++_Ptrnext)
		{	
		int _Bytes;
		if ((_Bytes = _Mbrtowc(_Ptrnext, _Ptr, _Count1, &_Mbst1, &_Cvt)) <= 0)
			break;
		_Ptr += _Bytes;
		_Count1 -= _Bytes;
		}
	*_Ptrnext = 0;
	return (_Ptrdest);
	}

		
class  codecvt_base
	: public locale::facet
	{	
public:
	enum
		{	
		ok, partial, error, noconv};
	typedef int result;

	codecvt_base(size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		}

	bool always_noconv() const throw ()
		{	
		return (do_always_noconv());
		}

	int max_length() const throw ()
		{	
		return (do_max_length());
		}

	int encoding() const throw ()
		{	
		return (do_encoding());
		}

	~codecvt_base()
		{	
		}

protected:
	virtual bool do_always_noconv() const throw ()
		{	
		return (true);
		}

	virtual int do_max_length() const throw ()
		{	
		return (1);
		}

	virtual int do_encoding() const throw ()
		{	
		return (1);	
		}
	};

		
template<class _Elem,
	class _Byte,
	class _Statype>
	class codecvt
		: public codecvt_base
	{	
public:
	typedef _Elem intern_type;
	typedef _Byte extern_type;
	typedef _Statype state_type;

	result in(_Statype& _State,
		const _Byte *_First1, const _Byte *_Last1, const _Byte *& _Mid1,
		_Elem *_First2, _Elem *_Last2, _Elem *& _Mid2) const
		{	
		return (do_in(_State,
			_First1, _Last1, _Mid1, _First2, _Last2, _Mid2));
		}

	result out(_Statype& _State,
		const _Elem *_First1, const _Elem *_Last1, const _Elem *& _Mid1,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		return (do_out(_State,
			_First1, _Last1, _Mid1, _First2, _Last2, _Mid2));
		}

	result unshift(_Statype& _State,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		return (do_unshift(_State, _First2, _Last2, _Mid2));
		}

	int length(const _Statype& _State, const _Byte *_First1,
		const _Byte *_Last1, size_t _Count) const throw ()
		{	
		return (do_length(_State, _First1, _Last1, _Count));
		}

	static locale::id id;	

	explicit codecvt(size_t _Refs = 0)
		: codecvt_base(_Refs)
		{	
		_Init(_Locinfo());
		}

	codecvt(const _Locinfo& _Lobj, size_t _Refs = 0)
		: codecvt_base(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 571) codecvt<_Elem, _Byte, _Statype>;
		return (2);
		}

protected:
	virtual ~codecvt()
		{	
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		_Cvt = _Lobj._Getcvt();
		}

	virtual result do_in(_Statype&,
		const _Byte *_First1, const _Byte *, const _Byte *& _Mid1,
		_Elem *_First2, _Elem *, _Elem *& _Mid2) const
		{	
		_Mid1 = _First1, _Mid2 = _First2;
		return (noconv);	
		}

	virtual result do_out(_Statype&,
		const _Elem *_First1, const _Elem *, const _Elem *& _Mid1,
		_Byte *_First2, _Byte *, _Byte *& _Mid2) const
		{	
		_Mid1 = _First1, _Mid2 = _First2;
		return (noconv);	
		}

	virtual result do_unshift(_Statype&,
		_Byte *, _Byte *, _Byte *&) const
		{	
		return (noconv);	
		}

	virtual int do_length(const _Statype&, const _Byte *_First1,
		const _Byte *_Last1, size_t _Count) const throw ()
		{	
		return (int)(_Count < (size_t)(_Last1 - _First1)
			? _Count : _Last1 - _First1);	
		}

private:
	_Locinfo::_Cvtvec _Cvt;	
	};

		
template<class _Elem,
	class _Byte,
	class _Statype>
	locale::id codecvt<_Elem, _Byte, _Statype>::id;

		
template<> class  codecvt<wchar_t, char, mbstate_t>
	: public codecvt_base
	{	
public:
	typedef wchar_t _Elem;
	typedef char _Byte;
	typedef mbstate_t _Statype;
	typedef _Elem intern_type;
	typedef _Byte extern_type;
	typedef _Statype state_type;

	result in(_Statype& _State,
		const _Byte *_First1, const _Byte *_Last1, const _Byte *& _Mid1,
		_Elem *_First2, _Elem *_Last2, _Elem *& _Mid2) const
		{	
		return (do_in(_State,
			_First1, _Last1, _Mid1, _First2, _Last2, _Mid2));
		}

	result out(_Statype& _State,
		const _Elem *_First1, const _Elem *_Last1, const _Elem *& _Mid1,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		return (do_out(_State,
			_First1, _Last1, _Mid1, _First2, _Last2, _Mid2));
		}

	result unshift(_Statype& _State,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		return (do_unshift(_State,
			_First2, _Last2, _Mid2));
		}

	int length(const _Statype& _State, const _Byte *_First1,
		const _Byte *_Last1, size_t _N2) const throw ()
		{	
		return (do_length(_State, _First1, _Last1, _N2));
		}

	static locale::id id;	

	explicit codecvt(size_t _Refs = 0)
		: codecvt_base(_Refs)
		{	
		_Init(_Locinfo());
		}

	codecvt(const _Locinfo& _Lobj, size_t _Refs = 0)
		: codecvt_base(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 683) codecvt<_Elem, _Byte, _Statype>;
		return (2);
		}

protected:
	virtual ~codecvt()
		{	
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		_Cvt = _Lobj._Getcvt();
		}

	virtual result do_in(_Statype& _State,
		const _Byte *_First1, const _Byte *_Last1, const _Byte *& _Mid1,
		_Elem *_First2, _Elem *_Last2, _Elem *& _Mid2) const
		{	
		_Mid1 = _First1, _Mid2 = _First2;
		result _Ans = _Mid1 == _Last1 ? ok : partial;
		int _Bytes;

		while (_Mid1 != _Last1 && _Mid2 != _Last2)
			switch (_Bytes = _Mbrtowc(_Mid2, _Mid1, _Last1 - _Mid1,
				&_State, &_Cvt))
			{	
			case -2:	
				_Mid1 = _Last1;
				return (_Ans);

			case -1:	
				return (error);

			case 0:	
				_Bytes = (int)::strlen(_Mid1) + 1;
				

			default:	
				_Mid1 += _Bytes, ++_Mid2, _Ans = ok;
			}
		return (_Ans);
		}

	virtual result do_out(_Statype& _State,
		const _Elem *_First1, const _Elem *_Last1, const _Elem *& _Mid1,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		_Mid1 = _First1, _Mid2 = _First2;
		result _Ans = _Mid1 == _Last1 ? ok : partial;
		int _Bytes;

		while (_Mid1 != _Last1 && _Mid2 != _Last2)
			if (___mb_cur_max_func() <= _Last2 - _Mid2)
				if ((_Bytes = _Wcrtomb(_Mid2, *_Mid1,
					&_State, &_Cvt)) <= 0)
					return (error);	
				else
					++_Mid1, _Mid2 += _Bytes, _Ans = ok;
			else
				{	
				_Byte _Buf[5];
				_Statype _Stsave = _State;

				if ((_Bytes = _Wcrtomb(_Buf, *_Mid1,
					&_State, &_Cvt)) <= 0)
					return (error);	
				else if (_Last2 - _Mid2 < _Bytes)
					{	
					_State = _Stsave;
					return (_Ans);
					}
				else
					{	
					memcpy(_Mid2, _Buf, _Bytes);
					++_Mid1, _Mid2 += _Bytes, _Ans = ok;
					}
				}
		return (_Ans);
		}

	virtual result do_unshift(_Statype& _State,
		_Byte *_First2, _Byte *_Last2, _Byte *& _Mid2) const
		{	
		_Mid2 = _First2;
		result _Ans = ok;
		int _Bytes;
		_Byte _Buf[5];
		_Statype _Stsave = _State;

		if ((_Bytes = _Wcrtomb(_Buf, L'\0', &_State, &_Cvt)) <= 0)
			_Ans = error;	
		else if (_Last2 - _Mid2 < --_Bytes)
			{	
			_State = _Stsave;
			_Ans = partial;
			}
		else if (0 < _Bytes)
			{	
			memcpy(_Mid2, _Buf, _Bytes);
			_Mid2 += _Bytes;
			}
		return (_Ans);
		}

	virtual int do_length(const _Statype& _State, const _Byte *_First1,
		const _Byte *_Last1, size_t _Count) const throw ()
		{	
		int _Wchars;
		const _Byte *_Mid1;
		_Statype _Mystate = _State;

		for (_Wchars = 0, _Mid1 = _First1;
			(size_t)_Wchars < _Count && _Mid1 != _Last1; )
			{	
			int _Bytes;
			_Elem _Ch;

			switch (_Bytes = _Mbrtowc(&_Ch, _Mid1, _Last1 - _Mid1,
				&_Mystate, &_Cvt))
				{	
			case -2:	
				return (_Wchars);

			case -1:	
				return (_Wchars);

			case 0:	
				_Bytes = (int)::strlen(_Mid1) + 1;
				

			default:	
				_Mid1 += _Bytes, ++_Wchars;
				}
			}
		return (_Wchars);
		}

	virtual bool do_always_noconv() const throw ()
		{	
		return (false);
		}

	virtual int do_max_length() const throw ()
		{	
		return (5);
		}

	virtual int do_encoding() const throw ()
		{	
		return (0);
		}

private:
	_Locinfo::_Cvtvec _Cvt;	
	};

		
template<class _Elem,
	class _Byte,
	class _Statype>
	class codecvt_byname
		: public codecvt<_Elem, _Byte, _Statype>
	{	
public:
	explicit codecvt_byname(const char *_Locname, size_t _Refs = 0)
		: codecvt<_Elem, _Byte, _Statype>(_Locinfo(_Locname), _Refs)
		{	
		}

protected:
	virtual ~codecvt_byname()
		{	
		}
	};

		
struct  ctype_base
	: public locale::facet
	{	
	enum
		{	
		alnum = 0x4|0x2|0x1|0x100, alpha = 0x2|0x1|0x100,
		cntrl = 0x20, digit = 0x4, graph = 0x4|0x2|0x10|0x1|0x100,
		lower = 0x2, print = 0x4|0x2|0x10|0x40|0x1|0x100|0x80,
		punct = 0x10, space = 0x8|0x40|0x000, upper = 0x1,
		xdigit = 0x80};
	typedef short mask;	

	ctype_base(size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		}

	~ctype_base()
		{	
		}
	};

		
template<class _Elem>
	class ctype
		: public ctype_base
	{	
public:
	typedef _Elem char_type;

	bool is(mask _Maskval, _Elem _Ch) const
		{	
		return (do_is(_Maskval, _Ch));
		}

	const _Elem *is(const _Elem *_First, const _Elem *_Last,
		mask *_Dest) const
		{	
		return (do_is(_First, _Last, _Dest));
		}

	const _Elem *scan_is(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		return (do_scan_is(_Maskval, _First, _Last));
		}

	const _Elem *scan_not(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		return (do_scan_not(_Maskval, _First, _Last));
		}

	_Elem tolower(_Elem _Ch) const
		{	
		return (do_tolower(_Ch));
		}

	const _Elem *tolower(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_tolower(_First, _Last));
		}

	_Elem toupper(_Elem _Ch) const
		{	
		return (do_toupper(_Ch));
		}

	const _Elem *toupper(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_toupper(_First, _Last));
		}

	_Elem widen(char _Byte) const
		{	
		return (do_widen(_Byte));
		}

	const char *widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		return (do_widen(_First, _Last, _Dest));
		}

	char narrow(_Elem _Ch, char _Dflt = '\0') const
		{	
		return (do_narrow(_Ch, _Dflt));
		}

	const _Elem *narrow(const _Elem *_First, const _Elem *_Last,
		char _Dflt, char *_Dest) const
		{	
		return (do_narrow(_First, _Last, _Dflt, _Dest));
		}

	static locale::id id;	

	explicit ctype(size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Locinfo());
		}

	ctype(const _Locinfo& _Lobj, size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 972) ctype<_Elem>;
		return (2);
		}

protected:
	virtual ~ctype()
		{	
		if (_Ctype._Delfl)
			free((void *)_Ctype._Table);
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		_Ctype = _Lobj._Getctype();
		}

	virtual bool do_is(mask _Maskval, _Elem _Ch) const
		{	
		return ((_Ctype._Table[(unsigned char)narrow(_Ch)]
			& _Maskval) != 0);
		}

	virtual const _Elem *do_is(const _Elem *_First, const _Elem *_Last,
		mask *_Dest) const
		{	
		for (; _First != _Last; ++_First, ++_Dest)
			*_Dest = _Ctype._Table[(unsigned char)narrow(*_First)];
		return (_First);
		}

	virtual const _Elem *do_scan_is(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && !is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	virtual const _Elem *do_scan_not(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	virtual _Elem do_tolower(_Elem _Ch) const
		{	
		return (widen((char)_Tolower((unsigned char)narrow(_Ch),
			&_Ctype)));
		}

	virtual const _Elem *do_tolower(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = widen((char)_Tolower((unsigned char)narrow(*_First),
				&_Ctype));
		return ((const _Elem *)_First);
		}

	virtual _Elem do_toupper(_Elem _Ch) const
		{	
		return (widen((char)_Toupper((unsigned char)narrow(_Ch),
			&_Ctype)));
		}

	virtual const _Elem *do_toupper(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = widen((char)_Toupper((unsigned char)narrow(*_First),
				&_Ctype));
		return ((const _Elem *)_First);
		}

	virtual _Elem do_widen(char _Byte) const
		{	
		return (_Widen(_Byte, (_Elem *)0));
		}

	virtual const char *do_widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		for (; _First != _Last; ++_First, ++_Dest)
			*_Dest = _Widen(*_First, (_Elem *)0);
		return (_First);
		}

	virtual char do_narrow(_Elem _Ch, char) const
		{	
		return (_Narrow(static_cast<_Elem>(_Ch)));
		}

	virtual const _Elem *do_narrow(const _Elem *_First, const _Elem *_Last,
		char, char *_Dest) const
		{	
		for (; _First != _Last; ++_First, ++_Dest)
			*_Dest = _Narrow(static_cast<_Elem>(*_First));
		return (_First);
		}

private:
	_Locinfo::_Ctypevec _Ctype;	
	};

		
template<class _Elem>
	locale::id ctype<_Elem>::id;

		
template<> class  ctype<char>
	: public ctype_base
	{	
	typedef ctype<char> _Myt;

public:
	typedef char _Elem;
	typedef _Elem char_type;

	bool is(mask _Maskval, _Elem _Ch) const
		{	
		return ((_Ctype._Table[(unsigned char)_Ch] & _Maskval) != 0);
		}

	const _Elem *is(const _Elem *_First, const _Elem *_Last,
		mask *_Dest) const
		{	
		for (; _First != _Last; ++_First, ++_Dest)
			*_Dest = _Ctype._Table[(unsigned char)*_First];
		return (_First);
		}

	const _Elem *scan_is(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && !is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	const _Elem *scan_not(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	_Elem tolower(_Elem _Ch) const
		{	
		return (do_tolower(_Ch));
		}

	const _Elem *tolower(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_tolower(_First, _Last));
		}

	_Elem toupper(_Elem _Ch) const
		{	
		return (do_toupper(_Ch));
		}

	const _Elem *toupper(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_toupper(_First, _Last));
		}

	_Elem widen(char _Byte) const
		{	
		return (do_widen(_Byte));
		}

	const _Elem *widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		return (do_widen(_First, _Last, _Dest));
		}

	_Elem narrow(_Elem _Ch, char _Dflt = '\0') const
		{	
		return (do_narrow(_Ch, _Dflt));
		}

	const _Elem *narrow(const _Elem *_First, const _Elem *_Last,
		char _Dflt, char *_Dest) const
		{	
		return (do_narrow(_First, _Last, _Dflt, _Dest));
		}

	static locale::id id;	

	explicit ctype(const mask *_Table = 0, bool _Deletetable = false,
		size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Locinfo());
		if (_Table != 0)
			{	
			_Tidy();
			_Ctype._Table = _Table;
			_Ctype._Delfl = _Deletetable ? -1 : 0;
			}
		}

	ctype(const _Locinfo& _Lobj, size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 1186) ctype<_Elem>;
		return (2);
		}

	static const size_t table_size;	

protected:
	virtual ~ctype()
		{	
		_Tidy();
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		_Ctype = _Lobj._Getctype();
		}

	void _Tidy()
		{	
		if (0 < _Ctype._Delfl)
			free((void *)_Ctype._Table);
		else if (_Ctype._Delfl < 0)
			delete[] (void *)_Ctype._Table;
		}

	virtual _Elem do_tolower(_Elem _Ch) const
		{	
		return ((_Elem)_Tolower((unsigned char)_Ch, &_Ctype));
		}

	virtual const _Elem *do_tolower(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = (_Elem)_Tolower((unsigned char)*_First, &_Ctype);
		return ((const _Elem *)_First);
		}

	virtual _Elem do_toupper(_Elem _Ch) const
		{	
		return ((_Elem)_Toupper((unsigned char)_Ch, &_Ctype));
		}

	virtual const _Elem *do_toupper(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = (_Elem)_Toupper((unsigned char)*_First, &_Ctype);
		return ((const _Elem *)_First);
		}

	virtual _Elem do_widen(char _Byte) const
		{	
		return (_Byte);
		}

	virtual const _Elem *do_widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		memcpy(_Dest, _First, _Last - _First);
		return (_Last);
		}

	virtual _Elem do_narrow(_Elem _Ch, char) const
		{	
		return (_Ch);
		}

	virtual const _Elem *do_narrow(const _Elem *_First, const _Elem *_Last,
		char, char *_Dest) const
		{	
		memcpy(_Dest, _First, _Last - _First);
		return (_Last);
		}

	const mask *table() const throw ()
		{	
		return (_Ctype._Table);
		}

	static const mask *__cdecl classic_table() throw ()
		{	
		const _Myt& _Fac = use_facet<_Myt >(locale::classic());
		return (_Fac.table());
		}

private:
	_Locinfo::_Ctypevec _Ctype;	
	};

		
template<> class  ctype<wchar_t>
	: public ctype_base
	{	
	typedef ctype<wchar_t> _Myt;

public:
	typedef wchar_t _Elem;
	typedef _Elem char_type;

	bool is(mask _Maskval, _Elem _Ch) const
		{	
		return (do_is(_Maskval, _Ch));
		}

	const _Elem *is(const _Elem *_First, const _Elem *_Last,
		mask *_Dest) const
		{	
		return (do_is(_First, _Last, _Dest));
		}

	const _Elem *scan_is(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		return (do_scan_is(_Maskval, _First, _Last));
		}

	const _Elem *scan_not(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		return (do_scan_not(_Maskval, _First, _Last));
		}

	_Elem tolower(_Elem _Ch) const
		{	
		return (do_tolower(_Ch));
		}

	const _Elem *tolower(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_tolower(_First, _Last));
		}

	_Elem toupper(_Elem _Ch) const
		{	
		return (do_toupper(_Ch));
		}

	const _Elem *toupper(_Elem *_First, const _Elem *_Last) const
		{	
		return (do_toupper(_First, _Last));
		}

	_Elem widen(char _Byte) const
		{	
		return (do_widen(_Byte));
		}

	const char *widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		return (do_widen(_First, _Last, _Dest));
		}

	char narrow(_Elem _Ch, char _Dflt = '\0') const
		{	
		return (do_narrow(_Ch, _Dflt));
		}

	const _Elem *narrow(const _Elem *_First, const _Elem *_Last,
		char _Dflt, char *_Dest) const
		{	
		return (do_narrow(_First, _Last, _Dflt, _Dest));
		}

	static locale::id id;	

	explicit ctype(size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Locinfo());
		}

	ctype(const _Locinfo& _Lobj, size_t _Refs = 0)
		: ctype_base(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale", 1367) ctype<_Elem>;
		return (2);
		}

protected:
	virtual ~ctype()
		{	
		if (_Ctype._Delfl)
			free((void *)_Ctype._Table);
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		_Ctype = _Lobj._Getctype();
		_Cvt = _Lobj._Getcvt();
		}

	virtual bool do_is(mask _Maskval, _Elem _Ch) const
		{	
		return ((_Getwctype(_Ch, &_Ctype) & _Maskval) != 0);
		}

	virtual const _Elem *do_is(const _Elem *_First, const _Elem *_Last,
		mask *_Dest) const
		{	
		return (_Getwctypes(_First, _Last, _Dest, &_Ctype));
		}

	virtual const _Elem *do_scan_is(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && !is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	virtual const _Elem *do_scan_not(mask _Maskval, const _Elem *_First,
		const _Elem *_Last) const
		{	
		for (; _First != _Last && is(_Maskval, *_First); ++_First)
			;
		return (_First);
		}

	virtual _Elem do_tolower(_Elem _Ch) const
		{	
		return (widen((char)_Tolower((unsigned char)narrow(_Ch),
			&_Ctype)));
		}

	virtual const _Elem *do_tolower(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = widen((char)_Tolower((unsigned char)narrow(*_First),
				&_Ctype));
		return ((const _Elem *)_First);
		}

	virtual _Elem do_toupper(_Elem _Ch) const
		{	
		return (widen((char)_Toupper((unsigned char)narrow(_Ch),
			&_Ctype)));
		}

	virtual const _Elem *do_toupper(_Elem *_First, const _Elem *_Last) const
		{	
		for (; _First != _Last; ++_First)
			*_First = widen((char)_Toupper((unsigned char)narrow(*_First),
				&_Ctype));
		return ((const _Elem *)_First);
		}

	virtual _Elem do_widen(char _Byte) const
		{	
		mbstate_t _Mbst = {0};
		wchar_t _Wc;
		return (_Mbrtowc(&_Wc, &_Byte, 1, &_Mbst, &_Cvt) <= 0
			? (wchar_t)(unsigned char)_Byte : _Wc);
		}

	virtual const char *do_widen(const char *_First, const char *_Last,
		_Elem *_Dest) const
		{	
		mbstate_t _Mbst = {0};
		while (_First != _Last)
			{
			int _Bytes;

			switch (_Bytes = _Mbrtowc(_Dest, _First, _Last - _First,
				&_Mbst, &_Cvt))
				{	
			case -2:	
			case -1:	
				return (_First);

			case 0:	
				_Bytes = (int)::strlen(_First) + 1;
				

			default:	
				_First += _Bytes, ++_Dest;
				}
			}
		return (_First);
		}

	virtual char do_narrow(_Elem _Ch, char _Dflt) const
		{	
		char _Buf[5];
		mbstate_t _Mbst = {0};
		return (_Wcrtomb(_Buf, _Ch, &_Mbst, &_Cvt) != 1
			? _Dflt : _Buf[0]);
		}

	virtual const _Elem *do_narrow(const _Elem *_First, const _Elem *_Last,
		char _Dflt, char *_Dest) const
		{	
		mbstate_t _Mbst = {0};
		for (; _First != _Last; ++_First)
			{
			int _Bytes;
			if ((_Bytes = _Wcrtomb(_Dest, *_First, &_Mbst, &_Cvt)) <= 0)
				{
				_Bytes = 1;
				*_Dest = _Dflt;
				}
			_Dest += _Bytes;
			}
		return (_First);
		}

private:
	_Locinfo::_Ctypevec _Ctype;	
	_Locinfo::_Cvtvec _Cvt;		
	};

		
template<class _Elem>
	class ctype_byname
	: public ctype<_Elem>
	{	
public:
	explicit ctype_byname(const char *_Locname, size_t _Refs = 0)
		: ctype<_Elem>(_Locinfo(_Locname), _Refs)
		{	
		}

protected:
	virtual ~ctype_byname()
		{	
		}
	};

 


}
#pragma warning(pop)
#pragma pack(pop)

#line 1529 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocale"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xiosbase"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
template<class _Dummy>
	class _Iosb
	{	
public:
	enum _Dummy_enum {_Dummy_enum_val = 1};	
	enum _Fmtflags
		{	
		_Fmtmask = 0x7fff, _Fmtzero = 0};
	typedef int fmtflags;

	static const _Fmtflags skipws = (_Fmtflags)0x0001;
	static const _Fmtflags unitbuf = (_Fmtflags)0x0002;
	static const _Fmtflags uppercase = (_Fmtflags)0x0004;
	static const _Fmtflags showbase = (_Fmtflags)0x0008;
	static const _Fmtflags showpoint = (_Fmtflags)0x0010;
	static const _Fmtflags showpos = (_Fmtflags)0x0020;
	static const _Fmtflags left = (_Fmtflags)0x0040;
	static const _Fmtflags right = (_Fmtflags)0x0080;
	static const _Fmtflags internal = (_Fmtflags)0x0100;
	static const _Fmtflags dec = (_Fmtflags)0x0200;
	static const _Fmtflags oct = (_Fmtflags)0x0400;
	static const _Fmtflags hex = (_Fmtflags)0x0800;
	static const _Fmtflags scientific = (_Fmtflags)0x1000;
	static const _Fmtflags fixed = (_Fmtflags)0x2000;
	static const _Fmtflags boolalpha = (_Fmtflags)0x4000;
	static const _Fmtflags adjustfield = (_Fmtflags)0x01c0;
	static const _Fmtflags basefield = (_Fmtflags)0x0e00;
	static const _Fmtflags floatfield = (_Fmtflags)0x3000;

	enum _Iostate
		{	
		_Statmask = 0x7};
	typedef int iostate;

	static const _Iostate goodbit = (_Iostate)0x0;
	static const _Iostate eofbit = (_Iostate)0x1;
	static const _Iostate failbit = (_Iostate)0x2;
	static const _Iostate badbit = (_Iostate)0x4;

	enum _Openmode
		{	
		_Openmask = 0x3f};
	typedef int openmode;

	static const _Openmode in = (_Openmode)0x01;
	static const _Openmode out = (_Openmode)0x02;
	static const _Openmode ate = (_Openmode)0x04;
	static const _Openmode app = (_Openmode)0x08;
	static const _Openmode trunc = (_Openmode)0x10;
	static const _Openmode binary = (_Openmode)0x20;

	enum _Seekdir
		{	
		_Seekmask = 0x3};
	typedef int seekdir;

	static const _Seekdir beg = (_Seekdir)0;
	static const _Seekdir cur = (_Seekdir)1;
	static const _Seekdir end = (_Seekdir)2;
	};

template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::skipws;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::unitbuf;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::uppercase;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::showbase;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::showpoint;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::showpos;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::left;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::right;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::internal;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::dec;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::oct;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::hex;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::scientific;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::fixed;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::boolalpha;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::adjustfield;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::basefield;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Fmtflags _Iosb<_Dummy>::floatfield;

template<class _Dummy>
	const typename _Iosb<_Dummy>::_Iostate _Iosb<_Dummy>::goodbit;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Iostate _Iosb<_Dummy>::eofbit;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Iostate _Iosb<_Dummy>::failbit;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Iostate _Iosb<_Dummy>::badbit;

template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::in;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::out;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::ate;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::app;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::trunc;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Openmode _Iosb<_Dummy>::binary;

template<class _Dummy>
	const typename _Iosb<_Dummy>::_Seekdir _Iosb<_Dummy>::beg;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Seekdir _Iosb<_Dummy>::cur;
template<class _Dummy>
	const typename _Iosb<_Dummy>::_Seekdir _Iosb<_Dummy>::end;

		
class  ios_base
	: public _Iosb<int>
	{	
public:

	typedef std::streamoff streamoff;
	typedef std::streampos streampos;

	enum event
		{	
		erase_event, imbue_event, copyfmt_event};

	typedef void (__cdecl *event_callback)(event, ios_base&, int);
	typedef unsigned int io_state, open_mode, seek_dir;

			
	class failure
		: public runtime_error
		{	
	public:
		explicit failure(const string &_Message)
			: runtime_error(_Message)
			{	
			}

		virtual ~failure()
			{	
			}

	protected:
		virtual void _Doraise() const
			{	
			throw (*this);
			}
	};

			
	class  Init
		{	
	public:
		Init();	

		~Init();	

	private:
		static int _Init_cnt;	
		};

	ios_base& operator=(const ios_base& _Right)
		{	
		if (this != &_Right)
			{	
			_Mystate = _Right._Mystate;
			copyfmt(_Right);
			}
		return (*this);
		}

	operator void *() const
		{	
		return (fail() ? 0 : (void *)this);
		}

	bool operator!() const
		{	
		return (fail());
		}

	void clear(iostate, bool);	

	void clear(iostate _State = goodbit)
		{	
		clear(_State, false);
		}

	void clear(io_state _State)
		{	
		clear((iostate)_State);
		}

	iostate rdstate() const
		{	
		return (_Mystate);
		}

	void setstate(iostate _State, bool _Exreraise)
		{	
		if (_State != goodbit)
			clear((iostate)((int)rdstate() | (int)_State), _Exreraise);
		}

	void setstate(iostate _State)
		{	
		if (_State != goodbit)
			clear((iostate)((int)rdstate() | (int)_State), false);
		}

	void setstate(io_state _State)
		{	
		setstate((iostate)_State);
		}

	bool good() const
		{	
		return (rdstate() == goodbit);
		}

	bool eof() const
		{	
		return ((int)rdstate() & (int)eofbit);
		}

	bool fail() const
		{	
		return (((int)rdstate()
			& ((int)badbit | (int)failbit)) != 0);
		}

	bool bad() const
		{	
		return (((int)rdstate() & (int)badbit) != 0);
		}

	iostate exceptions() const
		{	
		return (_Except);
		}

	void exceptions(iostate _Newexcept)
		{	
		_Except = (iostate)((int)_Newexcept & (int)_Statmask);
		clear(_Mystate);
		}

	void exceptions(io_state _State)
		{	
		exceptions((iostate)_State);
		}

	fmtflags flags() const
		{	
		return (_Fmtfl);
		}

	fmtflags flags(fmtflags _Newfmtflags)
		{	
		fmtflags _Oldfmtflags = _Fmtfl;
		_Fmtfl = (fmtflags)((int)_Newfmtflags & (int)_Fmtmask);
		return (_Oldfmtflags);
		}

	fmtflags setf(fmtflags _Newfmtflags)
		{	
		ios_base::fmtflags _Oldfmtflags = _Fmtfl;
		_Fmtfl = (fmtflags)((int)_Fmtfl
			| (int)_Newfmtflags & (int)_Fmtmask);
		return (_Oldfmtflags);
		}

	fmtflags setf(fmtflags _Newfmtflags, fmtflags _Mask)
		{	
		ios_base::fmtflags _Oldfmtflags = _Fmtfl;
		_Fmtfl = (fmtflags)(((int)_Fmtfl & (int)~_Mask)
			| ((int)_Newfmtflags & (int)_Mask & (int)_Fmtmask));
		return (_Oldfmtflags);
		}

	void unsetf(fmtflags _Mask)
		{	
		_Fmtfl = (fmtflags)((int)_Fmtfl & (int)~_Mask);
		}

	streamsize precision() const
		{	
		return (_Prec);
		}

	streamsize precision(streamsize _Newprecision)
		{	
		streamsize _Oldprecision = _Prec;
		_Prec = _Newprecision;
		return (_Oldprecision);
		}

	streamsize width() const
		{	
		return (_Wide);
		}

	streamsize width(streamsize _Newwidth)
		{	
		streamsize _Oldwidth = _Wide;
		_Wide = _Newwidth;
		return (_Oldwidth);
		}

	locale getloc() const
		{	
		return (*_Ploc);
		}

	locale imbue(const locale&);	

	static int __cdecl xalloc()
		{	
		_Lockit _Lock(2);	
		return (_Index++);
		}

	long& iword(int _Idx)
		{	
		return (_Findarr(_Idx)._Lo);
		}

	void *& pword(int _Idx)
		{	
		return (_Findarr(_Idx)._Vp);
		}

	void register_callback(event_callback, int);	

	ios_base& copyfmt(const ios_base&);	

	virtual ~ios_base();	

	static bool __cdecl sync_with_stdio(bool _Newsync = true)
		{	
		_Lockit _Lock(2);	
		const bool _Oldsync = _Sync;
		_Sync = _Newsync;
		return (_Oldsync);
		}

	void _Addstd();	

protected:
	ios_base()
		: _Stdstr(0)
		{	
		}

	void _Init();	

private:
			
	struct _Iosarray
		{	
	public:
		_Iosarray(int _Idx, _Iosarray *_Link)
			: _Next(_Link), _Index(_Idx), _Lo(0), _Vp(0)
			{	
			}

		_Iosarray *_Next;	
		int _Index;	
		long _Lo;	
		void *_Vp;	
		};

			
	struct _Fnarray
		{	
		_Fnarray(int _Idx, event_callback _Pnew, _Fnarray *_Link)
			: _Next(_Link), _Index(_Idx), _Pfn(_Pnew)
			{	
			}

		_Fnarray *_Next;	
		int _Index;	
		event_callback _Pfn;	
		};

	void _Callfns(event);	

	_Iosarray& _Findarr(int);	

	void _Tidy();	

	iostate _Mystate;	
	iostate _Except;	
	fmtflags _Fmtfl;	
	streamsize _Prec;	
	streamsize _Wide;	
	_Iosarray *_Arr;	
	_Fnarray *_Calls;	
	locale *_Ploc;	
	size_t _Stdstr;	

	static int _Index;	
	static bool _Sync;	
	};





}
#pragma warning(pop)
#pragma pack(pop)

#line 441 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xiosbase"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\streambuf"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
template<class _Elem, class _Traits>
	class basic_streambuf
	{	
	basic_streambuf(const basic_streambuf<_Elem, _Traits>&);	
	basic_streambuf<_Elem, _Traits>&
		operator=(const basic_streambuf<_Elem, _Traits>&);	

protected:
	basic_streambuf()
		: _Plocale(new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\streambuf", 21) locale)
		{	
		_Init();
		}

	basic_streambuf(_Uninitialized)
		{	
		}

public:
	typedef basic_streambuf<_Elem, _Traits> _Myt;
	typedef _Elem char_type;
	typedef _Traits traits_type;

	virtual ~basic_streambuf()
		{	
		std::_DebugHeapDelete(_Plocale);
		}

	typedef typename _Traits::int_type int_type;
	typedef typename _Traits::pos_type pos_type;
	typedef typename _Traits::off_type off_type;

	pos_type pubseekoff(off_type _Off, ios_base::seekdir _Way,
		ios_base::openmode _Mode = ios_base::in | ios_base::out)
		{	
		return (seekoff(_Off, _Way, _Mode));
		}

	pos_type pubseekoff(off_type _Off, ios_base::seek_dir _Way,
		ios_base::open_mode _Mode)
		{	
		return (pubseekoff(_Off, (ios_base::seekdir)_Way,
			(ios_base::openmode)_Mode));
		}

	pos_type pubseekpos(pos_type _Pos,
		ios_base::openmode _Mode = ios_base::in | ios_base::out)
		{	
		return (seekpos(_Pos, _Mode));
		}

	pos_type pubseekpos(pos_type _Pos, ios_base::open_mode _Mode)
		{	
		return (seekpos(_Pos, (ios_base::openmode)_Mode));
		}

	_Myt *pubsetbuf(_Elem *_Buffer, streamsize _Count)
		{	
		return (setbuf(_Buffer, _Count));
		}

	locale pubimbue(const locale &_Newlocale)
		{	
		locale _Oldlocale = *_Plocale;
		imbue(_Newlocale);
		*_Plocale = _Newlocale;
		return (_Oldlocale);
		}

	locale getloc() const
		{	
		return (*_Plocale);
		}

	streamsize in_avail()
		{	
		return (gptr() != 0 && gptr() < egptr()
			? (streamsize)(egptr() - gptr()) : showmanyc());
		}

	int pubsync()
		{	
		return (sync());
		}

	int_type sbumpc()
		{	
		return (gptr() != 0 && gptr() < egptr()
			? _Traits::to_int_type(*_Gninc()) : uflow());
		}

	int_type sgetc()
		{	
		return (gptr() != 0 && gptr() < egptr()
			? _Traits::to_int_type(*gptr()) : underflow());
		}

	streamsize sgetn(_Elem *_Ptr, streamsize _Count)
		{	
		return (xsgetn(_Ptr, _Count));
		}

	int_type snextc()
		{	
		return (_Traits::eq_int_type(_Traits::eof(), sbumpc())
			? _Traits::eof() : sgetc());
		}

	int_type sputbackc(_Elem _Ch)
		{	
		return (gptr() != 0 && eback() < gptr()
			&& _Traits::eq(_Ch, gptr()[-1])
			? _Traits::to_int_type(*_Gndec())
			: pbackfail(_Traits::to_int_type(_Ch)));
		}

	void stossc()
		{	
		if (gptr() != 0 && gptr() < egptr())
			_Gninc();
		else
			uflow();
		}

	int_type sungetc()
		{	
		return (gptr() != 0 && eback() < gptr()
			? _Traits::to_int_type(*_Gndec()) : pbackfail());
		}

	int_type sputc(_Elem _Ch)
		{	
		return (pptr() != 0 && pptr() < epptr()
			? _Traits::to_int_type(*_Pninc() = _Ch)
			: overflow(_Traits::to_int_type(_Ch)));
		}

	streamsize sputn(const _Elem *_Ptr, streamsize _Count)
		{	
		return (xsputn(_Ptr, _Count));
		}

	void _Lock()
		{	
		_Mylock._Lock();
		}

	void _Unlock()
		{	
		_Mylock._Unlock();
		}

protected:
	_Elem *eback() const
		{	
		return (*_IGfirst);
		}

	_Elem *gptr() const
		{	
		return (*_IGnext);
		}

	_Elem *pbase() const
		{	
		return (*_IPfirst);
		}

	_Elem *pptr() const
		{	
		return (*_IPnext);
		}

	_Elem *egptr() const
		{	
		return (*_IGnext + *_IGcount);
		}

	void gbump(int _Off)
		{	
		*_IGcount -= _Off;
		*_IGnext += _Off;
		}

	void setg(_Elem *_First, _Elem *_Next, _Elem *_Last)
		{	
		*_IGfirst = _First;
		*_IGnext = _Next;
		*_IGcount = (int)(_Last - _Next);
		}

	_Elem *epptr() const
		{	
		return (*_IPnext + *_IPcount);
		}

	_Elem *_Gndec()
		{	
		++*_IGcount;
		return (--*_IGnext);
		}

	_Elem *_Gninc()
		{	
		--*_IGcount;
		return ((*_IGnext)++);
		}

	void pbump(int _Off)
		{	
		*_IPcount -= _Off;
		*_IPnext += _Off;
		}

	void setp(_Elem *_First, _Elem *_Last)
		{	
		*_IPfirst = _First;
		*_IPnext = _First;
		*_IPcount = (int)(_Last - _First);
		}

	void setp(_Elem *_First, _Elem *_Next, _Elem *_Last)
		{	
		*_IPfirst = _First;
		*_IPnext = _Next;
		*_IPcount = (int)(_Last - _Next);
		}

	_Elem *_Pninc()
		{	
		--*_IPcount;
		return ((*_IPnext)++);
		}

	void _Init()
		{	
		_IGfirst = &_Gfirst, _IPfirst = &_Pfirst;
		_IGnext = &_Gnext, _IPnext = &_Pnext;
		_IGcount = &_Gcount, _IPcount = &_Pcount;
		setp(0, 0), setg(0, 0, 0);
		}

	void _Init(_Elem **_Gf, _Elem **_Gn, int *_Gc,
		_Elem **_Pf, _Elem **_Pn, int *_Pc)
		{	
		_IGfirst = _Gf, _IPfirst = _Pf;
		_IGnext = _Gn, _IPnext = _Pn;
		_IGcount = _Gc, _IPcount = _Pc;
		}

	virtual int_type overflow(int_type = _Traits::eof())
		{	
		return (_Traits::eof());
		}

	virtual int_type pbackfail(int_type = _Traits::eof())
		{	
		return (_Traits::eof());
		}

	virtual streamsize showmanyc()
		{	
		return (0);
		}

	virtual int_type underflow()
		{	
		return (_Traits::eof());
		}

	virtual int_type uflow()
		{	
		return (_Traits::eq_int_type(_Traits::eof(), underflow())
			? _Traits::eof() : _Traits::to_int_type(*_Gninc()));
		}

	virtual streamsize xsgetn(_Elem * _Ptr, streamsize _Count)
		{	
		int_type _Meta;
		streamsize _Size, _Copied;

		for (_Copied = 0; 0 < _Count; )
			if (gptr() != 0 && 0 < (_Size = (streamsize)(egptr() - gptr())))
				{	
				if (_Count < _Size)
					_Size = _Count;
				_Traits::copy(_Ptr, gptr(), _Size);
				_Ptr += _Size;
				_Copied += _Size;
				_Count -= _Size;
				gbump((int)_Size);
				}
			else if (_Traits::eq_int_type(_Traits::eof(), _Meta = uflow()))
				break;	
			else
				{	
				*_Ptr++ = _Traits::to_char_type(_Meta);
				++_Copied;
				--_Count;
				}

		return (_Copied);
		}

	virtual streamsize xsputn(const _Elem *_Ptr, streamsize _Count)
		{	
		streamsize _Size, _Copied;

		for (_Copied = 0; 0 < _Count; )
			if (pptr() != 0 && 0 < (_Size = (streamsize)(epptr() - pptr())))
				{	
				if (_Count < _Size)
					_Size = _Count;
				_Traits::copy(pptr(), _Ptr, _Size);
				_Ptr += _Size;
				_Copied += _Size;
				_Count -= _Size;
				pbump((int)_Size);
				}
			else if (_Traits::eq_int_type(_Traits::eof(),
				overflow(_Traits::to_int_type(*_Ptr))))
				break;	
			else
				{	
				++_Ptr;
				++_Copied;
				--_Count;
				}

		return (_Copied);
		}

	virtual pos_type seekoff(off_type, ios_base::seekdir,
		ios_base::openmode = ios_base::in | ios_base::out)
		{	
		return (streampos(_BADOFF));
		}

	virtual pos_type seekpos(pos_type,
		ios_base::openmode = ios_base::in | ios_base::out)
		{	
		return (streampos(_BADOFF));
		}

	virtual _Myt *setbuf(_Elem *, streamsize)
		{	
		return (this);
		}

	virtual int sync()
		{	
		return (0);
		}

	virtual void imbue(const locale&)
		{	
		}

private:
	_Mutex _Mylock;	
	_Elem *_Gfirst;	
	_Elem *_Pfirst;	
	_Elem **_IGfirst;	
	_Elem **_IPfirst;	
	_Elem *_Gnext;	
	_Elem *_Pnext;	
	_Elem **_IGnext;	
	_Elem **_IPnext;	
	int _Gcount;	
	int _Pcount;	
	int *_IGcount;	
	int *_IPcount;	
	locale *_Plocale;	
	};

 



}
#pragma warning(pop)
#pragma pack(pop)

#line 396 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\streambuf"





#line 10 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

#pragma pack(push,8)
#pragma warning(push,3)

namespace std {

		
template<class _Elem>
	class numpunct
		: public locale::facet
	{	
public:
	typedef basic_string<_Elem, char_traits<_Elem>, allocator<_Elem> >
		string_type;
	typedef _Elem char_type;

	static locale::id id;	

	_Elem decimal_point() const
		{	
		return (do_decimal_point());
		}

	_Elem thousands_sep() const
		{	
		return (do_thousands_sep());
		}

	string grouping() const
		{	
		return (do_grouping());
		}

	string_type falsename() const
		{	
		return (do_falsename());
		}

	string_type truename() const
		{	
		return (do_truename());
		}

	explicit numpunct(size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Locinfo());
		}

	numpunct(const _Locinfo& _Lobj, size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Lobj);
		}

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum", 68) numpunct<_Elem>;
		return (4);
		}

protected:
	virtual ~numpunct()
		{	
		_Tidy();
		}

protected:
	void _Init(const _Locinfo& _Lobj)
		{	
		const lconv *_Ptr = _Lobj._Getlconv();

		_Grouping = 0;
		_Falsename = 0;
		_Truename = 0;

		try {
		_Grouping = _Maklocstr(_Ptr->grouping, (char *)0, _Lobj._Getcvt());
		_Falsename = _Maklocstr(_Lobj._Getfalse(), (_Elem *)0, _Lobj._Getcvt());
		_Truename = _Maklocstr(_Lobj._Gettrue(), (_Elem *)0, _Lobj._Getcvt());
		} catch (...) {
		_Tidy();
		throw;
		}

		_Dp = _Widen(_Ptr->decimal_point[0], (_Elem *)0);
		_Kseparator = _Widen(_Ptr->thousands_sep[0], (_Elem *)0);
		}

	virtual _Elem do_decimal_point() const
		{	
		return (_Dp);
		}

	virtual _Elem do_thousands_sep() const
		{	
		return (_Kseparator);
		}

	virtual string do_grouping() const
		{	
		return (string(_Grouping));
		}

	virtual string_type do_falsename() const
		{	
		return (string_type(_Falsename));
		}

	virtual string_type do_truename() const
		{	
		return (string_type(_Truename));
		}

private:
	void _Tidy()
		{	
		std::_DebugHeapDelete((void *)(void *)_Grouping);
		std::_DebugHeapDelete((void *)(void *)_Falsename);
		std::_DebugHeapDelete((void *)(void *)_Truename);
		}

	const char *_Grouping;	
	_Elem _Dp;	
	_Elem _Kseparator;	
	const _Elem *_Falsename;	
	const _Elem *_Truename;	
	};

typedef numpunct<char> _Npc;
typedef numpunct<wchar_t> _Npwc;

		
template<class _Elem>
	class numpunct_byname
		: public numpunct<_Elem>
	{	
public:
	explicit numpunct_byname(const char *_Locname, size_t _Refs = 0)
		: numpunct<_Elem>(_Locinfo(_Locname), _Refs)
		{	
		}

protected:
	virtual ~numpunct_byname()
		{	
		}
	};

		
template<class _Elem>
	locale::id numpunct<_Elem>::id;

 

		
template<class _Elem,
	class _InIt = istreambuf_iterator<_Elem, char_traits<_Elem> > >
	class num_get
		: public locale::facet
	{	
public:
	typedef numpunct<_Elem> _Mypunct;
	typedef basic_string<_Elem, char_traits<_Elem>, allocator<_Elem> >
		_Mystr;

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum", 180) num_get<_Elem, _InIt>;
		return (4);
		}

	static locale::id id;	

protected:
	virtual ~num_get()
		{	
		}

protected:
	void _Init(const _Locinfo&)
		{	
		}

public:
	explicit num_get(size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Locinfo());
		}

	num_get(const _Locinfo& _Lobj, size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Lobj);
		}

	typedef _Elem char_type;
	typedef _InIt iter_type;

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, _Bool& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned short& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned int& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, long& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned long& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}
 

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, __int64& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned __int64& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}
 #line 255 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, float& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, double& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, long double& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

	_InIt get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, void *& _Val) const
		{	
		return (do_get(_First, _Last, _Iosbase, _State, _Val));
		}

protected:
	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, _Bool& _Val) const
		{	
		int _Ans = -1;	

		if (_Iosbase.flags() & ios_base::boolalpha)
			{	
			const _Mypunct& _Fac = use_facet<_Mypunct >(_Iosbase.getloc());
			_Mystr _Str((typename _Mystr::size_type)1, (char_type)0);
			_Str += _Fac.falsename();
			_Str += (char_type)0;
			_Str += _Fac.truename();	
			_Ans = _Getloctxt(_First, _Last, (size_t)2, _Str.c_str());
			}
		else
			{	
			char _Ac[32], *_Ep;
			(*_errno()) = 0;
			const unsigned long _Ulo = ::strtoul(_Ac, &_Ep,
				_Getifld(_Ac, _First, _Last, _Iosbase.flags(),
					_Iosbase.getloc()));
			if (_Ep != _Ac && (*_errno()) == 0 && _Ulo <= 1)
				_Ans = _Ulo;
			}

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ans < 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans != 0;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned short& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		int _Base = _Getifld(_Ac, _First, _Last, _Iosbase.flags(),
			_Iosbase.getloc());	
		char *_Ptr = _Ac[0] == '-' ? _Ac + 1 : _Ac;	
		const unsigned long _Ans =
			::strtoul(_Ptr, &_Ep, _Base);	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ptr || (*_errno()) != 0 || 0xffff < _Ans)
			_State |= ios_base::failbit;
		else
			_Val = (unsigned short)(_Ac[0] == '-'
				? 0 -_Ans : _Ans);	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned int& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		int _Base = _Getifld(_Ac, _First, _Last, _Iosbase.flags(),
			_Iosbase.getloc());	
		char *_Ptr = _Ac[0] == '-' ? _Ac + 1 : _Ac;	
		const unsigned long _Ans =
			::strtoul(_Ptr, &_Ep, _Base);	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ptr || (*_errno()) != 0 || 0xffffffff < _Ans)
			_State |= ios_base::failbit;
		else
			_Val = _Ac[0] == '-' ? 0 -_Ans : _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, long& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		const long _Ans = ::strtol(_Ac, &_Ep,
			_Getifld(_Ac, _First, _Last, _Iosbase.flags(),
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned long& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		const unsigned long _Ans = ::strtoul(_Ac, &_Ep,
			_Getifld(_Ac, _First, _Last, _Iosbase.flags(),
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}
 

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, __int64& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		const __int64 _Ans = ::_strtoi64(_Ac, &_Ep,
			_Getifld(_Ac, _First, _Last, _Iosbase.flags(),
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, unsigned __int64& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;
		const unsigned __int64 _Ans = ::_strtoui64(_Ac, &_Ep,
			_Getifld(_Ac, _First, _Last, _Iosbase.flags(),
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}
 #line 429 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, float& _Val) const
		{	
		char _Ac[8 + 36 + 16], *_Ep;
		(*_errno()) = 0;
		const float _Ans = ::_Stof(_Ac, &_Ep,
			_Getffld(_Ac, _First, _Last,
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, double& _Val) const
		{	
		char _Ac[8 + 36 + 16], *_Ep;
		(*_errno()) = 0;
		const double _Ans = ::_Stod(_Ac, &_Ep,
			_Getffld(_Ac, _First, _Last,
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, long double& _Val) const
		{	
		char _Ac[8 + 36 + 16], *_Ep;
		(*_errno()) = 0;
		const long double _Ans = ::_Stold(_Ac, &_Ep,
			_Getffld(_Ac, _First, _Last,
				_Iosbase.getloc()));	

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = _Ans;	
		return (_First);
		}

	virtual _InIt do_get(_InIt _First, _InIt _Last, ios_base& _Iosbase,
		ios_base::iostate& _State, void *& _Val) const
		{	
		char _Ac[32], *_Ep;
		(*_errno()) = 0;

 
		int _Base = _Getifld(_Ac, _First, _Last, ios_base::hex,
			_Iosbase.getloc());	
		const unsigned __int64 _Ans =
			(sizeof (void *) == sizeof (unsigned long))
				? (unsigned __int64)::strtoul(_Ac, &_Ep, _Base)
				: ::_strtoui64(_Ac, &_Ep, _Base);

 



#line 503 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

		if (_First == _Last)
			_State |= ios_base::eofbit;
		if (_Ep == _Ac || (*_errno()) != 0)
			_State |= ios_base::failbit;
		else
			_Val = (void *)((char *)0 + _Ans);	
		return (_First);
		}

private:
	static int __cdecl _Getifld(char *_Ac, _InIt& _First, _InIt& _Last,
		ios_base::fmtflags _Basefield, const locale& _Loc)
		{	
		const _Elem _E0 = _Widen('0', (_Elem *)0);
		const _Mypunct& _Fac = use_facet<_Mypunct >(_Loc);
		const string _Grouping = _Fac.grouping();
		const _Elem _Kseparator = _Fac.thousands_sep();
		char *_Ptr = _Ac;

		if (_First == _Last)
			;	
		else if (*_First == _Widen('+', (_Elem *)0))
			*_Ptr++ = '+', ++_First;	
		else if (*_First == _Widen('-', (_Elem *)0))
			*_Ptr++ = '-', ++_First;	

		_Basefield &= ios_base::basefield;
		int _Base = _Basefield == ios_base::oct ? 8
			: _Basefield == ios_base::hex ? 16
			: _Basefield == ios_base::_Fmtzero ? 0 : 10;

		bool _Seendigit = false;	
		bool _Nonzero = false;	

		if (_First != _Last && *_First == _E0)
			{	
			_Seendigit = true, ++_First;
			if (_First != _Last && (*_First == _Widen('x', (_Elem *)0)
					|| *_First == _Widen('X', (_Elem *)0))
				&& (_Base == 0 || _Base == 16))
				_Base = 16, _Seendigit = false, ++_First;
			else if (_Base == 0)
				_Base = 8;
			}

		int _Dlen = _Base == 0 || _Base == 10 ? 10
			: _Base == 8 ? 8 : 16 + 6;
		string _Groups((size_t)1, (char)_Seendigit);
		size_t _Group = 0;

		for (char *const _Pe = &_Ac[32 - 1];
			_First != _Last; ++_First)
			if (::memchr("0123456789abcdefABCDEF",
				*_Ptr = _Narrow(static_cast<_Elem>(*_First)), _Dlen) != 0)
				{	
				if ((_Nonzero || *_Ptr != '0') && _Ptr < _Pe)
					++_Ptr, _Nonzero = true;
				_Seendigit = true;
				if (_Groups[_Group] != 127)
					++_Groups[_Group];
				}
			else if (_Groups[_Group] == '\0'
				|| _Kseparator == (_Elem)0
				|| *_First != _Kseparator)
				break;	
			else
				{	
				_Groups.append((string::size_type)1, '\0');
				++_Group;
				}

		if (_Group == 0)
			;	
		else if ('\0' < _Groups[_Group])
			++_Group;	
		else
			_Seendigit = false;	

		for (const char *_Pg = _Grouping.c_str(); _Seendigit && 0 < _Group; )
			if (*_Pg == 127)
				break;	
			else if (0 < --_Group && *_Pg != _Groups[_Group]
				|| 0 == _Group && *_Pg < _Groups[_Group])
				_Seendigit = false;	
			else if ('\0' < _Pg[1])
				++_Pg;	

		if (_Seendigit && !_Nonzero)
			*_Ptr++ = '0';	
		else if (!_Seendigit)
			_Ptr = _Ac;	
		*_Ptr = '\0';
		return (_Base);
		}

	static int __cdecl _Getffld(char *_Ac, _InIt& _First, _InIt &_Last,
		const locale& _Loc)
		{	
		const _Elem _E0 = _Widen('0', (_Elem *)0);
		const _Mypunct& _Fac = use_facet<_Mypunct >(_Loc);
		char *_Ptr = _Ac;

		if (_First == _Last)
			;	
		else if (*_First == _Widen('+', (_Elem *)0))
			*_Ptr++ = '+', ++_First;	
		else if (*_First == _Widen('-', (_Elem *)0))
			*_Ptr++ = '-', ++_First;	

		bool _Seendigit = false;	
		for (; _First != _Last && *_First == _E0; _Seendigit = true, ++_First)
			;	
		if (_Seendigit)
			*_Ptr++ = '0';	

		int _Significant = 0;	
		int _Pten = 0;	

		for (; _First != _Last
			&& (::isdigit)(*_Ptr = _Narrow(static_cast<_Elem>(*_First)));
				_Seendigit = true, ++_First)
			if (_Significant < 36)
				++_Ptr, ++_Significant;	
			else
				++_Pten;	

		if (_First != _Last && *_First == _Fac.decimal_point())
			*_Ptr++ = localeconv()->decimal_point[0], ++_First;	

		if (_Significant == 0)
			{	
			for (; _First != _Last && *_First == _E0;
				_Seendigit = true, ++_First)
				--_Pten;	
			if (_Pten < 0)
				*_Ptr++ = '0', ++_Pten;	
			}

		for (; _First != _Last
			&& (::isdigit)(*_Ptr = _Narrow(static_cast<_Elem>(*_First)));
				_Seendigit = true, ++_First)
			if (_Significant < 36)
				++_Ptr, ++_Significant;	

		if (_Seendigit && _First != _Last
			&& (*_First == _Widen('e', (_Elem *)0)
				|| *_First == _Widen('E', (_Elem *)0)))
			{	
			*_Ptr++ = 'e', ++_First;
			_Seendigit = false, _Significant = 0;

			if (_First == _Last)
				;	
			else if (*_First == _Widen('+', (_Elem *)0))
				*_Ptr++ = '+', ++_First;	
			else if (*_First == _Widen('-', (_Elem *)0))
				*_Ptr++ = '-', ++_First;	
			for (; _First != _Last && *_First == _E0; )
				_Seendigit = true, ++_First;	
			if (_Seendigit)
				*_Ptr++ = '0';	
			for (; _First != _Last
				&& (::isdigit)(*_Ptr = _Narrow(static_cast<_Elem>(*_First)));
				_Seendigit = true, ++_First)
				if (_Significant < 8)
					++_Ptr, ++_Significant;	
			}

		if (!_Seendigit)
			_Ptr = _Ac;	
		*_Ptr = '\0';
		return (_Pten);
		};
	};

		
template<class _Elem,
	class _InIt>
	locale::id num_get<_Elem, _InIt>::id;

		
template<class _Elem,
	class _OutIt = ostreambuf_iterator<_Elem, char_traits<_Elem> > >
	class num_put
		: public locale::facet
	{	
public:
	typedef numpunct<_Elem> _Mypunct;
	typedef basic_string<_Elem, char_traits<_Elem>, allocator<_Elem> >
		_Mystr;

	static size_t __cdecl _Getcat(const locale::facet **_Ppf = 0)
		{	
		if (_Ppf != 0 && *_Ppf == 0)
			*_Ppf = new(std::_DebugHeapTag, "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum", 698) num_put<_Elem, _OutIt>;
		return (4);
		}

	static locale::id id;	

protected:
	virtual ~num_put()
		{	
		}

protected:
	void _Init(const _Locinfo&)
		{	
		}

public:
	explicit num_put(size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Locinfo());
		}

	num_put(const _Locinfo& _Lobj, size_t _Refs = 0)
		: locale::facet(_Refs)
		{	
		_Init(_Lobj);
		}

	typedef _Elem char_type;
	typedef _OutIt iter_type;

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		_Bool _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		long _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		unsigned long _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}
 

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		__int64 _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		unsigned __int64 _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}
 #line 761 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		double _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		long double _Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

	_OutIt put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		const void *_Val) const
		{	
		return (do_put(_Dest, _Iosbase, _Fill, _Val));
		}

protected:
	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		_Bool _Val) const
		{	
		if (!(_Iosbase.flags() & ios_base::boolalpha))
			return (do_put(_Dest, _Iosbase, _Fill, (long)_Val));
		else
			{	
			const _Mypunct& _Fac = use_facet<_Mypunct >(_Iosbase.getloc());
			const _Mystr _Str(_Val ? _Fac.truename() : _Fac.falsename());

			size_t _Fillcount = _Iosbase.width() <= 0
				|| (size_t)_Iosbase.width() <= _Str.size()
					? 0 : (size_t)_Iosbase.width() - _Str.size();

			if ((_Iosbase.flags() & ios_base::adjustfield) != ios_base::left)
				{	
				_Dest = _Rep(_Dest, _Fill, _Fillcount);
				_Fillcount = 0;
				}
			_Dest = _Put(_Dest, _Str.c_str(), _Str.size());	
			_Iosbase.width(0);
			return (_Rep(_Dest, _Fill, _Fillcount));	
			}
		}

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		long _Val) const
		{	
		char _Buf[2 * 32], _Fmt[6];
		return (_Iput(_Dest, _Iosbase, _Fill, _Buf,
			::sprintf(_Buf, _Ifmt(_Fmt, "ld",
				_Iosbase.flags()), _Val)));
		}

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		unsigned long _Val) const
		{	
		char _Buf[2 * 32], _Fmt[6];
		return (_Iput(_Dest, _Iosbase, _Fill, _Buf,
			::sprintf(_Buf, _Ifmt(_Fmt, "lu",
				_Iosbase.flags()), _Val)));
		}
 

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		__int64 _Val) const
		{	
		char _Buf[2 * 32], _Fmt[8];
		return (_Iput(_Dest, _Iosbase, _Fill, _Buf,
			::sprintf(_Buf, _Ifmt(_Fmt, "Ld",
				_Iosbase.flags()), _Val)));
		}

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		unsigned __int64 _Val) const
		{	
		char _Buf[2 * 32], _Fmt[8];
		return (_Iput(_Dest, _Iosbase, _Fill, _Buf,
			::sprintf(_Buf, _Ifmt(_Fmt, "Lu",
				_Iosbase.flags()), _Val)));
		}
 #line 843 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		double _Val) const
		{	
		char _Buf[8 + 36 + 64], _Fmt[8];
		streamsize _Precision = _Iosbase.precision() <= 0
			&& !(_Iosbase.flags() & ios_base::fixed)
				? 6 : _Iosbase.precision();	
		int _Significance = 36 < _Precision
			? 36 : (int)_Precision;	
		_Precision -= _Significance;
		size_t _Beforepoint = 0;	
		size_t _Afterpoint = 0;	

		if ((_Iosbase.flags() & ios_base::floatfield) == ios_base::fixed)
			{	
			bool _Signed = _Val < 0;
			if (_Signed)
				_Val = -_Val;

			for (; 1e35 <= _Val && _Beforepoint < 5000; _Beforepoint += 10)
				_Val /= 1e10;	

			if (0 < _Val)
				for (; 10 <= _Precision && _Val <= 1e-35
					&& _Afterpoint < 5000; _Afterpoint += 10)
					{	
					_Val *= 1e10;
					_Precision -= 10;
					}

			if (_Signed)
				_Val = -_Val;
			}

		return (_Fput(_Dest, _Iosbase, _Fill, _Buf,
			_Beforepoint, _Afterpoint, _Precision,
				::sprintf(_Buf, _Ffmt(_Fmt, 0, _Iosbase.flags()),
					_Significance, _Val)));	
		}

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		long double _Val) const
		{	
		char _Buf[8 + 36 + 64], _Fmt[8];
		streamsize _Precision = _Iosbase.precision() <= 0
			&& !(_Iosbase.flags() & ios_base::fixed)
				? 6 : _Iosbase.precision();	
		int _Significance = 36 < _Precision
			? 36 : (int)_Precision;	
		_Precision -= _Significance;
		size_t _Beforepoint = 0;	
		size_t _Afterpoint = 0;	

		if ((_Iosbase.flags() & ios_base::floatfield) == ios_base::fixed)
			{	
			bool _Signed = _Val < 0;
			if (_Signed)
				_Val = -_Val;

			for (; 1e35 <= _Val && _Beforepoint < 5000; _Beforepoint += 10)
				_Val /= 1e10;	

			if (0 < _Val)
				for (; 10 <= _Precision && _Val <= 1e-35
					&& _Afterpoint < 5000; _Afterpoint += 10)
					{	
					_Val *= 1e10;
					_Precision -= 10;
					}

			if (_Signed)
				_Val = -_Val;
			}

		return (_Fput(_Dest, _Iosbase, _Fill, _Buf,
			_Beforepoint, _Afterpoint, _Precision,
				::sprintf(_Buf, _Ffmt(_Fmt, 'L', _Iosbase.flags()),
					_Significance, _Val)));	
		}

	virtual _OutIt do_put(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		const void *_Val) const
		{	
		char _Buf[2 * 32];
		return (_Iput(_Dest, _Iosbase, _Fill, _Buf,
			::sprintf(_Buf, "%p", _Val)));
		}

	static char *__cdecl _Ffmt(char *_Fmt, char _Spec,
		ios_base::fmtflags _Flags)
		{	
		char *_Ptr = _Fmt;
		*_Ptr++ = '%';

		if (_Flags & ios_base::showpos)
			*_Ptr++ = '+';
		if (_Flags & ios_base::showpoint)
			*_Ptr++ = '#';
		*_Ptr++ = '.';
		*_Ptr++ = '*';	
		if (_Spec != '\0')
			*_Ptr++ = _Spec;	

		ios_base::fmtflags _Ffl = _Flags & ios_base::floatfield;
		*_Ptr++ = _Ffl == ios_base::fixed ? 'f'
			: _Ffl == ios_base::scientific ? 'e' : 'g';	
		*_Ptr = '\0';
		return (_Fmt);
		}

	static _OutIt __cdecl _Fput(_OutIt _Dest, ios_base& _Iosbase,
		_Elem _Fill, const char *_Buf,
			size_t _Beforepoint, size_t _Afterpoint,
				size_t _Trailing, size_t _Count)
		{	
		_Elem _E0 = _Widen('0', (_Elem *)0);
		size_t _Fillcount = _Beforepoint + _Afterpoint + _Trailing + _Count;
		_Fillcount = _Iosbase.width() <= 0
			|| (size_t)_Iosbase.width() <= _Fillcount
				? 0 : (size_t)_Iosbase.width() - _Fillcount;

		ios_base::fmtflags _Adjustfield =
			_Iosbase.flags() & ios_base::adjustfield;
		if (_Adjustfield != ios_base::left
			&& _Adjustfield != ios_base::internal)
			{	
			_Dest = _Rep(_Dest, _Fill, _Fillcount);
			_Fillcount = 0;
			}
		else if (_Adjustfield == ios_base::internal)
			{	
			if (0 < _Count && (*_Buf == '+' || *_Buf == '-'))
				{	
				_Dest = _Putc(_Dest, _Buf, 1);
				++_Buf, --_Count;
				}
			_Dest = _Rep(_Dest, _Fill, _Fillcount);
			_Fillcount = 0;
			}

		const char *_Ptr = (const char *)::memchr(_Buf,
			localeconv()->decimal_point[0], _Count);	
		if (_Ptr != 0)
			{	
			const _Mypunct& _Fac = use_facet<_Mypunct >(_Iosbase.getloc());
			size_t _Fracoffset = _Ptr - _Buf + 1;
			_Dest = _Putc(_Dest, _Buf, _Fracoffset - 1);
			_Dest = _Rep(_Dest, _E0, _Beforepoint);
			_Dest = _Rep(_Dest, _Fac.decimal_point(), 1);
			_Dest = _Rep(_Dest, _E0, _Afterpoint);
			_Buf += _Fracoffset, _Count -= _Fracoffset;
			}

		if ((_Ptr = (const char *)::memchr(_Buf, 'e', _Count)) != 0)
			{	
			size_t _Expoffset = _Ptr - _Buf + 1;
			_Dest = _Putc(_Dest, _Buf, _Expoffset - 1);
			_Dest = _Rep(_Dest, _E0, _Trailing), _Trailing = 0;
			_Dest = _Putc(_Dest, _Iosbase.flags() & ios_base::uppercase
				? "E" : "e", 1);
			_Buf += _Expoffset, _Count -= _Expoffset;
			}

		_Dest = _Putc(_Dest, _Buf, _Count);	
		_Dest = _Rep(_Dest, _E0, _Trailing);	
		_Iosbase.width(0);
		return (_Rep(_Dest, _Fill, _Fillcount));	
		}

	static char *__cdecl _Ifmt(char *_Fmt, const char *_Spec,
		ios_base::fmtflags _Flags)
		{	
		char *_Ptr = _Fmt;
		*_Ptr++ = '%';

		if (_Flags & ios_base::showpos)
			*_Ptr++ = '+';
		if (_Flags & ios_base::showbase)
			*_Ptr++ = '#';
		if (_Spec[0] != 'L')
			*_Ptr++ = _Spec[0];	
		else
			{	
			*_Ptr++ = 'I';
			*_Ptr++ = '6';
			*_Ptr++ = '4';
			}

		ios_base::fmtflags _Basefield = _Flags & ios_base::basefield;
		*_Ptr++ = _Basefield == ios_base::oct ? 'o'
			: _Basefield != ios_base::hex ? _Spec[1]	
			: _Flags & ios_base::uppercase ? 'X' : 'x';
		*_Ptr = '\0';
		return (_Fmt);
		}

	static _OutIt __cdecl _Iput(_OutIt _Dest, ios_base& _Iosbase, _Elem _Fill,
		char *_Buf, size_t _Count)
		{	
		const size_t _Prefix = *_Buf == '+' || *_Buf == '-' ? 1
			: *_Buf == '0' && (_Buf[1] == 'x' || _Buf[1] == 'X') ? 2
			: 0;
		const _Mypunct& _Fac = use_facet<_Mypunct >(_Iosbase.getloc());
		const string _Grouping = _Fac.grouping();
		const _Elem _Kseparator = _Fac.thousands_sep();
		bool _Grouped = '\0' < *_Grouping.c_str();

		if (_Grouped)
			{	
			const char *_Pg = _Grouping.c_str();
			size_t _Off = _Count;
			for (_Grouped = false; *_Pg != 127 && '\0' < *_Pg
				&& (size_t)*_Pg < _Off - _Prefix; _Grouped = true)
				{	
				_Off -= *_Pg;
				::memmove(&_Buf[_Off + 1], &_Buf[_Off],
					_Count + 1 - _Off);
				_Buf[_Off] = ',', ++_Count;
				if ('\0' < _Pg[1])
					++_Pg;	
				}
			}

		size_t _Fillcount = _Iosbase.width() <= 0
			|| (size_t)_Iosbase.width() <= _Count
				? 0 : (size_t)_Iosbase.width() - _Count;

		ios_base::fmtflags _Adjustfield =
			_Iosbase.flags() & ios_base::adjustfield;
		if (_Adjustfield != ios_base::left
			&& _Adjustfield != ios_base::internal)
			{	
			_Dest = _Rep(_Dest, _Fill, _Fillcount);
			_Fillcount = 0;
			}
		else if (_Adjustfield == ios_base::internal)
			{	
			_Dest = _Putc(_Dest, _Buf, _Prefix);	
			_Buf += _Prefix, _Count -= _Prefix;
			_Dest = _Rep(_Dest, _Fill, _Fillcount), _Fillcount = 0;
			}

		if (!_Grouped)
			_Dest = _Putc(_Dest, _Buf, _Count);	
		else
			for (; ; ++_Buf, --_Count)
				{	
				size_t _Groupsize = strcspn(_Buf, ",");
				_Dest = _Putc(_Dest, _Buf, _Groupsize);
				_Buf += _Groupsize, _Count -= _Groupsize;
				if (_Count == 0)
					break;
				if (_Kseparator != (_Elem)0)
					_Dest = _Rep(_Dest, _Kseparator, 1);
				}

		_Iosbase.width(0);
		return (_Rep(_Dest, _Fill, _Fillcount));	
		}

	static _OutIt __cdecl _Put(_OutIt _Dest, const _Elem *_Ptr, size_t _Count)
		{	
		for (; 0 < _Count; --_Count, ++_Dest, ++_Ptr)
			*_Dest = *_Ptr;
		return (_Dest);
		}

	static _OutIt __cdecl _Putc(_OutIt _Dest, const char *_Ptr, size_t _Count)
		{	
		for (; 0 < _Count; --_Count, ++_Dest, ++_Ptr)
			*_Dest = _Widen(*_Ptr, (_Elem *)0);
		return (_Dest);
		}

	static _OutIt __cdecl _Rep(_OutIt _Dest, _Elem _Ch, size_t _Count)
		{	
		for (; 0 < _Count; --_Count, ++_Dest)
			*_Dest = _Ch;
		return (_Dest);
		}
	};

		
template<class _Elem,
	class _OutIt>
	locale::id num_put<_Elem, _OutIt>::id;

 











}
#pragma warning(pop)
#pragma pack(pop)

#line 1148 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\xlocnum"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ios"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
template<class _Elem,
	class _Traits>
	class basic_ios
		: public ios_base
	{	
public:
	typedef basic_ios<_Elem, _Traits> _Myt;
	typedef basic_ostream<_Elem, _Traits> _Myos;
	typedef basic_streambuf<_Elem, _Traits> _Mysb;
	typedef ctype<_Elem> _Ctype;
	typedef _Elem char_type;
	typedef _Traits traits_type;
	typedef typename _Traits::int_type int_type;
	typedef typename _Traits::pos_type pos_type;
	typedef typename _Traits::off_type off_type;

	explicit basic_ios(_Mysb *_Strbuf)
		{	
		init(_Strbuf);
		}

	virtual ~basic_ios()
		{	
		}

	void clear(iostate _State = goodbit, bool _Except = false)
		{	
		ios_base::clear((iostate)(_Mystrbuf == 0
			? (int)_State | (int)badbit : (int)_State), _Except);
		}

	void clear(io_state _State)
		{	
		clear((iostate)_State);
		}

	void setstate(iostate _State, bool _Except = false)
		{	
		if (_State != goodbit)
			clear((iostate)((int)rdstate() | (int)_State), _Except);
		}

	void setstate(io_state _State)
		{	
		setstate((iostate)_State);
		}

	_Myt& copyfmt(const _Myt& _Right)
		{	
		_Tiestr = _Right.tie();
		_Fillch = _Right.fill();
		ios_base::copyfmt(_Right);
		return (*this);
		}

	_Myos *tie() const
		{	
		return (_Tiestr);
		}

	_Myos *tie(_Myos *_Newtie)
		{	
		_Myos *_Oldtie = _Tiestr;
		_Tiestr = _Newtie;
		return (_Oldtie);
		}

	_Mysb *rdbuf() const
		{	
		return (_Mystrbuf);
		}

	_Mysb *rdbuf(_Mysb *_Strbuf)
		{	
		_Mysb *_Oldstrbuf = _Mystrbuf;
		_Mystrbuf = _Strbuf;
		clear();
		return (_Oldstrbuf);
		}

	locale imbue(const locale& _Loc)
		{	
		locale _Oldlocale = ios_base::imbue(_Loc);
		if (rdbuf() != 0)
			rdbuf()->pubimbue(_Loc);
		return (_Oldlocale);
		}

	_Elem fill() const
		{	
		return (_Fillch);
		}

	_Elem fill(_Elem _Newfill)
		{	
		_Elem _Oldfill = _Fillch;
		_Fillch = _Newfill;
		return (_Oldfill);
		}

	char narrow(_Elem _Ch, char _Dflt = '\0') const
		{	
		const _Ctype& _Facet = use_facet<_Ctype >(getloc());
		return (_Facet.narrow(_Ch, _Dflt));
		}

	_Elem widen(char _Byte) const
		{	
		const _Ctype& _Facet = use_facet<_Ctype >(getloc());
		return (_Facet.widen(_Byte));
		}

protected:
	void init(_Mysb *_Strbuf = 0, bool _Isstd = false)
		{	
		_Mystrbuf = _Strbuf;
		_Tiestr = 0;
		_Fillch = _Widen(' ', (_Elem *)0);
		_Init();	

		if (_Mystrbuf == 0)
			setstate(badbit);
		if (_Isstd)
			_Addstd();	
		}

	basic_ios()
		{	
		}

private:
	basic_ios(const _Myt&);	
	_Myt& operator=(const _Myt&);	

	_Mysb *_Mystrbuf;	
	_Myos *_Tiestr;	
	_Elem _Fillch;	
	};

 






		
inline ios_base& __cdecl boolalpha(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::boolalpha);
	return (_Iosbase);
	}

inline ios_base& __cdecl dec(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::dec, ios_base::basefield);
	return (_Iosbase);
	}

inline ios_base& __cdecl fixed(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::fixed, ios_base::floatfield);
	return (_Iosbase);
	}

inline ios_base& __cdecl hex(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::hex, ios_base::basefield);
	return (_Iosbase);
	}

inline ios_base& __cdecl internal(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::internal, ios_base::adjustfield);
	return (_Iosbase);
	}

inline ios_base& __cdecl left(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::left, ios_base::adjustfield);
	return (_Iosbase);
	}

inline ios_base& __cdecl noboolalpha(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::boolalpha);
	return (_Iosbase);
	}

inline ios_base& __cdecl noshowbase(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::showbase);
	return (_Iosbase);
	}

inline ios_base& __cdecl noshowpoint(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::showpoint);
	return (_Iosbase);
	}

inline ios_base& __cdecl noshowpos(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::showpos);
	return (_Iosbase);
	}

inline ios_base& __cdecl noskipws(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::skipws);
	return (_Iosbase);
	}

inline ios_base& __cdecl nounitbuf(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::unitbuf);
	return (_Iosbase);
	}

inline ios_base& __cdecl nouppercase(ios_base& _Iosbase)
	{	
	_Iosbase.unsetf(ios_base::uppercase);
	return (_Iosbase);
	}

inline ios_base& __cdecl oct(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::oct, ios_base::basefield);
	return (_Iosbase);
	}

inline ios_base& __cdecl right(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::right, ios_base::adjustfield);
	return (_Iosbase);
	}

inline ios_base& __cdecl scientific(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::scientific, ios_base::floatfield);
	return (_Iosbase);
	}

inline ios_base& __cdecl showbase(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::showbase);
	return (_Iosbase);
	}

inline ios_base& __cdecl showpoint(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::showpoint);
	return (_Iosbase);
	}

inline ios_base& __cdecl showpos(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::showpos);
	return (_Iosbase);
	}

inline ios_base& __cdecl skipws(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::skipws);
	return (_Iosbase);
	}

inline ios_base& __cdecl unitbuf(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::unitbuf);
	return (_Iosbase);
	}

inline ios_base& __cdecl uppercase(ios_base& _Iosbase)
	{	
	_Iosbase.setf(ios_base::uppercase);
	return (_Iosbase);
	}
}
#pragma warning(pop)
#pragma pack(pop)

#line 295 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ios"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
 
 

 



 


 





#line 29 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"

		
template<class _Elem, class _Traits>
	class basic_ostream
		: virtual public basic_ios<_Elem, _Traits>
	{	
public:
	typedef basic_ostream<_Elem, _Traits> _Myt;
	typedef basic_ios<_Elem, _Traits> _Myios;
	typedef basic_streambuf<_Elem, _Traits> _Mysb;
	typedef ostreambuf_iterator<_Elem, _Traits> _Iter;
	typedef num_put<_Elem, _Iter> _Nput;

	explicit basic_ostream(basic_streambuf<_Elem, _Traits> *_Strbuf,
		bool _Isstd = false)
		{	
		_Myios::init(_Strbuf, _Isstd);
		}

	basic_ostream(_Uninitialized)
		{	
		ios_base::_Addstd();
		}

	virtual ~basic_ostream()
		{	
		}

	typedef typename _Traits::int_type int_type;
	typedef typename _Traits::pos_type pos_type;
	typedef typename _Traits::off_type off_type;

	class _Sentry_base
		{	
	public:
		_Sentry_base(_Myt& _Ostr)
			: _Myostr(_Ostr)
			{	
			if (_Myostr.rdbuf() != 0)
				_Myostr.rdbuf()->_Lock();
			}

		~_Sentry_base()
			{	
			if (_Myostr.rdbuf() != 0)
				_Myostr.rdbuf()->_Unlock();
			}

		_Myt& _Myostr;	
		};

	class sentry
		: public _Sentry_base
		{	
	public:
		explicit sentry(_Myt& _Ostr)
			: _Sentry_base(_Ostr)
			{	
			if (_Ostr.good() && _Ostr.tie() != 0)
				_Ostr.tie()->flush();
			_Ok = _Ostr.good();	
			}

		~sentry()
			{	
 
			if (!uncaught_exception())
				_Myostr._Osfx();
			}
 


#line 102 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"

		operator bool() const
			{	
			return (_Ok);
			}

	private:
		sentry(const sentry&);	
		sentry& operator=(const sentry&);	

		bool _Ok;	
		};

	bool opfx()
		{	
		if (ios_base::good() && _Myios::tie() != 0)
			_Myios::tie()->flush();
		return (ios_base::good());
		}

	void osfx()
		{	
		_Osfx();
		}

	void _Osfx()
		{	
		if (ios_base::flags() & ios_base::unitbuf)
			flush();	
		}

	_Myt& operator<<(_Myt& (__cdecl *_Pfn)(_Myt&))
		{	
		return ((*_Pfn)(*this));
		}

	_Myt& operator<<(_Myios& (__cdecl *_Pfn)(_Myios&))
		{	
		(*_Pfn)(*(_Myios *)this);
		return (*this);
		}

	_Myt& operator<<(ios_base& (__cdecl *_Pfn)(ios_base&))
		{	
		(*_Pfn)(*(ios_base *)this);
		return (*this);
		}

	_Myt& operator<<(_Bool _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(short _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());
			ios_base::fmtflags _Bfl =
				ios_base::flags() & ios_base::basefield;
			long _Tmp = (_Bfl == ios_base::oct
				|| _Bfl == ios_base::hex)
				? (long)(unsigned short)_Val : (long)_Val;

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Tmp).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(unsigned short _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), (unsigned long)_Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(int _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());
			ios_base::fmtflags _Bfl =
				ios_base::flags() & ios_base::basefield;
			long _Tmp = (_Bfl == ios_base::oct
				|| _Bfl == ios_base::hex)
				? (long)(unsigned int)_Val : (long)_Val;

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Tmp).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(unsigned int _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), (unsigned long)_Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(long _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(unsigned long _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}
 

	_Myt& operator<<(__int64 _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(unsigned __int64 _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}
 #line 341 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"

	_Myt& operator<<(float _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), (double)_Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(double _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(long double _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(const void *_Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nput& _Fac = use_facet<_Nput >(ios_base::getloc());

			try {
			if (_Fac.put(_Iter(_Myios::rdbuf()), *this,
				_Myios::fill(), _Val).failed())
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator<<(_Mysb *_Strbuf)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		bool _Copied = false;
		const sentry _Ok(*this);

		if (_Ok && _Strbuf != 0)
			for (int_type _Meta = _Traits::eof(); ; _Copied = true)
				{	
				try {
				_Meta = _Traits::eq_int_type(_Traits::eof(), _Meta)
					? _Strbuf->sgetc() : _Strbuf->snextc();
				} catch (...) {
					_Myios::setstate(ios_base::failbit);
					throw;
				}

				if (_Traits::eq_int_type(_Traits::eof(), _Meta))
					break;	

				try {
					if (_Traits::eq_int_type(_Traits::eof(),
						_Myios::rdbuf()->sputc(
							_Traits::to_char_type(_Meta))))
						{	
						_State |= ios_base::badbit;
						break;
						}
				} catch (...) { _Myios::setstate(ios_base::badbit, true); }
				}

		ios_base::width(0);
		_Myios::setstate(!_Copied ? _State | ios_base::failbit : _State);
		return (*this);
		}

	_Myt& put(_Elem _Ch)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (!_Ok)
			_State |= ios_base::badbit;
		else
			{	
			try {
			if (_Traits::eq_int_type(_Traits::eof(),
				_Myios::rdbuf()->sputc(_Ch)))
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& write(const _Elem *_Str, streamsize _Count)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (!_Ok)
			_State |= ios_base::badbit;
		else
			{	
			try {
			if (_Myios::rdbuf()->sputn(_Str, _Count) != _Count)
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& flush()
		{	
		ios_base::iostate _State = ios_base::goodbit;
		if (!ios_base::fail() && _Myios::rdbuf()->pubsync() == -1)
			_State |= ios_base::badbit;	
		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& seekp(pos_type _Pos)
		{	
		if (!ios_base::fail()
			&& (off_type)_Myios::rdbuf()->pubseekpos(_Pos,
				ios_base::out) == _BADOFF)
			_Myios::setstate(ios_base::failbit);
		return (*this);
		}

	_Myt& seekp(off_type _Off, ios_base::seekdir _Way)
		{	
		if (!ios_base::fail()
			&& (off_type)_Myios::rdbuf()->pubseekoff(_Off, _Way,
				ios_base::out) == _BADOFF)
			_Myios::setstate(ios_base::failbit);
		return (*this);
		}

	pos_type tellp()
		{	
		if (!ios_base::fail())
			return (_Myios::rdbuf()->pubseekoff(0,
				ios_base::cur, ios_base::out));
		else
			return (pos_type(_BADOFF));
		}
	};

 




		

template<class _Elem, class _Traits> inline
	basic_ostream<_Elem, _Traits>& __cdecl operator<<(
		basic_ostream<_Elem, _Traits>& _Ostr, const _Elem *_Val)
	{	
	typedef basic_ostream<_Elem, _Traits> _Myos;
	ios_base::iostate _State = ios_base::goodbit;
	streamsize _Count = (streamsize)_Traits::length(_Val);	
	streamsize _Pad = _Ostr.width() <= 0 || _Ostr.width() <= _Count
		? 0 : _Ostr.width() - _Count;
	const typename _Myos::sentry _Ok(_Ostr);

	if (!_Ok)
		_State |= ios_base::badbit;
	else
		{	
		try {
		if ((_Ostr.flags() & ios_base::adjustfield) != ios_base::left)
			for (; 0 < _Pad; --_Pad)	
				if (_Traits::eq_int_type(_Traits::eof(),
					_Ostr.rdbuf()->sputc(_Ostr.fill())))
					{	
					_State |= ios_base::badbit;
					break;
					}

		if (_State == ios_base::goodbit
			&& _Ostr.rdbuf()->sputn(_Val, _Count) != _Count)
			_State |= ios_base::badbit;

		if (_State == ios_base::goodbit)
			for (; 0 < _Pad; --_Pad)	
				if (_Traits::eq_int_type(_Traits::eof(),
					_Ostr.rdbuf()->sputc(_Ostr.fill())))
					{	
					_State |= ios_base::badbit;
					break;
					}
		_Ostr.width(0);
		} catch (...) { (_Ostr).setstate(ios_base::badbit, true); }
		}

	_Ostr.setstate(_State);
	return (_Ostr);
	}

template<class _Elem, class _Traits> inline
	basic_ostream<_Elem, _Traits>& __cdecl operator<<(
		basic_ostream<_Elem, _Traits>& _Ostr, _Elem _Ch)
	{	
	typedef basic_ostream<_Elem, _Traits> _Myos;
	ios_base::iostate _State = ios_base::goodbit;
	const typename _Myos::sentry _Ok(_Ostr);

	if (_Ok)
		{	
		streamsize _Pad = _Ostr.width() <= 1 ? 0 : _Ostr.width() - 1;

		try {
		if ((_Ostr.flags() & ios_base::adjustfield) != ios_base::left)
			for (; _State == ios_base::goodbit && 0 < _Pad;
				--_Pad)	
				if (_Traits::eq_int_type(_Traits::eof(),
					_Ostr.rdbuf()->sputc(_Ostr.fill())))
					_State |= ios_base::badbit;

		if (_State == ios_base::goodbit
			&& _Traits::eq_int_type(_Traits::eof(),
				_Ostr.rdbuf()->sputc(_Ch)))
			_State |= ios_base::badbit;

		for (; _State == ios_base::goodbit && 0 < _Pad;
			--_Pad)	
			if (_Traits::eq_int_type(_Traits::eof(),
				_Ostr.rdbuf()->sputc(_Ostr.fill())))
				_State |= ios_base::badbit;
		} catch (...) { (_Ostr).setstate(ios_base::badbit, true); }
		}

	_Ostr.width(0);
	_Ostr.setstate(_State);
	return (_Ostr);
	}

template<class _Traits> inline
	basic_ostream<char, _Traits>& __cdecl operator<<(
		basic_ostream<char, _Traits>& _Ostr, const signed char *_Val)
	{	
	return (_Ostr << (const char *)_Val);
	}

template<class _Traits> inline
	basic_ostream<char, _Traits>& __cdecl operator<<(
		basic_ostream<char, _Traits>& _Ostr, signed char _Ch)
	{	
	return (_Ostr << (char)_Ch);
	}

template<class _Traits> inline
	basic_ostream<char, _Traits>& __cdecl operator<<(
		basic_ostream<char, _Traits>& _Ostr, const unsigned char *_Val)
	{	
	return (_Ostr << (const char *)_Val);
	}

template<class _Traits> inline
	basic_ostream<char, _Traits>& __cdecl operator<<(
		basic_ostream<char, _Traits>& _Ostr, unsigned char _Ch)
	{	
	return (_Ostr << (char)_Ch);
	}

		
template<class _Elem, class _Traits> inline
	basic_ostream<_Elem, _Traits>&
		__cdecl endl(basic_ostream<_Elem, _Traits>& _Ostr)
	{	
	_Ostr.put(_Ostr.widen('\n'));
	_Ostr.flush();
	return (_Ostr);
	}

template<class _Elem, class _Traits> inline
	basic_ostream<_Elem, _Traits>&
		__cdecl ends(basic_ostream<_Elem, _Traits>& _Ostr)
	{	
	_Ostr.put(_Elem());
	return (_Ostr);
	}

template<class _Elem, class _Traits> inline
	basic_ostream<_Elem, _Traits>&
		__cdecl flush(basic_ostream<_Elem, _Traits>& _Ostr)
	{	
	_Ostr.flush();
	return (_Ostr);
	}

 inline basic_ostream<char, char_traits<char> >&
	__cdecl endl(basic_ostream<char, char_traits<char> >& _Ostr)
	{	
	_Ostr.put('\n');
	_Ostr.flush();
	return (_Ostr);
	}

 inline basic_ostream<wchar_t, char_traits<wchar_t> >&
	__cdecl endl(basic_ostream<wchar_t,
		char_traits<wchar_t> >& _Ostr)
	{	
	_Ostr.put('\n');
	_Ostr.flush();
	return (_Ostr);
	}

 inline basic_ostream<char, char_traits<char> >&
	__cdecl ends(basic_ostream<char, char_traits<char> >& _Ostr)
	{	
	_Ostr.put('\0');
	return (_Ostr);
	}

 inline basic_ostream<wchar_t, char_traits<wchar_t> >&
	__cdecl ends(basic_ostream<wchar_t,
		char_traits<wchar_t> >& _Ostr)
	{	
	_Ostr.put('\0');
	return (_Ostr);
	}

 inline basic_ostream<char, char_traits<char> >&
	__cdecl flush(basic_ostream<char, char_traits<char> >& _Ostr)
	{	
	_Ostr.flush();
	return (_Ostr);
	}

 inline basic_ostream<wchar_t, char_traits<wchar_t> >&
	__cdecl flush(basic_ostream<wchar_t,
		char_traits<wchar_t> >& _Ostr)
	{	
	_Ostr.flush();
	return (_Ostr);
	}

 





















}
#pragma warning(pop)
#pragma pack(pop)

#line 752 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\ostream"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\istream"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
template<class _Elem,
	class _Traits>
	class basic_istream
		: virtual public basic_ios<_Elem, _Traits>
	{	
public:
	typedef basic_istream<_Elem, _Traits> _Myt;
	typedef basic_ios<_Elem, _Traits> _Myios;
	typedef basic_streambuf<_Elem, _Traits> _Mysb;
	typedef istreambuf_iterator<_Elem, _Traits> _Iter;
	typedef ctype<_Elem> _Ctype;
	typedef num_get<_Elem, _Iter> _Nget;

	explicit basic_istream(_Mysb *_Strbuf, bool _Isstd = false,
		bool _Noinit = false)
		: _Chcount(0)
		{	
		if (!_Noinit)
			_Myios::init(_Strbuf, _Isstd);
		}

	basic_istream(_Uninitialized)
		{	
		ios_base::_Addstd();
		}

	virtual ~basic_istream()
		{	
		}

	typedef typename _Traits::int_type int_type;
	typedef typename _Traits::pos_type pos_type;
	typedef typename _Traits::off_type off_type;

		
	class _Sentry_base
		{	
	public:
		_Sentry_base(_Myt& _Istr)
			: _Myistr(_Istr)
			{	
			if (_Myistr.rdbuf() != 0)
				_Myistr.rdbuf()->_Lock();
			}

		~_Sentry_base()
			{	
			if (_Myistr.rdbuf() != 0)
				_Myistr.rdbuf()->_Unlock();
			}

		_Myt& _Myistr;	
		};

	class sentry
		: public _Sentry_base
		{	
	public:
		explicit sentry(_Myt& _Istr, bool _Noskip = false)
			: _Sentry_base(_Istr)
			{	
			_Ok = _Myistr._Ipfx(_Noskip);
			}

		operator bool() const
			{	
			return (_Ok);
			}

	private:
		sentry(const sentry&);	
		sentry& operator=(const sentry&);	

		bool _Ok;	
		};

	bool _Ipfx(bool _Noskip = false)
		{	
		if (ios_base::good())
			{	
			if (_Myios::tie() != 0)
				_Myios::tie()->flush();

			if (!_Noskip && ios_base::flags() & ios_base::skipws)
				{	
				const _Ctype& _Facet = use_facet<_Ctype >(ios_base::getloc());

				try {
				int_type _Meta = _Myios::rdbuf()->sgetc();

				for (; ; _Meta = _Myios::rdbuf()->snextc())
					if (_Traits::eq_int_type(_Traits::eof(), _Meta))
						{	
						_Myios::setstate(ios_base::eofbit);
						break;
						}
					else if (!_Facet.is(_Ctype::space,
						_Traits::to_char_type(_Meta)))
						break;	
				} catch (...) { _Myios::setstate(ios_base::badbit, true); }
				}

			if (ios_base::good())
				return (true);
			}
		_Myios::setstate(ios_base::failbit);
		return (false);
		}

	bool ipfx(bool _Noskip = false)
		{	
		return _Ipfx(_Noskip);
		}

	void isfx()
		{	
		}

	_Myt& operator>>(_Myt& (__cdecl *_Pfn)(_Myt&))
		{	
		return ((*_Pfn)(*this));
		}

	_Myt& operator>>(_Myios& (__cdecl *_Pfn)(_Myios&))
		{	
		(*_Pfn)(*(_Myios *)this);
		return (*this);
		}

	_Myt& operator>>(ios_base& (__cdecl *_Pfn)(ios_base&))
		{	
		(*_Pfn)(*(ios_base *)this);
		return (*this);
		}

	_Myt& operator>>(_Bool& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(short& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			long _Tmp = 0;
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Tmp);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }

			if (_State & ios_base::failbit
				|| _Tmp < (-32768) || 32767 < _Tmp)
				_State |= ios_base::failbit;
			else
				_Val = (short)_Tmp;
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(unsigned short& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(int& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			long _Tmp = 0;
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Tmp);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }

			if (_State & ios_base::failbit
				|| _Tmp < (-2147483647 - 1) || 2147483647 < _Tmp)
				_State |= ios_base::failbit;
			else
				_Val = _Tmp;
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(unsigned int& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);
		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(long& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());
			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(unsigned long& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}
 

	_Myt& operator>>(__int64& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(unsigned __int64& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);
		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}
 #line 330 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\istream"

	_Myt& operator>>(float& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(double& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);
		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(long double& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());
			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(void *& _Val)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		const sentry _Ok(*this);

		if (_Ok)
			{	
			const _Nget& _Facet = use_facet<_Nget >(ios_base::getloc());

			try {
			_Facet.get(_Iter(_Myios::rdbuf()), _Iter(0),
				*this, _State, _Val);
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& operator>>(_Mysb *_Strbuf)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		bool _Copied = false;
		const sentry _Ok(*this);

		if (_Ok && _Strbuf != 0)
			{	
			try {
			int_type _Meta = _Myios::rdbuf()->sgetc();

			for (; ; _Meta = _Myios::rdbuf()->snextc())
				if (_Traits::eq_int_type(_Traits::eof(), _Meta))
					{	
					_State |= ios_base::eofbit;
					break;
					}
				else
					{	
					try {
						if (_Traits::eq_int_type(_Traits::eof(),
							_Strbuf->sputc(_Traits::to_char_type(_Meta))))
							break;
					} catch (...) {
						break;
					}
					_Copied = true;
					}
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(!_Copied ? _State | ios_base::failbit : _State);
		return (*this);
		}

	int_type get()
		{	
		int_type _Meta = 0;
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (!_Ok)
			_Meta = _Traits::eof();	
		else
			{	
			try {
			_Meta = _Myios::rdbuf()->sbumpc();

			if (_Traits::eq_int_type(_Traits::eof(), _Meta))
				_State |= ios_base::eofbit | ios_base::failbit;	
			else
				++_Chcount;	
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (_Meta);
		}

	_Myt& get(_Elem *_Str, streamsize _Count)
		{	
		return (get(_Str, _Count, _Myios::widen('\n')));
		}

	_Myt& get(_Elem *_Str, streamsize _Count, _Elem _Delim)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok && 0 < _Count)
			{	
			try {
			int_type _Meta = _Myios::rdbuf()->sgetc();

			for (; 0 < --_Count; _Meta = _Myios::rdbuf()->snextc())
				if (_Traits::eq_int_type(_Traits::eof(), _Meta))
					{	
					_State |= ios_base::eofbit;
					break;
					}
				else if (_Traits::to_char_type(_Meta) == _Delim)
					break;	
				else
					{	
					*_Str++ = _Traits::to_char_type(_Meta);
					++_Chcount;
					}
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_Chcount == 0
			? _State | ios_base::failbit : _State);
		*_Str = _Elem();	
		return (*this);
		}

	_Myt& get(_Elem& _Ch)
		{	
		int_type _Meta = get();
		if (!_Traits::eq_int_type(_Traits::eof(), _Meta))
			_Ch = _Traits::to_char_type(_Meta);
		return (*this);
		}

	_Myt& get(_Mysb& _Strbuf)
		{	
		return (get(_Strbuf, _Myios::widen('\n')));
		}

	_Myt& get(_Mysb& _Strbuf, _Elem _Delim)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok)
			{	
			try {
			int_type _Meta = _Myios::rdbuf()->sgetc();

			for (; ; _Meta = _Myios::rdbuf()->snextc())
				if (_Traits::eq_int_type(_Traits::eof(), _Meta))
					{	
					_State |= ios_base::eofbit;
					break;
					}
				else
					{	
					try {
						_Elem _Ch = _Traits::to_char_type(_Meta);
						if (_Ch == _Delim
							|| _Traits::eq_int_type(_Traits::eof(),
								_Strbuf.sputc(_Ch)))
							break;
					} catch (...) {
						break;
					}
					++_Chcount;
					}
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		if (_Chcount == 0)
			_State |= ios_base::failbit;
		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& getline(_Elem *_Str, streamsize _Count)
		{	
		return (getline(_Str, _Count, _Myios::widen('\n')));
		}

	_Myt& getline(_Elem *_Str, streamsize _Count, _Elem _Delim)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok && 0 < _Count)
			{	
			int_type _Metadelim = _Traits::to_int_type(_Delim);

			try {
			int_type _Meta = _Myios::rdbuf()->sgetc();

			for (; ; _Meta = _Myios::rdbuf()->snextc())
				if (_Traits::eq_int_type(_Traits::eof(), _Meta))
					{	
					_State |= ios_base::eofbit;
					break;
					}
				else if (_Meta == _Metadelim)
					{	
					++_Chcount;
					_Myios::rdbuf()->sbumpc();
					break;
					}
				else if (--_Count <= 0)
					{	
					_State |= ios_base::failbit;
					break;
					}
				else
					{	
					++_Chcount;
					*_Str++ = _Traits::to_char_type(_Meta);
					}
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		*_Str = _Elem();	
		_Myios::setstate(_Chcount == 0 ? _State | ios_base::failbit : _State);
		return (*this);
		}

	_Myt& ignore(streamsize _Count = 1, int_type _Metadelim = _Traits::eof())
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok && 0 < _Count)
			{	
			try {
			for (; ; )
				{	
				int_type _Meta;
				if (_Count != 2147483647 && --_Count < 0)
					break;	
				else if (_Traits::eq_int_type(_Traits::eof(),
					_Meta = _Myios::rdbuf()->sbumpc()))
					{	
					_State |= ios_base::eofbit;
					break;
					}
				else
					{	
					++_Chcount;
					if (_Meta == _Metadelim)
						break;	
					}
				}
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& read(_Elem *_Str, streamsize _Count)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok)
			{	
			try {
			const streamsize _Num = _Myios::rdbuf()->sgetn(_Str, _Count);
			_Chcount += _Num;
			if (_Num != _Count)
				_State |= ios_base::eofbit | ios_base::failbit;	
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	streamsize readsome(_Elem *_Str, streamsize _Count)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);
		streamsize _Num;

		if (!_Ok)
			_State |= ios_base::failbit;	
		else if ((_Num = _Myios::rdbuf()->in_avail()) < 0)
			_State |= ios_base::eofbit;	
		else if (0 < _Num)
			read(_Str, _Num < _Count ? _Num : _Count);	

		_Myios::setstate(_State);
		return (gcount());
		}

	int_type peek()
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		int_type _Meta = 0;
		const sentry _Ok(*this, true);

		if (!_Ok)
			_Meta = _Traits::eof();	
		else
			{	
			try {
			if (_Traits::eq_int_type(_Traits::eof(),
				_Meta = _Myios::rdbuf()->sgetc()))
				_State |= ios_base::eofbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (_Meta);
		}

	_Myt& putback(_Elem _Ch)
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok)
			{	
			try {
			if (_Traits::eq_int_type(_Traits::eof(),
				_Myios::rdbuf()->sputbackc(_Ch)))
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	_Myt& unget()
		{	
		ios_base::iostate _State = ios_base::goodbit;
		_Chcount = 0;
		const sentry _Ok(*this, true);

		if (_Ok)
			{	
			try {
			if (_Traits::eq_int_type(_Traits::eof(),
				_Myios::rdbuf()->sungetc()))
				_State |= ios_base::badbit;
			} catch (...) { _Myios::setstate(ios_base::badbit, true); }
			}

		_Myios::setstate(_State);
		return (*this);
		}

	streamsize gcount() const
		{	
		return (_Chcount);
		}

	int sync()
		{	
		ios_base::iostate _State = ios_base::goodbit;
		int _Ans;

		if (_Myios::rdbuf() == 0)
			_Ans = -1;	
		else if (_Myios::rdbuf()->pubsync() == -1)
			{	
			_State |= ios_base::badbit;
			_Ans = -1;
			}
		else
			_Ans = 0;	

		_Myios::setstate(_State);
		return (_Ans);
		}

	_Myt& seekg(pos_type _Pos)
		{	
		if (!ios_base::fail()
			&& (off_type)_Myios::rdbuf()->pubseekpos(_Pos,
				ios_base::in) == _BADOFF)
			_Myios::setstate(ios_base::failbit);
		return (*this);
		}

	_Myt& seekg(off_type _Off, ios_base::seekdir _Way)
		{	
		if (!ios_base::fail()
			&& (off_type)_Myios::rdbuf()->pubseekoff(_Off, _Way,
				ios_base::in) == _BADOFF)
			_Myios::setstate(ios_base::failbit);
		return (*this);
		}

	pos_type tellg()
		{	
		if (!ios_base::fail())
			return (_Myios::rdbuf()->pubseekoff(0,
				ios_base::cur, ios_base::in));
		else
			return (pos_type(_BADOFF));
		}

private:
	streamsize _Chcount;	
	};

 




		
template<class _Elem,
	class _Traits>
	class basic_iostream
	: public basic_istream<_Elem, _Traits>,
		public basic_ostream<_Elem, _Traits>
	{	
public:
	explicit basic_iostream(basic_streambuf<_Elem, _Traits> *_Strbuf)
		: basic_istream<_Elem, _Traits>(_Strbuf, false, true),
			basic_ostream<_Elem, _Traits>(_Strbuf)
		{	
		}

	virtual ~basic_iostream()
		{	
		}
	};

 




		
template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, _Elem *_Str)
	{	
	typedef basic_istream<_Elem, _Traits> _Myis;
	typedef ctype<_Elem> _Ctype;
	ios_base::iostate _State = ios_base::goodbit;
	_Elem *_Str0 = _Str;
	const typename _Myis::sentry _Ok(_Istr);

	if (_Ok)
		{	
		const _Ctype& _Facet = use_facet<_Ctype >(_Istr.getloc());

		try {
		streamsize _Count = 0 < _Istr.width() ? _Istr.width() : 2147483647;
		typename _Myis::int_type _Meta = _Istr.rdbuf()->sgetc();
		_Elem _Ch;
		for (; 0 < --_Count; _Meta = _Istr.rdbuf()->snextc())
			if (_Traits::eq_int_type(_Traits::eof(), _Meta))
				{	
				_State |= ios_base::eofbit;
				break;
				}
			else if (_Facet.is(_Ctype::space,
				_Ch = _Traits::to_char_type(_Meta))
					|| _Ch == _Elem())
				break;	
			else
				*_Str++ = _Traits::to_char_type(_Meta);	
		} catch (...) { (_Istr).setstate(ios_base::badbit, true); }
		}

	*_Str = _Elem();	
	_Istr.width(0);
	_Istr.setstate(_Str == _Str0 ? _State | ios_base::failbit : _State);
	return (_Istr);
	}

template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, _Elem& _Ch)
	{	
	typedef basic_istream<_Elem, _Traits> _Myis;
	typename _Myis::int_type _Meta;
	ios_base::iostate _State = ios_base::goodbit;
	const typename _Myis::sentry _Ok(_Istr);

	if (_Ok)
		{	
		try {
		_Meta = _Istr.rdbuf()->sbumpc();
		if (_Traits::eq_int_type(_Traits::eof(), _Meta))
			_State |= ios_base::eofbit | ios_base::failbit;	
		else
			_Ch = _Traits::to_char_type(_Meta);	
		} catch (...) { (_Istr).setstate(ios_base::badbit, true); }
		}

	_Istr.setstate(_State);
	return (_Istr);
	}


template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, signed char *_Str)
	{	
	return (_Istr >> (char *)_Str);
	}

template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, signed char& _Ch)
	{	
	return (_Istr >> (char&)_Ch);
	}

template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, unsigned char *_Str)
	{	
	return (_Istr >> (char *)_Str);
	}

template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, unsigned char& _Ch)
	{	
	return (_Istr >> (char&)_Ch);
	}

template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>& __cdecl operator>>(
		basic_istream<_Elem, _Traits>& _Istr, signed short * _Str)
	{	
	return (_Istr >> (wchar_t *)_Str);
	}

 


















		
template<class _Elem,
	class _Traits> inline
	basic_istream<_Elem, _Traits>&
		__cdecl ws(basic_istream<_Elem, _Traits>& _Istr)
	{	
	typedef basic_istream<_Elem, _Traits> _Myis;
	typedef ctype<_Elem> _Ctype;
	ios_base::iostate _State = ios_base::goodbit;
	const typename _Myis::sentry _Ok(_Istr, true);

	if (_Ok)
		{	
		const _Ctype& _Facet = use_facet<_Ctype >(_Istr.getloc());

		try {
		for (typename _Traits::int_type _Meta = _Istr.rdbuf()->sgetc(); ;
			_Meta = _Istr.rdbuf()->snextc())
			if (_Traits::eq_int_type(_Traits::eof(), _Meta))
				{	
				_State |= ios_base::eofbit;
				break;
				}
			else if (!_Facet.is(_Ctype::space,
				_Traits::to_char_type(_Meta)))
				break;	
		} catch (...) { (_Istr).setstate(ios_base::badbit, true); }
		}

	_Istr.setstate(_State);
	return (_Istr);
	}

 inline basic_istream<char, char_traits<char> >&
	__cdecl ws(basic_istream<char, char_traits<char> >& _Istr)
	{	
	typedef char _Elem;
	typedef char_traits<_Elem> _Traits;
	ios_base::iostate _State = ios_base::goodbit;
	const basic_istream<_Elem, _Traits>::sentry _Ok(_Istr, true);

	if (_Ok)
		{	
		const ctype<_Elem>& _Facet = use_facet<ctype<_Elem> >(_Istr.getloc());

		try {
		for (_Traits::int_type _Meta = _Istr.rdbuf()->sgetc(); ;
			_Meta = _Istr.rdbuf()->snextc())
			if (_Traits::eq_int_type(_Traits::eof(), _Meta))
				{	
				_State |= ios_base::eofbit;
				break;
				}
			else if (!_Facet.is(ctype<_Elem>::space,
				_Traits::to_char_type(_Meta)))
				break;	
		} catch (...) { (_Istr).setstate(ios_base::badbit, true); }
		}

	_Istr.setstate(_State);
	return (_Istr);
	}

 inline basic_istream<wchar_t, char_traits<wchar_t> >&
	__cdecl ws(basic_istream<wchar_t, char_traits<wchar_t> >& _Istr)
	{	
	typedef wchar_t _Elem;
	typedef char_traits<_Elem> _Traits;
	ios_base::iostate _State = ios_base::goodbit;
	const basic_istream<_Elem, _Traits>::sentry _Ok(_Istr, true);

	if (_Ok)
		{	
		const ctype<_Elem>& _Facet = use_facet<ctype<_Elem> >(_Istr.getloc());

		try {
		for (_Traits::int_type _Meta = _Istr.rdbuf()->sgetc(); ;
			_Meta = _Istr.rdbuf()->snextc())
			if (_Traits::eq_int_type(_Traits::eof(), _Meta))
				{	
				_State |= ios_base::eofbit;
				break;
				}
			else if (!_Facet.is(ctype<_Elem>::space,
				_Traits::to_char_type(_Meta)))
				break;	

		} catch (...) { (_Istr).setstate(ios_base::badbit, true); }
		}
	_Istr.setstate(_State);
	return (_Istr);
	}
}
#pragma warning(pop)
#pragma pack(pop)

#line 1042 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\istream"





#line 6 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\strstream"

#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
class strstreambuf
	: public streambuf
	{	
public:
	enum
		{	
		_Allocated = 1,	
		_Constant = 2,	
		_Dynamic = 4,	
		_Frozen = 8};	
	typedef int _Strstate;

	explicit strstreambuf(streamsize _Count = 0)
		{	
		_Init(_Count);
		}

	strstreambuf(void *(__cdecl *_Allocfunc)(size_t),
		void (__cdecl *_Freefunc)(void *))
		{	
		_Init();
		_Palloc = _Allocfunc;
		_Pfree = _Freefunc;
		}

	strstreambuf(char *_Getptr, streamsize _Count, char *_Putptr = 0)
		{	
		_Init(_Count, _Getptr, _Putptr);
		}

	strstreambuf(unsigned char *_Getptr, streamsize _Count,
		unsigned char *_Putptr = 0)
		{	
		_Init(_Count, (char *)_Getptr, (char *)_Putptr);
		}

	strstreambuf(const char *_Getptr, streamsize _Count)
		{	
		_Init(_Count, (char *)_Getptr, 0, _Constant);
		}

	strstreambuf(const unsigned char *_Getptr, streamsize _Count)
		{	
		_Init(_Count, (char *)_Getptr, 0, _Constant);
		}

	 virtual ~strstreambuf();	

	 void freeze(bool = true);	

	char *str()
		{	
		freeze();
		return (gptr());
		}

	streamsize pcount() const
		{	
		return (pptr() == 0 ? 0 : (streamsize)(pptr() - pbase()));
		}

	strstreambuf(signed char *_Getptr, streamsize _Count,
		signed char *_Putptr = 0)
		{	
		_Init(_Count, (char *)_Getptr, (char *)_Putptr);
		}

	strstreambuf(const signed char *_Getptr, streamsize _Count)
		{	
		_Init(_Count, (char *)_Getptr, 0, _Constant);
		}

protected:
	 virtual int overflow(int = (-1));	

	 virtual int pbackfail(int = (-1));	

	 virtual int underflow();	

	 virtual streampos seekoff(streamoff,
		ios_base::seekdir,
		ios_base::openmode =
			ios_base::in | ios_base::out);	

	 virtual streampos seekpos(streampos,
		ios_base::openmode =
			ios_base::in | ios_base::out);	

	 void _Init(streamsize = 0, char * = 0, char * = 0,
		_Strstate = (_Strstate)0);	

	 void _Tidy();	

private:
	enum
		{	
		_MINSIZE = 32};

	streamsize _Minsize;	
	char *_Pendsave;	
	char *_Seekhigh;	
	_Strstate _Strmode;	
	void *(__cdecl *_Palloc)(size_t);	
	void (__cdecl *_Pfree)(void *);	
	};

		
class istrstream
	: public istream
	{	
public:

	explicit istrstream(const char *_Ptr)
		: istream(&_Mysb), _Mysb(_Ptr, 0)
		{	
		}

	istrstream(const char *_Ptr, streamsize _Count)
		: istream(&_Mysb), _Mysb(_Ptr, _Count)
		{	
		}

	explicit istrstream(char *_Ptr)
		: istream(&_Mysb), _Mysb((const char *)_Ptr, 0)
		{	
		}

	istrstream(char *_Ptr, int _Count)
		: istream(&_Mysb), _Mysb((const char *)_Ptr, _Count)
		{	
		}

	 virtual ~istrstream();	

	strstreambuf *rdbuf() const
		{	
		return ((strstreambuf *)&_Mysb);
		}

	char *str()
		{	
		return (_Mysb.str());
		}

private:
	strstreambuf _Mysb;	
	};

		
class ostrstream
	: public ostream
	{	
public:
	ostrstream()
		: ostream(&_Mysb), _Mysb()
		{	
		}

	 ostrstream(char *, streamsize,
		ios_base::openmode =
			ios_base::out);	

	 virtual ~ostrstream();	

	strstreambuf *rdbuf() const
		{	
		return ((strstreambuf *)&_Mysb);
		}

	void freeze(bool _Freezeit = true)
		{	
		_Mysb.freeze(_Freezeit);
		}

	char *str()
		{	
		return (_Mysb.str());
		}

	streamsize pcount() const
		{	
		return (_Mysb.pcount());
		}

private:
	strstreambuf _Mysb;	
	};

		
class strstream
	: public iostream
	{	
public:
	typedef char char_type;
	typedef int int_type;
	typedef streampos pos_type;
	typedef streamoff off_type;

	strstream()
		: iostream(&_Mysb), _Mysb()
		{	
		}

	 strstream(char *, streamsize,
		ios_base::openmode =
			ios_base::in | ios_base::out);	

	 virtual ~strstream();	

	strstreambuf *rdbuf() const
		{	
		return ((strstreambuf *)&_Mysb);
		}

	void freeze(bool _Freezeit = true)
		{	
		_Mysb.freeze(_Freezeit);
		}

	char *str()
		{	
		return (_Mysb.str());
		}

	streamsize pcount() const
		{	
		return (_Mysb.pcount());
		}

private:
	strstreambuf _Mysb;	
	};
}
#pragma warning(pop)
#pragma pack(pop)

#line 249 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\strstream"





#line 14 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"


#line 1 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iostream"

#pragma once




#pragma pack(push,8)
#pragma warning(push,3)
namespace std {

		
extern  istream cin, *_Ptr_cin;
extern  ostream cout, *_Ptr_cout;
extern  ostream cerr, *_Ptr_cerr;
extern  ostream clog, *_Ptr_clog;

		
class  _Winit {
public:
	_Winit();
	~_Winit();
private:
	static int _Init_cnt;
	};

		
extern  wistream wcin, *_Ptr_wcin;
extern  wostream wcout, *_Ptr_wcout;
extern  wostream wcerr, *_Ptr_wcerr;
extern  wostream wclog, *_Ptr_wclog;
}
#pragma warning(pop)
#pragma pack(pop)

#line 36 "D:\\Program Files\\Microsoft Visual Studio .NET\\VC7\\INCLUDE\\iostream"





#line 17 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"
#line 18 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"
using namespace std;

class DataStream;





class StreamObject
{
public:
	virtual ~StreamObject() {};
private:
	virtual void read(DataStream* stream) = 0;
	virtual void write(DataStream* stream) const = 0;

	friend DataStream;

public:
	friend ostream& operator << (ostream& out, const StreamObject& obj);
	virtual void print(ostream& out) const {};
#line 40 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"
};


ostream& operator << (ostream& out, const StreamObject& obj);
#line 45 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"



class DataStream
{
public:
	DataStream(){};
	virtual ~DataStream() {};

	
	virtual void read(char *buffer, int size) = 0;
	virtual void write(const char *buffer, int size) = 0;
	virtual bool eof() { return false; }; 
										
	virtual void flush() {}; 
							

	DataStream& operator << (StreamObject& obj) { obj.write(this); return *this; };
	DataStream& operator >> (StreamObject& obj){ obj.read(this); return *this; };
	DataStream& operator << (char data) { write(reinterpret_cast<const char*>(&data), sizeof data); return *this; };
	DataStream& operator >> (char& data) { read(reinterpret_cast<char*>(&data), sizeof data); return *this; };
};

#line 69 "d:\\liuxiong\\bombman\\gamemanager\\DataStream.h"
#line 15 "d:\\liuxiong\\bombman\\gamemanager\\UDPServer.h"
#line 1 "d:\\liuxiong\\bombman\\gamemanager\\WinsockInit.h"
#pragma once


#pragma comment( lib, "ws2_32" )












class WinsockInit 
{
	static int count;
public:
	WinsockInit();
	~WinsockInit();
};

namespace {
	WinsockInit init;
}


class UDPException : public std::exception
{
	const char *msg;
public:
	UDPException(const char *aMsg) : std::exception(), msg(aMsg) {};
	virtual const char *what() const throw() { return msg; };
};

#line 39 "d:\\liuxiong\\bombman\\gamemanager\\WinsockInit.h"
#line 16 "d:\\liuxiong\\bombman\\gamemanager\\UDPServer.h"

 



class ServerSocket
{
	SOCKET sock;
	sockaddr_in name;
	strstream str; 
public:
	ServerSocket(int aPort);
	~ServerSocket();

	void send(const char *buffer, int size);
	void flush();
};



class UDPServer : public DataStream, private ServerSocket
{
public:
	UDPServer(int aPort) : DataStream(), ServerSocket(aPort) {};
	
	
	virtual void read(char *buffer, int size) { throw UDPException("Cannot read from the socket on the client side"); };
	virtual void write(const char *buffer, int size) { ServerSocket::send(buffer, size); };
	virtual void flush() { ServerSocket::flush(); }
};

#line 48 "d:\\liuxiong\\bombman\\gamemanager\\UDPServer.h"
#line 4 "d:\\liuxiong\\bombman\\gamemanager\\GameManager.h"



#pragma once

using namespace System;

__value enum Status{A, P, R}; 
__value struct GameInfo{
	Game * game;
	Status status;
};
	

namespace GameManager
{
	static const Port=1020;
	[event_receiver(managed)]
	public __gc class GMClass
	{
	private: 
		UDPServer __nogc *stream;
		Server svr;
		Collections::Hashtable* gamepool;
		
	public:
		GMClass() {
			gamepool = new Collections::Hashtable;
			
		}
		bool createGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort);
		bool joinGame(Int32 nGameID, Int32 nUserID);
		bool moveBunny(Int32 nGameID, Int32 nPlayer, Int32 nDirection);
		bool dropBomb(Int32 nGameID, Int32 nPlayer);
	private:
		void initBunny(const int nGameID, const int nUserID);
	};
}
#line 6 "t.cpp"


namespace GameManager {
	bool GMClass::createGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort){
		





		int i, j;
		
		for (i = 0; i<11; i++) 
			for (j=0; j<13; j++) 
				svr.game[nGameID].arBoard[i][j] = EMPTY;
			
		
		GameInfo gameinfo;
		gameinfo.status = A;
		Game __pin* p = &(svr.game[nGameID]);
		gameinfo.game = reinterpret_cast<Game __nogc*>(p);
		gamepool->Add(__box(nGameID),__box(gameinfo)); 		
		
		return true;
	}

	
	
	void GMClass::initBunny(const int nGameID, const int nUserID){
		cout << "Entering initBunny" << endl;
		cout << "nUserID=" << nUserID;
	}
}
