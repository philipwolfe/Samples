tlbimp dx7vb.dll /out:DxVBLib.dll

vbc /out:Sample1.exe Sample1Form.vb /r:%ASSEMBLYLOCATION%\System.WinForms.DLL /r:%ASSEMBLYLOCATION%\System.Drawing.dll /r:DxVBLib.dll

Sample1.exe