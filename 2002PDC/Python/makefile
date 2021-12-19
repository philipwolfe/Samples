all: ..\ManagedPython.key corglue pyruntime p2c

..\ManagedPython.key:
	@if not exist ..\ManagedPython.key echo Creating a new key for signing the assemblies
	if not exist ..\ManagedPython.key sn -k ..\ManagedPython.key

corglue::
	cd $*
	..\nmake /nologo  /$(MAKEFLAGS)
	cd $(MAKEDIR)

pyruntime::
	cd $*
	..\nmake /nologo /$(MAKEFLAGS)
	cd $(MAKEDIR)

p2c::
	cd $*
	..\nmake /nologo  /$(MAKEFLAGS)
	@echo You can now run the test suite by executing 'testall.bat' in the P2C directory
	@echo You can also check out some of the samples in the 'pc2\samples' directory.

