tlbimp dx7vb.dll /out:DxVBLib.dll

vbc /out:Sample3.exe Sample3Form.vb /r:%ASSEMBLYLOCATION%\System.WinForms.DLL /r:%ASSEMBLYLOCATION%\System.Drawing.dll /r:DxVBLib.dll

Sample3.exe