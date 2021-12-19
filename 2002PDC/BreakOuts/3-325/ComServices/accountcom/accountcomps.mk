
accountcomps.dll: dlldata.obj accountcom_p.obj accountcom_i.obj
	link /dll /out:accountcomps.dll /def:accountcomps.def /entry:DllMain dlldata.obj accountcom_p.obj accountcom_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del accountcomps.dll
	@del accountcomps.lib
	@del accountcomps.exp
	@del dlldata.obj
	@del accountcom_p.obj
	@del accountcom_i.obj
