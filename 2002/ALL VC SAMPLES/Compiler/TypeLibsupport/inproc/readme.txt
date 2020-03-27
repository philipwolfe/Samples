The projects in this sample should be built in the following order:

Please follow the steps as below to build and run this sample:

1. Build inproc.vcproj to generate inproc.dll
2. Build ipdrive.vcproj to generate ipdrive.exe
3. Register server (MUST DO)
	a. change the path in server\inproc.reg to the path of the inproc.dll you just built.
	b. run regedit "server\inproc.reg"
4. Set ipdrive project as the start project and run this application.
	


