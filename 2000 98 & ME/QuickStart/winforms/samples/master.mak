#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\Tutorial\QuickStart\master.mak
!include $(QSDIR)\master.mak

#since we want the compiler to import from some dll's, let's specify the std WinForms ones here
_CS_WINFORMS_IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL
_VB_WINFORMS_IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL


# Bin dir is \com20sdk\QuickStart\WinForms\Bin
_OUTDIR=$(QSDIR)\WinForms\Bin
_CS_OUTDIR=$(QSDIR)\WinForms\Bin\Cs
_VB_OUTDIR=$(QSDIR)\WinForms\Bin\VB


