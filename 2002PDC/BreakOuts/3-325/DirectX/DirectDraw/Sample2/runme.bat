tlbimp dx7vb.dll /out:DxVBLib.dll

vbc /out:Sample2.exe Sample2Form.vb /r:%ASSEMBLYLOCATION%\System.DLL /r:%ASSEMBLYLOCATION%\System.WinForms.DLL /r:%ASSEMBLYLOCATION%\System.Drawing.dll /r:DxVBLib.dll

Sample2.exe